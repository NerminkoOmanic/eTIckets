using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class PodKategorija
    {
        public PodKategorija()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PodKategorijaId { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
