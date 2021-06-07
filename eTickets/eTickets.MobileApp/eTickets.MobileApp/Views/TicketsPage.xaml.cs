using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTickets.MobileApp.Utility;
using eTickets.MobileApp.ViewModels;
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
            await _model.Init();
            if (!StaticHelper.VrstaTicket.Equals("request"))
            {
                AddToolBar.IsEnabled = false;
                AddToolBar.Text = "";
                AddToolBar.IconImageSource = null;
            }
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}