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
    public partial class frmDodajPodkategoriju : Form
    {
        private readonly APIService _podkategorijaService = new APIService("podkategorija");
        private readonly APIService _kategorijaService = new APIService("kategorija");


        public frmDodajPodkategoriju()
        {
            InitializeComponent();
        }

        private async void frmDodajPodkategoriju_Load(object sender, EventArgs e)
        {
            await BindKategorija();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new PodKategorijaRequest()
                {
                    Naziv = txtbNaziv.Text,
                    KategorijaId = cmbKategorija.SelectedIndex
                };

                await _podkategorijaService.Insert<Model.PodKategorija>(request);
                MessageBox.Show(Properties.Resources.msgSuccessAddItem);
                this.Close();
            }
        }



        #region BindDataGrids
        private async Task BindKategorija()
        {
            var lst = await _kategorijaService.Get<List<eTickets.Model.Kategorija>>(null);
            
            lst.Insert(0,new Model.Kategorija());

            cmbKategorija.DataSource = lst;
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "KategorijaId";
        }


        #endregion

        #region Validation
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
        private void cmbKategorija_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKategorija.SelectedIndex<1)
            {
                errorProvider.SetError(cmbKategorija,Properties.Resources.msgValidation_ReqField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbKategorija,null);
            }
        }

        #endregion

        
    }
}
