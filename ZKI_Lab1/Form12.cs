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
using System.Numerics;
using System.Security.Cryptography;

namespace ZKI_Lab1
{
    public partial class Form12 : Form
    {
        int p;
        int q;
        int n;
        int phi;
        int ee;
        int d;
        RNGCryptoServiceProvider rng;

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            rng = new RNGCryptoServiceProvider();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = 61;
            q = 53;

            n = p * q;
            phi = (p - 1) * (q - 1);

            ee = GenerateCoprime(phi, rng);

 
            d = ModInverse(ee, phi);


            Console.WriteLine("Открытый ключ: ({0}, {1})", ee, n);

       
            Console.WriteLine("Закрытый ключ: {0}", d);

            string message = "Секретный текст";
            Console.WriteLine("Исходное сообщение: " + message);

      
            BigInteger encrypted = Encrypt(message, ee, n);
            Console.WriteLine("Зашифрованное сообщение: " + encrypted);

       
            string decrypted = Decrypt(encrypted, d, n);
            Console.WriteLine("Расшифрованное сообщение: " + decrypted);
        }

        static int GeneratePrime(RNGCryptoServiceProvider rng2, int bitLength)
        {
            byte[] bytes = new byte[bitLength / 8];
            BigInteger number;

            do
            {
                rng2.GetBytes(bytes);
                bytes[0] |= 0x80;
                bytes[bytes.Length - 1] |= 0x01;
                number = new BigInteger(bytes);
            }
            while (!IsProbablyPrime(rng2, number)); 

            return (int)number;
        }

        static bool IsProbablyPrime(RNGCryptoServiceProvider rng2, BigInteger number, int witnesses = 10)
        {
            if (number <= 1 || number % 2 == 0)
                return false;
            if (number <= 3)
                return true;

            BigInteger d = number - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            byte[] bytes = new byte[number.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    rng2.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= number - 2);

                BigInteger x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1)
                        return false;
                    if (x == number - 1)
                        break;
                }

                if (x != number - 1)
                    return false;
            }

            return true;
        }


        static int ModInverse(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {

                int q = a / m;
                int t = m;


                m = a % m;
                a = t;
                t = y;

                y = x - q * t;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

        static BigInteger Encrypt(string message, int e, int n)
        {

            return BigInteger.ModPow(BigInteger.Parse(message), e, n);
        }

        static string Decrypt(BigInteger encryptedMsg, int d, int n)
        {

            BigInteger decrypted = BigInteger.ModPow(encryptedMsg, d, n);
            return decrypted.ToString();
        }

        static int GenerateCoprime(int phi, RNGCryptoServiceProvider rng)
        {
            byte[] bytes = new byte[4];
            int e;

            do
            {
                rng.GetBytes(bytes);
                e = Math.Abs(BitConverter.ToInt32(bytes, 0));
                e %= (phi - 2);
                e += 2;
            }
            while (GCD(e, phi) != 1);

            return e;
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
