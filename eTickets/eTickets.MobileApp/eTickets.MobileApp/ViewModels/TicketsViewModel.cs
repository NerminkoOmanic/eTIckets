using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eTickets.Model;
using eTickets.Model.Requests;
using Xamarin.Forms;

namespace eTickets.MobileApp.ViewModels
{
    public class TicketsViewModel
    {
        private readonly APIService _ticketsService = new APIService("ticket");
        public TicketsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Ticket> TicketsList { get; set; } = new ObservableCollection<Ticket>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var searchObject = new TicketSearchRequest()
            {
                AktivnaProdaja = true
            };

            var list = await _ticketsService.Get<List<Ticket>>(searchObject);

            TicketsList.Clear();
            foreach (var ticket in list)
            {
                TicketsList.Add(ticket);
            }
        }
    }
}
