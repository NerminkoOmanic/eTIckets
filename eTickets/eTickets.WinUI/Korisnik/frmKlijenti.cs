﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTickets.Model;
using eTickets.Model.Requests;
using Flurl;
using Flurl.Http;

namespace eTickets.WinUI.Korisnik
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService _apiService = new APIService("korisnik");
        public frmKlijenti()
        {
            InitializeComponent();
            dgvKlijenti.AutoGenerateColumns = false;
        }
        private  void GenerateGrid(KorisnikSearchRequest search)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                KorisnickoIme = txtbSearch.Text,
                UlogaId = 2 //Klijenti uloga id = 2, prikaz klijenata
            };
            var result = await _apiService.Get<List<eTickets.Model.Korisnik>>(search);

            dgvKlijenti.DataSource = result;
        }

        private void frmKlijenti_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvKlijenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKlijenti.SelectedRows[0].Cells[0].Value;

            //frmDodajAdmina frm = new frmDodajAdmina(int.Parse(id.ToString()));
            //frm.Show();
        }
    }
}
