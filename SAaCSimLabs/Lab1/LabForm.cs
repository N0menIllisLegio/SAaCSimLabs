using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                ExecuteInUIThread(() => StatusLabel.Text = "Generating numbers...");
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
            }).ContinueWith(task =>
            {
                ProgressStage("Calculating statistics...");
                Calculations calculations = new Calculations(generator);
                ExecuteInUIThread(() => outputBox.Text += $"M = {calculations.ExpectedValue:F5}\n");
                ExecuteInUIThread(() => outputBox.Text += $"D = {calculations.Variance:F5}\n");
                ExecuteInUIThread(() => outputBox.Text += $"σ = {calculations.StandardDeviation:F5}\n");

                ProgressStage("Building plot...");
                calculations.BuildHistogram(Plot.plt);
                Plot.Render();

                ProgressStage("Calculating distribution evenness...");
                calculations.EstimateDistributionEvenness();
                ExecuteInUIThread(() => outputBox.Text += $"2K/N = {calculations.EstimateDistributionEvenness():F5} -> {Math.PI / 4:F5}\n");

                ProgressStage("Calculating period...");
                int period = calculations.Period;
                int aperiodicitySegment = calculations.AperiodicitySegment;

                string periodOutput = period != 0 ? 
                    $"P = {period}\n" : "Not enough numbers to calculate period.\n";
                string aperiodicitySegmentOutput = aperiodicitySegment != 0 ? 
                    $"L = {aperiodicitySegment}" : "Not enough numbers to calculate aperiodicity segment.";

                ExecuteInUIThread(() => outputBox.Text += periodOutput);
                ExecuteInUIThread(() => outputBox.Text += aperiodicitySegmentOutput);

                ProgressStage("Complete.");
            });
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
