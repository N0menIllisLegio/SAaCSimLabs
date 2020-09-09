using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAaCSimLabs.Generators;

namespace SAaCSimLabs.Lab2
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
            DistributionComboBox.SelectedIndex = 0;
            UniformDistributionInit();
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            string distribution = DistributionComboBox.SelectedItem.ToString();

            int count = (int) CountInput.Value;
            int seed = (int) SeedInput.Value;
            int multiplier = (int) MultiplierInput.Value;
            int range = (int) RangeInput.Value;
            bool showAllNumbers = !DisplayedNumbersLimiter.Checked;

            IGenerator generator;
            MLCG generatorMLCG = new MLCG(seed, multiplier, range);

            ClearComponents();
            GeneratingProgress.Maximum = count;

            switch (distribution)
            {
                case "Uniform":
                    generator = new UniformGenerator(Input1.Value, Input2.Value, generatorMLCG);
                    break;
                case "Gauss":
                    generator = new GaussGenerator(Input1.Value, Input2.Value, Input3.Value, count, generatorMLCG);
                    break;
                case "Exponential":
                    generator = new ExponentialGenerator(Input1.Value, generatorMLCG);
                    break;
                case "Gamma":
                    generator = new GammaGenerator(Input1.Value, Input2.Value, count, generatorMLCG);
                    break;
                case "Triangular":
                    generator = new TriangularGenerator(Input1.Value, Input2.Value, TriangularMinCheckBox.Checked, count, generatorMLCG);
                    break;
                case "Simpson":
                    generator = new SimpsonGenerator(Input1.Value, Input2.Value, count, generatorMLCG);
                    break;
                default:
                    generator = generatorMLCG;
                    break;
            }

            await Task.Factory.StartNew(() =>
            {
                ProgressStage("Generating numbers...");

                for (int i = 0; i < count; i++)
                {
                    if (showAllNumbers || i < 100)
                    {
                        string row = $"{i + 1}. {generator.NextNumber()}";
                        ExecuteInUIThread(() => NumbersList.Items.Add(row));
                    }
                    else
                    {
                        generator.NextNumber();
                    }

                    ExecuteInUIThread(() => GeneratingProgress.Value++);
                }

                ProgressStage("Calculating statistics...");

                Calculations calculations = new Calculations(generator);
                AddToOutputBox($"M = {calculations.ExpectedValue:F5}");
                AddToOutputBox($"D = {calculations.Variance:F5}");
                AddToOutputBox($"σ = {calculations.StandardDeviation:F5}");

                ProgressStage("Building plot...");
                calculations.BuildHistogram(Plot.plt);
                Plot.Render();

                ProgressStage("Complete.");
            });
        }

        private void DistributionComboBox_SelectedValueChanged(object sender, EventArgs e)
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
            decimal step = 1, decimal min = 0, decimal max = 10, int decimalPlaces = 0, decimal? value = null)
        {


            input.Enabled = enabled;
            input.Increment = step;
            input.Minimum = min;
            input.Maximum = max;
            input.DecimalPlaces = decimalPlaces;

            if (value == null || value < min || value > max)
            {
                input.Value = min;
            }
            else
            {
                input.Value = value.Value;
            }
        }

        private void UniformDistributionInit()
        {
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2, 7);
            InitNumericInput(Input2, true, 1, 0, 1000, 2, 11);
        }

        private void GaussDistributionInit()
        {
            SetInputLabels("n:", "mₓ:", "σₓ:");
            InitNumericInput(Input1, true, 1, 6, 12, value: 6);
            InitNumericInput(Input2, true, 1, 0, 1000, 2, 400);
            InitNumericInput(Input3, true, 1, 0, 1000, 2, 20);
        }

        private void ExponentialDistributionInit()
        {
            SetInputLabels("λ:");
            InitNumericInput(Input1, true, 1, 0.01m, 1000, 2, 1);
        }

        private void GammaDistributionInit()
        {
            SetInputLabels("η:", "λ:");
            InitNumericInput(Input1, true, 1, 1, 500, 0, 17);
            InitNumericInput(Input2, true, 1, 0.01m, 500, 2, 0.51m);
        }

        private void TriangularDistributionInit()
        {
            TriangularMinCheckBox.Enabled = true;
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2, 3);
            InitNumericInput(Input2, true, 1, 0, 1000, 2, 11);
        }

        private void SimpsonDistributionInit()
        {
            SetInputLabels("a:", "b:");
            InitNumericInput(Input1, true, 1, 0, 1000, 2, 9);
            InitNumericInput(Input2, true, 1, 0, 1000, 2, 2);
        }

        private void DisableAllInputs()
        {
            TriangularMinCheckBox.Enabled = false;
            InitNumericInput(Input2, false);
            InitNumericInput(Input3, false);
        }


    #endregion

        private void AddToOutputBox(string message)
        {
            ExecuteInUIThread(() => OutputBox.Text += message + "\n");
        }

        private void ProgressStage(string stageName)
        {
            ExecuteInUIThread(() => StatusLabel.Text = stageName);
        }

        private void ExecuteInUIThread(Action action)
        {
            this.Invoke(action);
        }

        private void ClearComponents()
        {
            GeneratingProgress.Value = 0;
            NumbersList.Items.Clear();
            Plot.plt.Clear();
            OutputBox.Text = "";
        }
    }
}
