using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Korisnik = new HashSet<Korisnik>();
            Ticket = new HashSet<Ticket>();
        }

        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
