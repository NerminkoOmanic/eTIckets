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
        private string _activeTicket = "active";
        private string _sellingTicket = "selling";
        private string _boughtTicket = "buying";
        public AppShell()
        {

            //var routeProdaje = $"{nameof(TicketsPage)}?VrstaListe=Prodaja";
            InitializeComponent();
            Routing.RegisterRoute(nameof(TicketsPage),typeof(TicketsPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            
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
                StaticHelper.VrstaTicket = "selling";
            }
            else if (args.Target.Location.OriginalString.Contains("SellingRoute"))
            {
                StaticHelper.VrstaTicket = "buying";
            }
            base.OnNavigating(args);

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnMenuItemBoughtClicked(object sender, EventArgs e)
        {
            var routeKupovine = $"//{nameof(TicketsPage)}?VrstaListe={_boughtTicket}";

            await Shell.Current.GoToAsync(routeKupovine);
        }
        private async void OnMenuItemActiveClicked(object sender, EventArgs e)
        {
            var routeKupovine = $"//{nameof(TicketsPage)}?VrstaListe={_activeTicket}";

            await Shell.Current.GoToAsync(routeKupovine);
        }
        private async void OnMenuItemSoldClicked(object sender, EventArgs e)
        {
            var routeKupovine = $"//{nameof(TicketsPage)}?VrstaListe={_sellingTicket}";

            await Shell.Current.GoToAsync(routeKupovine);
        }
    }
}
