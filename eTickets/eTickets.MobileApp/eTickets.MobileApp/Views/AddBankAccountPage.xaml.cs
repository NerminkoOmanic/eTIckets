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
    public partial class AddBankAccountPage : ContentPage
    {
        private AddBankAccountViewModel bank= null;

        public AddBankAccountPage()
        {
            InitializeComponent();
            BindingContext = bank = new AddBankAccountViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bank.Init();
        }
    }
}