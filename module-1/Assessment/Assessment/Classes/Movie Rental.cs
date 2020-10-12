using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Classes
{
    class Movie_Rental
    {
        private SortedDictionary<string, List<Movies>> inventory;

            public Movie_Rental(IEnumerable<Movies>movieList)
        {
            this.inventory = new SortedDictionary<string, List<Movies>>();

            foreach (Movies movies in movieList)
            {
                if (!inventory.ContainsKey(movies.PremiumMovie))
                {
                    inventory[movies.PremiumMovie] = new List<Movies>();
                }
                inventory[movies.PremiumMovie].Add(movies);
            }
        }
   
    //public string[]PremiumMovie
        //{
        //    //get
        //    //{
        //    //    //List<string> premiumMovie in inventory.Keys)
        //    //    //    {
        //    //    //    premiumMovie.Add(premiumMovie);
        //    //    }
        //    //    return premiumMovie.ToArray();
        //    //}
        //}
    }
}
