using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTickets.MobileApp.Converters;
using eTickets.MobileApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTickets.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTicketPage : ContentPage
    {
        private AddTicketViewModel _model = null;

        public AddTicketPage()
        {
            InitializeComponent();
            BindingContext = _model = new AddTicketViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DpDatum.Date= DateTime.Today;
            await _model.Init();
        }

        private async void ButtonPickImage_OnClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);


               
                _model.Slika= StreamToByte.ReadFully(stream);

                        //var memorystream = new MemoryStream();

                //await stream.CopyToAsync(memorystream);

                //_model.Slika = memorystream.ToArray();
            }

        }

        private async void ButtonTakeImage_OnClicked(object sender, EventArgs e)
        {
            if (!MediaPicker.IsCaptureSupported)
                await Shell.Current.DisplayAlert("Error", "Taking picture is not supported", "OK");
            else
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result!=null)
                {
                    var stream = await result.OpenReadAsync();

                    resultImage.Source = ImageSource.FromStream(() => stream);

                    var memorystream = new MemoryStream();

                    await stream.CopyToAsync(memorystream);

                    _model.Slika = memorystream.ToArray();

                   
                }
            }
            
            
        }

        #region ValidationLabels

        private void naziv_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryNaziv.Text))
            {
                ErrorLabel_Naziv.IsVisible = true;
                ErrorLabel_Naziv.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Naziv.IsVisible = false;
            }
        }
        private void naziv_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryNaziv.Text))
            {
                ErrorLabel_Naziv.IsVisible = true;
                ErrorLabel_Naziv.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Naziv.IsVisible = false;
            }
        }

        private void cijena_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryCijena.Text))
            {
                ErrorLabel_Cijena.IsVisible = true;
                ErrorLabel_Cijena.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Cijena.IsVisible = false;
            }
        }
        private void cijena_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryCijena.Text))
            {
                ErrorLabel_Cijena.IsVisible = true;
                ErrorLabel_Cijena.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Cijena.IsVisible = false;
            }
        }

        private void sektor_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(EntrySektor.Text))
            {
                ErrorLabel_Sektor.IsVisible = true;
                ErrorLabel_Sektor.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Sektor.IsVisible = false;
            }
        }
        private void sektor_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(EntrySektor.Text))
            {
                ErrorLabel_Sektor.IsVisible = true;
                ErrorLabel_Sektor.Text = "*Field is required";
            }
            else
            {
                ErrorLabel_Sektor.IsVisible = false;
            }
        }

        #endregion
    }
}