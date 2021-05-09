using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Korisniks = new HashSet<Korisnik>();
            Tickets = new HashSet<Ticket>();
        }

        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Korisnik> Korisniks { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
