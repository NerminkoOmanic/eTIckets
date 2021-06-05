using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.Model;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _gradService = new APIService("grad");
        private readonly APIService _spolService = new APIService("spol");
        private readonly APIService _ulogaService = new APIService("uloga");

        public RegisterViewModel()
        {

            InitCommand = new Command(async () => await Init());
            RegistracijaCommand = new Command(async () =>
            {
                await Registracija();

            });
        }

        public int KlijentUlogaId { get; set; }
        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        public ObservableCollection<Spol> SpolList { get; set; } = new ObservableCollection<Spol>();

        #region Properties
         string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        string _ime = string.Empty;
        public string Ime
        {
            get => _ime;
            set => SetProperty(ref _ime, value);
        }


        string _prezime = string.Empty;
        public string Prezime
        {
            get => _prezime;
            set => SetProperty(ref _prezime, value);
        }
        string _korisnickoime = string.Empty;
        public string KorisnickoIme
        {
            get => _korisnickoime;
            set => SetProperty(ref _korisnickoime, value);
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get => _lozinka;
            set => SetProperty(ref _lozinka, value);
        }

        string _lozinkaprovjera = string.Empty;
        public string LozinkaProvjera
        {
            get => _lozinkaprovjera;
            set => SetProperty(ref _lozinkaprovjera, value);
        }

        string _telefon = string.Empty;
        public string Telefon
        {
            get => _email;
            set => SetProperty(ref _telefon, value);
        }

        DateTime _datumrodjenja ;
        public DateTime DatumRodenja
        {
            get => _datumrodjenja;
            set => SetProperty(ref _datumrodjenja, value);
        }


        Grad _selectedGrad = null;
        public Grad SelectedGrad
        {
            get => _selectedGrad;
            set
            {
                SetProperty(ref _selectedGrad, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        Spol _selectedSpol = null;
        public Spol SelectedSpol
        {
            get => _selectedSpol;
            set
            {
                SetProperty(ref _selectedSpol, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
        


        #endregion


        public ICommand InitCommand { get; set; }

        public ICommand RegistracijaCommand { get; set; }

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

            if (SpolList.Count == 0)
            {
                var spollist = await _spolService.Get<List<Spol>>(null);
                foreach (var spol in spollist)
                {

                    SpolList.Add(spol);
                }
            }
            var uloList = await _ulogaService.Get<List<Uloga>>(null);
                foreach (var uloga in uloList)
                {
                    if (uloga.Naziv.Equals("Klijent"))
                    {
                        KlijentUlogaId = uloga.UlogaId;
                    }
                }
            }
           




        }
    }
}
