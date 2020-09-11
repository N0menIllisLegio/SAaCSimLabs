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
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputBox.Location = new System.Drawing.Point(13, 42);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(775, 396);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "";
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(12, 12);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(101, 23);
            this.SimulateButton.TabIndex = 1;
            this.SimulateButton.Text = "Simulate";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.OutputBox);
            this.Name = "LabForm";
            this.Text = "LabForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button SimulateButton;
    }
}