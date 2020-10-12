using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Classes
{
    class Movies
    {
        public string MovieTitle { get; set; }
        public string MovieFormat { get; set; }
        public string PremiumMovie { get; set; }



        public Movies(string movieTitle, string movieFormat, string premiumMovie)
        {
            this.MovieTitle = movieTitle;
            this.MovieFormat = movieFormat;
            this.PremiumMovie = premiumMovie;
        }
        
        }
    }

