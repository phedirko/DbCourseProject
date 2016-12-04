using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        
        public List<Contract> Contracts { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
