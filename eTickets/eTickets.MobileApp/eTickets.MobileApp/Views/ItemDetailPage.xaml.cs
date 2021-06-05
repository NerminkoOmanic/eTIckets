using eTickets.MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace eTickets.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}