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
    public partial class OnlinePaymentPage : ContentPage
    {
        private OnlinePaymentViewModel _model = null;

        public OnlinePaymentPage(int ticketId)
        {
            InitializeComponent();
            BindingContext = _model = new OnlinePaymentViewModel();


            _model.TicketId = ticketId;
        }
    }
}