using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTickets.Model.Requests
{
    public class PodKategorijaRequest
    {
        [Required]
        public int KategorijaId { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}
