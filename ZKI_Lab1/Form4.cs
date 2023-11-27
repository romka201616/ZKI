using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ZKI_Lab2;
using ZKI_Labs;

namespace ZKI_Lab1
{
    public partial class Form4 : Form
    {
        public int CezarKey { get; set; }
        public string CezarPhraze { get; set; } = String.Empty;
        public string CezarEncryptedPhraze { get; set; } = String.Empty;
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<string> CryptSystem = new();
        public string MessageForEncrypt { get; set; } = String.Empty;
        public string MessageForDecrypt { get; set; } = String.Empty;
        public string EncryptedMessage { get; set; } = String.Empty;
        public string CryptoSystemMessage { get; set; } = String.Empty;

        public Form4()
        {
            InitializeComponent();
            comboBox1.Items.Add("Lab1");
            comboBox1.Items.Add("Lab2");
            comboBox1.Items.Add("Lab3");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty) return;
            CezarKey = int.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty) return;
            CezarPhraze = textBox2.Text;
            SetCryptoSystem(EncryptCezar());
        }

        public void SetCryptoSystem(string phrazeCezar)
        {
            StringBuilder cryptoSystemMessage = new StringBuilder();
            StringBuilder Rows = new StringBuilder();
            for (int i = 0; i < phrazeCezar.Length; i++)
            {
                cryptoSystemMessage.Append(phrazeCezar[i]);
                Rows.Append(phrazeCezar[i]);
                Rows.Append("\n");
            }

            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (phrazeCezar.IndexOf(Alphabet[i]) != -1) continue;
                cryptoSystemMessage.Append(Alphabet[i]);
                Rows.Append(Alphabet[i]);
                Rows.Append("\n");
            }

            textBox6.Text = cryptoSystemMessage.ToString();
            textBox7.Text = Rows.ToString();

            CryptoSystemMessage = cryptoSystemMessage.ToString();
            for (int i = 0; i < 26; i++)
            {
                CryptSystem.Add(cryptoSystemMessage.ToString());
                textBox5.Text += cryptoSystemMessage.ToString() + "\n";
                cryptoSystemMessage.Append(cryptoSystemMessage[0]);
                cryptoSystemMessage.Remove(0, 1);
            }
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
            CezarEncryptedPhraze = encryptMessage.ToString();
            return encryptMessage.ToString();
        }

        public string EncryptVijer(string message)
        {
            string newKey = "";
            while (newKey.Length < MessageForEncrypt.Length)
            {
                newKey += CezarEncryptedPhraze;
            }
            label6.Text = newKey;
            StringBuilder encryptVijer = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                int rowIndex = CryptoSystemMessage.IndexOf(message[i]);
                int colIndex = CryptoSystemMessage.IndexOf(newKey[i]);
                encryptVijer.Append(CryptSystem[rowIndex][colIndex]);
            }
            return encryptVijer.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageForEncrypt = textBox3.Text;
            string encryptMessage = EncryptVijer(MessageForEncrypt);
            textBox4.Text = encryptMessage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageForDecrypt = textBox3.Text;
            string dencryptMessage = DencryptVijer(MessageForDecrypt);
            textBox4.Text = dencryptMessage;
        }

        private string DencryptVijer(string messageForDencrypt)
        {
            string newKey = "";
            while (newKey.Length < MessageForDecrypt.Length)
            {
                newKey += CezarEncryptedPhraze;
            }
            label6.Text = newKey;
            StringBuilder dencryptVijer = new StringBuilder();
            for (int i = 0; i < messageForDencrypt.Length; i++)
            {
                int colIndex = CryptoSystemMessage.IndexOf(newKey[i]);
                for (int j = 0; j < CryptSystem.Count; j++)
                {
                    if (messageForDencrypt[i] == CryptSystem[j][colIndex])
                    {
                        dencryptVijer.Append(CryptoSystemMessage[j]);
                        break;
                    }
                }
            }
            return dencryptVijer.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            SaveToFile(textBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = ReadFile();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Lab1":
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();
                    break;

                case "Lab2":
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                    break;
                case "Lab3":
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.Show();
                    break;
            }
        }
    }
}
