using System.Windows.Forms;
using ZKI_Lab2;
using ZKI_Labs;

namespace ZKI_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Lab2");
            comboBox1.Items.Add("Lab3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ключ столбцов: 4321, Ключ строк: 2341
            var colOrder = new int[] { 3, 2, 1, 0 };
            var rowOrder = new int[] { 1, 2, 3, 0 };
            int col = 4;
            int row = 4;
            string text = textBox1.Text;
            var array = new char[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    array[i, j] = ' ';
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                array[i / row, i % row] = text[i];
            }
            char[,] arrayCop = array.Clone() as char[,];

            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    array[i, colOrder[j]] = arrayCop[i, j];
                }
            }
            arrayCop = array.Clone() as char[,];

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    textBox2.Text += ($"{array[i, j]} ");
                }
                textBox2.Text += Environment.NewLine;
            }

            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    array[rowOrder[j], i] = arrayCop[j, i];
                }
            }

            textBox1.Clear();
            text = "";
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    textBox1.Text += ($"{array[i, j]} ");
                    text += array[i, j];
                }

                textBox1.Text += Environment.NewLine;
            }

            File.WriteAllText("array.txt", text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox3.Text = fileText;

            //Столбцы: 4321, Строки: 2341
            var colOrder = new int[] { 3, 2, 1, 0 };
            var rowOrder = new int[] { 1, 2, 3, 0 };
            int col = 4;
            int row = 4;
            string text = textBox3.Text;
            var array = new char[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    array[i, j] = ' ';
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                array[i / row, i % row] = text[i];
            }
            char[,] arrayCop = array.Clone() as char[,];

            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    arrayCop[i, j] = array[i, colOrder[j]];
                }
            }
            array = arrayCop.Clone() as char[,];

            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    arrayCop[j, i] = array[rowOrder[j], i];
                }
            }

            textBox4.Clear();
            text = "";
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    textBox4.Text += ($"{arrayCop[i, j]}");
                    text += arrayCop[i, j];
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
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