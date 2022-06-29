using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeePayrollService
{
    public class Payroll
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Service_DB;";
        public List<EmployeeProfile> employeeProfiles = new List<EmployeeProfile>();
        public void addEmployee(List<EmployeeProfile> employeeProfiles)
        {
            foreach (EmployeeProfile employeeProfile in employeeProfiles)
            {
                this.createRecord(employeeProfile);
                Console.WriteLine("Employee Added: " + employeeProfile.Name);
            }
        }
        public void addEmployeeWithThread(List<EmployeeProfile> employeeProfiles)
        {
            foreach (EmployeeProfile employeeProfile in employeeProfiles)
            {
                Task Thread = new Task(() =>
                {
                    this.createRecord(employeeProfile);
                    Console.WriteLine("Employee Added: " + employeeProfile.Name);
                });
                Thread.Start();
            }
        }
        public void createRecord(EmployeeProfile profile)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            lock (this)
            {
                using (connect)
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", profile.Name);
                    command.Parameters.AddWithValue("@salary", profile.salary);
                    command.Parameters.AddWithValue("@startDate", profile.DateTime);
                    command.Parameters.AddWithValue("@Gender", profile.gender);
                    command.Parameters.AddWithValue("@phone_number", profile.phone);
                    command.Parameters.AddWithValue("@address", profile.address);
                    command.Parameters.AddWithValue("@department", profile.dept);
                    command.Parameters.AddWithValue("@basic_pay", profile.basicPay);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Record created successfully.");
                    connect.Close();
                }
            }
        }
    }
}
