using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    //The purpose of this class is to handle all database operations related to the City sql table/ City c# class.
    public class CitySqlDAO:ICityDao
    {
        private string connectionString;
        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<City> GetCities(string countryCode)
        {
            List<City> cities = new List<City>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Open the connection
                connection.Open();

                //Create a comand to contain our SQL statement
                string sql = $"Select * from City: ";
                SqlCommand cmd = new SqlCommand(sql, connection);
             

                //Execute the command and save the reference to the result set*
                SqlDataReader rdr = cmd.ExecuteReader();

                //Loop through each row in the result set
                while (rdr.Read())
                {
                    //For this row, create a city object
                    City city = new City();
                    city.CityId = Convert.ToInt32(rdr["CityId"]);
                    city.CountryCode = Convert.ToString(rdr["CountryCode"]);
                    city.District = Convert.ToString(rdr["District"]);
                    city.Name = Convert.ToString(rdr["Name"]);
                    city.Population = Convert.ToInt32(rdr["Population"]);

                    cities.Add(city);
                }
            }
        }

        public List<City> GetCities()
        {
            throw new NotImplementedException();
        }
    }
}