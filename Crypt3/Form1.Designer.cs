namespace Crypt3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            открытьФайлToolStripMenuItem = new ToolStripMenuItem();
            открытьАрхивToolStripMenuItem = new ToolStripMenuItem();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Сообщение";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 46);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(503, 92);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(521, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(366, 407);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(12, 459);
            button1.Name = "button1";
            button1.Size = new Size(499, 23);
            button1.TabIndex = 3;
            button1.Text = "Сжать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { открытьФайлToolStripMenuItem, открытьАрхивToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(898, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // открытьФайлToolStripMenuItem
            // 
            открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            открытьФайлToolStripMenuItem.Size = new Size(98, 20);
            открытьФайлToolStripMenuItem.Text = "Открыть файл";
            открытьФайлToolStripMenuItem.Click += открытьФайлToolStripMenuItem_Click;
            // 
            // открытьАрхивToolStripMenuItem
            // 
            открытьАрхивToolStripMenuItem.Name = "открытьАрхивToolStripMenuItem";
            открытьАрхивToolStripMenuItem.Size = new Size(101, 20);
            открытьАрхивToolStripMenuItem.Text = "Открыть архив";
            открытьАрхивToolStripMenuItem.Click += открытьАрхивToolStripMenuItem_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(12, 161);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(499, 175);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(14, 357);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(497, 96);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 143);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 7;
            label2.Text = "Сжатое";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 339);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 8;
            label3.Text = "Расжатое";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(521, 463);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 494);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private DataGridView dataGridView1;
        private Button button1;
        private MenuStrip menuStrip1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private Label label2;
        private Label label3;
        private ToolStripMenuItem открытьФайлToolStripMenuItem;
        private ToolStripMenuItem открытьАрхивToolStripMenuItem;
        private Label label4;
    }
}