using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Views;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;
using Exception = System.Exception;

namespace eTickets.MobileApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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
            RegistrationCommand = new Command(async () => await Register());
            AddBankCommand = new Command(async () => await OnAddBankClicked());
            Title = "Register";
        }

        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        public ObservableCollection<Spol> SpolList { get; set; } = new ObservableCollection<Spol>();

        #region Properties

        string _bankaccount = string.Empty;
        public string BankAccount
        {
            get => _bankaccount;
            set => SetProperty(ref _bankaccount, value);
        }

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
            set => SetProperty(ref _selectedGrad, value);
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
        public ICommand AddBankCommand { get; set; }


        #region Validation
        private bool ValidateEmptyFields()
        {
            if (EditProfile)
            {
                if (string.IsNullOrEmpty(Email) || SelectedGrad==null || string.IsNullOrEmpty(Telefon))
                {
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Ime) || string.IsNullOrEmpty(Prezime)
                    || string.IsNullOrEmpty(KorisnickoIme) || string.IsNullOrEmpty(Lozinka) || string.IsNullOrEmpty(LozinkaProvjera)
                    || SelectedGrad==null || SelectedSpol ==null || string.IsNullOrEmpty(Telefon))
                {
                    return false;
                }
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

        private bool ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(Telefon))
                return false;
            

            int loopIndex = 0;

            foreach (var letter in Telefon)
            {
                if (loopIndex == 0 && char.IsSymbol(letter) && !letter.Equals(char.Parse("+")))
                    return false;
            

                if (Char.IsLetter(letter))
                    return false;
                

                if (loopIndex != 0 && char.IsSymbol(letter))
                    return false;

                loopIndex++;
            }


            return true;
        }
        

        private bool ValidateEmailFormat()
        {
            try
            {
                MailAddress mail = new MailAddress(Email);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ValidateEmailUniqueEdit(List<Korisnik> lst)
        {
            foreach (var korisnik in lst)
            {
                if(korisnik.Email == Email && korisnik.KorisnikId != APIService.PrijavljeniKorisnik.KorisnikId)
                    return false;
            }

            return true;
        }
        
        #endregion

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

            if (APIService.PrijavljeniKorisnik != null)
            {
                EditProfileSetProperties();
            }
            
        }
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

            if (ValidateEmailFormat()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email needs to be in valid format", "OK");
                return;
            }

            if (ValidatePhone() == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Phone number needs to be in valid format (eg. +123456788", "OK");
                return;
            }


            var searchRequest = new KorisnikSearchRequest()
            {
                EmailValidacija = Email
            };
            var emailLst = await _korisnikService.Get<List<Korisnik>>(searchRequest);
            if (emailLst.Count > 0 && !EditProfile)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email already exist", "OK");
                return;
            }
            if (emailLst.Count > 0 && EditProfile)
            {
                if (!ValidateEmailUniqueEdit(emailLst))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email already exist", "OK");
                    return;
                }
            }

            if (EditProfile)
            {
                var request = new KorisnikUpdateRequest()
                {
                    Email = Email,
                    BankAccount = BankAccount,
                    GradId = SelectedGrad.GradId,
                    Lozinka = Lozinka,
                    Telefon = Telefon
                };

                var updatedKorisnik = await _korisnikService.Update<Korisnik>(APIService.PrijavljeniKorisnik.KorisnikId, request);
                await Application.Current.MainPage.DisplayAlert("Success", "Profile updated!","OK");

                APIService.PrijavljeniKorisnik = updatedKorisnik;
                if (!string.IsNullOrEmpty(Lozinka))
                {
                    APIService.Password = Lozinka;
                }
                Application.Current.MainPage = new AppShell();

            }
            else
            {
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
                await _korisnikService.Insert<Korisnik>(request);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered your account! You will now be redirected to login page.", "OK");
                Application.Current.MainPage = new LoginPage();

            }

            

           
        }

        public async Task OnAddBankClicked()
        {
            var route = $"{nameof(AddBankAccountPage)}";
            await Shell.Current.GoToAsync(route);
        }
        private void EditProfileSetProperties()
        {
            Title = "Edit profile";
            EditProfile = true;
            Email = APIService.PrijavljeniKorisnik.Email;
            Telefon = APIService.PrijavljeniKorisnik.Telefon;
            if(APIService.PrijavljeniKorisnik.BankAccount!=null)
                BankAccount = APIService.PrijavljeniKorisnik.BankAccount;
            SelectedGrad = GradoviList.FirstOrDefault(x => x.GradId == APIService.PrijavljeniKorisnik.GradId);
        }

    }
}
