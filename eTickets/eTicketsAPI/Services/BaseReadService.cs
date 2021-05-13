using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch:class
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;

        public BaseReadService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var dbSet = Context.Set<TDb>();

            var list = dbSet.ToList();

            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var dbSet = Context.Set<TDb>();
            
            var entity = dbSet.Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
