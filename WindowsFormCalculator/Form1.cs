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

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (txtInput.Text.StartsWith("(") && txtInput.Text.EndsWith(")"))
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "/";
                txtInput.Text = "";

            }
            else if (txtInput.Text.StartsWith("("))
            {
                txtInput.Text = txtInput.Text + "/";
            }
            else if (txtEquation.Text.EndsWith("/") || txtEquation.Text.EndsWith("-") || txtEquation.Text.EndsWith("+") || txtEquation.Text.EndsWith("*") && txtInput.Text == "")
            {
                operate = txtEquation.Text;
                operate = operate.Substring(0, operate.Length - 1);
                Console.WriteLine(operate);
                txtEquation.Text = operate + "/";
                operate = string.Empty;
            }
            else
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "/";
                Console.WriteLine("working");
                txtInput.Text = "";
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if(txtInput.Text.StartsWith("(") && txtInput.Text.EndsWith(")"))
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "*";
                txtInput.Text = "";
            }
            else if (txtInput.Text.StartsWith("("))
            {
                txtInput.Text = txtInput.Text + "*";
            }

            else if (txtEquation.Text.EndsWith("/") || txtEquation.Text.EndsWith("-") || txtEquation.Text.EndsWith("+") || txtEquation.Text.EndsWith("*") && txtInput.Text == "")
            {
                operate = txtEquation.Text;
                operate = operate.Substring(0, operate.Length - 1);
                Console.WriteLine(operate);
                txtEquation.Text = operate + "*";
                operate = string.Empty;
            }
            else
            {
                equation = txtInput.Text + "*";
                txtEquation.Text = txtEquation.Text + equation;
                txtInput.Text = "";
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (txtInput.Text.StartsWith("(") && txtInput.Text.EndsWith(")"))
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "-";
                txtInput.Text = "";
            }
            else if (txtInput.Text.StartsWith("("))
            {
                txtInput.Text = txtInput.Text + "-";
            }
            else if (txtEquation.Text.EndsWith("/") || txtEquation.Text.EndsWith("-") || txtEquation.Text.EndsWith("+") || txtEquation.Text.EndsWith("*") && txtInput.Text == "")
            {
                operate = txtEquation.Text;
                operate = operate.Substring(0, operate.Length - 1);
                Console.WriteLine(operate);
                txtEquation.Text = operate + "-";
                operate = string.Empty;
            }
            else if (txtInput.Text != null)
            {
                equation = txtInput.Text + "-";
                txtEquation.Text = txtEquation.Text + equation;
                txtInput.Text = "";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Validator.containsResult(txtEquation) == true)
            {
                ClearFields();
            }
            else if (txtInput.Text.StartsWith("(") && txtInput.Text.EndsWith(")"))
            {
                txtEquation.Text = txtEquation.Text + txtInput.Text + "+";
                txtInput.Text = "";
            }
            else if (txtInput.Text.StartsWith("("))
            {
                txtInput.Text = txtInput.Text + "+";
            }

            else if (txtEquation.Text.EndsWith("/") || txtEquation.Text.EndsWith("-") || txtEquation.Text.EndsWith("+") || txtEquation.Text.EndsWith("*") && txtInput.Text == "")
            {
                operate = txtEquation.Text;
                operate = operate.Substring(0, operate.Length - 1);
                Console.WriteLine(operate);
                txtEquation.Text = operate + "+";
                operate = string.Empty; ;
            }
            else if (txtInput.Text != null)
            {
                equation = txtInput.Text + "+";
                txtEquation.Text = txtEquation.Text + equation;
                txtInput.Text = "";
            }
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
        //Commented out on Designer
        private void btnPow_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != null)
            {
                txtInput.Text = txtInput.Text + "^";
            }
        }
        //double final;
        //public double PowerCalculation(string power)
        //{
        //    string expression;
        //    expression = txtInput.Text.Remove(txtInput.Text.Length -1); 
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("expression", typeof(string), expression);
        //    DataRow row = dt.NewRow();
        //    dt.Rows.Add(row);
        //    final = Math.Pow(double.Parse((string)row["expression"]),double.Parse(power));
        //    txtInput.Text = final.ToString();
        //    return final;

        //}

        private void btnenter_Click(object sender, EventArgs e)
        {
            txtEquation.Text = txtEquation.Text + txtInput.Text;
            equation = txtEquation.Text;
            calculation = Evaluate(equation);
            txtEquation.Text = equation + Environment.NewLine + Environment.NewLine + "Result:   " + calculation.ToString();

        }
        private void CalcPow()
        {
            string pattern = @"(\([^)]*\)|\d+)\^(\([^)]*\)|\d+)";
            if(txtEquation.Text.Contains("^"))
            { 
                while (txtEquation.Text.Contains("^"))
                {
                    Match m = Regex.Match(txtEquation.Text, pattern);
                    //Console.WriteLine("'{0}' found at position {1}", m.Value, m.Index);
                    int mIndex = m.Index;
                    int mLength = m.Value.Length;
                    //Console.WriteLine(m.Length);
                    int powind = m.Value.IndexOf("^");
                    double beforepow = double.Parse(m.Value.Substring(0, powind));
                    //Console.WriteLine(beforepow);
                    double afterpow = double.Parse(m.Value.Substring(powind + 1));
                    //Console.WriteLine(afterpow);
                    double calcpow = Math.Pow(beforepow, afterpow);
                    //Console.WriteLine(calcpow);
                    string test2 = txtEquation.Text;
                    test2 = test2.Remove(mIndex, mLength).Insert(mIndex, calcpow.ToString());
                    //Console.WriteLine(test2);
                    txtEquation.Text = test2;
                    //m = m.NextMatch();
                }
            }
        }

        public double Evaluate(string expression)
        {
            //txtEquation.Text = txtEquation.Text + txtInput.Text;
            //txtInput.Text = "0";
            CalcPow();

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
        }

        private void btnLog_Click(object sender, EventArgs e)
        {

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
            if (txtInput.Text != null)
            {
                txtInput.Text = Math.Pow(double.Parse(txtInput.Text),2).ToString();
            }

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != null)
            {
                txtInput.Text = Math.Sqrt(double.Parse(txtInput.Text)).ToString();
            }
        }
    }
}
