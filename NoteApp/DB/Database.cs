using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using NoteApp.Model;

namespace NoteApp.DB
{
    public class Database
    {

        //create and save local database sqlite
        private static string databaseFile = Path.Combine(Environment.CurrentDirectory, "noteappdemos.db3");
        private static string dbPath = "https://noteapp-10d20-default-rtdb.europe-west1.firebasedatabase.app/";




        //method to save data to database 
        public static async Task<bool> Insert<T>(T item)
        {

            //sqlite database
            /*
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);
                if (rows > 0)
                    result = true;
            }

            return result;
            */

            var jsonBody = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonBody,Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var result = await client.PostAsync($"{dbPath}{item.GetType().Name.ToLower()}.json",content);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



        }


        //method to update data in database like rename etc.
        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Update(item);
                if (rows > 0)
                    result = true;
            }

            return result;
        }

        //method to remove item from database 
        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Delete(item);
                if (rows > 0)
                    result = true;
            }

            return result;
        }


        //method to show item from database like notebook or note
        public static async Task<List<T>> Read<T>() where T : HasId
        {
            //sqlite database
            /*
            List<T> items;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }

            return items;
      
            */

            //firebase
            using (var client = new HttpClient())
            {

                //if (jsonResult != "null" && result.IsSuccessStatusCode)
                var result = await client.GetAsync($"{dbPath}{typeof(T).Name.ToLower()}.json");
                if (!result.IsSuccessStatusCode)
                    return null;
                var jsonResult = await result.Content.ReadAsStringAsync();

                if (jsonResult != "null" && result.IsSuccessStatusCode)
                {
                    var objects = JsonConvert.DeserializeObject<Dictionary<string, T>>(jsonResult);

                    List<T> list = new List<T>();
                    foreach (var o in objects)
                    {
                        o.Value.Id = o.Key;
                        list.Add(o.Value);
                    }

                    return list;
                }
                else
                {
                    return null;
                }
              

            }
          
        }
    }
}
