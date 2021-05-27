using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model;
using eTickets.Model.Requests;
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
            dgvKlijenti.AutoGenerateColumns = false;
        }
        private async Task GenerateGrid(KorisnikSearchRequest search)
        {
            var result = await _apiService.Get<List<KorisnikViewExtension>>(search);

            dgvKlijenti.DataSource = result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                KorisnickoIme = txtbSearch.Text,
                UlogaId = 2 //Klijenti uloga id = 2, prikaz klijenata
            };

            await GenerateGrid(search);

        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                UlogaId = 2 //Klijenti uloga id = 2, prikaz klijenata
            };
            await GenerateGrid(search);
        }

        private void dgvKlijenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKlijenti.SelectedRows[0].Cells[0].Value;

            frmResetPassword frm = new frmResetPassword(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
