using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmSelectedAdmin : Form
    {
        private int _id;
        public frmSelectedAdmin(int id)
        {
            InitializeComponent();
            _id = id;
        }
    }
}
