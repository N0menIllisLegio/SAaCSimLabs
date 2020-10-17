using SAaCSimLabs.Lab3.Components;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAaCSimLabs.Lab3
{
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
        }

        private async void SimulateButton_Click(object sender, EventArgs e)
        {
            ClearComponents();

            var system = new MassServiceSystem(10000);

            //var source = new SourceWithDiscardingDiscipline(0, system, 0, 0.5);
            //var queue = new Queue(1, 1, 1);
            //var pi1 = new ChannelWithDiscardingDiscipline(2, 2, 0.45);
            //var pi2 = new Channel(3, 3, 0.35);

            var source = new SourceWithBlockingDiscipline(0, system, 0, 2);
            var pi1 = new ChannelWithDiscardingDiscipline(1, 1, 0.5);
            var pi2 = new Channel(2, 2, 0.5);
            var pi3 = new Channel(3, 2, 0.4);

            system.SetComponents(source, pi1, pi2, pi3);
            await Task.Factory.StartNew(() => system.Start());

            system.ProbabilityStatesInfos.ForEach(stateInfo => 
                ProbabilitiesOutput.Rows.Add(null, stateInfo.ToString(), stateInfo.Times / (double)system.Tact));

            AddToOutputBox("A", system.AbsoluteBandwidth);
            AddToOutputBox("Q", system.RelativeBandwidth);
            AddToOutputBox("Pотк", system.DeclineProbability);
            AddToOutputBox("Lс", system.AvgRequestsInSystem);
            AddToOutputBox("Wоч", system.AvgTimeOfRequestInQueue);
            AddToOutputBox("Wс", system.AvgTimeOfRequestInSystem);

            system.CoefsOfChannelCapacity.ForEach(coef => AddToOutputBox($"Kк({coef.Key}) = {coef.Value:F3}"));
            system.AvgQueueLength.ForEach(length => AddToOutputBox($"Lоч({length.Key}) = {length.Value:F3}"));
            system.BlockingProbability.ForEach(block => AddToOutputBox($"Pбл({block.Key}) = {block.Value:F3}"));
        }

        private void AddToOutputBox(string name, double value)
        {
            OutputBox.Text += string.Format("{0,-6}={1,6:F3}", name, value) + Environment.NewLine;
        }

        private void AddToOutputBox(string message)
        {
            OutputBox.Text += message + Environment.NewLine;
        }

        private void ClearComponents()
        {
            OutputBox.Text = "";
            ProbabilitiesOutput.Rows.Clear();
        }
    }
}
