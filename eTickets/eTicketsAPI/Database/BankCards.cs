using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class BankCards
    {
        public BankCards()
        {
            BankTransactions = new HashSet<BankTransactions>();
        }

        public string CardId { get; set; }
        public int ControlNumber { get; set; }
        public string CardOwner { get; set; }
        public string CardValid { get; set; }
        public string AccountId { get; set; }

        public virtual BankAccounts Account { get; set; }
        public virtual ICollection<BankTransactions> BankTransactions { get; set; }
    }
}
