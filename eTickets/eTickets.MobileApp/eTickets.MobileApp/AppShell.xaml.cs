using eTickets.MobileApp.ViewModels;
using eTickets.MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eTickets.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            var routeAktivne = $"//{nameof(TicketsPage)}?VrstaListe=Aktivna";

            //var routeProdaje = $"{nameof(TicketsPage)}?VrstaListe=Prodaja";
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Shell.Current.GoToAsync(routeAktivne);
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnMenuItemBoughtClicked(object sender, EventArgs e)
        {
            var routeKupovine = $"//{nameof(TicketsPage)}?VrstaListe=Kupovina";

            await Shell.Current.GoToAsync(routeKupovine);
        }
        private async void OnMenuItemSoldClicked(object sender, EventArgs e)
        {
            var routeKupovine = $"//{nameof(TicketsPage)}?VrstaListe=Prodaja";

            await Shell.Current.GoToAsync(routeKupovine);
        }
    }
}
