using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Views;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _korisnikService = new APIService("korisnik");
        private readonly APIService _gradService = new APIService("grad");
        private readonly APIService _spolService = new APIService("spol");
        private readonly APIService _ulogaService = new APIService("uloga");


        public bool EditProfile { get; set; }
        private int _klijentUlogaId;
        public RegisterViewModel()
        {

            InitCommand = new Command(async () => await Init());
            RegistrationCommand = new Command(async () =>
            {
                await Register();

            });
        }

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
            get => _telefon;
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

        public ICommand RegistrationCommand { get; set; }

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

            if (_klijentUlogaId == 0)
            {
                var ulogeList = await _ulogaService.Get<List<Uloga>>(null);
                foreach (var uloga in ulogeList)
                {
                    if (uloga.Naziv.Equals("Klijent"))
                    {
                        _klijentUlogaId = uloga.UlogaId;
                    }
                }
            }
            
        }

        #region Validation
        private bool ValidateEmptyFields()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Ime) || string.IsNullOrEmpty(Prezime)
                || string.IsNullOrEmpty(KorisnickoIme) || string.IsNullOrEmpty(Lozinka) || string.IsNullOrEmpty(LozinkaProvjera)
                || SelectedGrad==null || SelectedSpol ==null || string.IsNullOrEmpty(Telefon))
            {
                return false;
            }
            return true;
        }

        private bool ValidatePasswordMatch()
        {
            if (Lozinka.Equals(LozinkaProvjera))
            {
                return true;
            }

            return false;
        }

        private bool ValidateEmail()
        {
            if (Email.Contains("@") && Email.Contains("."))
            {
                return true;
            }

            return false;
        }

        #endregion

        async Task Register()
        {

            if (ValidateEmptyFields()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You have to fill in all the fields", "OK");
                return;
            }

            if (ValidatePasswordMatch()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password and confirmation does not match", "OK");
                return;
            }

            if (ValidateEmail()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email needs to be in format xxx@xxx.xxx", "OK");
                return;
            }


            var searchRequest = new KorisnikSearchRequest()
            {
                EmailValidacija = Email
            };
            var emailLst = await _korisnikService.Get<List<Korisnik>>(searchRequest);
            if (emailLst.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email already exist", "OK");
                return;
            }


            searchRequest.EmailValidacija = null;
            searchRequest.KorisnickoIme = KorisnickoIme;
            var usernameList = await _korisnikService.Get<List<Korisnik>>(searchRequest);
            if (usernameList.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username already exist", "OK");
                return;
            }


            var request = new KorisnikInsertRequest()
                {

                    DatumRodjenja = DatumRodenja,
                    SpolId = SelectedSpol.SpolId,
                    Email = Email,
                    Ime = Ime,
                    Prezime = Prezime,
                    KorisnickoIme = KorisnickoIme,
                    Lozinka = Lozinka,
                    LozinkaPotvrda = LozinkaProvjera,
                    GradId = SelectedGrad.GradId,
                    UlogaId = _klijentUlogaId,
                    Telefon = Telefon
                };


            var noviKorisnik = await _korisnikService.Insert<Korisnik>(request);


            if (noviKorisnik != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered your account! You will now be redirected to login page.", "OK");
                APIService.PrijavljeniKorisnik = null;
                APIService.Username = null;
                APIService.Password = null;
                Application.Current.MainPage = new LoginPage();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Registration failed, please try again", "OK");
            }
           
        }

    }
}
