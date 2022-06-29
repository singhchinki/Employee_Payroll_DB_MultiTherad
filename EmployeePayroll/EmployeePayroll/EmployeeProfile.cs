using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeProfile
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal salary { get; set; }
        public DateTime DateTime { get; set; }
        public string gender { get; set; }
        public double phone { get; set; }
        public string address { get; set; }
        public string dept { get; set; }
        public decimal basicPay { get; set; }
        public int deductions { get; set; }
        public int taxablePay { get; set; }
        public int incomeTax { get; set; }
        public int netPay { get; set; }

        public EmployeeProfile(int id, string name, decimal salary, DateTime dateTime, string gender, double phone, string address, string dept, decimal basicPay, int deductions, int taxablePay, int incomeTax, int netPay)
        {
            this.id = id;
            Name = name;
            this.salary = salary;
            DateTime = dateTime;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.dept = dept;
            this.basicPay = basicPay;
            this.deductions = deductions;
            this.taxablePay = taxablePay;
            this.incomeTax = incomeTax;
            this.netPay = netPay;
        }
    }
}
