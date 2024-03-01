using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZKI_Lab1
{
    public partial class Form9 : Form
    {
        public static List<int> Sequence { get; set; } = new List<int>();
        public static string Message { get; set; } = string.Empty;
        public static int M { get; set; }
        public static int N { get; set; }

        public Form9()
        {
            InitializeComponent();
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll();
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.DeselectAll();
            richTextBox3.SelectAll();
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.DeselectAll();
            richTextBox4.SelectAll();
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox4.DeselectAll();
            richTextBox5.SelectAll();
            richTextBox5.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox5.DeselectAll();
            richTextBox6.SelectAll();
            richTextBox6.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox6.DeselectAll();
            richTextBox7.SelectAll();
            richTextBox7.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox7.DeselectAll();
            richTextBox8.SelectAll();
            richTextBox8.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox8.DeselectAll();
            richTextBox9.SelectAll();
            richTextBox9.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox9.DeselectAll();
            richTextBox10.SelectAll();
            richTextBox10.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox10.DeselectAll();
            richTextBox11.SelectAll();
            richTextBox11.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox11.DeselectAll();
        }

        private string ReadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Выберите файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                return fileContent;
            }

            return string.Empty;
        }

        private void SaveToFile(string text)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog.Title = "Сохранить файл";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, text);
                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] numberStrings = textBox1.Text.Split(' ');
            var tmp = new List<int>();
            bool ascendant = true;

            foreach (string numberString in numberStrings)
            {
                int number = int.Parse(numberString);
                tmp.Add(number);
            }

            for (int i = 0; i < tmp.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += tmp[j];
                }
                if (i > 0 && tmp[i] <= sum)
                {
                    ascendant = false;
                    break;
                }
            }

            if (tmp.Count == 8 && ascendant)
            {
                Sequence = tmp;
                Message = textBox1.Text;
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);
            Sequence.Add(number);
            for (int i = 1; i < 8; i++)
            {
                number *= 2;
                Sequence.Add(number);
                textBox1.Text += " " + number.ToString();
            }
            textBox1.ForeColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = ReadFile();
            string[] numberStrings = text.Split(' ');
            var tmp = new List<int>();
            bool ascendant = true;
            textBox1.Clear();

            foreach (string numberString in numberStrings)
            {
                int number = int.Parse(numberString);
                tmp.Add(number);
                textBox1.Text += number + " ";
            }

            for (int i = 0; i < tmp.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += tmp[j];
                }
                if (i > 0 && tmp[i] <= sum)
                {
                    ascendant = false;
                    break;
                }
            }

            if (tmp.Count == 8 && ascendant)
            {
                Sequence = tmp;
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(textBox3.Text);
            if (tmp > Sequence.Sum())
            {
                textBox3.ForeColor = Color.Green;
                M = tmp;

            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            M = Sequence.Sum() + 1;
            textBox3.Text = M.ToString();
            textBox3.ForeColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(ReadFile());
            textBox3.Text = tmp.ToString();
            if (tmp > Sequence.Sum())
            {
                textBox3.ForeColor = Color.Green;
                M = tmp;

            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Message = textBox1.Text.ToUpper();

            for (int i = 0; i < Message.Length; i++)
            {


            }
        }

        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        

        public static bool IsCoprime(int number1, int number2)
        {
            int gcd = FindGCD(number1, number2);

            return gcd == 1;
        }

        public static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(textBox4.Text);
            if (IsCoprime(tmp, M))
            {
                textBox4.ForeColor = Color.Green;
                N = tmp;

            }
            else
            {
                textBox4.ForeColor = Color.Red;
            }
        }
        public int GenerateCoprime(int number)
        {
            int coprime = 2;

            while (true)
            {
                if (IsCoprime(number, coprime))
                {
                    textBox4.ForeColor = Color.Green;
                    return coprime;
                }

                coprime++;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            N = GenerateCoprime(M);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(ReadFile());
            textBox4.Text = tmp.ToString();
            if (IsCoprime(tmp, M))
            {
                textBox4.ForeColor = Color.Green;
                N = tmp;

            }
            else
            {
                textBox4.ForeColor = Color.Red;
            }
        }
    }
}
