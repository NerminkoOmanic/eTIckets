using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    public class OnlinePaymentViewModel : BaseViewModel
    {
        private readonly APIService _ticketService = new APIService("ticket");
        private readonly APIService _bankService = new APIService("bank");
        private readonly APIService _kupovineService = new APIService("kupovine");

        public int TicketId { get; set; }


        #region Properties

        string _card;
        string _controlNumber;
        string _cardOwner;
        string _cardValid;

        public string Card
        {
            get => _card;
            set => SetProperty(ref _card, value);
        }
        public string ControlNumber
        {
            get => _controlNumber;
            set => SetProperty(ref _controlNumber, value);
        }
        public string CardOwner
        {
            get => _cardOwner;
            set => SetProperty(ref _cardOwner, value);
        }
        public string CardValid
        {
            get => _cardValid;
            set => SetProperty(ref _cardValid, value);
        }
        
        #endregion

        #region Validation


        private bool ValidateEmpty()
        {
            if (string.IsNullOrWhiteSpace(Card) || string.IsNullOrWhiteSpace(CardOwner) ||
                string.IsNullOrWhiteSpace(CardValid) || string.IsNullOrWhiteSpace(ControlNumber))
            {
                return false;
            }

            return true;
        }

        private bool ValidateControlNumber()
        {
            foreach (var x in ControlNumber)
            {
                if (!Char.IsDigit(x))
                    return false;
            }

            return true;
        }

        #endregion
        public OnlinePaymentViewModel()
        {
            PayCommand = new Command(async () => await Pay());
        }
        public Command PayCommand { get; set; }

        public async Task Pay()
        {
            if (!ValidateEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all the fields", "OK");
                return;
            }
            if (!ValidateControlNumber())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Control number can contain only numbers !", "OK");
                return;
            }


            var ticket = await _ticketService.GetById<Ticket>(TicketId);



            OnlinePaymentRequest requestPayment = new OnlinePaymentRequest()
            {
                CardId = Card,
                CardOwner = CardOwner,
                ControlNumber = Int32.Parse(ControlNumber),
                CardValid = CardValid,
                AccountId = ticket.Prodavac.BankAccount,
                Iznos = ticket.Cijena,
                Datum = DateTime.Now
            };

            var result = await _bankService.Insert<eTickets.Model.BankTransaction>(requestPayment);

            if (result == null)
            {
                await Shell.Current.DisplayAlert("Error", "Wrong card details or insuficient balance", "OK");
                return;
            }

            var requestKupovine = new KupovineInsertRequest()
            {
                KupacId = APIService.PrijavljeniKorisnik.KorisnikId,
                Datum = DateTime.Now,
                TicketId = TicketId,
                TransakcijaId = result.TransactionId
            };

            await _kupovineService.Insert<eTickets.Model.Kupovine>(requestKupovine);

            await Shell.Current.DisplayAlert("Success", "You bought ticket, enjoy the event", "Ok");
            Application.Current.MainPage = new AppShell();

        }
    }
}
