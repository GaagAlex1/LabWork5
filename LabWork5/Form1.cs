using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace LabWork5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void isCorrect()
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Привет! Давайте уже начнем.";
        }

        private string[][] ParseText(ref string text)
        {
            string[] strings = text.Split('\n');
            string[][] lastStr = new string[strings.Length][];
            for (int i = 0; i < strings.Length; i++)
            {
                string[] stroka = strings[i].Split(' ');
                lastStr[i] = stroka;
            }
            return lastStr;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            delSrarif(ref str);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 44 && e.KeyChar != 8 && e.KeyChar != 32 && e.KeyChar != 13)
            {
                e.Handled = true;
            }   
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string newLine = Environment.NewLine;
            textBox1.Text += newLine;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /* private void button4_Click(object sender, EventArgs e)
         {
            int masString, masColumn;

             Random rnd = new Random();
             if ((textBox2.Text == "") || (textBox3.Text == ""))
                 textBox1.Text = "Введите целое число для создания массива из случайных чисел";
             else
             {
                 if (textBox3.Text == "0")
                 {
                     int[] dinMas = new int[masColumn];
                     for (int i = 0; i < masColumn; i++)
                     {

                         dinMas[i] = rnd.Next(-100,100);
                     }
                     textBox1.Text = string.Join(" ", dinMas);
                 }

             }
         }*/
        private void checkEmpty(ref string[][] text)
        {
            if (text.Length == 0)
            {
                MessageBox.Show("Пустой массив []");
            }
        }
        private void delSrarif(ref string Solve)
        {
            
            string messageText = "";
            
            
            string text = textBox1.Text;
            string[][] array = ParseText(ref text);
            checkEmpty(ref array);
            int[] ints = new int[array[0].Length];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = Convert.ToInt32(array[0][i]);
            }
           
            double srArif = 0d;
            int indexElem = -100;
            for (int i = 0; i < ints.Length - 1; i++)
                srArif += ints[i];
            srArif /= ints.Length;
            
            for (int i = 0; i < ints.Length; i++)
            {

                if (ints[i] == Math.Round(srArif))
                {
                    indexElem = i;
                    break;
                }
            }
            if (indexElem == -100)
            {
                messageText += $"В массиве нет элемента, равного среднему арфметическому всех чисел в массиве.";
                MessageBox.Show(messageText);
            }
            else
            {
                int[] newArray = new int[ints.Length - 1];
                for (int i = 0; i < indexElem; i++)
                    newArray[i] = ints[i];
                for (int i = indexElem + 1; i < ints.Length; i++)
                    newArray[i] = ints[i];
                messageText += $"{ints} Был удален элемент {ints[indexElem]}";
                MessageBox.Show(messageText);
                for (int i = 0; i<newArray.Length;i++)
                {
                    messageText += Convert.ToString(newArray[i]);
                }
                textBox1.Text = messageText;
            }
            
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Привет! Давайте уже начнем.")
            {
                textBox1.Text = "";

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
