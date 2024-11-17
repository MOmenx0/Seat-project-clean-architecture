using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.Common.Repositories
{
    public interface ITestRepository : IBaseRepository<Tests>
    {
        int CreateTest(Tests test);
    }
}
