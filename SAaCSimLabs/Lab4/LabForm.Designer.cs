namespace SAaCSimLabs.Lab4
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
            this.Simulate = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.RequestsGrid = new System.Windows.Forms.DataGridView();
            this.Plot = new ScottPlot.FormsPlot();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lQueueSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbQueues = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.udQueueFee = new System.Windows.Forms.NumericUpDown();
            this.udQueueSize = new System.Windows.Forms.NumericUpDown();
            this.udChannelFee = new System.Windows.Forms.NumericUpDown();
            this.udChannels = new System.Windows.Forms.NumericUpDown();
            this.udRequestWorth = new System.Windows.Forms.NumericUpDown();
            this.udRequestProcessTime = new System.Windows.Forms.NumericUpDown();
            this.udRequestsPerHour = new System.Windows.Forms.NumericUpDown();
            this.udHours = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.RequestsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQueueFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQueueSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChannelFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestWorth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestProcessTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestsPerHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHours)).BeginInit();
            this.SuspendLayout();
            // 
            // Simulate
            // 
            this.Simulate.Location = new System.Drawing.Point(6, 374);
            this.Simulate.Name = "Simulate";
            this.Simulate.Size = new System.Drawing.Size(253, 54);
            this.Simulate.TabIndex = 0;
            this.Simulate.Text = "Simulate";
            this.Simulate.UseVisualStyleBackColor = true;
            this.Simulate.Click += new System.EventHandler(this.Simulate_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputBox.Location = new System.Drawing.Point(283, 20);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(416, 429);
            this.OutputBox.TabIndex = 1;
            this.OutputBox.Text = "";
            // 
            // RequestsGrid
            // 
            this.RequestsGrid.AllowUserToAddRows = false;
            this.RequestsGrid.AllowUserToDeleteRows = false;
            this.RequestsGrid.AllowUserToOrderColumns = true;
            this.RequestsGrid.AllowUserToResizeRows = false;
            this.RequestsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestsGrid.Location = new System.Drawing.Point(706, 12);
            this.RequestsGrid.Name = "RequestsGrid";
            this.RequestsGrid.ReadOnly = true;
            this.RequestsGrid.RowHeadersVisible = false;
            this.RequestsGrid.Size = new System.Drawing.Size(616, 440);
            this.RequestsGrid.TabIndex = 2;
            this.RequestsGrid.Text = "dataGridView1";
            this.RequestsGrid.Visible = false;
            // 
            // Plot
            // 
            this.Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot.Location = new System.Drawing.Point(706, 12);
            this.Plot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(618, 440);
            this.Plot.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hours:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "λ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "t:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Request worth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Channels:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Channel Fee:";
            // 
            // lQueueSize
            // 
            this.lQueueSize.AutoSize = true;
            this.lQueueSize.Location = new System.Drawing.Point(17, 200);
            this.lQueueSize.Name = "lQueueSize";
            this.lQueueSize.Size = new System.Drawing.Size(68, 15);
            this.lQueueSize.TabIndex = 5;
            this.lQueueSize.Text = "Queue Size:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Queue Fee:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.udQueueFee);
            this.groupBox1.Controls.Add(this.udQueueSize);
            this.groupBox1.Controls.Add(this.udChannelFee);
            this.groupBox1.Controls.Add(this.udChannels);
            this.groupBox1.Controls.Add(this.udRequestWorth);
            this.groupBox1.Controls.Add(this.udRequestProcessTime);
            this.groupBox1.Controls.Add(this.udRequestsPerHour);
            this.groupBox1.Controls.Add(this.udHours);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lQueueSize);
            this.groupBox1.Controls.Add(this.Simulate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 437);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbQueues);
            this.groupBox2.Controls.Add(this.rbCustom);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Location = new System.Drawing.Point(6, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 112);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modes";
            // 
            // rbQueues
            // 
            this.rbQueues.AutoSize = true;
            this.rbQueues.Location = new System.Drawing.Point(6, 53);
            this.rbQueues.Name = "rbQueues";
            this.rbQueues.Size = new System.Drawing.Size(65, 19);
            this.rbQueues.TabIndex = 8;
            this.rbQueues.Text = "Queues";
            this.rbQueues.UseVisualStyleBackColor = true;
            this.rbQueues.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(6, 78);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(67, 19);
            this.rbCustom.TabIndex = 8;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(7, 28);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(50, 19);
            this.rbAll.TabIndex = 8;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Total";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // udQueueFee
            // 
            this.udQueueFee.DecimalPlaces = 2;
            this.udQueueFee.Location = new System.Drawing.Point(149, 227);
            this.udQueueFee.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udQueueFee.Name = "udQueueFee";
            this.udQueueFee.Size = new System.Drawing.Size(110, 23);
            this.udQueueFee.TabIndex = 6;
            this.udQueueFee.ThousandsSeparator = true;
            this.udQueueFee.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // udQueueSize
            // 
            this.udQueueSize.Location = new System.Drawing.Point(149, 198);
            this.udQueueSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udQueueSize.Name = "udQueueSize";
            this.udQueueSize.Size = new System.Drawing.Size(110, 23);
            this.udQueueSize.TabIndex = 6;
            this.udQueueSize.ThousandsSeparator = true;
            // 
            // udChannelFee
            // 
            this.udChannelFee.DecimalPlaces = 2;
            this.udChannelFee.Location = new System.Drawing.Point(149, 169);
            this.udChannelFee.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udChannelFee.Name = "udChannelFee";
            this.udChannelFee.Size = new System.Drawing.Size(110, 23);
            this.udChannelFee.TabIndex = 6;
            this.udChannelFee.ThousandsSeparator = true;
            this.udChannelFee.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // udChannels
            // 
            this.udChannels.Location = new System.Drawing.Point(149, 140);
            this.udChannels.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udChannels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udChannels.Name = "udChannels";
            this.udChannels.Size = new System.Drawing.Size(110, 23);
            this.udChannels.TabIndex = 6;
            this.udChannels.ThousandsSeparator = true;
            this.udChannels.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // udRequestWorth
            // 
            this.udRequestWorth.DecimalPlaces = 2;
            this.udRequestWorth.Location = new System.Drawing.Point(149, 111);
            this.udRequestWorth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udRequestWorth.Name = "udRequestWorth";
            this.udRequestWorth.Size = new System.Drawing.Size(110, 23);
            this.udRequestWorth.TabIndex = 6;
            this.udRequestWorth.ThousandsSeparator = true;
            this.udRequestWorth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // udRequestProcessTime
            // 
            this.udRequestProcessTime.DecimalPlaces = 2;
            this.udRequestProcessTime.Location = new System.Drawing.Point(149, 82);
            this.udRequestProcessTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.udRequestProcessTime.Name = "udRequestProcessTime";
            this.udRequestProcessTime.Size = new System.Drawing.Size(110, 23);
            this.udRequestProcessTime.TabIndex = 6;
            this.udRequestProcessTime.ThousandsSeparator = true;
            this.udRequestProcessTime.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // udRequestsPerHour
            // 
            this.udRequestsPerHour.Location = new System.Drawing.Point(149, 53);
            this.udRequestsPerHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRequestsPerHour.Name = "udRequestsPerHour";
            this.udRequestsPerHour.Size = new System.Drawing.Size(110, 23);
            this.udRequestsPerHour.TabIndex = 6;
            this.udRequestsPerHour.ThousandsSeparator = true;
            this.udRequestsPerHour.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // udHours
            // 
            this.udHours.Location = new System.Drawing.Point(149, 23);
            this.udHours.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHours.Name = "udHours";
            this.udHours.Size = new System.Drawing.Size(110, 23);
            this.udHours.TabIndex = 6;
            this.udHours.ThousandsSeparator = true;
            this.udHours.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.RequestsGrid);
            this.Controls.Add(this.OutputBox);
            this.MinimumSize = new System.Drawing.Size(1350, 500);
            this.Name = "LabForm";
            this.Text = "Lab4";
            ((System.ComponentModel.ISupportInitialize)(this.RequestsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQueueFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQueueSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChannelFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestWorth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestProcessTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRequestsPerHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Simulate;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.DataGridView RequestsGrid;
        private ScottPlot.FormsPlot Plot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lQueueSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udQueueFee;
        private System.Windows.Forms.NumericUpDown udQueueSize;
        private System.Windows.Forms.NumericUpDown udChannelFee;
        private System.Windows.Forms.NumericUpDown udChannels;
        private System.Windows.Forms.NumericUpDown udRequestWorth;
        private System.Windows.Forms.NumericUpDown udRequestProcessTime;
        private System.Windows.Forms.NumericUpDown udRequestsPerHour;
        private System.Windows.Forms.NumericUpDown udHours;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbQueues;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

