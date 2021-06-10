using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.MobileApp.ViewModels
{
    public class AddBankAccountViewModel : BaseViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private readonly APIService _bankService = new APIService("bank");

        public AddBankAccountViewModel()
        {

        }

        string _bankaccount = string.Empty;
        public string BankAccount
        {
            get => _bankaccount;
            set => SetProperty(ref _bankaccount, value);
        }

    }
}
