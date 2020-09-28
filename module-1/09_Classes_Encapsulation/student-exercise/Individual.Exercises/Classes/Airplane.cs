using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; private set; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }
        public int TotalFirstClassSeats { get; private set; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }

        }

        public int TotalCoachSeats { get; private set; }

        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;

        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass)
            {

                if (AvailableFirstClassSeats >= totalNumberOfSeats)
                {
                    BookedFirstClassSeats += totalNumberOfSeats;
                    return true;
                }
            }
            else
            {
                if (AvailableCoachSeats >= totalNumberOfSeats)
                {
                    BookedCoachSeats += totalNumberOfSeats;
                    return true;
                }
            }

            return false;
        }
    }
}