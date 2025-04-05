namespace obraz
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
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            negativeGreyScaleToolStripMenuItem = new ToolStripMenuItem();
            negativeToolStripMenuItem = new ToolStripMenuItem();
            negativegreyToolStripMenuItem = new ToolStripMenuItem();
            greyScaleToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, negativeGreyScaleToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(51, 29);
            fileToolStripMenuItem.Text = "file";
            fileToolStripMenuItem.Click += FileToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(149, 34);
            saveToolStripMenuItem.Text = "save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(149, 34);
            loadToolStripMenuItem.Text = "load";
            loadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // negativeGreyScaleToolStripMenuItem
            // 
            negativeGreyScaleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { negativeToolStripMenuItem, negativegreyToolStripMenuItem, greyScaleToolStripMenuItem });
            negativeGreyScaleToolStripMenuItem.Name = "negativeGreyScaleToolStripMenuItem";
            negativeGreyScaleToolStripMenuItem.Size = new Size(181, 29);
            negativeGreyScaleToolStripMenuItem.Text = "Negative/GreyScale";
            // 
            // negativeToolStripMenuItem
            // 
            negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            negativeToolStripMenuItem.Size = new Size(270, 34);
            negativeToolStripMenuItem.Text = "Negative";
            negativeToolStripMenuItem.Click += NegativeToolStripMenuItem_Click;
            // 
            // negativegreyToolStripMenuItem
            // 
            negativegreyToolStripMenuItem.Name = "negativegreyToolStripMenuItem";
            negativegreyToolStripMenuItem.Size = new Size(270, 34);
            negativegreyToolStripMenuItem.Text = "Negativegrey";
            negativegreyToolStripMenuItem.Click += NegativegreyToolStripMenuItem_Click;
            // 
            // greyScaleToolStripMenuItem
            // 
            greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            greyScaleToolStripMenuItem.Size = new Size(270, 34);
            greyScaleToolStripMenuItem.Text = "GreyScale";
            greyScaleToolStripMenuItem.Click += GreyScaleToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 353);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem negativeGreyScaleToolStripMenuItem;
        private ToolStripMenuItem negativeToolStripMenuItem;
        private ToolStripMenuItem greyScaleToolStripMenuItem;
        private ToolStripMenuItem negativegreyToolStripMenuItem;
    }
}
