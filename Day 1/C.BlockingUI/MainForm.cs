using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C.BlockingUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bDoSomething_Click(object sender, EventArgs e)
        {
            NetReader();
        }

        private void NetReader()
        {
            WebClient client = new WebClient();
            try
            {
                client.OpenRead("http://8.8.8.1");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            MessageBox.Show("Ready!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Thread worker = new Thread(NetReader);
            worker.Start();
        }
    }
}
