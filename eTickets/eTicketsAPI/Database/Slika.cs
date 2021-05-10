using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Slika
    {
        public Slika()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int SlikaId { get; set; }
        public byte[] Slika1 { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
