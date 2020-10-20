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
        public List<Project> GetAllProjects()
        { 
            List<Project> output = new List<Project>();
            try
            {
                using (SqlConnection conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from project;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Project proj = new Project();
                        proj.ProjectId = Convert.ToInt32(reader["project_id"]);
                        proj.Name = Convert.ToString(reader["name"]);
                        proj.StartDate = Convert.ToDateTime(reader["start_date"]);
                        proj.EndDate = Convert.ToDateTime(reader["end_date"]);

                        output.Add(proj);
                    }
                }
                return output;
            
            }
          catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            throw new NotImplementedException();
        }

    }
}
