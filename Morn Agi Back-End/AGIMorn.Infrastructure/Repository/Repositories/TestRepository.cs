using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Repositories;
using AGI.Morn.Domain.Entities;
using AGI.Morn.Infrastructure.Data;
using AGI.Morn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Infrastructure.Repository.Repositories
{
    public class TestRepository : BaseRepository<Tests> 
    {
        public TestRepository(ApplicationDbContext context) : base(context) {
        }


    }
}
