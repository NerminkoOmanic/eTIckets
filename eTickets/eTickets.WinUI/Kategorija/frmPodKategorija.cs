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
        
        private readonly APIService _apiService = new APIService("podkategorija");
        public frmPodKategorija()
        {
            InitializeComponent();
            dgvPodKategorija.AutoGenerateColumns = false;
        }

        private async void frmPodKategorija_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<eTickets.Model.PodKategorija>>(null);

            dgvPodKategorija.DataSource = result;

            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmDodajPodkategoriju frm = new frmDodajPodkategoriju();
            frm.Show();
        }
    }
}
