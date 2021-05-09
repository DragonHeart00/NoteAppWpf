using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoteApp.DB
{
    public class Database
    {

        //create and save local database sqlite
        private static string databaseFile = Path.Combine(Environment.CurrentDirectory, "noteappdemos.db3");

        //method to save data to database 
        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);
                if (rows > 0)
                    result = true;
            }

            return result;
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
        public static List<T> Read<T>() where T : new()
        {
            List<T> items;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }

            return items;
        }


    }
}
