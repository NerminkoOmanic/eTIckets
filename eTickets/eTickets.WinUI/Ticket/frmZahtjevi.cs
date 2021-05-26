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

namespace eTickets.WinUI.Ticket
{
    public partial class frmZahtjevi : Form
    {
        private readonly APIService _ticketService = new APIService("ticket");
        
        public frmZahtjevi()
        {
            InitializeComponent();
            dgvZahtjevi.AutoGenerateColumns = false;

        }

        private async Task GenerateGrid(TicketSearchRequest search)
        {
            var result = await _ticketService.Get<List<eTickets.Model.Ticket>>(search);

            dgvZahtjevi.DataSource = result;
        }

        private async void frmZahtjevi_Load(object sender, EventArgs e)
        {
            var search = new TicketSearchRequest()
            {
                OrderByDatum = true,
                Zahtjev = true //prikaz zahtjeva za prodajama
            };
            await GenerateGrid(search);
        }

        private void dgvZahtjevi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvZahtjevi.SelectedRows[0].Cells[0].Value;

            frmZahtjevDetalji frm = new frmZahtjevDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
