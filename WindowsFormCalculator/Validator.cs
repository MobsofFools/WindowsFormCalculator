using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalculator
{
    public static class Validator
    {
        public static bool isEmpty(TextBox inputBox)
        {
            bool isValid = true; 
            if (inputBox.Text != "")
            {
                isValid = false;
            }
            return isValid;
        }

        public static bool endsInOperator(TextBox inputBox)
        {
            bool isValid = false;
            if(inputBox.Text.EndsWith("+") || inputBox.Text.EndsWith("-") ||
                inputBox.Text.EndsWith("*") || inputBox.Text.EndsWith("/"))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool containsPower(string expression)
        {
            bool isValid = false;
            if (expression.Contains("^"))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool containsResult(TextBox inputBox)
        {
            bool isValid = false;
            if (inputBox.Text.Contains("Result"))
                {
                isValid = true;
            }
            return isValid;
        }
        public static bool isFresh(TextBox input, TextBox exp)
        {
            bool isValid = false;
            if(input.Text == "0" && exp.Text == "")
            {
                isValid = true;
            }
            return isValid;
             
        }
        public static bool startswithLeftPara(TextBox inputBox)
        {
            bool isValid = false;
            if (inputBox.Text.StartsWith("("))
            {
                isValid = true;
            }
            return isValid;
        }
        public static bool endswithRightPara(TextBox inputBox)
        {
            bool isValid = false;
            if (inputBox.Text.EndsWith(")"))
            {
                isValid = true;
            }
            return isValid;
        }

    }
}
