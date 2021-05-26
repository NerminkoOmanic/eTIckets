using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class BankAccounts
    {
        public BankAccounts()
        {
            BankCards = new HashSet<BankCards>();
            BankTransactions = new HashSet<BankTransactions>();
        }

        public string AccountId { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<BankCards> BankCards { get; set; }
        public virtual ICollection<BankTransactions> BankTransactions { get; set; }
    }
}
