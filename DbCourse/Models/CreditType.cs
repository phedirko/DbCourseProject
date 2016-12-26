using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class CreditType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double MinSumm { get; set; }
        public double MaxSum { get; set; }
        
        public double MinPercentage { get; set; }
        public double MaxPercentage { get; set; }

        public int MinMonth { get; set; }
        public int MaxMonth { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
