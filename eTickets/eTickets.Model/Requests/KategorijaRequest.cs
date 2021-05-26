using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KategorijaRequest
    {
        [Required]
        public string Naziv { get; set; }

    }
}
