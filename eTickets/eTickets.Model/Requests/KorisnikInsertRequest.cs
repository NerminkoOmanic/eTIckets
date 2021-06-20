using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KorisnikInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; } 

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        public string Telefon { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        [PasswordPropertyText]
        public string Lozinka { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        [PasswordPropertyText]
        public string LozinkaPotvrda { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public int UlogaId { get; set; }

        [Required]
        public int GradId { get; set; }

        [Required]
        public int SpolId { get; set; }


    }
}
