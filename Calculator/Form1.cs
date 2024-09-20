using System;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Operation", "Operation");
            dataGridView1.Columns.Add("Result", "Result");
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            textBox1.KeyPress += textBox1_KeyPress;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 1)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("perform calculation");
                    }
                    if(!textBox1.Text.Contains('+') && !textBox1.Text.Contains('-') && !textBox1.Text.Contains('*') && !textBox1.Text.Contains('/')) 
                    {
                        MessageBox.Show("perform calculation");
                    }
                    else
                    {
                        CalculateExpression();
                        e.Handled = true;
                    }
                }
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && !textBox1.Text.Contains('.'))
            {
                return;
            }
           

            if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                return;
            }
            e.Handled = true;
            //this.textBox1.Focus();
            
        }

        private void CalculateExpression()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("perform calculation");
            }
            try
            {
                string expression = textBox1.Text;

                var result = new System.Data.DataTable().Compute(expression, null);

                dataGridView1.Rows.Insert(0, expression, result.ToString());

                textBox1.Text = result.ToString();



                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;

                isNewOperation = true;
            }
            catch (Exception ex)
            {
                textBox1.Text = "Error";
            }
        }




        private bool isNewOperation = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            isOperatorPressed = false;
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "9";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                textBox1.Text = "";
                isNewOperation = false;
            }
            textBox1.Text += "0";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            firstNumber = 0;
            currentOperator = "";
            isOperatorPressed = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                firstNumber = double.Parse(textBox1.Text);
                currentOperator = "+";
                textBox1.Text = "";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (currentOperator != "")
            {
                Calculate();
            }

            firstNumber = double.Parse(textBox1.Text);
            currentOperator = "*";
            textBox1.Text = "";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (currentOperator != "")
            {
                Calculate();
            }

            firstNumber = double.Parse(textBox1.Text);
            currentOperator = "/";
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (isOperatorPressed)
                {
                    Calculate();
                }

                firstNumber = double.Parse(textBox1.Text);
                currentOperator = "-";
                isOperatorPressed = true;
                textBox1.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Calculate();
        }
        private bool isOperatorPressed = true;
        private double firstNumber = 0;
        private string currentOperator = "";
        private void Calculate()
        {
            double secondNumber = double.Parse(textBox1.Text);
            string operationPerformed = currentOperator;

            string fullExpression = $"{firstNumber} {operationPerformed} {secondNumber}";

            switch (currentOperator)
            {
                case "+":
                    textBox1.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    textBox1.Text = (firstNumber - secondNumber).ToString();

                    break;
                case "*":
                    textBox1.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        textBox1.Text = "Math error";
                    }
                    else
                    {
                        textBox1.Text = (firstNumber / secondNumber).ToString();
                    }
                    break;

            }
            dataGridView1.Rows.Insert(0, fullExpression, textBox1.Text);

            isNewOperation = true;
            firstNumber = 0;
            currentOperator = "";
            isOperatorPressed = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.ReadOnly = true;
            //this.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
