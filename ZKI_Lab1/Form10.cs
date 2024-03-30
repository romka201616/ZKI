using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.Xml;

namespace ZKI_Lab1
{
    public partial class Form10 : Form
    {
        DES des = new DESCryptoServiceProvider();
        byte[] encrypted;
        byte[] key;
        byte[] iv;

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
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

        public byte[] GetKeyFromPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                byte[] desKey = new byte[8];
                Array.Copy(passwordHash, desKey, 8);

                return desKey;
            }
        }

        public void EncryptMessage()
        {
            string message = textBox1.Text;

            key = GetKeyFromPassword(textBox3.Text);
            iv = des.IV;

            encrypted = EncryptStringToBytes_DES(message, key, iv);
            textBox2.Text = Convert.ToBase64String(encrypted);

            textBox1.Clear();
            textBox3.Clear();
        }

        public void DecryptMessage()
        {
            string decrypted;
            try
            {
                key = GetKeyFromPassword(textBox4.Text);
                decrypted = DecryptStringFromBytes_DES(encrypted, key, iv);

                textBox1.Text = decrypted;

                textBox2.Clear();
                textBox4.Clear();
            }
            catch
            {
                MessageBox.Show("Неправильный пароль");
            }
        }

        static byte[] EncryptStringToBytes_DES(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
            {
                desAlg.Key = Key;
                desAlg.IV = IV;

                ICryptoTransform encryptor = desAlg.CreateEncryptor(desAlg.Key, desAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        static string DecryptStringFromBytes_DES(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
            {
                desAlg.Key = Key;
                desAlg.IV = IV;

                ICryptoTransform decryptor = desAlg.CreateDecryptor(desAlg.Key, desAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncryptMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DecryptMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = ReadFile();
            string[] words = text.Split(" ");
            textBox1.Text = words[0];
            textBox2.Text = words[1];
        }
    }
}
