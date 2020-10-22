using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class DepartmentSqlDAO : IDepartmentDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public DepartmentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {

            //Return a list of all departments

            List<Department> list = new List<Department>();

            string sql = "Select * from Department";
            
                //Connect to a database and execute the query
               try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                   // Create a SqlCommand to represent a statement
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //Execute the statement and get a reader
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Build a Department object from the data in the row
                        Department dept = new Department();
                        dept.Id = Convert.ToInt32(reader["department_Id"]);
                        dept.Name = Convert.ToString(reader["name"]);

                        list.Add(dept);
                    }
                }
                return list;
            }
            catch 
            {
                // Log the error and re-throw
                throw;
            }
          
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            //Create the sql to insert a new row into the Department table
            string sql = "Insert into Department (name) values (@deptName); Select @@Identity;";
           
            try
            //Create a new connection 
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Create the command object, using sql and the connection
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //Bind parameters to the command
                    cmd.Parameters.AddWithValue("@deptName", newDepartment.Name);
                    //Execute the command to insert the row
                    int newDepartmentId = Convert.ToInt32(cmd.ExecuteScalar());
                    //Somehow determine the id of the new department
                    //Return the id
                    return newDepartmentId;
                }
                
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            string sql = "Update department set name=@deptName where department_id=@deptId";
            try
            {
                //Create the connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Open the connection
                    conn.Open();
                    //Create a command
                    SqlCommand cmd = new SqlCommand(sql , conn);
                    //Bind all parameters
                    cmd.Parameters.AddWithValue("@deptName", updatedDepartment.Name);
                    cmd.Parameters.AddWithValue("deptId", updatedDepartment.Id);
                   //Execute the statement
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //Return whether the update actually worked5
                    return (rowsAffected > 0);
                }
            }
            catch
            {
                throw;
            }
        }

       
    }
}
