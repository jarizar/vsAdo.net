using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class MDIPrincial : Form
    {
        public MDIPrincial()
        {
            InitializeComponent();
        }

        private void reporteDeTrackConEFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reporteDeTrackConRepositoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmReportTracks();
            form.MdiParent = this;
            form.Show();
        }
    }
}
