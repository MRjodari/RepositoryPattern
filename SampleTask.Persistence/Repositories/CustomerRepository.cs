using Microsoft.EntityFrameworkCore;
using SampleTask.Application.Interfaces.Repos;
using SampleTask.Domain.Entities;
using SampleTask.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
      
        public CustomerRepository(AppDbContext context) : base(context)
        {
           
        }
    }
}
