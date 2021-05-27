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
        public decimal Cijena { get; set; }
        public string Account { get; set; }
    }
}
