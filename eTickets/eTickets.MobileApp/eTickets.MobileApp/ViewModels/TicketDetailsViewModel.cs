using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class TicketDetailsViewModel : BaseViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private readonly APIService _kupovineService = new APIService("kupovine");
        private readonly APIService _slikaService = new APIService("slika");




        public int Id { get; set; }



        #region Properties

        string _nazivDogadjaja;
        string _sektor;
        string _red;
        string _sjedalo;
        string _cijena;
        DateTime _datum; 
        byte[] _slika;
        string _grad;
        string _kupac;
        string _prodavac;


        public string Kupac
        {
            get => _kupac;
            set => SetProperty(ref _kupac, value);
        }
        public string Prodavac
        {
            get => _prodavac;
            set => SetProperty(ref _prodavac, value);
        }
        public string Grad
        {
            get => _grad;
            set => SetProperty(ref _grad, value);
        }
        public byte[] Slika
        {
            get => _slika;
            set => SetProperty(ref _slika, value);
        }
        public DateTime Datum
        {
            get => _datum;
            set => SetProperty(ref _datum, value);
        }
        public string Cijena
        {
            get => _cijena;
            set => SetProperty(ref _cijena, value);
        }
        public string Sjedalo
        {
            get => _sjedalo;
            set => SetProperty(ref _sjedalo, value);
        }
        public string Red
        {
            get => _red;
            set => SetProperty(ref _red, value);
        }
        public string NazivDogadjaja
        {
            get => _nazivDogadjaja;
            set => SetProperty(ref _nazivDogadjaja, value);
        }
        public string Sektor
        {
            get => _sektor;
            set => SetProperty(ref _sektor, value);
        }
        
        
        #endregion
        
        public TicketDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            CancelCommand = new Command(async () => await Cancel());
        }

        public ICommand InitCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public async Task Init()
        {

            if (Id != 0)
            {
                if (StaticHelper.VrstaTicket.Equals("selling") || StaticHelper.VrstaTicket.Equals("buying"))
                {
                    var searchRequest = new KupovineSearchRequest()
                    {
                        TicketId = Id
                    };
                    var lstResponse = await _kupovineService.Get<List<Kupovine>>(searchRequest);

                    var response = lstResponse.FirstOrDefault();

                    if (response != null)
                    {
                        Sektor = response.Ticket.Sektor;
                        NazivDogadjaja = response.NazivDogadjaja;
                        Cijena = response.CijenaString;
                        Datum = response.Ticket.Datum;
                        Slika = response.Ticket.Slika.SlikaBytes;
                        Grad = response.Ticket.Grad.Naziv;
                        Kupac = response.KupacString;
                        Prodavac = response.ProdavacString;

                        if (response.Ticket.Red != 0)
                        {
                            Red = response.Ticket.Red.ToString();
                        }
                        else
                        {
                            Red = "-";
                        }

                        if (response.Ticket.Sjedalo != null)
                        {
                            Sjedalo = response.Ticket.Sjedalo;
                        }
                    }
                }
                else
                {
                    var response = await _ticketsService.GetById<Ticket>(Id);

                    Sektor = response.Sektor;
                    NazivDogadjaja = response.NazivDogadjaja;
                    Sjedalo = response.Sjedalo;
                    Cijena = response.Cijena.ToString(CultureInfo.InvariantCulture);
                    Datum = response.Datum;
                    Slika = response.Slika.SlikaBytes;
                    Grad = response.Grad.Naziv;

                    if (response.Red != 0)
                    {
                        Red = response.Red.ToString();
                    }
                    else
                    {
                        Red = "-";
                    }
                }

                Title = "Ticket details";
            }
            
        }

        public async Task Cancel()
        {
            var entity = await _ticketsService.GetById<eTickets.Model.Ticket>(Id);

            if (await _ticketsService.Remove(Id))
            {
                if (await _slikaService.Remove(entity.SlikaId))
                {
                    if (StaticHelper.VrstaTicket.Equals("active"))
                        await Shell.Current.DisplayAlert("Success", "Ticket is removed", "OK");

                    if (StaticHelper.VrstaTicket.Equals("request"))
                        await Shell.Current.DisplayAlert("Success", "Request is canceled", "OK");

                    Application.Current.MainPage = new AppShell();
                }
            }
            else
            {
                        await Shell.Current.DisplayAlert("Error", "Ticket is already sold or deleted", "OK");
                        Application.Current.MainPage = new AppShell();
            }

            
        }
        

    }
}
