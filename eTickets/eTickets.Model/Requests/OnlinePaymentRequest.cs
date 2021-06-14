using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class OnlinePaymentRequest
    {
        public string CardId { get; set; }
        public int ControlNumber { get; set; }
        public string CardOwner { get; set; }
        public string CardValid { get; set; }
        public decimal Iznos { get; set; }

        //bank account of user which is selling certain ticket
        public string AccountId { get; set; }

        public DateTime Datum { get; set; }
    }
}
