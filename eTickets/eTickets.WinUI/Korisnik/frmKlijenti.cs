using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService _apiService = new APIService("korisnik");
        public frmKlijenti()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            //pozivamo api
            //localhost

            var result = await _apiService.Get<eTickets.Model.Korisnik>();

            dgvKlijenti.DataSource = result;
        }

        
    }
}
