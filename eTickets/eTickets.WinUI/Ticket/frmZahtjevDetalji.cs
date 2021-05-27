using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model.Requests;
using eTickets.WinUI.Properties;

namespace eTickets.WinUI.Ticket
{
    public partial class frmZahtjevDetalji : Form
    {
        private readonly APIService _ticketService = new APIService("ticket");
        private readonly APIService _slikaService = new APIService("slika");

        private int _id;

        public frmZahtjevDetalji(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmZahtjevDetalji_Load(object sender, EventArgs e)
        {
            var entity = await _ticketService.GetById<eTickets.Model.Ticket>(_id);

            lbNazivDogadjaja.Text = entity.NazivDogadjaja;
            lbDatum.Text = entity.Datum.ToShortTimeString();
            lbSektor.Text = entity.Sektor;
            lbRed.Text = entity.Red.ToString();
            lbSjedalo.Text = entity.Sjedalo;
            lbPodKategorija.Text = entity.PodKategorija.Naziv;
            lbCijena.Text = entity.Cijena + " KM";
            lbProdavac.Text = entity.Prodavac.KorisnickoIme;

            var imageStream = new MemoryStream(entity.Slika.SlikaBytes);
            pbSlika.Image =  Image.FromStream(imageStream);
            pbSlika.SizeMode = PictureBoxSizeMode.Zoom;

            if (entity.AdminId != null)
            {
                lbAdmin.Text = entity.Admin.KorisnickoIme;
                btnApprove.Hide();
                btnDeny.Hide();
            }
            else
            {
                lbApproved.Hide();
                lbAdmin.Hide();
            }

        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            var request = new TicketUpdateRequest()
            {
                AdminId = APIService.PrijavljeniKorisnik.KorisnikId
            };

            await _ticketService.Update<Model.Ticket>(_id, request);

            MessageBox.Show(Properties.Resources.msgSuccesApproved);
            this.Close();
        }

        private async void btnDeny_Click(object sender, EventArgs e)
        {
            var entity = await _ticketService.GetById<eTickets.Model.Ticket>(_id);
            if (await _ticketService.Remove(_id))
            {
                if (await _slikaService.Remove(entity.SlikaId) )
                {
                    MessageBox.Show(Resources.msgRequestDenied);
                }
            }
            else
            {
                MessageBox.Show(Resources.msgError);
            }

            
        }
    }
}
