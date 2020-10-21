using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICountryLanguageDAO
    {
        /// <summary>
        /// Gets all languages for a given country.
        /// </summary>
        /// <param name="countryCode">The country code to filter by.</param>
        /// <returns></returns>
        IList<CountryLanguage> GetLanguages(string countryCode);

    }
}
