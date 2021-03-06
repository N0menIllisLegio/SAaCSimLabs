﻿using System;
using System.Windows.Forms;

namespace SAaCSimLabs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Lab1Button_Click(object sender, EventArgs e)
        {
            Lab1.LabForm lab1Form = new Lab1.LabForm();
            lab1Form.ShowDialog(this);
        }

        private void Lab2Button_Click(object sender, EventArgs e)
        {
            Lab2.LabForm lab2Form = new Lab2.LabForm();
            lab2Form.ShowDialog(this);
        }

        private void Lab3Button_Click(object sender, EventArgs e)
        {
            Lab3.LabForm lab3Form = new Lab3.LabForm();
            lab3Form.ShowDialog(this);
        }

        private void Lab4Button_Click(object sender, EventArgs e)
        {
            Lab4.LabForm lab4Form = new Lab4.LabForm();
            lab4Form.ShowDialog(this);
        }
    }
}
