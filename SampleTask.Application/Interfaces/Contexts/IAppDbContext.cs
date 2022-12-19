using Microsoft.EntityFrameworkCore;
using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Application.Interfaces.Contexts
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; set; }

    }
}
