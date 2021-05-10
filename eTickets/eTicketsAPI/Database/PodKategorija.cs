using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class PodKategorija
    {
        public PodKategorija()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int PodKategorijaId { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
