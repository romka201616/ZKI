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
        public static List<int> OpenSequence { get; set; } = new List<int>();
        public static List<List<int>> WeightsSums { get; set; } = new List<List<int>>();
        public static List<int> C { get; set; } = new List<int>();
        public static List<int> A { get; set; } = new List<int>();
        public static string Message { get; set; } = string.Empty;
        public static string DecryptedMessage { get; set; } = string.Empty;
        public static int M { get; set; }
        public static int N { get; set; }
        public static int N1 { get; set; }
        Dictionary<char, string> letterCodes = new Dictionary<char, string>
        {
            {'а', "11100000"},
            {'б', "11100001"},
            {'в', "11100010"},
            {'г', "11100011"},
            {'д', "11100100"},
            {'е', "11100101"},
            {'ё', "10111000"},
            {'ж', "11100110"},
            {'з', "11100111"},
            {'и', "11101000"},
            {'й', "11101001"},
            {'к', "11101010"},
            {'л', "11101011"},
            {'м', "11101100"},
            {'н', "11101101"},
            {'о', "11101110"},
            {'п', "11101111"},
            {'р', "11110000"},
            {'с', "11110001"},
            {'т', "11110010"},
            {'у', "11110011"},
            {'ф', "11110100"},
            {'х', "11110101"},
            {'ц', "11110110"},
            {'ч', "11110111"},
            {'ш', "11111000"},
            {'щ', "11111001"},
            {'ъ', "11111010"},
            {'ы', "11111011"},
            {'ь', "11111100"},
            {'э', "11111101"},
            {'ю', "11111110"},
            {'я', "11111111"},
            {'А', "11000000"},
            {'Б', "11000001"},
            {'В', "11000010"},
            {'Г', "11000011"},
            {'Д', "11000100"},
            {'Е', "11000101"},
            {'Ё', "10101000"},
            {'Ж', "11000110"},
            {'З', "11000111"},
            {'И', "11001000"},
            {'Й', "11001001"},
            {'К', "11001010"},
            {'Л', "11001011"},
            {'М', "11001100"},
            {'Н', "11001101"},
            {'О', "11001110"},
            {'П', "11001111"},
            {'Р', "11010000"},
            {'С', "11010001"},
            {'Т', "11010010"},
            {'У', "11010011"},
            {'Ф', "11010100"},
            {'Х', "11010101"},
            {'Ц', "11010110"},
            {'Ч', "11010111"},
            {'Ш', "11011000"},
            {'Щ', "11011001"},
            {'Ъ', "11011010"},
            {'Ы', "11011011"},
            {'Ь', "11011100"},
            {'Э', "11011101"},
            {'Ю', "11011110"},
            {'Я', "11011111"}
        };


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
            richTextBox12.SelectAll();
            richTextBox12.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox12.DeselectAll();
            richTextBox13.SelectAll();
            richTextBox13.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox13.DeselectAll();
            richTextBox14.SelectAll();
            richTextBox14.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox14.DeselectAll();
            richTextBox15.SelectAll();
            richTextBox15.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox15.DeselectAll();
            richTextBox16.SelectAll();
            richTextBox16.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox16.DeselectAll();
            richTextBox17.SelectAll();
            richTextBox17.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox17.DeselectAll();
            richTextBox18.SelectAll();
            richTextBox18.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox18.DeselectAll();
            richTextBox19.SelectAll();
            richTextBox19.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox19.DeselectAll();
            richTextBox20.SelectAll();
            richTextBox20.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox20.DeselectAll();
            richTextBox21.SelectAll();
            richTextBox21.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox21.DeselectAll();
            richTextBox22.SelectAll();
            richTextBox22.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox22.DeselectAll();
            richTextBox23.SelectAll();
            richTextBox23.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox23.DeselectAll();
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button6_Click_1(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            M = Sequence.Sum() + 1;
            textBox3.Text = M.ToString();
            textBox3.ForeColor = Color.Green;
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            Message = textBox2.Text;

            for (int i = 0; i < Message.Length; i++)
            {
                richTextBox1.Text += Message[i];
                richTextBox1.Text += Environment.NewLine;
                richTextBox2.Text += letterCodes[Message[i]];
                richTextBox2.Text += Environment.NewLine;
                WeightsSums.Add(new List<int>());
            }

            for (int i = 0; i < Message.Length; i++)
            {
                if (letterCodes[Message[i]][0] == '1')
                {
                    richTextBox3.Text += OpenSequence[0].ToString();
                    richTextBox3.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[0]);
                }
                else 
                {
                    richTextBox3.Text += "-";
                    richTextBox3.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][1] == '1')
                {
                    richTextBox4.Text += OpenSequence[1].ToString();
                    richTextBox4.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[1]);
                }
                else
                {
                    richTextBox4.Text += "-";
                    richTextBox4.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][2] == '1')
                {
                    richTextBox5.Text += OpenSequence[2].ToString();
                    richTextBox5.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[2]);
                }
                else
                {
                    richTextBox5.Text += "-";
                    richTextBox5.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][3] == '1')
                {
                    richTextBox6.Text += OpenSequence[3].ToString();
                    richTextBox6.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[3]);
                }
                else
                {
                    richTextBox6.Text += "-";
                    richTextBox6.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][4] == '1')
                {
                    richTextBox7.Text += OpenSequence[4].ToString();
                    richTextBox7.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[4]);
                }
                else
                {
                    richTextBox7.Text += "-";
                    richTextBox7.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][5] == '1')
                {
                    richTextBox8.Text += OpenSequence[5].ToString();
                    richTextBox8.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[5]);
                }
                else
                {
                    richTextBox8.Text += "-";
                    richTextBox8.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][6] == '1')
                {
                    richTextBox9.Text += OpenSequence[6].ToString();
                    richTextBox9.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[6]);
                }
                else
                {
                    richTextBox9.Text += "-";
                    richTextBox9.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][7] == '1')
                {
                    richTextBox10.Text += OpenSequence[7].ToString();
                    richTextBox10.Text += Environment.NewLine;
                    WeightsSums[i].Add(OpenSequence[7]);
                }
                else
                {
                    richTextBox10.Text += "-";
                    richTextBox10.Text += Environment.NewLine;
                }
            }

            for (int i = 0; i < Message.Length; i++)
            {
                C.Add(WeightsSums[i].Sum());
                richTextBox11.Text += WeightsSums[i].Sum().ToString();
                richTextBox11.Text += Environment.NewLine;
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

        private void button10_Click_1(object sender, EventArgs e)
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
            int a = 2;

            while (true)
            {
                if (number % a != 0 && IsPrime(a) && NoCommonDivisors(number, a))
                {
                    return a;
                }
                a++;
            }
        }

        static bool NoCommonDivisors(int a, int b)
        {
            for (int i = 2; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0) return false;
            }

            return true;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            N = GenerateCoprime(M);
            textBox4.Text = N.ToString();
            textBox4.ForeColor = Color.Green;
        }

        private void button8_Click_1(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            while (true) 
            {
                tmp++;
                if((N * tmp) % M == 1)
                {
                    N1 = tmp;
                    textBox5.Text = N1.ToString();
                    textBox5.ForeColor = Color.Green;
                    break;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(textBox5.Text);
            if ((N * tmp) % M == 1)
            {
                N1 = tmp;
                textBox5.ForeColor = Color.Green;
            }
            else
            {
                textBox5.ForeColor = Color.Red;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(ReadFile());
            if ((N * tmp) % M == 1)
            {
                N1 = tmp;
                textBox5.ForeColor = Color.Green;
            }
            else
            {
                textBox5.ForeColor = Color.Red;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string[] numberStrings = textBox6.Text.Split(' ');
            var tmp = new List<int>();
            bool flag = true;

            foreach (string numberString in numberStrings)
            {
                int number = int.Parse(numberString);
                tmp.Add(number);
            }

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i] != ((Sequence[i] * N) % M))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                OpenSequence = tmp;
                textBox6.ForeColor = Color.Green;
            }
            else
            {
                textBox6.ForeColor = Color.Red;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox6.Text = ReadFile();
            string[] numberStrings = textBox6.Text.Split(' ');
            var tmp = new List<int>();
            bool flag = true;

            foreach (string numberString in numberStrings)
            {
                int number = int.Parse(numberString);
                tmp.Add(number);
            }

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i] != ((Sequence[i] * N) % M))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                OpenSequence = tmp;
                textBox6.ForeColor = Color.Green;
            }
            else
            {
                textBox6.ForeColor = Color.Red;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Message.Length; i++)
            {
                richTextBox22.Text += Message[i];
                richTextBox22.Text += Environment.NewLine;
                richTextBox21.Text += letterCodes[Message[i]];
                richTextBox21.Text += Environment.NewLine;
                WeightsSums.Add(new List<int>());
            }
            DecryptedMessage = Message;
            for (int i = 0; i < Message.Length; i++)
            {
                if (letterCodes[Message[i]][0] == '1')
                {
                    richTextBox20.Text += Sequence[0].ToString();
                    richTextBox20.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox20.Text += "-";
                    richTextBox20.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][1] == '1')
                {
                    richTextBox19.Text += Sequence[1].ToString();
                    richTextBox19.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox19.Text += "-";
                    richTextBox19.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][2] == '1')
                {
                    richTextBox18.Text += Sequence[2].ToString();
                    richTextBox18.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox18.Text += "-";
                    richTextBox18.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][3] == '1')
                {
                    richTextBox17.Text += Sequence[3].ToString();
                    richTextBox17.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox17.Text += "-";
                    richTextBox17.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][4] == '1')
                {
                    richTextBox16.Text += Sequence[4].ToString();
                    richTextBox16.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox16.Text += "-";
                    richTextBox16.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][5] == '1')
                {
                    richTextBox15.Text += Sequence[5].ToString();
                    richTextBox15.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox15.Text += "-";
                    richTextBox15.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][6] == '1')
                {
                    richTextBox14.Text += Sequence[6].ToString();
                    richTextBox14.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox14.Text += "-";
                    richTextBox14.Text += Environment.NewLine;
                }

                if (letterCodes[Message[i]][7] == '1')
                {
                    richTextBox13.Text += Sequence[7].ToString();
                    richTextBox13.Text += Environment.NewLine;
                }
                else
                {
                    richTextBox13.Text += "-";
                    richTextBox13.Text += Environment.NewLine;
                }
            }
            

            for (int i = 0; i < Message.Length; i++)
            {
                richTextBox12.Text += C[i].ToString();
                richTextBox12.Text += Environment.NewLine;
            }

            for (int i = 0; i < Message.Length; i++)
            {
                A.Add((C[i] * N1) % M);
                richTextBox23.Text += A[i].ToString();
                richTextBox23.Text += Environment.NewLine;
            }

            textBox7.Text = DecryptedMessage;
        }
    }
}
