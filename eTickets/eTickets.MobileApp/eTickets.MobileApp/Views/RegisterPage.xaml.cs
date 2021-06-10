using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTickets.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTickets.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private RegisterViewModel register= null;

        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = register = new RegisterViewModel();
            

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabel_Ime.IsVisible = false;
            ErrorLabel_Prezime.IsVisible = false;
            ErrorLabel_KorisnickoIme.IsVisible = false;
            ErrorLabel_Email.IsVisible = false;
            ErrorLabel_Telefon.IsVisible = false;
            ErrorLabel_Lozinka.IsVisible = false;
            ErrorLabel_LozinkaProvjera.IsVisible = false;
            LabelBank.IsVisible = false;
            LabelValueBank.IsVisible = false;
            ButtonBank.IsVisible = false;
            Datum.Date= DateTime.Today;
            if (APIService.PrijavljeniKorisnik != null)
            {
                ButtonGoBack.IsVisible = false;
                LabelKorisnickoIme.IsVisible = false;
                KorisnickoIme.IsVisible = false;
                LabelDatum.IsVisible = false;
                Datum.IsVisible = false;
                LabelSpol.IsVisible = false;
                PickerSpol.IsVisible = false;
                LabelIme.IsVisible = false;
                Ime.IsVisible = false;
                LabelPrezime.IsVisible = false;
                Prezime.IsVisible = false;
                LabelTitle.Text = "Edit your profile";
                LabelTitle.FontSize = 20;
                LabelBank.IsVisible = true;
                LabelValueBank.IsVisible = true;
                ButtonBank.IsVisible = true;
            }
            await register.Init();
        }

        #region validationLabels
        private void ime_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "*First name is required";
            }
            else
            {
                ErrorLabel_Ime.IsVisible = false;
            }
        }
        private void ime_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "*First name is required";
            }
            else
            {
                ErrorLabel_Ime.IsVisible = false;
            }
        }
        private void prezime_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "*Last name is required";
            }
            else
            {
                ErrorLabel_Prezime.IsVisible = false;
            }
        }
        private void prezime_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "*Last name is required";
            }
            else
            {
                ErrorLabel_Prezime.IsVisible = false;
            }
        }
        private void korisnickoime_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(KorisnickoIme.Text))
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "*Username is required";
            }
            else
            {
                ErrorLabel_KorisnickoIme.IsVisible = false;
            }
        }
        private void korisnickoime_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(KorisnickoIme.Text))
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "*Username is required";
            }
            else
            {
                ErrorLabel_KorisnickoIme.IsVisible = false;

            }
          

        }
        private void email_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "*Email is required";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;

            }

        }
        private void email_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "*Email is required";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;

            }


        }
        private void telefon_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "*Phone number is required";
            }
            else
            {
                ErrorLabel_Telefon.IsVisible = false;

            }

        }
        private void telefon_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "*Phone number is required";
            }
            else
            {
                ErrorLabel_Telefon.IsVisible = false;

            }


        }
        private void lozinka_unfocused(object sender, System.EventArgs e)
        {
          

            if (string.IsNullOrEmpty(Lozinka.Text))
            {
                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "*Password is required";
            }
            else
            {
                ErrorLabel_Lozinka.IsVisible = false;
            }
            

        }
        private void lozinka_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Lozinka.Text))
            {
                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "*Password is required";
            }
            else if (Lozinka.Text.Length < 6)
            {
                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "*Password needs to contain at least 6 characters";
            }
            else
            {
                ErrorLabel_Lozinka.IsVisible = false;
            }


        }
        private void lozinkap_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Lozinkap.Text))
            {
                ErrorLabel_LozinkaProvjera.IsVisible = true;
                ErrorLabel_LozinkaProvjera.Text = "*Password confirmation is required";
            }
            else
            {
                ErrorLabel_LozinkaProvjera.IsVisible = false;


            }

        }
        private void lozinkap_changed(object sender, System.EventArgs e)
        {
            if (!Lozinkap.Text.Equals(Lozinka.Text))
            {
                ErrorLabel_LozinkaProvjera.IsVisible = true;
                ErrorLabel_LozinkaProvjera.Text = "*Password confirmation and password are not equal";
            }
            else
            {
                ErrorLabel_LozinkaProvjera.IsVisible = false;
            }
        }
        

        #endregion
        

        private async void ImageButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
           
        }
    }
}