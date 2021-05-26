using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Ticket
    {
        public Ticket()
        {
            Kupovine = new HashSet<Kupovine>();
        }

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
        public bool Prodano { get; set; }

        public virtual Korisnik Admin { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual PodKategorija PodKategorija { get; set; }
        public virtual Korisnik Prodavac { get; set; }
        public virtual Slika Slika { get; set; }
        public virtual ICollection<Kupovine> Kupovine { get; set; }
    }
}
