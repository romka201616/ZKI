namespace ZKI_Lab1
{
    partial class Form11
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(318, 32);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 178);
            button1.Name = "button1";
            button1.Size = new Size(159, 42);
            button1.TabIndex = 1;
            button1.Text = "Зашифровать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(355, 140);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(420, 32);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(100, 63);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 32);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(214, 63);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 32);
            textBox4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 45);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 5;
            label1.Text = "p";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 45);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 6;
            label2.Text = "q";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(355, 178);
            button2.Name = "button2";
            button2.Size = new Size(159, 42);
            button2.TabIndex = 7;
            button2.Text = "Расшифровать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 45);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 8;
            label3.Text = "e";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(430, 74);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(475, 74);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(475, 45);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 10;
            label6.Text = "d";
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form11";
            Text = "Form11";
            Load += Form11_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}