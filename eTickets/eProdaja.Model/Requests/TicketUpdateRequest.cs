using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class TicketUpdateRequest
    {

        [MinLength(3)]
        [Required]
        public string NazivDogadjaja { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public string Sektor { get; set; }

        public int? Red { get; set;}

        [Required]
        public decimal Cijena { get; set; }

    }
}
