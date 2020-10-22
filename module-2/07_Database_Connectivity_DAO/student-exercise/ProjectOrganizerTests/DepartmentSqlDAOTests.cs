using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace ProjectOrganizerTests
{
    [TestClass]
    public class DepartmentSqlDAOTests
    {
        TransactionScope transaction;
        [TestInitialize]

        public void SetupDB()
        {
            //Create a transaction
            transaction = new TransactionScope();

            //Read the script file
            string path = "SetupDB.sql";
            string sql = File.ReadAllText(path);
            //Execute the sql
            string cs = @"Server= .\SQLExpress; Database=EmployeeDB; Trusted_Connection=True;";
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
    public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
    }
}
