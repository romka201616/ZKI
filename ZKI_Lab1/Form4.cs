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
        Lab4 lab4 = new Lab4();
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lab4.CaesarKey = int.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab4.CaesarPhrase = textBox2.Text;
            lab4.CaesarEncryptedPhrase = lab4.Encipher(lab4.CaesarPhrase, lab4.CaesarKey);
            label6.Text = lab4.CaesarEncryptedPhrase;

            StringBuilder cryptoSystemMessage = new StringBuilder();
            for (int i = 0; i < lab4.CaesarEncryptedPhrase.Length; i++)
            {
                cryptoSystemMessage.Append(lab4.CaesarEncryptedPhrase[i]);
            }
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (lab4.CaesarEncryptedPhrase.IndexOf(alphabet[i]) != -1) continue;
            }
        }
    }
}
