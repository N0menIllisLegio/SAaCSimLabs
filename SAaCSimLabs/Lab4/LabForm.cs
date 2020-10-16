using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAaCSimLabs.Lab4
{
    public partial class LabForm : Form
    {   
        private delegate void ExecuteFunc();
        private ExecuteFunc func;

        public LabForm()
        {
            InitializeComponent();
            func = CalculateTotal;
            udChannels.Enabled = false;
        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            ClearOutput();
            func();
        }

        private async void CalculateCustom()
        {
            // Read inputs
            int hours = (int) udHours.Value;
            int requestsPerHour = (int) udRequestsPerHour.Value;
            double avgRequestProcessTime = (double) udRequestProcessTime.Value;
            double requestWorth = (double) udRequestWorth.Value;
            double channelFee = (double) udChannelFee.Value;
            double queueFee = (double) udQueueFee.Value;

            int channels = (int) udChannels.Value;
            int queueSize = (int) udQueueSize.Value;

            // Create system
            MassServiceSystem mSS = new MassServiceSystem(hours, requestsPerHour, avgRequestProcessTime, 
                requestWorth, channelFee, channels, queueSize, queueFee);

            // Run system
            await Task.Factory.StartNew(() => mSS.Start());

            // Display results
            OutputBox.Text += $"Profit: {mSS.PureProfit,6:F2} y.e.\n";
            RequestsGrid.DataSource = mSS.Requests;
        }

        private async void CalculateTotal()
        {
            // Read inputs
            int hours = (int) udHours.Value;
            int requestsPerHour = (int) udRequestsPerHour.Value;
            double avgRequestProcessTime = (double) udRequestProcessTime.Value;
            double requestWorth = (double) udRequestWorth.Value;
            double channelFee = (double) udChannelFee.Value;
            double queueFee = (double) udQueueFee.Value;

            // Init values
            double profit2Channel = 0;
            double profit3Channel = 0;
            double queueProfit = 0;
            int queueSize = 0;

            // Run 2 channel system
            Task task2Channel = Task.Factory.StartNew(() =>
            {
                MassServiceSystem mSS = new MassServiceSystem(hours, requestsPerHour, avgRequestProcessTime, 
                    requestWorth, channelFee, 2);
                mSS.Start();
                profit2Channel = mSS.PureProfit;
            });

            // Run 3 channel system
            Task task3Channel = Task.Factory.StartNew(() =>
            {
                MassServiceSystem mSS = new MassServiceSystem(hours, requestsPerHour, avgRequestProcessTime, 
                    requestWorth, channelFee, 3);
                mSS.Start();
                profit3Channel = mSS.PureProfit;
            });

            // Run system with queue [1..20] and 2 channels
            Task taskQueue = Task.Factory.StartNew(() =>
            {
                MassServiceSystem mSS = new MassServiceSystem(hours, requestsPerHour, avgRequestProcessTime, 
                    requestWorth, channelFee, 2, 1, queueFee);

                // [1..20] - queue's sizes for testing
                for (int i = 1; i < 21; i++)
                {
                    mSS.QueueSize = i;
                    mSS.Start();

                    if (queueProfit < mSS.PureProfit)
                    {
                        // get queue size with max profit
                        queueProfit = mSS.PureProfit;
                        queueSize = mSS.QueueSize;
                    }
                }
            });

            // Wait for task complition and display results
            await Task.WhenAll(new[] {task2Channel, task3Channel, taskQueue});

            // Display results
            OutputBox.Text += $"2 Channels profit | {profit2Channel,6:F2} y.e.\n";
            OutputBox.Text += $"3 Channels profit | {profit3Channel,6:F2} y.e.\n";
            OutputBox.Text += $"QueueSize: {queueSize} | {queueProfit,6:F2} y.e.\n";

            BuildTotalPlot(new []{profit2Channel, profit3Channel, Math.Round(queueProfit)}, queueSize);
        }


        private void BuildTotalPlot(double[] profit, int queueSize)
        {
            // Build Bars plot
            double[] xs = new[] {1D, 2D, 3D};
            string[] xLabels = { "2 Channels", "3 Channels", $"Queue {queueSize}" };
            
            Plot.plt.PlotBar(xs, profit, showValues: true);
            Plot.plt.XTicks(xs, xLabels);

            Plot.Render();
        }

        private async void CalculateQueues()
        {
            // Read inputs
            int hours = (int) udHours.Value;
            int requestsPerHour = (int) udRequestsPerHour.Value;
            double avgRequestProcessTime = (double) udRequestProcessTime.Value;
            double requestWorth = (double) udRequestWorth.Value;
            double channelFee = (double) udChannelFee.Value;
            double queueFee = (double) udQueueFee.Value;

            int channels = (int) udChannels.Value;
            int queueSize = (int) udQueueSize.Value;
            
            // Create system
            MassServiceSystem mSS = new MassServiceSystem(hours, requestsPerHour, avgRequestProcessTime, 
                requestWorth, channelFee, channels, queueSize, queueFee);

            // Profits from systems with different queue sizes 
            List<double> profit = new List<double>();

            // Calc profits and display them
            while (mSS.QueueSize > 0)
            {
                await Task.Factory.StartNew(() => mSS.Start());
                OutputBox.Text += $"QueueSize:{mSS.QueueSize,3} | {mSS.PureProfit,6:F2} y.e.\n";
                profit.Add(mSS.PureProfit);
                mSS.QueueSize--;
            }

            BuildQueuesPlot(profit);   
        }

        private void BuildQueuesPlot(List<double> profit)
        {
            profit.Reverse();
            double[] xs = new double[profit.Count];
            int maxIndex =  profit.IndexOf(profit.Max()) + 1;

            for (int i = 0; i < profit.Count; i++)
            {
                xs[i] = i + 1;
            }

            Plot.plt.PlotScatter(xs, profit.ToArray());
            Plot.plt.Grid(xSpacing: 1);

            Plot.plt.PlotVLine(x: maxIndex, label: "Max Profit", color: Color.Red);
            Plot.plt.PlotVLine(x: 3, label: "Statistics", color: Color.Green);
            
            Plot.plt.Legend();

            Plot.Render();
        }

        private void ClearOutput()
        {
            OutputBox.Text = "";
            Plot.plt.Clear();
            Plot.plt.XTicks();
            Plot.Render();
        }

        /// <summary>
        /// Change content on display
        /// </summary>
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearOutput();
            RadioButton radioButton = sender as RadioButton;
            udQueueSize.Minimum = 0;
            udQueueSize.Value = 0;
            udChannels.Enabled = true;
            lQueueSize.Text = "Queue Size:";

            RequestsGrid.Visible = false;
            Plot.Visible = true;

            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Total":
                        udChannels.Enabled = false;
                        func = CalculateTotal;
                        break;
                    case "Queues":
                        udQueueSize.Minimum = 1;
                        lQueueSize.Text = "Max Queues:";
                        func = CalculateQueues;
                        break;
                    default:
                        RequestsGrid.Visible = true;
                        Plot.Visible = false;
                        func = CalculateCustom;
                        break;
                }
            }
        }
    }
}
