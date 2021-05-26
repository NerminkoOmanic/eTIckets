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
    public partial class frmKategorije : Form
    {
        private readonly APIService _apiService = new APIService("kategorija");

        public frmKategorije()
        {
            InitializeComponent();
            dgvKategorija.AutoGenerateColumns = false;
        }

        private async void frmKategorije_Load(object sender, EventArgs e)
        {
           
            var result = await _apiService.Get<List<eTickets.Model.Kategorija>>(null);

            dgvKategorija.DataSource = result;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmDodajKategoriju frm = new frmDodajKategoriju();
            frm.Show();
        }
    }
}
