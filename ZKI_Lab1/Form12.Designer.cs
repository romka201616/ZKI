namespace ZKI_Lab1
{
    partial class Form12
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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(159, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(320, 32);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(159, 183);
            button1.Name = "button1";
            button1.Size = new Size(107, 39);
            button1.TabIndex = 1;
            button1.Text = "Зашифровать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form12
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form12";
            Text = "Form12";
            Load += Form12_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
    }
}