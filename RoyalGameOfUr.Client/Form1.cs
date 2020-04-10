using RoyalGameOfUr.Common.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalGameOfUr.Client
{
    public partial class Form1 : Form
    {
        GameClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new GameClient(123);
            client.ConnectToServer();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.SendData(new TestPacket(12, "my name is a very long name", Enumerable.Range(0, 256).ToList()));
            
        }
    }
}
