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

namespace eTickets.WinUI.Ticket
{
    public partial class frmZahtjevDetalji : Form
    {
        private readonly APIService _ticketService = new APIService("ticket");
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

            var imageStream = new MemoryStream(entity.Slika.SlikaBytes);
            pbSlika.Image =  Image.FromStream(imageStream);
            pbSlika.SizeMode = PictureBoxSizeMode.Zoom;

        }
    }
}
