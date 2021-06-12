using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    public class AddTicketViewModel : BaseViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private readonly APIService _podkategorijeService = new APIService("podkategorija");
        private readonly APIService _gradService = new APIService("podkategorija");

        public AddTicketViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Submit());

        }



        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        public ObservableCollection<PodKategorija> PodKategorijaList { get; set; } = new ObservableCollection<PodKategorija>();

        #region Properties

        string _nazivDogadjaja;
        string _sektor;
        string _red;
        string _sjedalo;
        string _cijena;
        DateTime _datum; 
        byte[] _slika;
        Grad _selectedGrad = null;
        PodKategorija _selectedPodKategorija = null;
        
        
        public Grad SelectedGrad
        {
            get => _selectedGrad;
            set => SetProperty(ref _selectedGrad, value);
        }
        public PodKategorija SelectedPodKategorija
        {
            get => _selectedPodKategorija;
            set => SetProperty(ref _selectedPodKategorija, value);
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

        #region Validation

        private async Task ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(NazivDogadjaja))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Event is mandatory field", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(Cijena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Price is mandatory field", "OK");
                return;
            }

            if (SelectedGrad == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Choose city, it is mandatory field", "OK");
                return;
            }
            if (SelectedPodKategorija == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Choose type of event, it is mandatory field", "OK");
                return;
            }

            foreach (var x in Red)
            {
                if (!Char.IsDigit(x))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Row can contain only numbers", "OK");
                    return;
                }
            }
            //if(Slika == null)
        }
        private bool ValidatePrice(decimal request)
        {
            if (request != 0)
            {
                return true;
            }

            return false;
        }

        #endregion
        public ICommand InitCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public async Task Init()
        {
            if (GradoviList.Count == 0)
            {
                var gradovilist = await _gradService.Get<List<Grad>>(null);
                foreach (var grad in gradovilist)
                {
                    GradoviList.Add(grad);
                }
            }

            if (PodKategorijaList.Count == 0)
            {
                var podKategorijaList = await _gradService.Get<List<Grad>>(null);
                foreach (var grad in podKategorijaList)
                {
                    GradoviList.Add(grad);
                }
            }
        }
        
        public async Task Submit()
        {
            
            await ValidateFields();

            var ticketRequest = new TicketInsertRequest()
            {
                NazivDogadjaja = NazivDogadjaja,
                Datum = Datum,
                GradId = SelectedGrad.GradId,
                PodKategorijaId = SelectedPodKategorija.PodKategorijaId,
                ProdavacId = APIService.PrijavljeniKorisnik.KorisnikId,
                Cijena = decimal.Parse(Cijena),
                Sektor = Sektor,
                Red = Int32.Parse(Red),
                Sjedalo = Sjedalo,
                SlikaBytes = Slika
            };

            await _ticketsService.Insert<Ticket>(ticketRequest);
            await Application.Current.MainPage.DisplayAlert("Success", "Your request is waiting for approval", "OK");
            await Shell.Current.GoToAsync("..");

        }

    }
}
