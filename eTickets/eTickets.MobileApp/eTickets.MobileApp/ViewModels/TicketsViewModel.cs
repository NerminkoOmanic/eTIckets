using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.MobileApp.Utility;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    
    public class TicketsViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        private string _vrsta { get; set; }
        public TicketsViewModel()
        {
            _vrsta = StaticHelper.VrstaTicket;
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Ticket> TicketsList { get; set; } = new ObservableCollection<Ticket>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var searchObject = new TicketSearchRequest();

            if (_vrsta != null)
            {
                if (_vrsta.Equals("activeAll"))
                {
                    searchObject.AktivnaProdaja = true;
                }
                if (_vrsta.Equals("active"))
                {
                    searchObject.AktivnaProdaja = true;
                    searchObject.
                }
                if (_vrsta.Equals("selling"))
                {
                    searchObject.AktivnaProdaja = true;
                }
                if (_vrsta.Equals("buying"))
                {
                    searchObject.AktivnaProdaja = true;
                }
            }

            var list = await _ticketsService.Get<List<Ticket>>(searchObject);

            TicketsList.Clear();
            foreach (var ticket in list)
            {
                TicketsList.Add(ticket);
            }
        }
    }
}
