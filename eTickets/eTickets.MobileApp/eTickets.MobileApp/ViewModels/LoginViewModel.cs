using eTickets.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("korisnik");
        public LoginViewModel()
        {
            LoginCommand = new Command(async() => await OnLoginClicked());
            RegisterCommand = new Command(OnRegisterClicked);
        }


        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        async Task OnLoginClicked()
        {
            IsBusy = true;

            APIService.Username = Username;
            APIService.Password = Password;

            //try
            //{
            //    await _service.Get<dynamic>(null);
            //    Application.Current.MainPage = new AboutPage();
            //}
            //catch (Exception e)
            //{

            //}

            try
            {
                APIService.PrijavljeniKorisnik = await _service.Get<eTickets.Model.Korisnik>(null, "profil");

                if (APIService.PrijavljeniKorisnik.Uloga.Naziv == "Klijent")
                {
                    Application.Current.MainPage = new AppShell();
                }

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "OK");

            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        
        private void OnRegisterClicked()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
