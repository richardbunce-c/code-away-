using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private string connectionString;

        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            List<Project> list = new List<Project>();
            string sql = "Select * from Project";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Project proj = new Project();
                        proj.ProjectId = Convert.ToInt32(reader["project_id"]);
                        proj.Name = Convert.ToString(reader["name"]);
                        proj.StartDate = Convert.ToDateTime(reader["from_date"]);
                        proj.EndDate = Convert.ToDateTime(reader["to_date"]);

                        list.Add(proj);
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
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            string sql = "Insert into project_employee(project_id,employee_id) values (@projectId, @employeeId)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Create the command object using the sql and the connection
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //Bind the parameters to the command
                    cmd.Parameters.AddWithValue("@projectId", projectId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    //Execute the command to insert the employee into the project
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //return the new Id
                    return (rowsAffected > 0);
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            string sql = "Delete from project_Id where employee_id=@empId and Project_id=@projId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Create the command object, using the sql and the connection
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //Bind the parameters to the command
                    cmd.Parameters.AddWithValue("@empId", employeeId);
                    cmd.Parameters.AddWithValue("@projId", projectId);

                    //Execute the command to insert the row
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //Return the new id
                    return (rowsAffected > 0);
                }
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            string sql = "Insert into project (name, from_date, to_date) values (@name, @fromDate, @toDate)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@fromDate", newProject.StartDate);
                    cmd.Parameters.AddWithValue("@toDate", newProject.EndDate);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch
            {
                throw;
            }

        }

    }


}

