using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class EmployeeSqlDAO : IEmployeeDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public EmployeeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from employee", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        emp.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        emp.FirstName = Convert.ToString(reader["first_name"]);
                        emp.LastName = Convert.ToString(reader["last_name"]);
                        emp.JobTitle = Convert.ToString(reader["job_title"]);
                        emp.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        emp.Gender = Convert.ToString(reader["gender"]);
                        emp.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        list.Add(emp);
                    }
                }
                return list;

            }
            catch
            {
                throw;
            }


        }

        /// <summary>
        /// Searches the system for an employee by first name or last name.
        /// </summary>
        /// <remarks>The search performed is a wildcard search.</remarks>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>A list of employees that match the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            List<Employee> list = new List<Employee>();

            string sql = "Select * from employee where first_name like @firstName and last_name like @lastName";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@firstName", $"%{firstname}%");
                    cmd.Parameters.AddWithValue("@lastName", $"%{lastname}%");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                  
                        emp.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        emp.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        emp.FirstName = Convert.ToString(reader["first_name"]);
                        emp.LastName = Convert.ToString(reader["last_name"]);
                        emp.JobTitle = Convert.ToString(reader["job_title"]);
                        emp.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        emp.Gender = Convert.ToString(reader["gender"]);
                        emp.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        list.Add(emp);

                    }
                    return list;
                }
            }
            catch
            {

                throw;
            }
            ;
        }
        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from employee where employee_id not in (SELECT employee_id FROM project_employee);", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        emp.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        emp.FirstName = Convert.ToString(reader["first_name"]);
                        emp.LastName = Convert.ToString(reader["last_name"]);
                        emp.JobTitle = Convert.ToString(reader["job_title"]);
                        emp.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        emp.Gender = Convert.ToString(reader["gender"]);
                        emp.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        list.Add(emp);
                    }
                    return list;
                }
            }
            catch
            {
                throw;

            }
        }
    }
}
