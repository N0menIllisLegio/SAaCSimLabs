namespace SAaCSimLabs.Lab1
{
    partial class LabForm
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
            this.components = new System.ComponentModel.Container();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.MultiplierInput = new System.Windows.Forms.NumericUpDown();
            this.RangeInput = new System.Windows.Forms.NumericUpDown();
            this.SeedInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumbersList = new System.Windows.Forms.ListBox();
            this.DisplayedNumbersLimiter = new System.Windows.Forms.CheckBox();
            this.StatusArea = new System.Windows.Forms.StatusStrip();
            this.GeneratingProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Plot = new ScottPlot.FormsPlot();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedInput)).BeginInit();
            this.StatusArea.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(32, 178);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(120, 23);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // CountInput
            // 
            this.CountInput.Location = new System.Drawing.Point(74, 22);
            this.CountInput.Maximum = new decimal(new int[] {
            25000000,
            0,
            0,
            0});
            this.CountInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.CountInput.Name = "CountInput";
            this.CountInput.Size = new System.Drawing.Size(120, 23);
            this.CountInput.TabIndex = 2;
            this.CountInput.ThousandsSeparator = true;
            this.CountInput.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // MultiplierInput
            // 
            this.MultiplierInput.Location = new System.Drawing.Point(74, 52);
            this.MultiplierInput.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.MultiplierInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MultiplierInput.Name = "MultiplierInput";
            this.MultiplierInput.Size = new System.Drawing.Size(120, 23);
            this.MultiplierInput.TabIndex = 3;
            this.MultiplierInput.ThousandsSeparator = true;
            this.MultiplierInput.Value = new decimal(new int[] {
            48271,
            0,
            0,
            0});
            // 
            // RangeInput
            // 
            this.RangeInput.Location = new System.Drawing.Point(75, 82);
            this.RangeInput.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.RangeInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RangeInput.Name = "RangeInput";
            this.RangeInput.Size = new System.Drawing.Size(120, 23);
            this.RangeInput.TabIndex = 4;
            this.RangeInput.ThousandsSeparator = true;
            this.RangeInput.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            // 
            // SeedInput
            // 
            this.SeedInput.Location = new System.Drawing.Point(74, 111);
            this.SeedInput.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.SeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeedInput.Name = "SeedInput";
            this.SeedInput.Size = new System.Drawing.Size(120, 23);
            this.SeedInput.TabIndex = 5;
            this.SeedInput.ThousandsSeparator = true;
            this.SeedInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Multiplier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Count";
            // 
            // NumbersList
            // 
            this.NumbersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NumbersList.FormattingEnabled = true;
            this.NumbersList.ItemHeight = 15;
            this.NumbersList.Location = new System.Drawing.Point(12, 229);
            this.NumbersList.Name = "NumbersList";
            this.NumbersList.Size = new System.Drawing.Size(405, 274);
            this.NumbersList.TabIndex = 10;
            // 
            // DisplayedNumbersLimiter
            // 
            this.DisplayedNumbersLimiter.AutoSize = true;
            this.DisplayedNumbersLimiter.Checked = true;
            this.DisplayedNumbersLimiter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayedNumbersLimiter.Location = new System.Drawing.Point(5, 140);
            this.DisplayedNumbersLimiter.Name = "DisplayedNumbersLimiter";
            this.DisplayedNumbersLimiter.Size = new System.Drawing.Size(175, 19);
            this.DisplayedNumbersLimiter.TabIndex = 12;
            this.DisplayedNumbersLimiter.Text = "Show only first 100 numbers";
            this.DisplayedNumbersLimiter.UseVisualStyleBackColor = true;
            // 
            // StatusArea
            // 
            this.StatusArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeneratingProgress,
            this.StatusLabel});
            this.StatusArea.Location = new System.Drawing.Point(0, 506);
            this.StatusArea.Name = "StatusArea";
            this.StatusArea.Size = new System.Drawing.Size(1004, 22);
            this.StatusArea.TabIndex = 14;
            // 
            // GeneratingProgress
            // 
            this.GeneratingProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.GeneratingProgress.Margin = new System.Windows.Forms.Padding(10, 3, 1, 3);
            this.GeneratingProgress.Name = "GeneratingProgress";
            this.GeneratingProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Plot
            // 
            this.Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot.Location = new System.Drawing.Point(425, 12);
            this.Plot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(566, 491);
            this.Plot.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CountInput);
            this.groupBox2.Controls.Add(this.GenerateButton);
            this.groupBox2.Controls.Add(this.MultiplierInput);
            this.groupBox2.Controls.Add(this.RangeInput);
            this.groupBox2.Controls.Add(this.DisplayedNumbersLimiter);
            this.groupBox2.Controls.Add(this.SeedInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 211);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(218, 12);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(199, 211);
            this.outputBox.TabIndex = 18;
            this.outputBox.Text = "";
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 528);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.StatusArea);
            this.Controls.Add(this.NumbersList);
            this.Name = "LabForm";
            this.Text = "Lab1";
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedInput)).EndInit();
            this.StatusArea.ResumeLayout(false);
            this.StatusArea.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.NumericUpDown CountInput;
        private System.Windows.Forms.NumericUpDown MultiplierInput;
        private System.Windows.Forms.NumericUpDown RangeInput;
        private System.Windows.Forms.NumericUpDown SeedInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox NumbersList;
        private System.Windows.Forms.CheckBox DisplayedNumbersLimiter;
        private System.Windows.Forms.StatusStrip StatusArea;
        private System.Windows.Forms.ToolStripProgressBar GeneratingProgress;
        private ScottPlot.FormsPlot Plot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.RichTextBox outputBox;
    }
}

