using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, @district, @population); Select @@identity;", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newId;
                }
            }
            catch (SqlException ex)
            {
                // TODO: This would normally be logged somewhere
                throw;
            }
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode = @countryCode;", conn);
                    // param name    // param value
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return cities;
        }

        private City RowToObject(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["CityId"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }
    }
}
