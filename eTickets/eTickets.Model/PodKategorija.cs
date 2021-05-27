using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model
{
    public partial class PodKategorija
    {
        public int PodKategorijaId { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public virtual Kategorija Kategorija { get; set; }

        public string KategorijaString => this.Kategorija.Naziv;

    }
}
