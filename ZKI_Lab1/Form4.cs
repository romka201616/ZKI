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

namespace ZKI_Lab1
{
    public partial class Form4 : Form
    {
        public int Key { get; set; }
        public string Fraza { get; set; }
        public string EncryptFraza { get; set; }

        public string Letters = "abcdefghijklmnopqrstuvwxyz";
        List<string> CryptSystem = new();
        public string MessageForEncrypt { get; set; }
        public string MessageForDencrypt { get; set; }
        public string EncryptMessage { get; set; }

        public string CryptoSystemMessage { get; set; }

        Lab4 lab4 = new Lab4();
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Form4()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty) return;
            Key = int.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty) return;
            Fraza = textBox2.Text;
            SetCryptoSystem(EncryptCezar());
        }

        public void SetCryptoSystem(string frazaCezar)
        {
            StringBuilder cryptoSystemMessage = new StringBuilder();
            StringBuilder Rows = new StringBuilder();
            for (int i = 0; i < frazaCezar.Length; i++)
            {
                cryptoSystemMessage.Append(frazaCezar[i]);
                Rows.Append(frazaCezar[i]);
                Rows.Append("\n");
            }

            for (int i = 0; i < Letters.Length; i++)
            {
                if (frazaCezar.IndexOf(Letters[i]) != -1) continue;
                cryptoSystemMessage.Append(Letters[i]);
                Rows.Append(Letters[i]);
                Rows.Append("\n");
            }

            txtColumns.Text = cryptoSystemMessage.ToString();
            txtRows.Text = Rows.ToString();

            CryptoSystemMessage = cryptoSystemMessage.ToString();
            for (int i = 0; i < 26; i++)
            {
                CryptSystem.Add(cryptoSystemMessage.ToString());
                txtCryptoSchem.Text += cryptoSystemMessage.ToString() + "\n";
                cryptoSystemMessage.Append(cryptoSystemMessage[0]);
                cryptoSystemMessage.Remove(0, 1);
            }
        }

        public string EncryptCezar()
        {
            StringBuilder encryptMessage = new StringBuilder();
            for (int i = 0; i < Fraza.Length; i++)
            {
                for (int j = 0; j < Letters.Length; j++)
                {
                    int index = j + Key;

                    if (index > Letters.Length)
                        index -= Letters.Length;

                    if (Fraza[i] == Letters[j])
                        encryptMessage.Append(Letters[index]);
                }
            }
            EncryptFraza = encryptMessage.ToString();
            return encryptMessage.ToString();
        }
    }
}
