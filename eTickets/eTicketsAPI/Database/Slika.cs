using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class Slika
    {
        public Slika()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int SlikaId { get; set; }
        public byte[] Slika1 { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
