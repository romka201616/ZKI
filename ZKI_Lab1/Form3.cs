using System.Net.Http.Headers;
using System.Windows.Forms;
using ZKI_Lab1;
using ZKI_Lab2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZKI_Labs
{
    public partial class Form3 : Form
    {
        private string[,] array;
        private List<string> list;

        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("Lab1");
            comboBox1.Items.Add("Lab2");
            list = new List<string>() { "D", "E", "B", "U", "G", "I", "N", "A", "C", "F", "H", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            array = new string[6, 6];
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = list[count];
                    count++;
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    textBox1.Text += array[i, j];
                }
                textBox1.Text += Environment.NewLine;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == text[count].ToString())
                    {
                        textBox3.Text += $"{i}{j}";
                        i = 0;
                        j = -1;
                        count++;
                    }
                    if (count == text.Length)
                    {
                        break;
                    }
                }
                if (count == text.Length)
                {
                    break;
                }
            }
            File.WriteAllText("array.txt", textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string text = System.IO.File.ReadAllText(filename);
            int count = 0;
            for (int i = 0; i < text.Length; i += 2)
            {
                textBox4.Text += array[int.Parse(text[i].ToString()), int.Parse(text[i + 1].ToString())];
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0 && !list.Contains(textBox2.Text[textBox2.TextLength - 1].ToString()))
            {
                textBox2.Clear();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
            }
        }
    }
}