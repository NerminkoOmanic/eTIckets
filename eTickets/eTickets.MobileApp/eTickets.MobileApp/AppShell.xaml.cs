using eTickets.MobileApp.ViewModels;
using eTickets.MobileApp.Views;
using System;
using System.Collections.Generic;
using eTickets.MobileApp.Utility;
using Xamarin.Forms;

namespace eTickets.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(TicketsPage),typeof(TicketsPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddBankAccountPage),typeof(AddBankAccountPage));
            Routing.RegisterRoute(nameof(RegisterPage),typeof(RegisterPage));
            Routing.RegisterRoute(nameof(TicketDetailsPage),typeof(TicketDetailsPage));
            Routing.RegisterRoute(nameof(AddTicketPage),typeof(AddTicketPage));

            
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {

            if (args.Target.Location.OriginalString.Contains("ActiveTickets"))
            {
                StaticHelper.VrstaTicket = "activeAll";
            }
            else if (args.Target.Location.OriginalString.Contains("ActiveRoute"))
            {
                StaticHelper.VrstaTicket = "active";
            }
            else if (args.Target.Location.OriginalString.Contains("BuyingRoute"))
            {
                StaticHelper.VrstaTicket = "buying";
            }
            else if (args.Target.Location.OriginalString.Contains("SellingRoute"))
            {
                StaticHelper.VrstaTicket = "selling";
            }
            else if (args.Target.Location.OriginalString.Contains("RequestRoute"))
            {
                StaticHelper.VrstaTicket = "request";
            }
            base.OnNavigating(args);

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            APIService.PrijavljeniKorisnik = null;
            APIService.Password = null;
            APIService.Username = null;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
