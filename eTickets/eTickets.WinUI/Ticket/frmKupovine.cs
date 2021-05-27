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

namespace eTickets.WinUI.Ticket
{
    public partial class frmKupovine : Form
    {
        private readonly APIService _kupovineService = new APIService("kupovine");

        public frmKupovine()
        {
            InitializeComponent();
            dgvKupovine.AutoGenerateColumns = false;
        }

        private async Task GenerateGrid()
        {
            var result = await _kupovineService.Get<List<KupovineDgvExtension>>(null);

            dgvKupovine.DataSource = result;
        }

        private async void frmKupovine_Load(object sender, EventArgs e)
        {
           await GenerateGrid();
        }

        
    }
}
