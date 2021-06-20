using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Utility;
using eTickets.MobileApp.Views;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{

    public class TicketsViewModel : BaseViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private readonly APIService _podkategorijeService = new APIService("podkategorija");
        private readonly APIService _kupovineService = new APIService("kupovine");
        private readonly APIService _recommendService = new APIService("recommend");


        private string _vrsta { get; set; }

        public TicketsViewModel()
        {
            _vrsta = StaticHelper.VrstaTicket;
            InitCommand = new Command(async () => await Init());

        }

        public ObservableCollection<Ticket> TicketsList { get; set; } = new ObservableCollection<Ticket>();
        public ObservableCollection<PodKategorija> PodKategorijaList { get; set; } = new ObservableCollection<PodKategorija>();

        PodKategorija _selectedPodKategorija = null;
        private Ticket _selectedTicket = null;
        public PodKategorija SelectedPodKategorija
        {
            get => _selectedPodKategorija;
            set
            {
                SetProperty(ref _selectedPodKategorija, value);
                if (value!=null)
                {
                InitCommand.Execute(null);
                }
            }
        }


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {

            if (PodKategorijaList.Count == 0)
            {
                var lsPodtKategorija = await _podkategorijeService.Get<List<PodKategorija>>(null);
                PodKategorijaList.Clear();

                foreach (var item in lsPodtKategorija)
                {
                    PodKategorijaList.Add(item);
                }
            }
            
            var searchObjectTicket = new TicketSearchRequest();
            var searchObjectKupovine = new KupovineSearchRequest();

            if (_vrsta != null)
            {
                if (_vrsta.Equals("activeAll"))
                {
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

            if (SelectedPodKategorija != null)
            {
                searchObjectKupovine.PodKategorijaId = SelectedPodKategorija.PodKategorijaId;
                searchObjectTicket.PodKategorijaId = SelectedPodKategorija.PodKategorijaId;
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
            else if (_vrsta == "activeAll")
            {
                var lstTickets = await _recommendService.Get<List<Ticket>>(null);
                TicketsList.Clear();
                foreach (var ticket in lstTickets)
                {
                    TicketsList.Add(ticket);
                }
            }
            else
            {
                var lstTickets = await _ticketsService.Get<List<Ticket>>(searchObjectTicket);

                TicketsList.Clear();
                foreach (var ticket in lstTickets)
                {
                    TicketsList.Add(ticket);
                } 
            }

            

            
        }



    }
}
