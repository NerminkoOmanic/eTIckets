using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTickets.WinUI.Kategorija
{
    public partial class frmPodKategorija : Form
    {
        public frmPodKategorija()
        {
            InitializeComponent();
            dgvPodKategorija.AutoGenerateColumns = false;
        }
    }
}
