using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficeNumber { get; set; }
        public bool Working { get; set; } = true;

        public List<Manager> Managers { get; set; }
    }
}
