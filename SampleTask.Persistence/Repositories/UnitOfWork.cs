using SampleTask.Application.Interfaces.Repos;
using SampleTask.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private ICustomerRepository _customerRepository;
        //private IGenericRepository<ICustomerRepository> _genericRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
