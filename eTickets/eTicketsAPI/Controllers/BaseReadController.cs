using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTicketsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseReadController<T> : ControllerBase where T:class
    {
        protected readonly IReadService<T> _service;

        public BaseReadController(IReadService<T> service)
        {
            _service = service;
        }

        // GET: api/Drzava
        [HttpGet]
        public virtual IEnumerable<T> GetDrzava()
        {
            return _service.Get();
        }

        // GET: api/Drzava/5
        [HttpGet("{id}")]
        public virtual T GetDrzavaById(int id)
        {
            return _service.GetById(id);
        }
    }
}
