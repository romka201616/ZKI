using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZKI_Lab1
{
    public partial class Form7 : Form
    {
        private Random random;
        private System.Windows.Forms.Timer timer; // Явно указываем использование System.Windows.Forms.Timer

        public int CezarKey { get; set; }
        public string CezarPhraze { get; set; } = String.Empty;
        public string CezarEncrypted { get; set; } = String.Empty;
        public int[] NumeralAlphabet { get; set; }
        public int[] Gamma { get; set; }
        public int[] DivisionRemainder { get; set; }
        public string Encrypted { get; set; } = String.Empty;
        public string Decrypted { get; set; } = String.Empty;
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";

        public Form7()
        {
            InitializeComponent();
            random = new Random();
            timer = new System.Windows.Forms.Timer(); // Явно создаем объект System.Windows.Forms.Timer
            timer.Interval = 500; // Интервал в миллисекундах (500 мс = 0,5 секунды)
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EncryptGamma();


        }

        public string EncryptCezar()
        {
            StringBuilder encryptMessage = new StringBuilder();
            for (int i = 0; i < CezarPhraze.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    int index = j + CezarKey;

                    if (index > Alphabet.Length)
                        index -= Alphabet.Length;

                    if (CezarPhraze[i] == Alphabet[j])
                        encryptMessage.Append(Alphabet[index]);
                }
            }
            CezarEncrypted = encryptMessage.ToString();
            return encryptMessage.ToString();
        }

        public string DecryptCezar()
        {
            StringBuilder decryptedMessage = new StringBuilder();
            for (int i = 0; i < CezarPhraze.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    int index = j - CezarKey;

                    if (index < 0)
                        index += Alphabet.Length;

                    if (CezarPhraze[i] == Alphabet[j])
                        decryptedMessage.Append(Alphabet[index]);
                }
            }
            Decrypted = decryptedMessage.ToString();
            
            return decryptedMessage.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CezarPhraze = textBox1.Text;
            CezarKey = int.Parse(textBox5.Text);
            textBox3.Text = EncryptCezar();

            StringBuilder numeralAlphabet = new StringBuilder();
            NumeralAlphabet = new int[CezarEncrypted.Length];

            for (int i = 0; i < CezarEncrypted.Length; i++)
            {
                NumeralAlphabet[i] = Alphabet.IndexOf(CezarEncrypted[i]);
                numeralAlphabet.Append(NumeralAlphabet[i].ToString());
                numeralAlphabet.Append(" ");
            }

            numeralAlphabet.Remove(numeralAlphabet.Length - 1, 1);
            textBox6.Text = numeralAlphabet.ToString();

            Gamma = new int[CezarEncrypted.Length];
            DivisionRemainder = new int[CezarEncrypted.Length];

            timer.Start();
        }

        public void EncryptGamma()
        {
            StringBuilder gamma = new StringBuilder();
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < Gamma.Length; i++)
            {
                Gamma[i] = random.Next(1, 37); // Генерация случайного числа от 1 до 36
                gamma.Append(Gamma[i].ToString());
                gamma.Append(" ");

                DivisionRemainder[i] = (NumeralAlphabet[i] + Gamma[i]) % Alphabet.Length;
                encrypted.Append(Alphabet[DivisionRemainder[i]]);
            }

            gamma.Remove(gamma.Length - 1, 1);
            textBox2.Text = gamma.ToString();

            textBox4.Text = encrypted.ToString();

            Encrypted = encrypted.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SaveToFile(DivisionRemainder.ToString() + " " + Gamma.ToString() + " " + CezarPhraze.ToString() + " " + CezarKey.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = ReadFile();

            NumeralAlphabet = new int[DivisionRemainder.Length];
            CezarPhraze = "";
            for (int i = 0; i < DivisionRemainder.Length; i++)
            {
                NumeralAlphabet[i] = (DivisionRemainder[i] + Alphabet.Length - Gamma[i]) % Alphabet.Length;
                CezarPhraze += Alphabet[NumeralAlphabet[i]];
            }

            textBox7.Text = DecryptCezar();

        }
    }
}
