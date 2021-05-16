using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Telefon { get; set; }

        public int? GradId { get; set; }

    }
}
