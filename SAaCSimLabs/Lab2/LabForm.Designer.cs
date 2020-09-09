namespace SAaCSimLabs.Lab2
{
    partial class LabForm
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
            this.components = new System.ComponentModel.Container();
            this.Plot = new ScottPlot.FormsPlot();
            this.DistributionComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SeedInput = new System.Windows.Forms.NumericUpDown();
            this.RangeInput = new System.Windows.Forms.NumericUpDown();
            this.MultiplierInput = new System.Windows.Forms.NumericUpDown();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.TriangularMinCheckBox = new System.Windows.Forms.CheckBox();
            this.DisplayedNumbersLimiter = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Input3 = new System.Windows.Forms.NumericUpDown();
            this.Input2 = new System.Windows.Forms.NumericUpDown();
            this.Input1 = new System.Windows.Forms.NumericUpDown();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.GeneratingProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumbersList = new System.Windows.Forms.ListBox();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeedInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input1)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Plot
            // 
            this.Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot.Location = new System.Drawing.Point(417, 12);
            this.Plot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(604, 480);
            this.Plot.TabIndex = 0;
            // 
            // DistributionComboBox
            // 
            this.DistributionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DistributionComboBox.FormattingEnabled = true;
            this.DistributionComboBox.Items.AddRange(new object[] {
            "Uniform",
            "Gauss",
            "Exponential",
            "Gamma",
            "Triangular",
            "Simpson"});
            this.DistributionComboBox.Location = new System.Drawing.Point(84, 23);
            this.DistributionComboBox.Name = "DistributionComboBox";
            this.DistributionComboBox.Size = new System.Drawing.Size(116, 23);
            this.DistributionComboBox.TabIndex = 1;
            this.DistributionComboBox.SelectedValueChanged += new System.EventHandler(this.DistributionComboBox_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SeedInput);
            this.groupBox1.Controls.Add(this.RangeInput);
            this.groupBox1.Controls.Add(this.MultiplierInput);
            this.groupBox1.Controls.Add(this.CountInput);
            this.groupBox1.Controls.Add(this.GenerateButton);
            this.groupBox1.Controls.Add(this.TriangularMinCheckBox);
            this.groupBox1.Controls.Add(this.DisplayedNumbersLimiter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.Input3);
            this.groupBox1.Controls.Add(this.Input2);
            this.groupBox1.Controls.Add(this.Input1);
            this.groupBox1.Controls.Add(this.DistributionComboBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 392);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(6, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 2);
            this.label10.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(6, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 2);
            this.label9.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "R₀:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "m:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "α:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "n:";
            // 
            // SeedInput
            // 
            this.SeedInput.Location = new System.Drawing.Point(84, 143);
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
            this.SeedInput.Size = new System.Drawing.Size(115, 23);
            this.SeedInput.TabIndex = 14;
            this.SeedInput.ThousandsSeparator = true;
            this.SeedInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RangeInput
            // 
            this.RangeInput.Location = new System.Drawing.Point(84, 113);
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
            this.RangeInput.Size = new System.Drawing.Size(115, 23);
            this.RangeInput.TabIndex = 13;
            this.RangeInput.ThousandsSeparator = true;
            this.RangeInput.Value = new decimal(new int[] {
            700001,
            0,
            0,
            0});
            // 
            // MultiplierInput
            // 
            this.MultiplierInput.Location = new System.Drawing.Point(84, 83);
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
            this.MultiplierInput.Size = new System.Drawing.Size(116, 23);
            this.MultiplierInput.TabIndex = 12;
            this.MultiplierInput.ThousandsSeparator = true;
            this.MultiplierInput.Value = new decimal(new int[] {
            30001,
            0,
            0,
            0});
            // 
            // CountInput
            // 
            this.CountInput.Location = new System.Drawing.Point(84, 53);
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
            this.CountInput.Size = new System.Drawing.Size(116, 23);
            this.CountInput.TabIndex = 11;
            this.CountInput.ThousandsSeparator = true;
            this.CountInput.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(6, 354);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(193, 29);
            this.GenerateButton.TabIndex = 10;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // TriangularMinCheckBox
            // 
            this.TriangularMinCheckBox.AutoSize = true;
            this.TriangularMinCheckBox.Enabled = false;
            this.TriangularMinCheckBox.Location = new System.Drawing.Point(15, 282);
            this.TriangularMinCheckBox.Name = "TriangularMinCheckBox";
            this.TriangularMinCheckBox.Size = new System.Drawing.Size(47, 19);
            this.TriangularMinCheckBox.TabIndex = 9;
            this.TriangularMinCheckBox.Text = "Min";
            this.TriangularMinCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisplayedNumbersLimiter
            // 
            this.DisplayedNumbersLimiter.AutoSize = true;
            this.DisplayedNumbersLimiter.Checked = true;
            this.DisplayedNumbersLimiter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayedNumbersLimiter.Location = new System.Drawing.Point(15, 329);
            this.DisplayedNumbersLimiter.Name = "DisplayedNumbersLimiter";
            this.DisplayedNumbersLimiter.Size = new System.Drawing.Size(175, 19);
            this.DisplayedNumbersLimiter.TabIndex = 8;
            this.DisplayedNumbersLimiter.Text = "Show only first 100 numbers";
            this.DisplayedNumbersLimiter.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Distribution:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label3.Location = new System.Drawing.Point(6, 255);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(16, 15);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "c:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 225);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 15);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "label2";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 195);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 15);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "label1";
            // 
            // Input3
            // 
            this.Input3.Location = new System.Drawing.Point(84, 251);
            this.Input3.Name = "Input3";
            this.Input3.Size = new System.Drawing.Size(116, 23);
            this.Input3.TabIndex = 4;
            this.Input3.ThousandsSeparator = true;
            // 
            // Input2
            // 
            this.Input2.Location = new System.Drawing.Point(84, 222);
            this.Input2.Name = "Input2";
            this.Input2.Size = new System.Drawing.Size(116, 23);
            this.Input2.TabIndex = 3;
            this.Input2.ThousandsSeparator = true;
            // 
            // Input1
            // 
            this.Input1.Location = new System.Drawing.Point(84, 193);
            this.Input1.Name = "Input1";
            this.Input1.Size = new System.Drawing.Size(116, 23);
            this.Input1.TabIndex = 2;
            this.Input1.ThousandsSeparator = true;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeneratingProgress,
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 504);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1034, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // GeneratingProgress
            // 
            this.GeneratingProgress.Name = "GeneratingProgress";
            this.GeneratingProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // NumbersList
            // 
            this.NumbersList.FormattingEnabled = true;
            this.NumbersList.ItemHeight = 15;
            this.NumbersList.Location = new System.Drawing.Point(225, 20);
            this.NumbersList.Name = "NumbersList";
            this.NumbersList.Size = new System.Drawing.Size(185, 469);
            this.NumbersList.TabIndex = 4;
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputBox.Location = new System.Drawing.Point(13, 411);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(206, 81);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.Text = "";
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 526);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.NumbersList);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Plot);
            this.Name = "LabForm";
            this.Text = "Lab2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeedInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input1)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot Plot;
        private System.Windows.Forms.ComboBox DistributionComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripProgressBar GeneratingProgress;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ListBox NumbersList;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.CheckBox TriangularMinCheckBox;
        private System.Windows.Forms.CheckBox DisplayedNumbersLimiter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.NumericUpDown Input3;
        private System.Windows.Forms.NumericUpDown Input2;
        private System.Windows.Forms.NumericUpDown Input1;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SeedInput;
        private System.Windows.Forms.NumericUpDown RangeInput;
        private System.Windows.Forms.NumericUpDown MultiplierInput;
        private System.Windows.Forms.NumericUpDown CountInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}