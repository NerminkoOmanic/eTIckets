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

    public partial class frmProfil : Form
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _gradService = new APIService("grad");
        private readonly APIService _spolService = new APIService("spol");

        private int _id ;
        public frmProfil(int korisnikId)
        {
            InitializeComponent();
            _id = korisnikId;
        }

        private async void frmProfil_Load(object sender, EventArgs e)
        {
            var entity = await _korisnikService.GetById<eTickets.Model.Korisnik>(_id);

            lbIme.Text = entity.Ime;
            lbPrezime.Text = entity.Prezime;
            lbDatum.Text = entity.DatumRodjenja.ToShortDateString();
            lbTelefon.Text = entity.Telefon;
            lbEmail.Text = entity.Email;
            lbGrad.Text = entity.GradString;
            lbSpol.Text = entity.SpolString;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {   
            frmEditAdmin frm = new frmEditAdmin(_id);
            frm.Show();

        }
    }
}
