using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            PodKategorijas = new HashSet<PodKategorija>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<PodKategorija> PodKategorijas { get; set; }
    }
}
