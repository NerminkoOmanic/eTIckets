using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class Spol
    {
        public Spol()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int SpolId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
