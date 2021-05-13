using System;
using Xunit;

namespace TestNotebookApp
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalc()
        {

      
            //test addition function
            double additions = NoteApp.Model.MathLogic.Addition(20,5);
            Assert.Equal("25", additions + "");

            //test addition with Multiplication functions
            double multiplications = NoteApp.Model.MathLogic.Multiplication(5, 5);
            double result = additions + multiplications;
            Assert.Equal("50", result + "");

            //test addition Multiplication and division functions
            double divisions = NoteApp.Model.MathLogic.Division(9, 3);
            // 50 + 9 / 3 = 53
            result = additions + multiplications + divisions;
            Assert.Equal("53", result + "");

            //test addition Multiplication division and Subtraction functions
            double subtractions = NoteApp.Model.MathLogic.Subtraction(14, 7);
            // 50 + 3 + 7 = 60
            result = additions + multiplications + divisions+ subtractions;
            Assert.Equal("60", result + "");

        }




    }
}
