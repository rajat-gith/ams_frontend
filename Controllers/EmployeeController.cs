using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Attendance.Models;

namespace Attendance.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowEmployeesLessThan8Hours()
        {
            List<Employee> employees = GetEmployeesLessThan8Hours();

            return View(employees);
        }
        private List<Employee> GetEmployeesLessThan8Hours()
        {
            List<Employee> employees = new List<Employee>();

            // Establish a connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source = LAPTOP-MRRGQ6LL\\SQLEXPRESS; Database = Attendance; Integrated Security = True"))
            {
                // Open the connection
                connection.Open();

                // Create a SQL query to fetch employees working less than 8 hours
                string query = "SELECT EMP_Name" +
                    "FROM local" +
                    "WHERE ID IN(SELECT ID FROM local WHERE DATEDIFF(HOUR, Local_InTime, Local_OutTime) < 8)";

                // Create a command object with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and retrieve the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read the data and map it to Employee objects
                        while (reader.Read())
                        {
                            Employee employee = new Employee()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                EMP_ID = Convert.ToInt32(reader["EMP_ID"]),
                                EMP_Name = reader["EMP_Name"].ToString(),
                                Attend_Date = Convert.ToDateTime(reader["Attend_Date"]),
                                Local_InTime = Convert.ToDateTime(reader["Local_InTime"]),
                                Local_OutTime = Convert.ToDateTime(reader["Local_OutTime"])
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

    }
}