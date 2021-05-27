using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Ticket = eTickets.Model.Ticket;

namespace eTicketsAPI.Services
{
    public class BankService : IBankService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;
        public BankService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public bool Get(string requestAccount)
        {
            if (Context.BankAccounts.FirstOrDefault(x => x.AccountId.Equals(requestAccount)) != null)
                return true;
            return false;
            
        }

        public int Insert(OnlinePaymentRequest request)
        {
            var card = Context.BankCards.Include(x=>x.Account)
                .FirstOrDefault(x => x.CardId.Equals(request.CardId));
            if (!ConfirmCard(request, card))
                return 0;

            //Naplata kupcu
            var accountKupac = Context.BankAccounts.FirstOrDefault(x=>x.AccountId == card.AccountId);
            accountKupac.Balance -= request.Cijena;

            //Isplata prodavacu
            var accountProdavac = Context.BankAccounts.FirstOrDefault(x => x.AccountId.Equals(request.Account));
            accountProdavac.Balance += request.Cijena;

            var entity = new BankTransactions()
            {
                CardId = request.CardId,
                Iznos = request.Cijena,
                Datum = DateTime.Now,
                AccountId = request.Account
            };

            Context.BankTransactions.Add(entity);
            Context.SaveChanges();

            return entity.TransactionId;

        }

        private bool ConfirmCard(OnlinePaymentRequest request, BankCards card)
        {
            if (card.CardOwner.Equals(request.CardOwner) && card.CardValid.Equals(request.CardValid)
                                                         && card.ControlNumber == request.ControlNumber
                                                         && card.Account.Balance>=request.Cijena)
            {
                return true;
            }

            return false;
        }
        public eTickets.Model.Kupovine Insert(KupovineInsertRequest request)
        {
            var entity = new Database.Kupovine();

            _mapper.Map(request, entity);

            Context.Kupovine.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<eTickets.Model.Kupovine>(entity);
        }

    }
}
