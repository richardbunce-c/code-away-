using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Transactions;
using System.Collections.Generic;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;

namespace ProjectOrganizerTests
{
    [TestClass]
    public class EmployeeSqlDAOTests
    {
        private TransactionScope tran;
        string cs = @"Server= .\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";
        private int numberOfEmployees = 0;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd;

                conn.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM employee;", conn);
                numberOfEmployees = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO department (name) VALUES ('Test Employee'); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            EmployeeSqlDAO employeeSqldao = new EmployeeSqlDAO(cs);

            List<Employee> employees = (List<Employee>)employeeSqldao.GetAllEmployees();

            Assert.AreEqual(numberOfEmployees, employees.Count);
        }

        [TestMethod]
        public void SearchTest()
        {
            EmployeeSqlDAO employeeSqldao = new EmployeeSqlDAO(cs);

            List<Employee> employees = (List<Employee>)employeeSqldao.Search("Sid", "Goodman");

            Assert.AreEqual(1, employees.Count);
        }

        [TestMethod]
        public void GetEmployeesWithoutProjectsTest()
        {
            EmployeeSqlDAO employeeSqlDAO = new EmployeeSqlDAO(cs);

            List<Employee> employees = (List<Employee>)employeeSqlDAO.GetEmployeesWithoutProjects();

            Assert.AreEqual(2, employees.Count);
        }
    }
}