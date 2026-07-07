using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_APM_additional
{
    public partial class Form1 : Form
    {
        private delegate double ComputeDelegate(double a, double b);

        public Form1()
        {
            InitializeComponent();
        }

        private double Compute(double a, double b)
        {
            Thread.Sleep(2000);
            return a + b;
        }

        private void Log(string message)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<string>(Log), message);
            }
            else
            {
                logBox.AppendText($"[{DateTime.Now}] {message}\r\n");
            }
        }

        private void isCompleteBtn_Click(object sender, EventArgs e)
        {
            Log("[IsComplete]: Starting...");
            ComputeDelegate del = Compute;

            bool isParam1Valid = double.TryParse(textBox1.Text, out double param1);
            bool isParam2Valid = double.TryParse(textBox2.Text, out double param2);

            if (!isParam1Valid || !isParam2Valid)
            {
                Log("[IsComplete]: Error. Invalid values");
                return;
            }

            var ar = del.BeginInvoke(param1, param2, null, null);

            while (!ar.IsCompleted)
            {
                Log("[IsComplete]: Still calculating...");
                Thread.Sleep(500);
            }

            double result = del.EndInvoke(ar);
            Log($"[IsComplete]: Result = {result}");
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            Log("[EndInvoke]: Starting...");
            ComputeDelegate del = Compute;

            bool isParam1Valid = double.TryParse(textBox1.Text, out double param1);
            bool isParam2Valid = double.TryParse(textBox2.Text, out double param2);

            if (!isParam1Valid || !isParam2Valid)
            {
                Log("[EndInvoke]: Error. Invalid values");
                return;
            }

            var ar = del.BeginInvoke(param1, param2, null, null);

            double result = del.EndInvoke(ar);
            Log($"[EndInvoke]: Result = {result}");
        }

        private void callbackBtn_Click(object sender, EventArgs e)
        {
            Log("[Callback]: Starting...");
            ComputeDelegate del = Compute;

            bool isParam1Valid = double.TryParse(textBox1.Text, out double param1);
            bool isParam2Valid = double.TryParse(textBox2.Text, out double param2);

            if (!isParam1Valid || !isParam2Valid)
            {
                Log("[Callback]: Error. Invalid values");
                return;
            }

            var ar = del.BeginInvoke(param1, param2, ComputeCallback, null);
        }

        private void ComputeCallback(IAsyncResult ar)
        {
            var del = (ComputeDelegate)((AsyncResult)ar).AsyncDelegate;

            double result = del.EndInvoke(ar);
            Log($"[Callback]: Result = {result}");
        }
    }
}
