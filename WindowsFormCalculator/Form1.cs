using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalculator
{
    public partial class Form1 : Form
    {
        string equation = string.Empty;
        double calculation;
        string operate = string.Empty;
        double result;
        readonly double valuee = 2.71828;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput.Text = "0";
        }
        private void btnClick(string num)
        {
            if(Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
                txtInput.Text = num;
            }
            else if(Validator.isFresh(txtInput,txtEquation))
            {
                txtInput.Text = num;
            }
            else
            {
                txtInput.Text = txtInput.Text + num;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btnClick("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnClick("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btnClick("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btnClick("4");

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btnClick("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btnClick("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btnClick("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btnClick("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btnClick("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btnClick("0");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (Validator.endswithRightPara(txtInput) == false)
            {
            }
            else if (Validator.isEmpty(txtInput) == true)
            {
                txtInput.Text = "0.";
            }
            else
            {
                txtInput.Text = txtInput.Text + ".";
            }
        }

        private void btnplumi_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (txtInput.Text.StartsWith("-"))
            {
                txtInput.Text = txtInput.Text.Substring(1);
            }
            else if(txtInput.Text.StartsWith("(-"))
            {
                txtInput.Text = txtInput.Text.Substring(2, txtInput.Text.Length - 3);

            }
            else if(!string.IsNullOrEmpty(txtInput.Text) && decimal.Parse(txtInput.Text) != 0)
            {
                txtInput.Text = "(-" + txtInput.Text +")";
            }
        }
        private void clearInput()
        {
            txtInput.Text = "";
        }

        private void btnOperator(string op)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (Validator.containsLog(txtInput.Text) == true)
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + ")" + op;
                clearInput();
            }
            else if (Validator.startswithLeftPara(txtInput) == true && Validator.endswithRightPara(txtInput) == true) // If input contains (xx )
            {
                txtEquation.Text = txtEquation.Text + op;
                clearInput();
            }
            else if (Validator.startswithLeftPara(txtInput) == true)
            {
                txtInput.Text = txtInput.Text + op;
            }

            else if(Validator.isEmpty(txtInput) == true && Validator.endsInOperator(txtEquation))
            {
                operate = txtEquation.Text;
                operate = operate.Substring(0, operate.Length - 1);
                txtEquation.Text = operate + op;
                operate = string.Empty;
                clearInput();
            }
            else if(Validator.endsInOperator(txtEquation) == true && Validator.isEmpty(txtInput) == false)
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + op;
                clearInput();
            }
            else
            {
                Console.WriteLine("wtf");
                txtEquation.Text = txtEquation.Text + txtInput.Text + op;
                clearInput();
            }
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            btnOperator("/");
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            btnOperator("*");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            btnOperator("-");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            btnOperator("+");
        }

        private void btnParLeft_Click(object sender, EventArgs e)
        {
            bool isDigit = Char.IsDigit(txtInput.Text.Last());
            bool isPar = txtInput.Text.EndsWith(")");

            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (txtInput.Text == "0" && txtEquation.Text =="")
            {
                txtInput.Text = "(";
            }
            else if (txtEquation.Text.EndsWith("+") || txtEquation.Text.EndsWith("-") ||
                txtEquation.Text.EndsWith("/") || txtEquation.Text.EndsWith("*") && txtInput.Text == "")
            {
                txtInput.Text = "(";
            }
            else if (txtInput.Text.EndsWith("("))
            {
                txtInput.Text = txtInput.Text + "(";
            }
            else if (isDigit == true) //Default to multiplication if no operator is called
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "*";
                txtInput.Text = "(";
            }
        }

        private void btnParRight_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else
            {
                txtInput.Text = txtInput.Text + ")";
            }
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            btnOperator("^");
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            txtEquation.Text = txtEquation.Text + txtInput.Text;
            // Need to Implement Bracket balancing check
            if(Validator.containsPower(txtEquation.Text)==true)
            {
                CalcPow();
            }
            else if(Validator.containsLog(txtEquation.Text)==true)
            {
                CalcLog();
            }
            equation = txtEquation.Text;
            calculation = Evaluate(equation);
            txtEquation.Text = equation + Environment.NewLine + Environment.NewLine + "Result:   " + calculation.ToString();
            clearInput();

        }
        private void CalcPow()
        {
            string pattern = @"(\([^)]*\)|\d+)\^(\([^)]*\)|\d+)";
            if(txtEquation.Text.Contains("^"))
            { 
                while (txtEquation.Text.Contains("^"))
                {
                    Match m = Regex.Match(txtEquation.Text, pattern);
                    int mIndex = m.Index;
                    int mLength = m.Value.Length;
                    int powind = m.Value.IndexOf("^");
                    double beforepow = double.Parse(m.Value.Substring(0, powind));
                    double afterpow = double.Parse(m.Value.Substring(powind + 1));
                    double calcpow = Math.Pow(beforepow, afterpow);
                    string test2 = txtEquation.Text;
                    test2 = test2.Remove(mIndex, mLength).Insert(mIndex, calcpow.ToString());
                    txtEquation.Text = test2;
                }
            }
        }
        private void CalcLog()
        {
            string logpat = @"(log|ln)(\(\d+\))";
            double result = 0;
            while (txtEquation.Text.Contains("log") || txtEquation.Text.Contains("ln"))
            {
                Match m = Regex.Match(txtEquation.Text, logpat);
                int mIndex = m.Index;
                int mLength = m.Value.Length;
                int parleft = m.Value.IndexOf("(");
                string match = m.Value;
                match = match.Substring(parleft + 1);
                match = match.Remove(match.Length - 1);
                double calc = double.Parse(match);

                if (m.Value.Contains("log"))
                {
                    result = Math.Log10(calc);
                }
                else if (m.Value.Contains("ln"))
                {
                    result = Math.Log(calc);
                }
                string replace = txtEquation.Text;
                replace = replace.Remove(mIndex, mLength).Insert(mIndex, result.ToString());
                txtEquation.Text = replace;
            }
        }

        public double Evaluate(string expression)
        {
            try
            {

                bool isPar = expression.EndsWith(")");
                bool isDigit = Char.IsDigit(expression.Last());
                if (isDigit == false && isPar == false)
                {
                    string message = "Equation incomplete, Continue?";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult dresult;
                    dresult = MessageBox.Show(message, caption, buttons);
                    if (dresult == DialogResult.OK)
                    {
                        if (expression.Length < 1)
                        {
                            MessageBox.Show("Cannot Proceed");
                            ClearFields();
                        }
                        else
                        {
                            while (isDigit == false)
                            {
                                expression = expression.Remove(expression.Length - 1);
                            }
                            DataTable table = new DataTable();
                            table.Columns.Add("expression", typeof(string), expression);
                            DataRow row = table.NewRow();
                            table.Rows.Add(row);
                            result = double.Parse((string)row["expression"]);
                        }
                    }
                }
                else
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("expression", typeof(string), expression);
                    DataRow row = table.NewRow();
                    table.Rows.Add(row);
                    result = double.Parse((string)row["expression"]);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error Has Occured");
                //ClearFields();
                return 0;

            }
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "0" && txtInput.Text != null)
            {
                txtInput.Text = "1/" + txtInput.Text;
            }

        }

        private void btne_Click(object sender, EventArgs e)
        {
            
            txtInput.Text = valuee.ToString();

        }
        

        private void btnNatLog_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if(Validator.isEmpty(txtInput) == true || txtInput.Text == "0")
            {
                txtInput.Text = "ln(";
            }
            else if(Validator.isEmpty(txtInput) == false)
            {
                txtInput.Text = "ln(" + txtInput.Text;
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (Validator.isEmpty(txtInput) == true || txtInput.Text == "0")
            {
                txtInput.Text = "log(";
            }
            else if (Validator.isEmpty(txtInput) == false)
            {
                txtInput.Text = "log(" + txtInput.Text;
            }
        }

        public void ClearFields()
        {
            this.txtInput.Text = "0";
            this.txtEquation.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true && Validator.isEmpty(txtInput) == false)
            {
                txtEquation.Text = "";
                txtInput.Text = Math.Pow(double.Parse(txtInput.Text), 2).ToString();
            }
            else if (Validator.isEmpty(txtInput) == false)
            {
                txtInput.Text = Math.Pow(double.Parse(txtInput.Text), 2).ToString();
            }

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true && Validator.isEmpty(txtInput) == false)
            {
                txtEquation.Text = "";
                txtInput.Text = Math.Sqrt(double.Parse(txtInput.Text)).ToString();
            }
            else if(Validator.isEmpty(txtInput) == false)
            {
                txtInput.Text = Math.Sqrt(double.Parse(txtInput.Text)).ToString();
            }
        }
    }
}
