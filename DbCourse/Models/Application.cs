using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class Application
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public double Sum { get; set; }
        public int Years { get; set; }

        public bool Status { get; set; }
    }
}
