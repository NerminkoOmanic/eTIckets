using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using eTicketsAPI.Filters;
using Microsoft.EntityFrameworkCore;

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

        public bool Get(BankAccountRequest request)
        {
            if (Context.BankAccounts.FirstOrDefault(x => x.AccountId.Equals(request.AccountId)) != null)
                return true;
            return false;
        }

        public eTickets.Model.BankTransaction Insert(OnlinePaymentRequest request)
        {
            
                var card = Context.BankCards.Include(x=>x.Account)
                    .FirstOrDefault(x => x.CardId.Equals(request.CardId));
                if (ConfirmCard(request, card))
                {
                    var entity = new BankTransactions();

                    _mapper.Map(request, entity);

                    Context.BankTransactions.Add(entity);

                    //Naplata kupcu
                    var accountKupac = Context.BankAccounts.FirstOrDefault(x=>x.AccountId == card.AccountId);
                    if (accountKupac != null)
                    {
                        accountKupac.Balance -= request.Iznos;
                    }

                    //Isplata prodavacu
                    var accountProdavac = Context.BankAccounts.FirstOrDefault(x => x.AccountId.Equals(request.AccountId));
                    if (accountProdavac != null)
                    {
                        accountProdavac.Balance += request.Iznos;
                    }

                    Context.SaveChanges();

                    var result = new eTickets.Model.BankTransaction();

                    _mapper.Map(entity, result);

                    return result;

                }

                return null;

            
            

        }

        private bool ConfirmCard(OnlinePaymentRequest request, BankCards card)
        {
            if (card.CardOwner.Equals(request.CardOwner) && card.CardValid.Equals(request.CardValid)
                                                         && card.ControlNumber == request.ControlNumber
                                                         && card.Account.Balance>=request.Iznos)
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
