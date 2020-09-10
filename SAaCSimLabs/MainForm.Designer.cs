namespace SAaCSimLabs
{
    partial class MainForm
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
            this.Lab1Button = new System.Windows.Forms.Button();
            this.Lab2Button = new System.Windows.Forms.Button();
            this.Lab3Button = new System.Windows.Forms.Button();
            this.Lab4Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lab1Button
            // 
            this.Lab1Button.Location = new System.Drawing.Point(12, 12);
            this.Lab1Button.Name = "Lab1Button";
            this.Lab1Button.Size = new System.Drawing.Size(170, 40);
            this.Lab1Button.TabIndex = 0;
            this.Lab1Button.Text = "Laboratory Work №1";
            this.Lab1Button.UseVisualStyleBackColor = true;
            this.Lab1Button.Click += new System.EventHandler(this.Lab1Button_Click);
            // 
            // Lab2Button
            // 
            this.Lab2Button.Location = new System.Drawing.Point(13, 58);
            this.Lab2Button.Name = "Lab2Button";
            this.Lab2Button.Size = new System.Drawing.Size(170, 40);
            this.Lab2Button.TabIndex = 1;
            this.Lab2Button.Text = "Laboratory Work №2";
            this.Lab2Button.UseVisualStyleBackColor = true;
            this.Lab2Button.Click += new System.EventHandler(this.Lab2Button_Click);
            // 
            // Lab3Button
            // 
            this.Lab3Button.Location = new System.Drawing.Point(12, 105);
            this.Lab3Button.Name = "Lab3Button";
            this.Lab3Button.Size = new System.Drawing.Size(170, 40);
            this.Lab3Button.TabIndex = 2;
            this.Lab3Button.Text = "Laboratory Work №3";
            this.Lab3Button.UseVisualStyleBackColor = true;
            this.Lab3Button.Click += new System.EventHandler(this.Lab3Button_Click);
            // 
            // Lab4Button
            // 
            this.Lab4Button.Enabled = false;
            this.Lab4Button.Location = new System.Drawing.Point(12, 151);
            this.Lab4Button.Name = "Lab4Button";
            this.Lab4Button.Size = new System.Drawing.Size(170, 40);
            this.Lab4Button.TabIndex = 3;
            this.Lab4Button.Text = "Laboratory Work №4";
            this.Lab4Button.UseVisualStyleBackColor = true;
            this.Lab4Button.Click += new System.EventHandler(this.Lab4Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 207);
            this.Controls.Add(this.Lab4Button);
            this.Controls.Add(this.Lab3Button);
            this.Controls.Add(this.Lab2Button);
            this.Controls.Add(this.Lab1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lab1Button;
        private System.Windows.Forms.Button Lab2Button;
        private System.Windows.Forms.Button Lab3Button;
        private System.Windows.Forms.Button Lab4Button;
    }
}