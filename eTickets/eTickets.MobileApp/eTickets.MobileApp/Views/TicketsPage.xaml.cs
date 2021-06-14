using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTickets.MobileApp.Utility;
using eTickets.MobileApp.ViewModels;
using eTickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTickets.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage : ContentPage
    {
        private TicketsViewModel _model = null;
        public TicketsPage()
        {
            InitializeComponent();
            BindingContext = _model = new TicketsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _model.SelectedPodKategorija = null;
            await _model.Init();
            if (!StaticHelper.VrstaTicket.Equals("request"))
            {
                AddToolBar.IsEnabled = false;
                AddToolBar.Text = "";
                AddToolBar.IconImageSource = null;
            }

            if (!StaticHelper.VrstaTicket.Equals("activeAll"))
            {
                PickerKategorija.IsVisible = false;
            }
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var ticket = ((ListView) sender).SelectedItem as Ticket;

                if (ticket == null)
                    return;

                await Navigation.PushAsync(new TicketDetailsPage(ticket.TicketId)); 
            
            

        }

        private async void AddToolBar_OnClicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(APIService.PrijavljeniKorisnik.BankAccount))
                await Navigation.PushAsync(new AddTicketPage());
            else
            {
                await Shell.Current.DisplayAlert("Error", "You need to add bank account first", "OK");
                return;
            }
        }
    }
}