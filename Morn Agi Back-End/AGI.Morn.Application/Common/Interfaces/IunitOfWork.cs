using AGI.Morn.Application.Common.Repositories;
using AGI.Morn.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.Common.Interfaces
{
    public interface IunitOfWork :IDisposable
    {
        IBaseRepository<productTypes> TypeRepositories { get; }
        IBaseRepository<productPrand> PrandsRepository { get; } 
        IBaseRepository<Product> ProductsRepository { get; }
        ITestRepository TestRepository { get; }
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        Task CommitTransactionAsync();
        void RollbackTransaction();
        Task RollbackTransactionAsync();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
