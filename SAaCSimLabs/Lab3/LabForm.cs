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
            var pi1 = new ChannelWithBlockingDiscipline(1, 0.6);
            var queue = new Queue(2, 1);
            var pi2 = new Channel(3, 0.4);

            system.SetComponents(source, pi1, queue, pi2);
            system.Execute();

            foreach (var stateInfo in system.ProbabilityStatesInfos)
            {
                string output = "";

                for (int i = stateInfo.State.Length - 1; i >= 0; i--)
                {
                    output += $"{stateInfo.State[i]}";
                }

                output += $" - {stateInfo.Times / (double)system.Tact:F4}";

                AddToOutputBox(output);
            }

            AddToOutputBox($"Completed: {system.Requests.Count(x => x.State == RequestState.Completed)}");
            AddToOutputBox($"Discarded: {system.Requests.Count(x => x.State == RequestState.Discarded)}");
            AddToOutputBox($"Processing: {system.Requests.Count(x => x.State == RequestState.Processing)}");
            AddToOutputBox($"Pending: {system.Requests.Count(x => x.State == RequestState.Pending)}");
            AddToOutputBox($"Requests: {system.Requests.Count}");
            AddToOutputBox("\n");

            AddToOutputBox(
                $"A: {system.Requests.Count(x => x.State == RequestState.Completed) / (double)system.Tact:0.000}");
            AddToOutputBox(
                $"Pотк: {system.Requests.Count(x => x.State == RequestState.Discarded) / (double)system.Requests.Count:0.000}");
            AddToOutputBox(
                $"Wstat: {system.Requests.Sum(x => x.ExistingTime) / (double)system.Requests.Count(x => x.State != RequestState.Discarded):0.000}");

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
