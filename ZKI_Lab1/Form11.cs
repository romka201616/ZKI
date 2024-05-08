using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZKI_Lab1
{
    public partial class Form11 : Form
    {

        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int ModInverse(int a, int m)
        {
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1)
                    return x;
            return -1;
        }

        private static int ModPow(int a, int b, int n)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
                result = (result * a) % n;
            return result;
        }

        private bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
                if (number % i == 0)
                    return false;
            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = int.Parse(textBox3.Text);
            int q = int.Parse(textBox4.Text);
            string message = textBox1.Text;

            if (!IsPrime(p) || !IsPrime(q))
            {
                MessageBox.Show("p и q должны быть простыми.");
                return;
            }

            int n = p * q;
            int phi = (p - 1) * (q - 1);

            int e1 = 2;
            while (GCD(e1, phi) != 1)
                e1++;

            label4.Text = e1.ToString();

            byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(message);
            BigInteger[] messageValues = new BigInteger[messageBytes.Length];
            for (int i = 0; i < messageBytes.Length; i++)
                messageValues[i] = new BigInteger(messageBytes[i]);

            BigInteger[] encryptedValues = new BigInteger[messageValues.Length];
            for (int i = 0; i < messageValues.Length; i++)
                encryptedValues[i] = BigInteger.ModPow(messageValues[i], e1, n);

            string encryptedText = "";
            foreach (BigInteger value in encryptedValues)
                encryptedText += value.ToString() + " ";
            textBox2.Text = encryptedText;
            textBox1.Clear();



        }

        private void button2_Click(object sender, EventArgs e)
        {

            int p = int.Parse(textBox3.Text);
            int q = int.Parse(textBox4.Text);
            string encryptedText = textBox2.Text.Remove(textBox2.Text.Length - 1);



            int n = p * q;
            int phi = (p - 1) * (q - 1);

            int e1 = 2;
            while (GCD(e1, phi) != 1)
                e1++;

            int d = ModInverse(e1, phi);

            label4.Text = e1.ToString();
            label5.Text = d.ToString();

            string[] encryptedValuesString = encryptedText.Split(' ');
            BigInteger[] encryptedValues = new BigInteger[encryptedValuesString.Length];
            for (int i = 0; i < encryptedValuesString.Length; i++)
                encryptedValues[i] = BigInteger.Parse(encryptedValuesString[i]);

            BigInteger[] decryptedValues = new BigInteger[encryptedValues.Length];
            for (int i = 0; i < encryptedValues.Length; i++)
                decryptedValues[i] = BigInteger.ModPow(encryptedValues[i], d, n);

            byte[] decryptedBytes = new byte[decryptedValues.Length];
            for (int i = 0; i < decryptedValues.Length; i++)
                decryptedBytes[i] = (byte)decryptedValues[i];
            string decryptedMessage = System.Text.Encoding.ASCII.GetString(decryptedBytes);

            textBox1.Text = decryptedMessage;
        }
    }
}

