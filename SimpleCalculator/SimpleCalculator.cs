using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    /*Author Momo Johnson   
     * C Sharp Project 7.1
     * This program add, divide, multiply and substract Operand of two numbers
     * */
    public partial class SimpleCalculator : Form
    {
        decimal operand1Valuel, operand2Value;
         Char operatorValue;
        public SimpleCalculator()
        {
            InitializeComponent();
        }

        //A method that calculates the result of the two opperand base on the input by the user
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //Validating various input being entered by the user using the validate method
                if (isValidInput())
                {
                    // if validation  method returns true, convert the various data
                    operand1Valuel = Decimal.Parse(txtOperand1.Text);
                    operatorValue = Char.Parse(txtOperator.Text);
                    operand2Value = Decimal.Parse(txtOperand2.Text);
                   
                    //A switch statement that checks for the operator that is being enter by the user
                    switch (operatorValue)
                    {
                        case '/':
                            decimal divisionAnswer = operand1Valuel / operand2Value;//Division answer
                            lblResult.Text = divisionAnswer.ToString("f2");//Setting the answer
                            txtOperand1.Focus();

                            break;
                        case '+':
                            decimal additionAnswer = operand1Valuel + operand2Value;//Addtion answer
                            lblResult.Text = additionAnswer.ToString("f2");//Setting of the answer
                            txtOperand1.Focus();
                            break;
                        case '*':
                            decimal multiplicationAnswer = operand1Valuel * operand2Value;//multiplication answer
                            lblResult.Text = multiplicationAnswer.ToString("F2");//Setting of the answer
                            txtOperand1.Focus();
                            break;
                        default:
                            decimal substractionAnswer = operand1Valuel - operand2Value;//substraction asnwer
                            lblResult.Text = substractionAnswer.ToString("F2");//Setting of the answer
                            txtOperand1.Focus();
                            break;
                    }
                }               

            }catch(Exception exe)
            {
                //If any error catch the operator error if the user didn't enter a char
                MessageBox.Show("An error has occured");
            }  
            
         }

        //A method that checks to sure that the textbox is not empty
        private bool isPresent(TextBox textbox, String name)
        {
            if(textbox.Text== "")
            {
                //If textbox is empty, prompt the user to enter a valid input                
                MessageBox.Show(name + " is a required field", "Error");
                textbox.Focus();
                textbox.Clear();

                return false;
            }
            return true;
        }

        //A method that checks to see if the number enter by the user is a decimal
        private bool isDecimal(TextBox texbox, String name)
        {
            decimal number;
            if(Decimal.TryParse(texbox.Text, out number))
            {
                return true;
            }
            //If the number isn't decimal, prompt the user to enter an integer or a decimal
            MessageBox.Show(name +" must be an integer or a decimal number", "Error");
            texbox.Focus();
            texbox.Clear();
            return false;
        }
        //A method that checks to make sure that the data inputed by the user is between 0-1000000
        private bool isValidData(TextBox textbox, String name)
        {
            decimal number;
            if(Decimal.TryParse(textbox.Text, out number))
            {
               if(number > 0 && number <= 1000000)
                {
                    return true;
                }
            }
            //If the number isn't between 1-1000000, prompt the user to enter a valid number
            MessageBox.Show(name + " must be a number between 0-1,000000", "Error");
            textbox.Focus();
            textbox.Clear();
            return false;
        }
        //A method that checks for a valid operator
        private bool isOperator(TextBox textbox, String name)
        {
            Char value;
            if(Char.TryParse(textbox.Text, out value))
            {
                if(value == '/' || value =='*'||value =='+' || value == '-')
                {
                    return true;
                }
            }
            MessageBox.Show(name + " must be *, /, +, or - operator", "Error Message");
            textbox.Focus();
            textbox.Clear();
            return false;
        }
        //An event handler that closes the window when clicked
        private void btmExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to exit");
            this.Close();
        }
        //Clear the field;
        private void txtOperand1_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        //A validation method for the various inputs
        private bool isValidInput()
        {
            if (!isPresent(txtOperand1, "Operand1"))
                return false;
            if (!isDecimal(txtOperand1, "Operand1"))
                return false;
            if (!isValidData(txtOperand1, "Operand1"))
                return false;
            if (!isOperator(txtOperator, "Operator"))
                return false;
            if (!isPresent(txtOperator, "Operator"))
                return false;           
            if (!isPresent(txtOperand2, "OPerant2"))
                return false;            
            if (!isDecimal(txtOperand2, "Operand2"))
                return false;      
            if (!isValidData(txtOperand2, "Operand2"))
                return false;
            
            return true;
        }
    }
}
