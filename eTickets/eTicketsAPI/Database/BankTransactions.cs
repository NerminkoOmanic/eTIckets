using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class BankTransactions
    {
        public int TransactionId { get; set; }
        public string CardId { get; set; }
        public decimal Iznos { get; set; }
        public DateTime Datum { get; set; }
        public string AccountId { get; set; }

        public virtual BankAccounts Account { get; set; }
        public virtual BankCards Card { get; set; }
    }
}
