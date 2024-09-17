using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using NCalc;
using System.Reflection;
using Antlr.Runtime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Calculatrice
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        
        void DisabledAllButtons()
        {

            button8.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            btnReverseSign.Enabled = false;
            button7.Enabled = false; 
            button16.Enabled = false;
            button15.Enabled = false;
            button6.Enabled = false; 
            button5.Enabled = false; 
            button1.Enabled = false; 
            button2.Enabled = false; 
            btnClearCalculator.Enabled = false;
            btnPour100.Enabled = false;
            panel1.Enabled = false;
            pictureBox1.Enabled = false;
            btnDivide.Enabled = false;
            btnSeven.Enabled = false;
            btnEight.Enabled = false;
            btnNine.Enabled = false;
            btnFour.Enabled = false;
            btnFive.Enabled = false;
            btnSex.Enabled = false;
            btnOne.Enabled = false;
            btnTwo.Enabled = false;
            btnThree.Enabled = false;
            btnMultiplicate.Enabled = false;
            btnMinus.Enabled = false;
            btnAdd.Enabled = false;
            btnZero.Enabled = false;
            button14.Enabled = false;
            btnEqual.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Text = "";
            LblResult.Text = "";
        }

        void EnabledAllButtons()
        {
            button8.Enabled =true;
            button10.Enabled = true;
            button11.Enabled = true;
            btnReverseSign.Enabled = true;
            button7.Enabled = true;
            button16.Enabled = true;
            button15.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            btnClearCalculator.Enabled = true;
            btnPour100.Enabled = true;
            panel1.Enabled = true;
            pictureBox1.Enabled = true;
            btnDivide.Enabled = true;
            btnSeven.Enabled = true;
            btnEight.Enabled = true;
            btnNine.Enabled = true;
            btnFour.Enabled = true;
            btnFive.Enabled = true;
            btnSex.Enabled = true;
            btnOne.Enabled = true;
            btnTwo.Enabled = true;
            btnThree.Enabled = true;
            btnMultiplicate.Enabled = true;
            btnMinus.Enabled = true;
            btnAdd.Enabled = true;
            btnZero.Enabled = true;
            button14.Enabled = true;
            btnEqual.Enabled = true;
            textBox1.Enabled = true;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 100)
            {
                MessageBox.Show("Fin Total is 100", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBox1.Select();



            int Index = textBox1.SelectionStart;
            
            if (Index == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 1)
                textBox1.SelectionStart = Index + 1;
            else
                textBox1.SelectionStart = textBox1.TextLength;

        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 99)
            {
                return;
            }

            textBox1.Select();

            int Index = textBox1.SelectionStart;

            if (textBox1.SelectionStart == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 1)
                textBox1.SelectionStart = Index + 1;
            else
                textBox1.SelectionStart = textBox1.TextLength;
        
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                LblResult.Text = "0";
                return;
            }

            /*
            if (
                
                (!Char.IsNumber(textBox1.Text[0]) && textBox1.Text[0] != '-' && textBox1.Text[0] != '(') 
                ||
                (!Char.IsNumber(textBox1.Text[textBox1.Text.Length -1])
                &&
                textBox1.Text[textBox1.Text.Length - 1] != ')')
                
                )
            {
                MessageBox.Show("Syntax Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */

            string expression = textBox1.Text;
            var expr = new Expression(expression);

            try
            {
                Type resultType = expr.Evaluate().GetType();

                if (resultType == typeof(double))
                {
                    double resultDouble = (double)expr.Evaluate();
                    LblResult.Text = Convert.ToString(resultDouble);
                }
                else if (resultType == typeof(int))
                {
                    int resultInt = (int)expr.Evaluate();
                    LblResult.Text = Convert.ToString(resultInt);
                }
                else
                {
                    LblResult.Text = Convert.ToString(expr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Syntax Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            /*
            List<double> ListNumbers;
            ListNumbers = new List<double> { };

            List<char> ListOperations;
            ListOperations = new List<char> { };



            // Enter Number In ListNumbers And Operations In ListOperations
            string Number = "";
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (Char.IsNumber(textBox1.Text[i]) || textBox1.Text[i] == '.' || textBox1.Text[i] == '-')
                {
                    if (textBox1.Text[i] == '-' && Number != "")
                    {
                        ListNumbers.Add(Convert.ToDouble(Number));
                        Number = "";
                        ListOperations.Add(textBox1.Text[i]);
                    }

                    Number = Number + textBox1.Text[i];
                }
                else
                {
                    ListNumbers.Add(Convert.ToDouble(Number));
                    Number = "";
                    ListOperations.Add(textBox1.Text[i]);
                }
            }

            if (Number != "")
            {
                ListNumbers.Add(Convert.ToDouble(Number));
            }

            if (FintechCalculator(ListNumbers, ListOperations))
                return;


            // Operation * And /
            for (int i = 0; i < ListOperations.Count; i++)
            {
                if (ListOperations[i] == '*' || ListOperations[i] == '/')
                {
                    switch (ListOperations[i])
                    {
                        case '*':
                            ListNumbers[i] *= ListNumbers[i + 1];

                            ListNumbers.RemoveAt(i + 1);
                            ListOperations.RemoveAt(i);

                            if (FintechCalculator(ListNumbers, ListOperations))
                                return;
                            i--;
                            break;
                        case '/':
                            ListNumbers[i] /= ListNumbers[i + 1];

                            ListNumbers.RemoveAt(i + 1);
                            ListOperations.RemoveAt(i);

                            if (FintechCalculator(ListNumbers, ListOperations))
                                return;
                            i--;
                            break;
                    }
                }

            }

            // Operation + And -

            for (int i = 0; i < ListOperations.Count; i++)
            {
                if (ListOperations[i] == '+')
                {
                    ListNumbers[i] += ListNumbers[i + 1];

                    ListNumbers.RemoveAt(i + 1);
                    ListOperations.RemoveAt(i);

                    if (FintechCalculator(ListNumbers, ListOperations))
                        return;

                    i--;

                }
                else if (ListNumbers[i] < 0 || ListNumbers[i + 1] < 0)
                {
                    ListNumbers[i] += ListNumbers[i + 1];

                    ListNumbers.RemoveAt(i + 1);

                    if (FintechCalculator(ListNumbers, ListOperations))
                        return;

                    i--;
                }
            }
            */
        }

        private void btnDeleteLastItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionStart >= 7 && textBox1.Text.Substring(textBox1.SelectionStart - 7, 7) == "Pow(10,")
            {
                int IndexCursor = textBox1.SelectionStart - 7;
                textBox1.Text = textBox1.Text.Remove(IndexCursor, 7);
                textBox1.SelectionStart = IndexCursor;

                return;
            }
            else if (textBox1.SelectionStart >= 5 && textBox1.Text.Substring(textBox1.SelectionStart - 5, 5) == "Sqrt(")
            {
                int IndexCursor = textBox1.SelectionStart - 5;
                textBox1.Text = textBox1.Text.Remove(IndexCursor, 5);
                textBox1.SelectionStart = IndexCursor;

                return;
            }
            else if (textBox1.SelectionStart >= 4 &&

                (textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Tan("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Cos("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Sin("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Pow(")
                )
            {
                int IndexCursor = textBox1.SelectionStart - 4;
                textBox1.Text = textBox1.Text.Remove(IndexCursor, 4);
                textBox1.SelectionStart = IndexCursor;

                return;
            }
            

            if (textBox1.SelectionStart == 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            else
            {
                int IndexCursor = textBox1.SelectionStart -1;
                textBox1.Text = textBox1.Text.Remove(IndexCursor, 1);
                textBox1.SelectionStart = IndexCursor;

            }


        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            LblResult.Text = string.Empty;
        }

        private void btnReverseSign_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                LblResult.Text = "0";
                return;
            }


            string expression = textBox1.Text;
            var expr = new Expression(expression);

            try
            {
                Type resultType = expr.Evaluate().GetType();

                if (resultType == typeof(double))
                {
                    double resultDouble = (double)expr.Evaluate();
                    LblResult.Text = Convert.ToString(resultDouble);
                }
                else if (resultType == typeof(int))
                {
                    int resultInt = (int)expr.Evaluate();
                    LblResult.Text = Convert.ToString(resultInt);
                }
                else
                {
                    LblResult.Text = Convert.ToString(expr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Syntax Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LblResult.Text = Convert.ToString(Convert.ToDouble(LblResult.Text) * -1);
            textBox1.Text = LblResult.Text;
        }

        private void StepBack_Click(object sender, EventArgs e)
        {

            textBox1.Select();
            if (textBox1.SelectionStart == 0)
            {
                textBox1.SelectionStart = 0;
                return;
            }

            if (textBox1.SelectionStart >= 7 && textBox1.Text.Substring(textBox1.SelectionStart - 7, 7) == "Pow(10,")
            {
                textBox1.SelectionStart -= 7;
                return;
            }
            else if (textBox1.SelectionStart >= 5 && textBox1.Text.Substring(textBox1.SelectionStart - 5, 5) == "Sqrt(")
            {
                textBox1.SelectionStart -= 5;
                return;
            }
            else if (textBox1.SelectionStart >= 4
                &&
                (textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Tan("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Cos("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Sin("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart - 4, 4) == "Pow(")
                 )
            {
                textBox1.SelectionStart -= 4;
                return;
                
            }
            


            textBox1.SelectionStart -= 1;
        }

        private void StepFront_Click(object sender, EventArgs e)
        {
            textBox1.Select();

            if (textBox1.SelectionStart == textBox1.TextLength)
            {
                textBox1.SelectionStart = textBox1.TextLength;
                return;
            }


            if (textBox1.TextLength - textBox1.SelectionStart >= 7 && textBox1.Text.Substring(textBox1.SelectionStart, 7) == "Pow(10,")
            {
                textBox1.SelectionStart += 7;
                return;
            }
            else if (textBox1.TextLength - textBox1.SelectionStart >= 5 && textBox1.Text.Substring(textBox1.SelectionStart, 5) == "Sqrt(")
            {
                textBox1.SelectionStart += 5;
                return;
            }
            else if(textBox1.TextLength - textBox1.SelectionStart >= 4
                &&
                (textBox1.Text.Substring(textBox1.SelectionStart, 4) == "Tan("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart, 4) == "Cos("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart, 4) == "Sin("
                    ||
                    textBox1.Text.Substring(textBox1.SelectionStart, 4) == "Pow(")
                )
            {
                textBox1.SelectionStart += 4;
                return;
            }

            textBox1.SelectionStart += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();

            textBox1.Focus();
        }

        private void MathMethods_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 99)
            {
                return;
            }

            textBox1.Select();

            int Index = textBox1.SelectionStart;

            if (textBox1.SelectionStart == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 4)
                textBox1.SelectionStart = Index + 4;
            else
                textBox1.SelectionStart = textBox1.TextLength;
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 99)
            {
                return;
            }

            textBox1.Select();

            int Index = textBox1.SelectionStart;

            if (textBox1.SelectionStart == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 5)
                textBox1.SelectionStart = Index + 5;
            else
                textBox1.SelectionStart = textBox1.TextLength;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 99)
            {
                return;
            }

            textBox1.Select();

            int Index = textBox1.SelectionStart;

            if (textBox1.SelectionStart == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 7)
                textBox1.SelectionStart = Index + 7;
            else
                textBox1.SelectionStart = textBox1.TextLength;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 99)
            {
                return;
            }

            textBox1.Select();

            int Index = textBox1.SelectionStart;

            if (textBox1.SelectionStart == 0)
                textBox1.Text += Convert.ToString(((System.Windows.Forms.Button)sender).Tag);
            else
                textBox1.Text = textBox1.Text.Insert(Index, Convert.ToString(((System.Windows.Forms.Button)sender).Tag));

            if (Index != 0 || Index != textBox1.TextLength - 4)
                textBox1.SelectionStart = Index + 4;
            else
                textBox1.SelectionStart = textBox1.TextLength;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if  (button11.Enabled == true && btnEqual.Enabled == true)
                DisabledAllButtons();
            else
                EnabledAllButtons();

        }


    }
}
