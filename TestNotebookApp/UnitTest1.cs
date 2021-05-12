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

            //test addition with Multiplication function
            double multiplications = NoteApp.Model.MathLogic.Multiplication(5, 5);
            double admod = additions + multiplications;
            Assert.Equal("50", admod + "");

        }

        [Fact]
        public void TestNote()
        {
           
        }
    }
}
