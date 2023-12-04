using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZKI_Lab2;
using ZKI_Labs;

namespace ZKI_Lab1
{
    public partial class Form5 : Form
    {
        public string PhrazeForEncrypt { get; set; } = String.Empty;
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<string> CryptSystem = new();
        public string MessageForEncrypt { get; set; } = String.Empty;
        public string FinalMessage { get; set; } = String.Empty;
        public char[,] FinalKey { get; set; }
        public string FinalEncrypted { get; set; } = String.Empty;
        public string FinalDecrypted { get; set; } = String.Empty;
        public string EncryptedMessage { get; set; } = String.Empty;
        public string CryptoSystemMessage { get; set; } = String.Empty;


        public Form5()
        {
            InitializeComponent();
            comboBox1.Items.Add("Lab1");
            comboBox1.Items.Add("Lab2");
            comboBox1.Items.Add("Lab3");
            comboBox1.Items.Add("Lab4");
        }

        public void SetCryptoSystem(string phrazeForCrypto)
        {
            StringBuilder cryptoSystemMessage = new StringBuilder();
            StringBuilder Rows = new StringBuilder();
            for (int i = 0; i < phrazeForCrypto.Length; i++)
            {
                cryptoSystemMessage.Append(phrazeForCrypto[i]);
                Rows.Append(phrazeForCrypto[i]);
                Rows.Append("\n");
            }

            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (phrazeForCrypto.IndexOf(Alphabet[i]) != -1) continue;
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

        public string EncryptVijer(string message)
        {
            string newKey = "";
            while (newKey.Length < MessageForEncrypt.Length)
            {
                newKey += PhrazeForEncrypt;
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            PhrazeForEncrypt = textBox9.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageForEncrypt = textBox8.Text;
            SetCryptoSystem(PhrazeForEncrypt);
            string s = EncryptVijer(MessageForEncrypt);
            for (int i = 0; i < s.Length; i++)
            {
                if (textBox10.Text.IndexOf(s[i]) == -1)
                {
                    textBox10.Text += s[i];
                }

            }
            int count = textBox10.Text.Length;
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (textBox10.Text.IndexOf(Alphabet[i]) == -1)
                {
                    textBox10.Text += Alphabet[i];
                    count++;
                    if (count % 6 == 0)
                    {
                        textBox10.Text += Environment.NewLine;
                    }
                }
            }
            textBox10.Text += ",. -";
            string tmp = textBox10.Text.Replace("\n", "").Replace("\r", "");
            int count2 = 0;
            FinalKey = new char[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    FinalKey[i, j] = tmp[count2];
                    count2++;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FinalMessage = textBox3.Text;
            if (FinalMessage.Length % 2 != 0)
            {
                MessageBox.Show("Нельзя нечётное кол-во символов");
                return;
            }
            int count = 0;
            int row, col;
            int row2, col2;
            for (int index = 0; index < FinalMessage.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (FinalKey[i, j] == FinalMessage[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }
                        if (FinalKey[i, j] == FinalMessage[index + 1])
                        {
                            if (row2 == -1 && col2 == -1)
                            {
                                row2 = i;
                                col2 = j;
                            }
                        }
                    }
                }
                if (row != row2 || col != col2)
                {
                    if (row == row2)
                    {
                        if (col == 5)
                        {
                            FinalEncrypted += FinalKey[row2, 0];
                            FinalEncrypted += FinalKey[row, col2 + 1];
                        }
                        else if (col2 == 5)
                        {
                            FinalEncrypted += FinalKey[row2, col + 1];
                            FinalEncrypted += FinalKey[row, 0];
                        }
                        else
                        {
                            FinalEncrypted += FinalKey[row2, col + 1];
                            FinalEncrypted += FinalKey[row, col2 + 1];
                        }
                    }
                    else if (col == col2)
                    {
                        if (row == 4)
                        {
                            FinalEncrypted += FinalKey[0, col2];
                            FinalEncrypted += FinalKey[row2 + 1, col];
                        }
                        else if (row2 == 4)
                        {
                            FinalEncrypted += FinalKey[row + 1, col2];
                            FinalEncrypted += FinalKey[0, col];
                        }
                        else
                        {
                            FinalEncrypted += FinalKey[row + 1, col2];
                            FinalEncrypted += FinalKey[row2 + 1, col];
                        }
                    }
                    else
                    {
                        FinalEncrypted += FinalKey[row, col2];
                        FinalEncrypted += FinalKey[row2, col];
                    }

                }
                else
                {
                    FinalEncrypted += FinalKey[row, col2];
                    FinalEncrypted += FinalKey[row2, col];
                }
            }
            textBox4.Text = FinalEncrypted;
            FinalEncrypted = String.Empty;
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

        private void button4_Click(object sender, EventArgs e)
        {
            FinalMessage = textBox3.Text;
            int count = 0;
            int row, col;
            int row2, col2;
            for (int index = 0; index < FinalMessage.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (FinalKey[i, j] == FinalMessage[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }
                        if (FinalKey[i, j] == FinalMessage[index + 1])
                        {
                            if (row2 == -1 && col2 == -1)
                            {
                                row2 = i;
                                col2 = j;
                            }
                        }
                    }
                }
                if (row != row2 || col != col2)
                {
                    if (row == row2)
                    {
                        if (col == 0)
                        {
                            FinalDecrypted += FinalKey[row2, 5];
                            FinalDecrypted += FinalKey[row, col2 - 1];
                        }
                        else if (col2 == 0)
                        {
                            FinalDecrypted += FinalKey[row2, col - 1];
                            FinalDecrypted += FinalKey[row, 5];
                        }
                        else
                        {
                            FinalDecrypted += FinalKey[row2, col - 1];
                            FinalDecrypted += FinalKey[row, col2 - 1];
                        }
                    }
                    else if (col == col2)
                    {
                        if (row == 0)
                        {
                            FinalDecrypted += FinalKey[4, col2];
                            FinalDecrypted += FinalKey[row2 - 1, col];
                        }
                        else if (row2 == 0)
                        {
                            FinalDecrypted += FinalKey[row - 1, col2];
                            FinalDecrypted += FinalKey[4, col];
                        }
                        else
                        {
                            FinalDecrypted += FinalKey[row - 1, col2];
                            FinalDecrypted += FinalKey[row2 - 1, col];
                        }
                    }
                    else
                    {
                        FinalDecrypted += FinalKey[row, col2];
                        FinalDecrypted += FinalKey[row2, col];
                    }

                }
                else
                {
                    FinalDecrypted += FinalKey[row, col2];
                    FinalDecrypted += FinalKey[row2, col];
                }
            }
            textBox4.Text = FinalDecrypted;
            FinalDecrypted = String.Empty;
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
                case "Lab4":
                    Form4 form4 = new Form4();
                    this.Hide();
                    form4.Show();
                    break;
            }
        }
    }
}
