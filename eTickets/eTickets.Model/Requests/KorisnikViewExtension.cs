using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KorisnikViewExtension : Korisnik
    {
        //nested props
        public string GradString => this.Grad.Naziv;
        public string SpolString => this.Spol.Naziv;

    }
}
