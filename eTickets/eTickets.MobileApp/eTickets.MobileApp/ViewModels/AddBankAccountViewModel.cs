using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Views;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    public class AddBankAccountViewModel : BaseViewModel
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _bankService = new APIService("bank");

        public AddBankAccountViewModel()
        {
            AddBankAccountCommand = new Command(async () => await AddBankAccount());
            Title = "Add bank account";

        }

        string _bankaccount = string.Empty;
        public string BankAccount
        {
            get => _bankaccount;
            set => SetProperty(ref _bankaccount, value);
        }

        public ICommand AddBankAccountCommand { get; set; }

        public void Init()
        {
            if (APIService.PrijavljeniKorisnik.BankAccount != null)
                BankAccount = APIService.PrijavljeniKorisnik.BankAccount;
        }
        public async Task AddBankAccount()
        {
            var bankRequest = new BankAccountRequest()
            {
                AccountId = BankAccount
            };

            if (await _bankService.Get<bool>(bankRequest))
            {
                var korisnikRequest = new KorisnikUpdateRequest()
                {
                    BankAccount = BankAccount,
                    Email = APIService.PrijavljeniKorisnik.Email,
                    Telefon = APIService.PrijavljeniKorisnik.Telefon

                };

                var updatedKorisnik = await _korisnikService.Update<Korisnik>(APIService.PrijavljeniKorisnik.KorisnikId, korisnikRequest);

                await Application.Current.MainPage.DisplayAlert("Success", "Bank account added", "OK");

                APIService.PrijavljeniKorisnik = updatedKorisnik;

                await Shell.Current.GoToAsync("..");
            }
            else
            {
            await Application.Current.MainPage.DisplayAlert("Error", "Bank account does not exist", "OK");

            }
        }

    }
}
