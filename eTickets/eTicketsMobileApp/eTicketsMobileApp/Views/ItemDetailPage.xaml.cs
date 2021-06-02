using eTicketsMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace eTicketsMobileApp.Views
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