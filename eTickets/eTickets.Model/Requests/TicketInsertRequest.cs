using System;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Model.Requests
{
    public class TicketInsertRequest
    {
        [Required]
        public int ProdavacId { get; set; }

        [MinLength(3)]
        [Required]
        public string NazivDogadjaja { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public string Sektor { get; set; }

        public int? Red { get; set; }

        [Required]
        public string Sjedalo { get; set; }

        [Required]
        public decimal Cijena { get; set; }

        [Required]
        public int SlikaId { get; set; }

        [Required]
        public int GradId { get; set; }

        [Required]
        public int PodKategorijaId { get; set; }
        public int? AdminId { get; set; }
        public bool Odobreno { get; set; }
        public bool Prodano { get; set; }
    }
}
