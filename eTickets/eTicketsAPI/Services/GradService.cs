using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class GradService : BaseReadService<eProdaja.Model.Grad,Database.Grad>, IGradService
    {

        public GradService(IB3012Context context, IMapper mapper) : base(context,mapper)
        {
        }

    }
}
