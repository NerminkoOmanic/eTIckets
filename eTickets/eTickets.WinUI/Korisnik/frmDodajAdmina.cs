using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmDodajAdmina : Form
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _gradService = new APIService("grad");
        private readonly APIService _spolService = new APIService("spol");


        public frmDodajAdmina()
        {
            InitializeComponent();
        }

        private async void frmDodajAdmina_Load(object sender, EventArgs e)
        {
           await BindGrad();
           await BindSpol();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new KorisnikInsertRequest()
                {
                    Ime = txtbIme.Text,
                    Prezime = txtbPrezime.Text,
                    Email = txtbEmail.Text,
                    Telefon = txtbTelefon.Text,
                    KorisnickoIme = txtbKorisnickoIme.Text,
                    Lozinka = txtbLozinka.Text,
                    LozinkaPotvrda = txtbPotvrdaLozinke.Text,
                    DatumRodjenja = dtpDatum.Value,
                    GradId = cmbGrad.SelectedIndex,
                    SpolId = cmbSpol.SelectedIndex,
                    UlogaId = 1
                };

                await _korisnikService.Insert<Model.Korisnik>(request);
                MessageBox.Show(Properties.Resources.msgSuccessAdd);

            }
            
        }

        #region BindDataGrids
        private async Task BindGrad()
        {
            var lst = await _gradService.Get<List<eTickets.Model.Grad>>(null);
            
            lst.Insert(0,new Model.Grad());

            cmbGrad.DataSource = lst;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
        }
        private async Task BindSpol()
        {
            var lst = await _spolService.Get<List<eTickets.Model.Spol>>(null);
            
            lst.Insert(0,new Spol());

            cmbSpol.DataSource = lst;
            cmbSpol.DisplayMember = "Naziv";
            cmbSpol.ValueMember = "SpolId";
        }

        #endregion

        #region Validation
        private async void txtbKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                KorisnickoImeValidacija = txtbKorisnickoIme.Text
            };
            var lst = await _korisnikService.Get<List<eTickets.Model.Korisnik>>(search);

            if (string.IsNullOrWhiteSpace(txtbKorisnickoIme.Text))
            {
                errorProvider.SetError(txtbKorisnickoIme,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else if (lst.Count>0)
            {
                errorProvider.SetError(txtbKorisnickoIme,Properties.Resources.msgUsernameExist);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbKorisnickoIme,null);
            }
        }
        private void txtbIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbIme.Text))
            {
                errorProvider.SetError(txtbIme,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbIme,null);
            }
        }
        private void txtbPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbPrezime.Text))
            {
                errorProvider.SetError(txtbPrezime,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;

            }
            else
            {
                errorProvider.SetError(txtbPrezime,null);
            }
        }
        private async void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                EmailValidacija = txtbEmail.Text
            };
            var lst = await _korisnikService.Get<List<eTickets.Model.Korisnik>>(search);
            if (string.IsNullOrWhiteSpace(txtbEmail.Text))
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else if (lst.Count>0)
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgEmailExist);
                e.Cancel = true;
            }
            else if (!(txtbEmail.Text.Contains("@") && txtbEmail.Text.Contains(".")) )
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgEmailFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbEmail,null);
            }
        }
        private void txtbTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbTelefon.Text))
            {
                errorProvider.SetError(txtbTelefon,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbTelefon,null);
            }
        }
        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGrad.SelectedIndex<1)
            {
                errorProvider.SetError(cmbGrad,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGrad,null);
            }
            
        }
        private void cmbSpol_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSpol.SelectedIndex<1)
            {
                errorProvider.SetError(cmbSpol,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbSpol,null);
            }
        }
        private void txtbLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbLozinka.Text))
            {
                errorProvider.SetError(txtbLozinka,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }

            if (txtbLozinka.Text.Length < 6 )
            {
                errorProvider.SetError(txtbLozinka,Properties.Resources.msgPasswordWeak);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbLozinka,null);
            }
        }
        private void txtbPotvrdaLozinke_Validating(object sender, CancelEventArgs e)
        {
            if (txtbPotvrdaLozinke.Text != txtbLozinka.Text)
            {
                errorProvider.SetError(txtbPotvrdaLozinke,Properties.Resources.msgPasswordMatch);
                e.Cancel = true;
            }
        }

        //need Implementation
        private void dtpDatum_Validating(object sender, CancelEventArgs e)
        {
            
        }

        #endregion

        
    }
}
