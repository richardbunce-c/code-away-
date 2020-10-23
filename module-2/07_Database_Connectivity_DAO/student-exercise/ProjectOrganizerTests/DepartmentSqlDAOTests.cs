using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace ProjectOrganizerTests
{
    [TestClass]
    public class DepartmentSqlDAOTests
    {
        
        string cs = @"Server= .\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";
        TransactionScope transaction;
        private int deptCount;
        private int department_id;
        private int didWork;

        //protected string cs { get; } = "Server= .\\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";

        [TestInitialize]

        public void SetupDB()
        {
            //Create a transaction
            transaction = new TransactionScope();

            //Read the script file
            string path = "SetupDB.sql";
            string sql = File.ReadAllText(path);
            //Execute the sql
            //string cs = @"Server= .\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            //Save any data that we need from the script

        }


        [TestCleanup]
        public void CleanupDB()
        {
            //Rollback the transaction
            transaction.Dispose();
        }

        [TestMethod]
        public void GetDepartmentsTest()
        {
            List<Department> listOfDepartments = new List<Department>()
            {
                new Department()
                {
                    Name="Department 1"
                },
                new Department()
                    {
                    Name="Department 2"
                }
            };

            //Arrange  create an instance of DepartmentSqlDAO
            DepartmentSqlDAO departmentSqlDAO = new DepartmentSqlDAO(cs);

            //Act Call Department
            IList<Department> testResult = departmentSqlDAO.GetDepartments();

            //Assert how many rows returned
            Assert.AreEqual(2, testResult.Count);
            //Assert are the names of the depts equivalent?
            Assert.AreEqual(listOfDepartments[0].Name, testResult[0].Name);
            Assert.AreEqual(listOfDepartments[1].Name, testResult[1].Name);

        }
        [TestMethod]

        public void UpdateDepartmentsTest()
        {
            DepartmentSqlDAO departmentSqldao = new DepartmentSqlDAO(cs);

            List<Department> departments = (List<Department>)departmentSqldao.GetDepartments();


            Department testDepartment = new Department();

            foreach (Department thisDepartment in departments)
            {
                if (thisDepartment.Name == "Test Department")
                {
                    testDepartment = thisDepartment;
                }
            }

            testDepartment.Name = "Changed Name";

        }
        [TestMethod]
        public void EqualsCreateDepartmentTest()
        {
            DepartmentSqlDAO departmentSqldao = new DepartmentSqlDAO(cs);

            Department department = new Department();
            department.Name = "TestProject";
            department_id = 1;

             didWork = departmentSqldao.EqualsCreateDepartment(department);

            Assert.AreNotEqual(department_id, didWork);

        }
    }
}
