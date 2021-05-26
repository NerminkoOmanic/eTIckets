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
    public partial class frmResetPassword : Form
    {
        private readonly APIService _korisnikService = new APIService("korisnik");

        private int _id;
        public frmResetPassword(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            var entity = await _korisnikService.GetById<eTickets.Model.Korisnik>(_id);

            var request = new KorisnikUpdateRequest()
            {
                Email = entity.Email,
                Telefon = entity.Telefon,
                GradId = entity.GradId,
                Lozinka = "Reset1"
            };

            await _korisnikService.Update<Model.Korisnik>(_id, request);

            MessageBox.Show(Properties.Resources.msgSucccessPasswordReset);
            this.Close();
        }
    }
}
