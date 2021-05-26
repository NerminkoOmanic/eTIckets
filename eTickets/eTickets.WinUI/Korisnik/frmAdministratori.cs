using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model.Requests;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmAdministratori : Form
    {
        private readonly APIService _apiService = new APIService("korisnik");

        public frmAdministratori()
        {
            InitializeComponent();
            dgvAdministratori.AutoGenerateColumns = false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajAdmina frm = new frmDodajAdmina();
            frm.Show();
        }

        private async void frmAdministratori_Load(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                UlogaId = 1 //Admin uloga id = 1, prikaz admina
            };
            await GenerateGrid(search);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                KorisnickoIme = txtbSearch.Text,
                UlogaId = 1 //Admin uloga id = 1, prikaz admina
            };
            await GenerateGrid(search);
        }

        private void dgvAdministratori_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvAdministratori.SelectedRows[0].Cells[0].Value;

            frmResetPassword frm = new frmResetPassword(int.Parse(id.ToString()));
            frm.Show();
        }

        private async Task GenerateGrid(KorisnikSearchRequest search)
        {
            var result = await _apiService.Get<List<eTickets.Model.Korisnik>>(search);

            dgvAdministratori.DataSource = result;
        }
    }
}
