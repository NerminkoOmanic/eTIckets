using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.WinUI.Properties;

namespace eTickets.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _apiService = new APIService("korisnik");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtbKorisnickoIme.Text;
            APIService.Password = txtbLozinka.Text;

            try
            {
                APIService.PrijavljeniKorisnik = await _apiService.Get<eTickets.Model.Korisnik>(null, "profil");

                if (APIService.PrijavljeniKorisnik.Uloga.Naziv == "Administrator")
                {
                    this.Hide();

                    frmIndex frm = new frmIndex();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(Resources.msgFailedLogin, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
