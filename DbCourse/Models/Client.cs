using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeAdress { get; set; }
        public string Passport { get; set; }
        public string IdentityCode { get; set; }
        public string PhoneNumber { get; set; }


        //public ApplicationUser User { get; set; }
        //public int ApplicationUserId { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
