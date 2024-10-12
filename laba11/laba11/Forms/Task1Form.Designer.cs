namespace laba11.Forms
{
    partial class Task1Form
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(830, 12);
            button1.Name = "button1";
            button1.Size = new Size(102, 59);
            button1.TabIndex = 0;
            button1.Text = "Вернуться к списку заданий";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(325, 136);
            label1.Name = "label1";
            label1.Size = new Size(295, 20);
            label1.TabIndex = 1;
            label1.Text = "Введите выражение в инфискной форме";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(388, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(431, 238);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 3;
            label2.Text = "Ошибка";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(422, 314);
            button2.Name = "button2";
            button2.Size = new Size(100, 48);
            button2.TabIndex = 4;
            button2.Text = "Ввести";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(226, 136);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 5;
            label3.Text = "Операнды";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(703, 136);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 6;
            label4.Text = "Операторы";
            // 
            // Task1Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 501);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(960, 540);
            Name = "Task1Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task1Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button button2;
        private Label label3;
        private Label label4;
    }
}