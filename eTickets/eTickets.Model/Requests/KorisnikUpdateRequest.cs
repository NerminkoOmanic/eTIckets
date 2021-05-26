using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefon { get; set; }
        public string Lozinka { get; set; }
        public int GradId { get; set; }
        public string LozinkaHash { get; set;}
        public string LozinkaSalt { get; set; }

    }
}
