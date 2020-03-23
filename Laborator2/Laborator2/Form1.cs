using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Laborator2
{
    public partial class Calculator : Form
    {
        public double number1, number2;
        public bool isFirstNumber;
        public int dotPosition;
        public string operation;
        public bool invert;

        public void updateDisplay()
        {
            if (isFirstNumber)
            {
                Display.Text = number1.ToString();
            }
            else
            {
                Display.Text = number2.ToString();
            }
        }

        public void addDigit(object sender , EventArgs e)
        {
            Button CurrentButton = sender as Button;
            double digit = Convert.ToDouble(CurrentButton.Text);
            if (invert)
                digit *= -1;

            if (number1.ToString().Length > 9)
                return;

            if (isFirstNumber)
            {
                if (dotPosition == -1)
                    number1 = number1 * 10 + digit;

                else
                    number1 = number1 + (digit / Math.Pow(10, Display.Text.Length - dotPosition + 1));
            }

            else
            {
                if (dotPosition == -1)
                    number2 = number2 * 10 + digit;

                else
                    number2 = number2 + (digit / Math.Pow(10, Display.Text.Length - dotPosition + 1));
            }

            updateDisplay();
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (dotPosition == -1)
            {
                Display.Text += ".";
                dotPosition = Display.Text.Length;
            }
        }

        private void operationInverse_Click(object sender, EventArgs e)
        {
            if (invert)
                invert = false;
            else
                invert = true;

            if (isFirstNumber)
            {
                number1 *= -1;
            }

            else
            {
                number2 *= -1;
            }

            updateDisplay();
        }

        private void DeleteChar_Click(object sender, EventArgs e)
        {
            if (isFirstNumber)
            {
                if (number1 > 9)
                {
                    string numberAsString = number1.ToString();
                    number1 = Convert.ToDouble(numberAsString.Substring(0, numberAsString.Length - 1));
                }
                else
                    number1 = 0.0;

            }

            else
            {
                if (number2 > 9)
                {
                    string numberAsString = number2.ToString();
                    number2 = Convert.ToDouble(numberAsString.Substring(0, numberAsString.Length - 1));
                }
                else
                    number2 = 0.0;
            }

            updateDisplay();
        }

        private void ClearEverything_Click(object sender, EventArgs e)
        {
            isFirstNumber = true;
            number1 = 0.0;
            number2 = 0.0;
            dotPosition = -1;
            updateDisplay();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (isFirstNumber)
                number1 = 0.0;
            else
                number2 = 0.0;

            updateDisplay();
        }

        public void initializeVariables()
        {
            number1 = 0.0;
            number2 = 0.0;
            operation = "";
            isFirstNumber = true;
            dotPosition = -1;
            invert = false;
        }

        private void operationEqual_Click(object sender, EventArgs e)
        {
            switch(operation)
            {
                case "":
                    return;

                case "+":
                    Display.Text = (number1 + number2).ToString();
                    initializeVariables();
                    break;

                case "-":
                    Display.Text = (number1 - number2).ToString();
                    initializeVariables();
                    break;

                case "*":
                    Display.Text = (number1 * number2).ToString();
                    initializeVariables();
                    break;

                case "/":
                    if (number2 == 0)
                    {
                        MessageBox.Show("Divison by 0 not allowed", "ERROR", MessageBoxButtons.OK);
                        break;
                    }

                    Display.Text = (number1 / number2).ToString();
                    initializeVariables();
                    break;

                default:
                    MessageBox.Show("Something went wrong");
                    initializeVariables();
                    break;
            }
        }

        private void operationMultiplication_Click(object sender, EventArgs e)
        {
            isFirstNumber = false;
            invert = false;
            dotPosition = -1;
            operation = "*";
        }

        private void operationSubstraction_Click(object sender, EventArgs e)
        {
            isFirstNumber = false;
            invert = false;
            dotPosition = -1;
            operation = "-";
        }

        private void operationAddition_Click(object sender, EventArgs e)
        {
            isFirstNumber = false;
            invert = false;
            dotPosition = -1;
            operation = "+";
        }

        private void operationDivision_Click(object sender, EventArgs e)
        {
            isFirstNumber = false;
            invert = false;
            dotPosition = -1;
            operation = "/";
        }

        public Calculator()
        {
            InitializeComponent();

            initializeVariables();

            Regex regex = new Regex("digit\\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Control control in this.Controls)
            {
                if (!(control is Button))
                    continue;

                Button button = (Button)control;
                Match match = regex.Match(control.Name);
                if(match.Success)
                    button.Click += addDigit;
            }
        }
    }
}
