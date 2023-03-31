using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tibimon
{
    public partial class nehezseg : Form
    {
        public nehezseg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.nehez = "kozepes";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.nehez = "konnyu";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.nehez = "nehez";
            this.Close();
        }

        private void nehezseg_Load(object sender, EventArgs e)
        {

        }
    }
}
