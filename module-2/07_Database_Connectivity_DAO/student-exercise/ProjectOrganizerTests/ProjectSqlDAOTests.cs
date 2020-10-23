using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace ProjectOrganizerTests
{
    [TestClass]
    public class ProjectSqlDAOTests
    {
        string cs = @"Server= .\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";
        private int numberOfProjects = 0;
        private int newProjectID = 0;
        private int newEmployeeID = 0;

        private TransactionScope transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            transactionScope = new TransactionScope();

            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                SqlCommand command;
                sqlConnection.Open();


                command = new SqlCommand("insert into employee values (1, 'Charlie', 'Brown', 'DogWalker', '1999-11-11', 'M', '2019-11-11'); select @@IDENTITY;", sqlConnection);
                newEmployeeID = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("insert into project values ('FreshStart', '2011-11-11', '2012-11-11'); select @@IDENTITY;", sqlConnection);
                newProjectID = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("select count(*) from project;", sqlConnection);
                numberOfProjects = Convert.ToInt32(command.ExecuteScalar());

            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void GetAllProjectsTest()
        {
            ProjectSqlDAO projectSqlDAO = new ProjectSqlDAO(cs);

            IList<Project> projects = projectSqlDAO.GetAllProjects();

            Assert.IsNotNull(projects, "GetAllProjects failed, the list was null.");
            Assert.AreEqual(numberOfProjects, projects.Count, "GetAllProjects failed, an incorrect number of projects has been returned.");
        }

        [TestMethod]
        public void AssignEmployeeToProjectTest()
        {
            ProjectSqlDAO projectSqlDAO = new ProjectSqlDAO(cs);

            bool didItWork = projectSqlDAO.AssignEmployeeToProject(newProjectID, newEmployeeID);

            Assert.IsTrue(didItWork);
        }

        [TestMethod]
        public void RemoveEmployeeFromProjectTest()
        {
            ProjectSqlDAO projectSqlDAO = new ProjectSqlDAO(cs);

            bool didItWork = projectSqlDAO.AssignEmployeeToProject(newProjectID, newEmployeeID);

            Assert.IsTrue(didItWork);
        }

        [TestMethod]
        public void CreateProjectTest()
        {
            ProjectSqlDAO projectSqlDAO = new ProjectSqlDAO(cs);

            Project project = new Project
            {
                Name = "Testing",
                StartDate = new DateTime(2015, 2, 15),
                EndDate = new DateTime(2019, 2, 19),
            };

            int result = projectSqlDAO.CreateProject(project);

            Assert.AreNotEqual(0, result, "Create Project failed, the method returned 0.");
        }
    }
}

