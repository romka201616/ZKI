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
    public partial class Form6 : Form
    {
        public string PhrazeForEncrypt { get; set; } = String.Empty;
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<string> CryptSystem = new();
        public string MessageForEncrypt { get; set; } = String.Empty;
        public string MessageForEncrypt2 { get; set; } = String.Empty;
        public string FinalMessage { get; set; } = String.Empty;
        public char[,] FinalKey { get; set; }
        public char[,] Array1 { get; set; }
        public char[,] Array2 { get; set; }
        public string FinalKey2 { get; set; } = String.Empty;
        public string FinalKey3 { get; set; } = String.Empty;
        public string FinalEncrypted { get; set; } = String.Empty;
        public string FinalDecrypted { get; set; } = String.Empty;
        public string EncryptedMessage { get; set; } = String.Empty;
        public string CryptoSystemMessage { get; set; } = String.Empty;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

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

        private void button9_Click(object sender, EventArgs e)
        {
            PhrazeForEncrypt = textBox9.Text;
            textBox10.Text += PhrazeForEncrypt;
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

        private void button8_Click(object sender, EventArgs e)
        {
            MessageForEncrypt = textBox8.Text;
            MessageForEncrypt2 = textBox1.Text;
            int count = 0;
            int row, col;
            int row2, col2;
            for (int index = 0; index < MessageForEncrypt.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (FinalKey[i, j] == MessageForEncrypt[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }
                        if (FinalKey[i, j] == MessageForEncrypt[index + 1])
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
                            FinalKey2 += FinalKey[row2, 0];
                            FinalKey2 += FinalKey[row, col2 + 1];
                        }
                        else if (col2 == 5)
                        {
                            FinalKey2 += FinalKey[row2, col + 1];
                            FinalKey2 += FinalKey[row, 0];
                        }
                        else
                        {
                            FinalKey2 += FinalKey[row2, col + 1];
                            FinalKey2 += FinalKey[row, col2 + 1];
                        }
                    }
                    else if (col == col2)
                    {
                        if (row == 4)
                        {
                            FinalKey2 += FinalKey[0, col2];
                            FinalKey2 += FinalKey[row2 + 1, col];
                        }
                        else if (row2 == 4)
                        {
                            FinalKey2 += FinalKey[row + 1, col2];
                            FinalKey2 += FinalKey[0, col];
                        }
                        else
                        {
                            FinalKey2 += FinalKey[row + 1, col2];
                            FinalKey2 += FinalKey[row2 + 1, col];
                        }
                    }
                    else
                    {
                        FinalKey2 += FinalKey[row, col2];
                        FinalKey2 += FinalKey[row2, col];
                    }

                }
                else
                {
                    FinalKey2 += FinalKey[row, col2];
                    FinalKey2 += FinalKey[row2, col];
                }
            }
            int count2 = FinalKey2.Length;
            textBox5.Text = FinalKey2;
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (textBox5.Text.IndexOf(Alphabet[i]) == -1)
                {
                    textBox5.Text += Alphabet[i];
                    count2++;
                    if (count2 % 5 == 0)
                    {
                        textBox5.Text += Environment.NewLine;
                    }
                }
            }
            textBox5.Text += ",. -";


            FinalKey3 = "";
            for (int index = 0; index < MessageForEncrypt2.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (FinalKey[i, j] == MessageForEncrypt2[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }
                        if (FinalKey[i, j] == MessageForEncrypt2[index + 1])
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
                            FinalKey3 += FinalKey[row2, 0];
                            FinalKey3 += FinalKey[row, col2 + 1];
                        }
                        else if (col2 == 5)
                        {
                            FinalKey3 += FinalKey[row2, col + 1];
                            FinalKey3 += FinalKey[row, 0];
                        }
                        else
                        {
                            FinalKey3 += FinalKey[row2, col + 1];
                            FinalKey3 += FinalKey[row, col2 + 1];
                        }
                    }
                    else if (col == col2)
                    {
                        if (row == 4)
                        {
                            FinalKey3 += FinalKey[0, col2];
                            FinalKey3 += FinalKey[row2 + 1, col];
                        }
                        else if (row2 == 4)
                        {
                            FinalKey3 += FinalKey[row + 1, col2];
                            FinalKey3 += FinalKey[0, col];
                        }
                        else
                        {
                            FinalKey3 += FinalKey[row + 1, col2];
                            FinalKey3 += FinalKey[row2 + 1, col];
                        }
                    }
                    else
                    {
                        FinalKey3 += FinalKey[row, col2];
                        FinalKey3 += FinalKey[row2, col];
                    }

                }
                else
                {
                    FinalKey3 += FinalKey[row, col2];
                    FinalKey3 += FinalKey[row2, col];
                }
            }
            count2 = FinalKey3.Length;
            textBox6.Text = FinalKey3;
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (textBox6.Text.IndexOf(Alphabet[i]) == -1)
                {
                    textBox6.Text += Alphabet[i];
                    count2++;
                    if (count2 % 5 == 0)
                    {
                        textBox6.Text += Environment.NewLine;
                    }
                }
            }
            textBox6.Text += ",. -";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageForEncrypt = textBox3.Text;
            FinalEncrypted = "";
            Array1 = new char[6, 5];
            string tmp = textBox5.Text.Replace("\n", "").Replace("\r", "");
            int tmpIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Array1[i, j] = tmp[tmpIndex];
                    tmpIndex++;
                }
            }


            Array2 = new char[6, 5];
            tmp = textBox6.Text.Replace("\n", "").Replace("\r", "");
            tmpIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Array2[i, j] = tmp[tmpIndex];
                    tmpIndex++;
                }
            }

            int count = 0;
            int row, col;
            int row2, col2;

            for (int index = 0; index < MessageForEncrypt.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (Array1[i, j] == MessageForEncrypt[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }

                        if (Array2[i, j] == MessageForEncrypt[index + 1])
                        {
                            if (row2 == -1 && col2 == -1)
                            {
                                row2 = i;
                                col2 = j;
                            }
                        }
                    }
                }

                if (row == row2 && col == col2)
                {
                    FinalEncrypted += Array2[row, col];
                    FinalEncrypted += Array1[row2, col2];
                }
                else
                {
                    if (row == row2 || col == col2)
                    {
                        FinalEncrypted += Array2[row, col];
                        FinalEncrypted += Array1[row2, col2];
                    }
                    else
                    {
                        FinalEncrypted += Array2[row, col2];
                        FinalEncrypted += Array1[row2, col];
                    }
                }
            }
            textBox4.Text = FinalEncrypted;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FinalEncrypted = textBox3.Text;
            FinalDecrypted = "";

            int count = 0;
            int row, col;
            int row2, col2;

            for (int index = 0; index < MessageForEncrypt.Length; index += 2)
            {
                row = -1;
                col = -1;
                row2 = -1;
                col2 = -1;

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (Array2[i, j] == FinalEncrypted[index])
                        {
                            if (row == -1 && col == -1)
                            {
                                row = i;
                                col = j;
                            }
                        }

                        if (Array1[i, j] == FinalEncrypted[index + 1])
                        {
                            if (row2 == -1 && col2 == -1)
                            {
                                row2 = i;
                                col2 = j;
                            }
                        }
                    }
                }

                if (row == row2 && col == col2)
                {
                    FinalDecrypted += Array1[row, col];
                    FinalDecrypted += Array2[row2, col2];
                }
                else
                {
                    if (row == row2 || col == col2)
                    {
                        FinalDecrypted += Array1[row, col];
                        FinalDecrypted += Array2[row2, col2];
                    }
                    else
                    {
                        FinalDecrypted += Array1[row, col2];
                        FinalDecrypted += Array2[row2, col];
                    }
                }
            }

            textBox4.Text = FinalDecrypted;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveToFile(textBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = ReadFile();
        }
    }
}
