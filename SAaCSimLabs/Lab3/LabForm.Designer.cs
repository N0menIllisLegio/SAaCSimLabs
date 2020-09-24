namespace SAaCSimLabs.Lab3
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
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbabilitiesOutput = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProbabilitiesOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputBox.Location = new System.Drawing.Point(404, 57);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(384, 381);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "";
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(12, 12);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(114, 39);
            this.SimulateButton.TabIndex = 1;
            this.SimulateButton.Text = "Simulate";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // Number
            // 
            this.Number.FillWeight = 25.38071F;
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // State
            // 
            this.State.FillWeight = 112.3096F;
            this.State.HeaderText = "System State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Probability
            // 
            this.Probability.FillWeight = 112.3096F;
            this.Probability.HeaderText = "Probability";
            this.Probability.Name = "Probability";
            this.Probability.ReadOnly = true;
            this.Probability.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProbabilitiesOutput
            // 
            this.ProbabilitiesOutput.AllowUserToAddRows = false;
            this.ProbabilitiesOutput.AllowUserToDeleteRows = false;
            this.ProbabilitiesOutput.AllowUserToResizeRows = false;
            this.ProbabilitiesOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProbabilitiesOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProbabilitiesOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProbabilitiesOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.State,
            this.Probability});
            this.ProbabilitiesOutput.Location = new System.Drawing.Point(12, 57);
            this.ProbabilitiesOutput.MultiSelect = false;
            this.ProbabilitiesOutput.Name = "ProbabilitiesOutput";
            this.ProbabilitiesOutput.RowHeadersVisible = false;
            this.ProbabilitiesOutput.Size = new System.Drawing.Size(386, 381);
            this.ProbabilitiesOutput.TabIndex = 2;
            this.ProbabilitiesOutput.Text = "dataGridView1";
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProbabilitiesOutput);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.OutputBox);
            this.Name = "LabForm";
            this.Text = "LabForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProbabilitiesOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.DataGridView ProbabilitiesOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
    }
}