using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountryLanguageSqlDAO : ICountryLanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public CountryLanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<CountryLanguage> GetLanguages(string countryCode)
        {
            List<CountryLanguage> languages = new List<CountryLanguage>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
@"SELECT cl.*, l.LanguageName 
FROM countrylanguage cl 
join Language l on cl.LanguageId = l.LanguageId 
WHERE cl.countrycode = @countrycode
ORDER BY IsOfficial DESC, Percentage DESC, LanguageName ASC",
                    conn);
                    cmd.Parameters.AddWithValue("@countrycode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CountryLanguage language = new CountryLanguage();
                        language.CountryCode = Convert.ToString(reader["CountryCode"]);
                        language.LanguageName = Convert.ToString(reader["LanguageName"]);
                        language.IsOfficial = Convert.ToBoolean(reader["IsOfficial"]);
                        language.Percentage = Convert.ToDouble (reader["Percentage"]);

                        languages.Add(language);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving languages.");
                throw;
            }

            return languages;
        }

    }
}
