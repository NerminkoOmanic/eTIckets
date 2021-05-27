using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class BaseCrudService<T, TDb, TSearch, TInsert, TUpdate>
                : BaseReadService<T, TDb, TSearch>, ICrudService<T, TSearch , TInsert, TUpdate>
        where T : class where TSearch : class where TInsert : class where  TUpdate : class where TDb:class
    {
        public BaseCrudService(IB3012Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var dbSet = Context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            dbSet.Add(entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var dbSet = Context.Set<TDb>();

            TDb entity = dbSet.Find(id);

            _mapper.Map(request, entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);

        }

        public virtual bool Remove(int id)
        {
            var dbSet = Context.Set<TDb>();
            TDb entity = dbSet.Find(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
                Context.SaveChanges();
                return true;
            }
            
            return false;
            
        }
    }
}
