using System.Windows.Forms;
using ZKI_Lab1;
using ZKI_Labs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZKI_Lab2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Lab1");
            comboBox1.Items.Add("Lab3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 4 9 2
            // 3 5 7
            // 8 1 6

            string text = textBox1.Text;
            text = text.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            while (text.Length != 9)
            {
                text += " ";
            }
            List<int> list = new List<int>() { 3, 8, 1, 2, 4, 6, 7, 0, 5 };

            string text2 = "";
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                count++;
                text2 += text[list[i]];
                textBox2.Text += text[list[i]];
                if (count % 3 == 0)
                {
                    textBox2.Text += Environment.NewLine;
                }
            }
            File.WriteAllText("array.txt", textBox2.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            //textBox3.Text = fileText;

            List<int> oldList = new List<int>() { 3, 8, 1, 2, 4, 6, 7, 0, 5 };
            List<int> list = new List<int>();
            int index = 0;
            for (int i = 0; i < oldList.Count; i++)
            {
                if (oldList[i] == index)
                {
                    list.Add(i);
                    i = -1;
                    index++;
                }
                if (list.Count == 9)
                {
                    break;
                }
            }

            //List<int> list = new List<int>() { 7, 2, 3, 0, 4, 8, 5, 6, 1 };

            string text = textBox2.Text;
            text = text.Replace("\n", "").Replace("\r", "");

            string text2 = "";
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                count++;
                text2 += text[list[i]];
                textBox3.Text += text[list[i]];
                if (count % 3 == 0)
                {
                    textBox3.Text += Environment.NewLine;
                }
            }
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

                case "Lab3":
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.Show();
                    break;
            }
        }
    }
}