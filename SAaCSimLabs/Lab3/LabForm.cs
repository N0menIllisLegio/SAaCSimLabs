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

            //18
            //var source = new SourceWithDiscardingDiscipline(system, 0, 0.5);
            //var pi1 = new ChannelWithBlockingDiscipline(1, 0.6);
            //var queue = new Queue(2, 1);
            //var pi2 = new Channel(3, 0.4);

            //27
            var source = new SourceWithDiscardingDiscipline(system, 0, 2);
            var pi1 = new ChannelWithDiscardingDiscipline(1, 0.4);
            var queue = new Queue(2, 2);
            var pi2 = new Channel(3, 0.5);

            //10
            //var source = new SourceWithDiscardingDiscipline(system, 0, 0.5);
            //var queue = new Queue(1, 1);
            //var pi1 = new ChannelWithDiscardingDiscipline(2, 0.45);
            //var pi2 = new Channel(3, 0.35);

            system.SetComponents(source, pi1, queue, pi2);
            system.Execute();

            foreach (var stateInfo in system.ProbabilityStatesInfos)
            {
               AddToOutputBox($"{stateInfo} - {stateInfo.Times / (double)system.Tact:F4}");
            }

            AddToOutputBox("");
            AddToOutputBox($"Completed: {system.Requests.Count(x => x.State == RequestState.Completed)}");
            AddToOutputBox($"Discarded: {system.Requests.Count(x => x.State == RequestState.Discarded)}");
            AddToOutputBox($"Processing: {system.Requests.Count(x => x.State == RequestState.Processing)}");
            AddToOutputBox($"Pending: {system.Requests.Count(x => x.State == RequestState.Pending)}");
            AddToOutputBox($"Requests: {system.Requests.Count}");
            AddToOutputBox("");
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
