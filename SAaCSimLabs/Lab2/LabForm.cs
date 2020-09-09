using System.Drawing;
using System.Windows.Forms;

namespace SAaCSimLabs.Lab2
{
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
            DistributionComboBox.SelectedIndex = 0;
            UniformDistributionInit();
        }

        private void GenerateButton_Click(object sender, System.EventArgs e)
        {

        }

        private void DistributionComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string distribution = comboBox?.SelectedItem.ToString();

            DisableAllInputs();

            switch (distribution)
            {
                case "Uniform":
                    UniformDistributionInit();
                    break;
                case "Gauss":
                    GaussDistributionInit();
                    break;
                case "Exponential":
                    ExponentialDistributionInit();
                    break;
                case "Gamma":
                    GammaDistributionInit();
                    break;
                case "Triangular":
                    TriangularDistributionInit();
                    break;
                case "Simpson":
                    SimpsonDistributionInit();
                    break;
            }
        }

        #region InputInitializers

        private void SetInputLabels(string label1, string label2 = null, string label3 = null)
        {
            Font strikeoutFont = new Font(Label1.Font, FontStyle.Strikeout);
            Label1.Text = label1;

            if (label2 != null)
            {
                Label2.Font = Label1.Font;
                Label2.Text = label2;
                Label2.Enabled = true;
            }
            else
            {
                Label2.Font = strikeoutFont;
                Label2.Enabled = false;
            }

            if (label3 != null)
            {
                Label3.Font = Label1.Font;
                Label3.Text = label3;
                Label3.Enabled = true;
            }
            else
            {
                Label3.Font = strikeoutFont;
                Label3.Enabled = false;
            }
        }

        private void InitNumericInput(NumericUpDown input, bool enabled, 
            decimal step = 1, decimal min = 0, decimal max = 10, int decimalPlaces = 0)
        {
            input.Enabled = enabled;
            input.Increment = step;
            input.Minimum = min;
            input.Maximum = max;
            input.DecimalPlaces = decimalPlaces;
            input.Value = min;
        }

        private void UniformDistributionInit()
        {
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2);
            InitNumericInput(Input2, true, 1, 0, 1000, 2);
        }

        private void GaussDistributionInit()
        {
            SetInputLabels("n:", "mₓ:", "σₓ:");
            InitNumericInput(Input1, true, 1, 6, 12);
            InitNumericInput(Input2, true, 1, 0, 1000, 2);
            InitNumericInput(Input3, true, 1, 0, 1000, 2);
        }

        private void ExponentialDistributionInit()
        {
            SetInputLabels("λ:");
            InitNumericInput(Input1, true, 1, 0.01m, 1000, 2);
        }

        private void GammaDistributionInit()
        {
            SetInputLabels("η:", "λ:");
            InitNumericInput(Input1, true, 1, 0.01m, 500, 2);
            InitNumericInput(Input2, true, 1, 0.01m, 500, 2);
        }

        private void TriangularDistributionInit()
        {
            TriangularMinCheckBox.Enabled = true;
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2);
            InitNumericInput(Input2, true, 1, 0, 1000, 2);
        }

        private void SimpsonDistributionInit()
        {
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2);
            InitNumericInput(Input2, true, 1, 0, 1000, 2);
        }

        private void DisableAllInputs()
        {
            TriangularMinCheckBox.Enabled = false;
            InitNumericInput(Input2, false);
            InitNumericInput(Input3, false);
        }


    #endregion
    }
}
