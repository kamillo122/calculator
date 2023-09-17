using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        private MathOperations ops = new MathOperations();
        private History history = new History();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = history.GetHistory();
        }
        private void one_button_Click(object sender, EventArgs e)
        {
            label1.Text += "1";
        }

        private void two_button_Click(object sender, EventArgs e)
        {
            label1.Text += "2";
        }

        private void three_button_Click(object sender, EventArgs e)
        {
            label1.Text += "3";
        }

        private void four_button_Click(object sender, EventArgs e)
        {
            label1.Text += "4";
        }

        private void five_button_Click(object sender, EventArgs e)
        {
            label1.Text += "5";
        }

        private void six_button_Click(object sender, EventArgs e)
        {
            label1.Text += "6";
        }

        private void seven_button_Click(object sender, EventArgs e)
        {
            label1.Text += "7";
        }

        private void eight_button_Click(object sender, EventArgs e)
        {
            label1.Text += "8";
        }

        private void nine_button_Click(object sender, EventArgs e)
        {
            label1.Text += "9";
        }

        private void zero_button_Click(object sender, EventArgs e)
        {
            label1.Text += "0";
        }

        private void separator_button_Click(object sender, EventArgs e)
        {
            label1.Text += ",";
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            ops.sign = '\0';
            ops.first_number = 0;
            ops.second_number = 0;
        }

        private void equal_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.second_number = Double.Parse(label1.Text);
                ops.Count();
                label1.Text = ops.GetResult();
                string equation = ops.first_number.ToString() + ops.sign + ops.second_number + "=" + ops.GetResult();
                history.Push(equation);
                textBox1.Text = history.GetHistory();
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse data!");
            }
        }

        private void plus_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.first_number = Double.Parse(label1.Text);
                ops.sign = '+';
                ops.state = true;
                label1.Text = "";
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse data!");
            }
        }

        private void minus_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.first_number = Double.Parse(label1.Text);
                ops.sign = '-';
                ops.state = true;
                label1.Text = "";
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse data!");
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Remove(label1.Text.Length - 1);
            if (ops.state)
            {
                try
                {
                    ops.second_number = Double.Parse(label1.Text);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse data!");
                }
            }
            else
            {
                try
                {
                    ops.first_number = Double.Parse(label1.Text);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse data!");
                }
            }
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.first_number = Double.Parse(label1.Text);
                ops.sign = '*';
                ops.state = true;
                label1.Text = "";
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse data!");
            }
        }

        private void division_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.first_number = Double.Parse(label1.Text);
                ops.sign = '/';
                ops.state = true;
                label1.Text = "";
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse data!");
            }
        }

        private void pow_button_Click(object sender, EventArgs e)
        {
            try
            {
                ops.first_number = Double.Parse(label1.Text);
                ops.sign = 'p';
                ops.Count();
                label1.Text = ops.GetResult();
                string equation = ops.first_number.ToString() + "^2" + "=" + ops.GetResult();
                history.Push(equation);
                textBox1.Text = history.GetHistory();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
