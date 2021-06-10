using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Utility;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{

    public class TicketsViewModel : BaseViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private readonly APIService _kupovineService = new APIService("kupovine");

        private string _vrsta { get; set; }

        public TicketsViewModel()
        {
            _vrsta = StaticHelper.VrstaTicket;
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Ticket> TicketsList { get; set; } = new ObservableCollection<Ticket>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var searchObjectTicket = new TicketSearchRequest();
            var searchObjectKupovine = new KupovineSearchRequest();

            if (_vrsta != null)
            {
                if (_vrsta.Equals("activeAll"))
                {
                    searchObjectTicket.AktivnaProdaja = true;
                    Title = "Tickets";
                }

                if (_vrsta.Equals("active"))
                {
                    searchObjectTicket.AktivnaProdaja = true;
                    searchObjectTicket.KorisnikId = APIService.PrijavljeniKorisnik.KorisnikId;
                    Title = "Active tickets";

                }

                if (_vrsta.Equals("selling"))
                {
                    searchObjectTicket.Prodano = true;
                    searchObjectTicket.KorisnikId = APIService.PrijavljeniKorisnik.KorisnikId;
                    Title = "Sold tickets";
                }

                if (_vrsta.Equals("buying"))
                {
                    searchObjectKupovine.KorisnikId = APIService.PrijavljeniKorisnik.KorisnikId;
                    Title = "Bought tickets";

                }

                if (_vrsta.Equals("request"))
                {
                    searchObjectTicket.Zahtjev = true;
                    searchObjectTicket.KorisnikId = APIService.PrijavljeniKorisnik.KorisnikId;
                    Title = "Requests";
                }
            }

            if (_vrsta == "buying")
            {
                var list = await _kupovineService.Get<List<Kupovine>>(searchObjectKupovine);
                TicketsList.Clear();
                foreach (var kupovina in list)
                {
                    TicketsList.Add(kupovina.Ticket);
                } 
            }
            else
            {
                var list = await _ticketsService.Get<List<Ticket>>(searchObjectTicket);

                TicketsList.Clear();
                foreach (var ticket in list)
                {
                    TicketsList.Add(ticket);
                } 
            }
            
        }

    }
}
