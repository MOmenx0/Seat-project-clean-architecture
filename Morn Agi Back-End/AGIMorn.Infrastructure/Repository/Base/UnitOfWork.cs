using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Repositories;
using AGI.Morn.Application.UseCases.ProductPrandCases.Queries;
using AGI.Morn.Domain.Entities;
using AGI.Morn.Infrastructure.Data;
using AGI.Morn.Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Infrastructure.Repository.Base
{
    public class UnitOfWork : IunitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public ITestRepository TestRepository { get; private set; }
        public IBaseRepository<productPrand> PrandsRepository { get;  private set; }
        public IBaseRepository<productTypes> TypeRepositories { get; private set; }
        public IBaseRepository<Product> ProductsRepository  { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            TypeRepositories = new BaseRepository<productTypes>(context);
            PrandsRepository = new BaseRepository<productPrand>(context);
            ProductsRepository = new BaseRepository<Product>(context);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

    }
}
