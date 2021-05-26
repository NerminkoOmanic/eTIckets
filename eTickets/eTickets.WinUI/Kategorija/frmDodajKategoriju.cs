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

namespace eTickets.WinUI.Kategorija
{
    public partial class frmDodajKategoriju : Form
    {
        private readonly APIService _kategorijaService = new APIService("kategorija");

        public frmDodajKategoriju()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new KategorijaRequest()
                {
                    Naziv = txtbNaziv.Text
                };

                await _kategorijaService.Insert<Model.Kategorija>(request);
                MessageBox.Show(Properties.Resources.msgSuccessAdd);
                this.Close();
            }
           
        }

        private void txtbNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbNaziv.Text))
            {
                errorProvider.SetError(txtbNaziv,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtbNaziv,null);
            }
        }
    }
}
