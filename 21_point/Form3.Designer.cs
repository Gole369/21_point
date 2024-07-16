namespace _21_point
{
    partial class Form3
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(41, 24);
            label1.Name = "label1";
            label1.Size = new Size(217, 54);
            label1.TabIndex = 0;
            label1.Text = "Банк: 1000";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(41, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(253, 51);
            textBox1.TabIndex = 1;
            textBox1.Text = "10";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(41, 192);
            button1.Name = "button1";
            button1.Size = new Size(253, 60);
            button1.TabIndex = 2;
            button1.Text = "ПОСТАВИТЬ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(41, 78);
            label2.Name = "label2";
            label2.Size = new Size(253, 54);
            label2.TabIndex = 3;
            label2.Text = "Ваша ставка:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 274);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "СТАВКА";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
    }
}