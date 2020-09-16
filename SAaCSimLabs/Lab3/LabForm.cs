using System;
using System.Linq;
using System.Windows.Forms;
using SAaCSimLabs.Lab3.Components;

namespace SAaCSimLabs.Lab3
{
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            ClearComponents();

            var system = new MassServiceSystem(10000);
            var source = new SourceWithDiscardingDiscipline(system, 0, 0.5);
            var queue = new Queue(1, 1);
            var pi1 = new ChannelWithDiscardingDiscipline(2, 0.45);
            var pi2 = new Channel(3, 0.35);

            system.SetComponents(source, pi1, queue, pi2);
            system.Execute();

            system.ProbabilityStatesInfos.ForEach(stateInfo => AddToOutputBox($"{stateInfo} - {stateInfo.Times / (double)system.Tact:F4}"));

            AddToOutputBox($"A = {system.AbsoluteBandwidth:F4}");
            AddToOutputBox($"Q = {system.RelativeBandwidth:F4}");
            AddToOutputBox($"Pотк = {system.DeclineProbability:F4}");
            AddToOutputBox($"Lс = {system.AvgRequestsInSystem:F4}");

            system.CoefsOfChannelCapacity.ForEach(coef => AddToOutputBox($"K of channel(π = {coef[1]}) = {coef[2]:F4}"));
            system.AvgQueueLength.ForEach(length => AddToOutputBox($"L of queue(places = {length[1]}) = {length[2]:F4}"));

            AddToOutputBox($"Wоч = {system.AvgTimeOfRequestInQueue:F4}");
            AddToOutputBox($"Wс = {system.AvgTimeOfRequestInSystem:F4}");
        }

        private void AddToOutputBox(string message)
        {
            ExecuteInUIThread(() => OutputBox.Text += message + Environment.NewLine);
        }

        private void ExecuteInUIThread(Action action)
        {
            this.Invoke(action);
        }

        private void ClearComponents()
        {
            OutputBox.Text = "";
        }
    }
}
