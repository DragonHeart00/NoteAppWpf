using NoteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteApp.UC
{
    /// <summary>
    /// Interaction logic for CalculatorUC.xaml
    /// </summary>
    public partial class CalculatorUC : UserControl
    {
        double lastNumber, result;
        Operator selectedOperator;
        public CalculatorUC()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // if (sender == divisionButton)
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {

                resultLabel.Content = "0";
            }

            if (sender == multiplicationButton)
                selectedOperator = Operator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = Operator.Division;
            if (sender == additionButton)
                selectedOperator = Operator.Addition;
            if (sender == subtractionButton)
                selectedOperator = Operator.Subtraction;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }

        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains(","))
            {
                //do nothing
            }
            else { resultLabel.Content = $"{resultLabel.Content},"; }
        }


        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (tempNumber != 0)

                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }


        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case Operator.Addition:
                        result = MathLogic.Addition(lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        result = MathLogic.Subtraction(lastNumber, newNumber);
                        break;
                    case Operator.Multiplication:
                        result = MathLogic.Multiplication(lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        result = MathLogic.Division(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }



    }
}
