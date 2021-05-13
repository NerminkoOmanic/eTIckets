using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class Grad
    {
        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public virtual Drzava Drzava { get; set; }
    }
}
