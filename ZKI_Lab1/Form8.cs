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
    public partial class Form8 : Form
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>()
        {
            { 29, 2 },
            { 31, 3 },
            { 37, 2 },
            { 41, 6 },
            { 43, 3 },
            { 47, 5 },
            { 53, 2 },
            { 59, 2 },
            { 61, 2 },
            { 67, 2 },
            { 71, 2 },
            { 73, 5 },
            { 79, 3 },
            { 83, 2 },
            { 89, 2 },

        };
        int[] keysArray;
        Random random = new Random();
        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string Message = String.Empty;
        public int[] M;
        public int G;
        public int P;
        public int X;
        public int Y;
        public int K;
        public BigInteger[] A;
        public BigInteger[] B;
        public string decrypted;

        public Form8()
        {
            InitializeComponent();
            keysArray = dictionary.Keys.ToArray();
            Alphabet = Alphabet.ToUpper();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        int GetSimpleNumber()
        {
            int randomIndex = random.Next(0, keysArray.Length);
            return keysArray[randomIndex];
        }

        int GetRelativelyPrimeNumber(int number)
        {
            int[] keys = dictionary.Keys.ToArray();
            List<int> relativelyPrimeNumbers = new List<int>();

            foreach (int key in keys)
            {
                if (GCD(number, key) == 1)
                {
                    relativelyPrimeNumbers.Add(key);
                }
            }

            if (relativelyPrimeNumbers.Count > 0)
            {
                int randomIndex = random.Next(0, relativelyPrimeNumbers.Count);
                while (relativelyPrimeNumbers[randomIndex] <= 1 || relativelyPrimeNumbers[randomIndex] >= P - 1)
                {
                    randomIndex = random.Next(0, relativelyPrimeNumbers.Count);
                }
                return relativelyPrimeNumbers[randomIndex];
            }

            return -1;
        }

        int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Message = textBox1.Text;
            A = new BigInteger[Message.Length];
            B = new BigInteger[Message.Length];
            M = new int[Message.Length];
            textBox9.Text = "";
            for (int i = 0; i < M.Length; i++)
            {
                M[i] = Alphabet.IndexOf(Message[i]);
                textBox9.Text += M[i] + " ";
            }
            P = GetSimpleNumber();
            //P = 53;
            textBox2.Text = P.ToString();
            G = dictionary[P];
            //G = 2;
            textBox3.Text = G.ToString();
            X = random.Next(0, P);
            //X = 5;
            textBox4.Text = X.ToString();
            Y = (int)Math.Pow(G, X) % P;
            textBox5.Text = Y.ToString();
            K = GetRelativelyPrimeNumber(P - 1);
            //K = 31;
            textBox6.Text = K.ToString();
            textBox7.Text = "";
            textBox8.Text = "";
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = (BigInteger)Math.Pow(G, K) % P;
                textBox7.Text += A[i] + " ";
                B[i] = ((BigInteger)Math.Pow(Y, K) * M[i]) % P;
                textBox8.Text += B[i] + " ";
            }

            SaveToFile("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadFile();
            decrypted = "";
            //for (int i = 0; i < Message.Length; i++)
            //{
            //    decrypted += (int)(((B[i] * (BigInteger)Math.Pow((int)A[i], P - 1 - X)) % P));
            //}
            textBox10.Text = "";
            for (int i = 0; i < M.Length; i++)
            {
                textBox10.Text += M[i] + " ";
            }
            textBox11.Text = Message;
        }
    }
}
