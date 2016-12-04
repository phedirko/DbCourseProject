using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCourse.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public double Summ { get; set; }
        public double Percentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfReg { get; set; }
        public int Months { get; set; }

        public double monthPayment;
        public double MonthPayment
        {
            get { return monthPayment; }
            set
            {
                monthPayment = Summ * Months / 12 * Math.Pow(Percentage, Convert.ToDouble(Months) / 12);
            }
        }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }


    }
}
