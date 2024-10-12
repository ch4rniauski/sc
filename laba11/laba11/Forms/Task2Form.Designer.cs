namespace laba11.Forms
{
    partial class Task2Form
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(830, 12);
            button1.Name = "button1";
            button1.Size = new Size(102, 59);
            button1.TabIndex = 1;
            button1.Text = "Вернуться к списку заданий";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Task2Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 501);
            Controls.Add(button1);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(960, 540);
            Name = "Task2Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task2Form";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}