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
            correctionToolStripMenuItem = new ToolStripMenuItem();
            brightnessToolStripMenuItem = new ToolStripMenuItem();
            contrastToolStripMenuItem = new ToolStripMenuItem();
            gammaToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem1 = new ToolStripMenuItem();
            strechingToolStripMenuItem = new ToolStripMenuItem();
            equalizationToolStripMenuItem = new ToolStripMenuItem();
            convolutionToolStripMenuItem = new ToolStripMenuItem();
            gaussToolStripMenuItem = new ToolStripMenuItem();
            uniformBlurToolStripMenuItem = new ToolStripMenuItem();
            customKarnelToolStripMenuItem = new ToolStripMenuItem();
            transformationsToolStripMenuItem = new ToolStripMenuItem();
            robertsToolStripMenuItem = new ToolStripMenuItem();
            prewittaToolStripMenuItem = new ToolStripMenuItem();
            sobelToolStripMenuItem = new ToolStripMenuItem();
            laplaceToolStripMenuItem = new ToolStripMenuItem();
            cannyToolStripMenuItem = new ToolStripMenuItem();
            laplaceZeroToolStripMenuItem = new ToolStripMenuItem();
            tresholdingToolStripMenuItem = new ToolStripMenuItem();
            manulTresholdingToolStripMenuItem = new ToolStripMenuItem();
            iterativeThresholdingToolStripMenuItem = new ToolStripMenuItem();
            houghTransformForLinesToolStripMenuItem = new ToolStripMenuItem();
            watershedSegmentationToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            trackBarBrightness = new TrackBar();
            trackBarContrast = new TrackBar();
            trackBarGamma = new TrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            harrisAlgorythmToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGamma).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, negativeGreyScaleToolStripMenuItem, correctionToolStripMenuItem, histogramToolStripMenuItem, convolutionToolStripMenuItem, transformationsToolStripMenuItem, tresholdingToolStripMenuItem, houghTransformForLinesToolStripMenuItem, watershedSegmentationToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1358, 33);
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
            negativeToolStripMenuItem.Size = new Size(219, 34);
            negativeToolStripMenuItem.Text = "Negative";
            negativeToolStripMenuItem.Click += NegativeToolStripMenuItem_Click;
            // 
            // negativegreyToolStripMenuItem
            // 
            negativegreyToolStripMenuItem.Name = "negativegreyToolStripMenuItem";
            negativegreyToolStripMenuItem.Size = new Size(219, 34);
            negativegreyToolStripMenuItem.Text = "Negativegrey";
            negativegreyToolStripMenuItem.Click += NegativegreyToolStripMenuItem_Click;
            // 
            // greyScaleToolStripMenuItem
            // 
            greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            greyScaleToolStripMenuItem.Size = new Size(219, 34);
            greyScaleToolStripMenuItem.Text = "GreyScale";
            greyScaleToolStripMenuItem.Click += GreyScaleToolStripMenuItem_Click;
            // 
            // correctionToolStripMenuItem
            // 
            correctionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { brightnessToolStripMenuItem, contrastToolStripMenuItem, gammaToolStripMenuItem });
            correctionToolStripMenuItem.Name = "correctionToolStripMenuItem";
            correctionToolStripMenuItem.Size = new Size(107, 29);
            correctionToolStripMenuItem.Text = "correction";
            // 
            // brightnessToolStripMenuItem
            // 
            brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            brightnessToolStripMenuItem.Size = new Size(197, 34);
            brightnessToolStripMenuItem.Text = "brightness";
            brightnessToolStripMenuItem.Click += brightnessToolStripMenuItem_Click;
            // 
            // contrastToolStripMenuItem
            // 
            contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            contrastToolStripMenuItem.Size = new Size(197, 34);
            contrastToolStripMenuItem.Text = "contrast";
            contrastToolStripMenuItem.Click += contrastToolStripMenuItem_Click;
            // 
            // gammaToolStripMenuItem
            // 
            gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            gammaToolStripMenuItem.Size = new Size(197, 34);
            gammaToolStripMenuItem.Text = "gamma";
            gammaToolStripMenuItem.Click += gammaToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { histogramToolStripMenuItem1, strechingToolStripMenuItem, equalizationToolStripMenuItem });
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(109, 29);
            histogramToolStripMenuItem.Text = "histogram";
            // 
            // histogramToolStripMenuItem1
            // 
            histogramToolStripMenuItem1.Name = "histogramToolStripMenuItem1";
            histogramToolStripMenuItem1.Size = new Size(209, 34);
            histogramToolStripMenuItem1.Text = "histogram";
            histogramToolStripMenuItem1.Click += histogramToolStripMenuItem1_Click;
            // 
            // strechingToolStripMenuItem
            // 
            strechingToolStripMenuItem.Name = "strechingToolStripMenuItem";
            strechingToolStripMenuItem.Size = new Size(209, 34);
            strechingToolStripMenuItem.Text = "Streching";
            strechingToolStripMenuItem.Click += strechingToolStripMenuItem_Click;
            // 
            // equalizationToolStripMenuItem
            // 
            equalizationToolStripMenuItem.Name = "equalizationToolStripMenuItem";
            equalizationToolStripMenuItem.Size = new Size(209, 34);
            equalizationToolStripMenuItem.Text = "Equalization";
            equalizationToolStripMenuItem.Click += equalizationToolStripMenuItem_Click;
            // 
            // convolutionToolStripMenuItem
            // 
            convolutionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gaussToolStripMenuItem, uniformBlurToolStripMenuItem, customKarnelToolStripMenuItem });
            convolutionToolStripMenuItem.Name = "convolutionToolStripMenuItem";
            convolutionToolStripMenuItem.Size = new Size(125, 29);
            convolutionToolStripMenuItem.Text = "Convolution";
            // 
            // gaussToolStripMenuItem
            // 
            gaussToolStripMenuItem.Name = "gaussToolStripMenuItem";
            gaussToolStripMenuItem.Size = new Size(225, 34);
            gaussToolStripMenuItem.Text = "gauss";
            gaussToolStripMenuItem.Click += gaussToolStripMenuItem_Click;
            // 
            // uniformBlurToolStripMenuItem
            // 
            uniformBlurToolStripMenuItem.Name = "uniformBlurToolStripMenuItem";
            uniformBlurToolStripMenuItem.Size = new Size(225, 34);
            uniformBlurToolStripMenuItem.Text = "Uniform Blur";
            uniformBlurToolStripMenuItem.Click += uniformBlurToolStripMenuItem_Click;
            // 
            // customKarnelToolStripMenuItem
            // 
            customKarnelToolStripMenuItem.Name = "customKarnelToolStripMenuItem";
            customKarnelToolStripMenuItem.Size = new Size(225, 34);
            customKarnelToolStripMenuItem.Text = "custom karnel";
            customKarnelToolStripMenuItem.Click += customKarnelToolStripMenuItem_Click;
            // 
            // transformationsToolStripMenuItem
            // 
            transformationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { robertsToolStripMenuItem, prewittaToolStripMenuItem, sobelToolStripMenuItem, laplaceToolStripMenuItem, cannyToolStripMenuItem, laplaceZeroToolStripMenuItem });
            transformationsToolStripMenuItem.Name = "transformationsToolStripMenuItem";
            transformationsToolStripMenuItem.Size = new Size(155, 29);
            transformationsToolStripMenuItem.Text = "Transformations";
            // 
            // robertsToolStripMenuItem
            // 
            robertsToolStripMenuItem.Name = "robertsToolStripMenuItem";
            robertsToolStripMenuItem.Size = new Size(211, 34);
            robertsToolStripMenuItem.Text = "Roberts";
            robertsToolStripMenuItem.Click += robertsToolStripMenuItem_Click;
            // 
            // prewittaToolStripMenuItem
            // 
            prewittaToolStripMenuItem.Name = "prewittaToolStripMenuItem";
            prewittaToolStripMenuItem.Size = new Size(211, 34);
            prewittaToolStripMenuItem.Text = "Prewitta";
            prewittaToolStripMenuItem.Click += prewittaToolStripMenuItem_Click;
            // 
            // sobelToolStripMenuItem
            // 
            sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            sobelToolStripMenuItem.Size = new Size(211, 34);
            sobelToolStripMenuItem.Text = "Sobel";
            sobelToolStripMenuItem.Click += sobelToolStripMenuItem_Click;
            // 
            // laplaceToolStripMenuItem
            // 
            laplaceToolStripMenuItem.Name = "laplaceToolStripMenuItem";
            laplaceToolStripMenuItem.Size = new Size(211, 34);
            laplaceToolStripMenuItem.Text = "Laplace";
            laplaceToolStripMenuItem.Click += laplaceToolStripMenuItem_Click;
            // 
            // cannyToolStripMenuItem
            // 
            cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            cannyToolStripMenuItem.Size = new Size(211, 34);
            cannyToolStripMenuItem.Text = "Canny";
            cannyToolStripMenuItem.Click += cannyToolStripMenuItem_Click;
            // 
            // laplaceZeroToolStripMenuItem
            // 
            laplaceZeroToolStripMenuItem.Name = "laplaceZeroToolStripMenuItem";
            laplaceZeroToolStripMenuItem.Size = new Size(211, 34);
            laplaceZeroToolStripMenuItem.Text = "Laplace zero";
            laplaceZeroToolStripMenuItem.Click += laplaceZeroToolStripMenuItem_Click;
            // 
            // tresholdingToolStripMenuItem
            // 
            tresholdingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manulTresholdingToolStripMenuItem, iterativeThresholdingToolStripMenuItem });
            tresholdingToolStripMenuItem.Name = "tresholdingToolStripMenuItem";
            tresholdingToolStripMenuItem.Size = new Size(119, 29);
            tresholdingToolStripMenuItem.Text = "Tresholding";
            // 
            // manulTresholdingToolStripMenuItem
            // 
            manulTresholdingToolStripMenuItem.Name = "manulTresholdingToolStripMenuItem";
            manulTresholdingToolStripMenuItem.Size = new Size(280, 34);
            manulTresholdingToolStripMenuItem.Text = "Manul Tresholding";
            manulTresholdingToolStripMenuItem.Click += manulTresholdingToolStripMenuItem_Click;
            // 
            // iterativeThresholdingToolStripMenuItem
            // 
            iterativeThresholdingToolStripMenuItem.Name = "iterativeThresholdingToolStripMenuItem";
            iterativeThresholdingToolStripMenuItem.Size = new Size(280, 34);
            iterativeThresholdingToolStripMenuItem.Text = "IterativeThresholding";
            iterativeThresholdingToolStripMenuItem.Click += iterativeThresholdingToolStripMenuItem_Click;
            // 
            // houghTransformForLinesToolStripMenuItem
            // 
            houghTransformForLinesToolStripMenuItem.Name = "houghTransformForLinesToolStripMenuItem";
            houghTransformForLinesToolStripMenuItem.Size = new Size(235, 29);
            houghTransformForLinesToolStripMenuItem.Text = "Hough Transform for lines";
            houghTransformForLinesToolStripMenuItem.Click += houghTransformForLinesToolStripMenuItem_Click;
            // 
            // watershedSegmentationToolStripMenuItem
            // 
            watershedSegmentationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { harrisAlgorythmToolStripMenuItem });
            watershedSegmentationToolStripMenuItem.Name = "watershedSegmentationToolStripMenuItem";
            watershedSegmentationToolStripMenuItem.Size = new Size(191, 29);
            watershedSegmentationToolStripMenuItem.Text = "WatershedTransform";
            watershedSegmentationToolStripMenuItem.Click += watershedSegmentationToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(0, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(531, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(512, 512);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // trackBarBrightness
            // 
            trackBarBrightness.Location = new Point(1126, 90);
            trackBarBrightness.Name = "trackBarBrightness";
            trackBarBrightness.Size = new Size(156, 69);
            trackBarBrightness.TabIndex = 3;
            trackBarBrightness.Scroll += trackBar1_Scroll;
            // 
            // trackBarContrast
            // 
            trackBarContrast.Location = new Point(1126, 189);
            trackBarContrast.Name = "trackBarContrast";
            trackBarContrast.Size = new Size(156, 69);
            trackBarContrast.TabIndex = 4;
            trackBarContrast.Scroll += trackBar2_Scroll;
            // 
            // trackBarGamma
            // 
            trackBarGamma.Location = new Point(1126, 295);
            trackBarGamma.Name = "trackBarGamma";
            trackBarGamma.Size = new Size(156, 69);
            trackBarGamma.TabIndex = 5;
            trackBarGamma.Scroll += trackBar3_Scroll;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1132, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1126, 143);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1132, 247);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // harrisAlgorythmToolStripMenuItem
            // 
            harrisAlgorythmToolStripMenuItem.Name = "harrisAlgorythmToolStripMenuItem";
            harrisAlgorythmToolStripMenuItem.Size = new Size(270, 34);
            harrisAlgorythmToolStripMenuItem.Text = "Harris algorythm";
            harrisAlgorythmToolStripMenuItem.Click += harrisAlgorythmToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1358, 861);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(trackBarGamma);
            Controls.Add(trackBarContrast);
            Controls.Add(trackBarBrightness);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGamma).EndInit();
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
        private ToolStripMenuItem correctionToolStripMenuItem;
        private ToolStripMenuItem brightnessToolStripMenuItem;
        private ToolStripMenuItem contrastToolStripMenuItem;
        private ToolStripMenuItem gammaToolStripMenuItem;
        private PictureBox pictureBox2;
        private TrackBar trackBarBrightness;
        private TrackBar trackBarContrast;
        private TrackBar trackBarGamma;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem strechingToolStripMenuItem;
        private ToolStripMenuItem equalizationToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem1;
        private ToolStripMenuItem convolutionToolStripMenuItem;
        private ToolStripMenuItem gaussToolStripMenuItem;
        private ToolStripMenuItem uniformBlurToolStripMenuItem;
        private ToolStripMenuItem customKarnelToolStripMenuItem;
        private ToolStripMenuItem transformationsToolStripMenuItem;
        private ToolStripMenuItem robertsToolStripMenuItem;
        private ToolStripMenuItem prewittaToolStripMenuItem;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem laplaceToolStripMenuItem;
        private ToolStripMenuItem cannyToolStripMenuItem;
        private ToolStripMenuItem laplaceZeroToolStripMenuItem;
        private ToolStripMenuItem tresholdingToolStripMenuItem;
        private ToolStripMenuItem manulTresholdingToolStripMenuItem;
        private ToolStripMenuItem iterativeThresholdingToolStripMenuItem;
        private ToolStripMenuItem houghTransformForLinesToolStripMenuItem;
        private ToolStripMenuItem watershedSegmentationToolStripMenuItem;
        private ToolStripMenuItem harrisAlgorythmToolStripMenuItem;
    }
}
