using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model.Requests;
using eTickets.WinUI.Properties;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmEditAdmin : Form
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _gradService = new APIService("grad");


        private int _id;
        public frmEditAdmin(int korisnikId)
        {
            InitializeComponent();
            _id = korisnikId;
        }

        private async void frmEditAdmin_Load(object sender, EventArgs e)
        {
            await BindGrad();

            var entity = await _korisnikService.GetById<eTickets.Model.Korisnik>(_id);

            txtbEmail.Text = entity.Email;
            txtbTelefon.Text = entity.Telefon;
            cmbGrad.SelectedIndex = entity.GradId;
        }
        private async Task BindGrad()
        {
            var lst = await _gradService.Get<List<eTickets.Model.Grad>>(null);
            
            lst.Insert(0,new Model.Grad());

            cmbGrad.DataSource = lst;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new KorisnikUpdateRequest()
                {
                    Email = txtbEmail.Text,
                    Telefon = txtbTelefon.Text,
                    GradId = cmbGrad.SelectedIndex
                };

                if (txtbLozinka.TextLength>4)
                    request.Lozinka = txtbLozinka.Text;
            
                

                await _korisnikService.Update<Model.Korisnik>(_id, request);

                MessageBox.Show(Properties.Resources.msgSuccessEdit);
                this.Close();
            }
            
        }


        #region Validation
        private async void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbEmail.Text))
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
                return;
            }
            try
            {
                MailAddress mail = new MailAddress(txtbEmail.Text);

            }
            catch (Exception b)
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgEmailFormat);
                e.Cancel = true;
                return;
            }

            var search = new KorisnikSearchRequest()
            {
                EmailValidacija = txtbEmail.Text
            };

            var lst = await _korisnikService.Get<List<eTickets.Model.Korisnik>>(search);

            if (lst.Count>0)
            {
                errorProvider.SetError(txtbEmail,Properties.Resources.msgEmailExist);
                e.Cancel = true;
                return;
            }
            errorProvider.SetError(txtbEmail,null);
            
        }
        
        private void txtbLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbLozinka.Text))
            {
                errorProvider.SetError(txtbLozinka,null);

            }

            if (txtbLozinka.Text.Length > 0 && txtbLozinka.Text.Length < 6 )
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
                errorProvider.SetError(txtbPotvrdaLozinke,Resources.msgPasswordMatch);
                e.Cancel = true;
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
            if (cmbGrad.SelectedIndex <1)
            {
                errorProvider.SetError(cmbGrad,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbTelefon,null);
            }
        }
        #endregion
        
    }
}
