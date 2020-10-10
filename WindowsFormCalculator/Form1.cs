using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalculator
{
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string equation = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        char plusminus;
        double result = 0.0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + "4";
            }

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0.";
            }
            else
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void btnplumi_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.StartsWith("-"))
            {
                textBox1.Text = textBox1.Text.Substring(1);
            }
            else if(!string.IsNullOrEmpty(textBox1.Text) && decimal.Parse(textBox1.Text) != 0)
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if(textBox1.Text)
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {

        }

        private void btnSub_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

        }

        private void btnParLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnParRight_Click(object sender, EventArgs e)
        {

        }

        private void btnPow_Click(object sender, EventArgs e)
        {

        }

        private void btnenter_Click(object sender, EventArgs e)
        {

        }

        private void btnInverse_Click(object sender, EventArgs e)
        {

        }

        private void btne_Click(object sender, EventArgs e)
        {

        }

        private void btnNatLog_Click(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "0";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            input = input.Remove(input.Length - 1);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {

        }
    }
}
