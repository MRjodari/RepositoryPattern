using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Application.Interfaces.Repos
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
    }
}
