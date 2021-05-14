using System;

namespace eTickets.Model
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int ProdavacId { get; set; }
        public string NazivDogadjaja { get; set; }
        public DateTime Datum { get; set; }
        public string Sektor { get; set; }
        public int? Red { get; set; }
        public string Sjedalo { get; set; }
        public decimal Cijena { get; set; }
        public int SlikaId { get; set; }
        public int GradId { get; set; }
        public int PodKategorijaId { get; set; }
        public int? AdminId { get; set; }
        public bool Odobreno { get; set; }
        public bool Prodano { get; set; }

        public virtual Korisnik Admin { get; set; }
        public virtual Grad Grad { get; set; }
        ////public virtual PodKategorija PodKategorija { get; set; }
        //public virtual Korisnik Prodavac { get; set; }
        //public virtual Slika Slika { get; set; }
    }
}
