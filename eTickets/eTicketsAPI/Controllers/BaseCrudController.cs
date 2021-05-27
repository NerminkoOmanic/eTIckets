using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTicketsAPI.Controllers
{
    public class BaseCrudController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> 
        where T:class where TSearch:class where TInsert:class where TUpdate:class
    {
        protected readonly ICrudService<T, TSearch, TInsert, TUpdate> _crudService;

        public BaseCrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert([FromBody]TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, [FromBody]TUpdate request)
        {
            return _crudService.Update(id,request);
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            return _crudService.Remove(id);
        }
    }
}
