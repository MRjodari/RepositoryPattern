using SampleTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Domain.Entities
{
    public class Customer: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
