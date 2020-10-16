using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAaCSimLabs.Generators;

namespace SAaCSimLabs.Lab1
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            int count = (int) CountInput.Value;
            int seed = (int) SeedInput.Value;
            int multiplier = (int) MultiplierInput.Value;
            int range = (int) RangeInput.Value;
            bool showAllNumbers = !DisplayedNumbersLimiter.Checked;

            MLCG generator = new MLCG(seed, multiplier, range);

            // Set max progressbar
            GeneratingProgress.Maximum = count;
            ClearComponents();

            // Generating numbers
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
            });

            ProgressStage("Calculating statistics...");
            Calculations calculations = new Calculations(generator);
            AddToOutputBox($"M = {calculations.ExpectedValue:F5}");
            AddToOutputBox($"D = {calculations.Variance:F5}");
            AddToOutputBox($"σ = {calculations.StandardDeviation:F5}");

            ProgressStage("Building plot...");
            calculations.BuildHistogram(Plot.plt);
            Plot.Render();

            ProgressStage("Calculating distribution evenness...");
            calculations.EstimateDistributionEvenness();
            AddToOutputBox($"2K/N = {calculations.EstimateDistributionEvenness():F5} -> {Math.PI / 4:F5}");

            ProgressStage("Calculating period...");
            int period = calculations.Period;
            int aperiodicitySegment = calculations.AperiodicitySegment;

            AddToOutputBox(period != 0 ? $"P = {period}" : "Not enough numbers to calculate period.");
            AddToOutputBox(aperiodicitySegment != 0 ? $"L = {aperiodicitySegment}" : "Not enough numbers to calculate aperiodicity segment.");

            ProgressStage("Complete.");
        }

        private void AddToOutputBox(string message)
        {
            ExecuteInUIThread(() => outputBox.Text += message + "\n");
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
            outputBox.Text = "";
        }
    }
}
