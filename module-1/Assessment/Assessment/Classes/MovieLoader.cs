using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment.Classes
{
    class MovieLoader
    {
        public static IEnumerable<Movies> LoadMovies(string filePath)
        {
            try
            {
                List<Movies> movies = new List<Movies>();
                using (StreamReader rdr = new StreamReader(filePath))
                {
                    while (!rdr.EndOfStream)
                    {
                        string input = rdr.ReadLine();
                        string[] fields = input.Split("|");
                        string movieName = fields[0];
                        string movieFormat = fields[1];
                        string premiumMovie = fields[2];

                        Movies movie = new Movies(movieName, movieFormat, premiumMovie);
                        movies.Add(movie);
                    }
                }
                return movies;
            }
            catch
            {
                return new List<Movies>();
            }
        }
    }
}
