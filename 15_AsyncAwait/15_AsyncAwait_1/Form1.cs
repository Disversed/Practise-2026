using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15_AsyncAwait_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void ConnectDbBtn_Click(object sender, EventArgs e)
        {
            connectDbBtn.Enabled = false;
            disconnectDbBtn.Enabled = true;

            toolStripStatus.Text = $"[{DateTime.Now}] Connecting to DB...";
            await Task.Delay(3000);
            toolStripStatus.Text = $"[{DateTime.Now}] Succesfully connected to DB.";
            timer.Start();
        }

        private void DisconnectDbBtn_Click(object sender, EventArgs e)
        {
            connectDbBtn.Enabled = true;
            disconnectDbBtn.Enabled = false;

            timer.Stop();
            toolStripStatus.Text = $"[{DateTime.Now}] Disconnected from DB.";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatus.Text = $"[{DateTime.Now}] Some data was received.";
        }
    }
}
