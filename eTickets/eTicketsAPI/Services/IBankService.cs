using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface IBankService
    {
        bool Get(BankAccountRequest request);
        eTickets.Model.BankTransaction Insert(OnlinePaymentRequest request);
    }
}
