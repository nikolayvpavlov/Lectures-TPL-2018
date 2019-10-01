using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAsyncAwait
{
    public partial class MainForm : Form
    {
        const string qotdUrl = "http://nvp-functions.azurewebsites.net/api/qotd?slow=true";

        public MainForm()
        {
            InitializeComponent();
        }

        private void bQotdThread_Click(object sender, EventArgs e)
        {
            ThreadStart worker = () =>
            {
                WebClient client = new WebClient();
                var stream = client.OpenRead(qotdUrl);
                using (var reader = new StreamReader(stream))
                {
                    var s = reader.ReadLine();
                    //Make sure the action is executed on the UI thread
                    Invoke((Action)
                        (() => labelQotd.Text = s));
                }
            };
            Thread aThread = new Thread(worker);
            aThread.Start();
        }

        private void WebClientReadComplete (object sender, OpenReadCompletedEventArgs e)
        {
            var stream = e.Result;
            using (var reader = new StreamReader(stream))
            {
                var str = reader.ReadLine();
                labelQotd.Text = str;
            }
        }

        private void bQotdAR_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += WebClientReadComplete;
            client.OpenReadAsync(new Uri(qotdUrl));  
        }

        private void bQotdSync_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            var stream = client.OpenRead(qotdUrl);
            using (var reader = new StreamReader(stream))
            {
                var s = reader.ReadLine();
                labelQotd.Text = s;
            }
        }

        private async void bQotdAsync_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            var stream = await client.OpenReadTaskAsync(qotdUrl);
            using (var reader = new StreamReader(stream))
            {
                var str = await reader.ReadLineAsync();
                labelQotd.Text = str;
            }

            //var t = client.OpenReadTaskAsync(qotdUrl);
            //t.ContinueWith(previous =>
            //{
            //    var reader = new StreamReader(previous.Result);
            //    var t2 = reader.ReadLineAsync();
            //    t2.ContinueWith(pr2 => labelQotd.Text = pr2.Result);
            //});
        }
    }
}
