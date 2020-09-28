using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        public int CurrentLevel { get; private set; } = 1;
        public int NumberOfLevels { get; private set; }
        public bool DoorIsOpen { get; private set; }

        public Elevator(int numberOfLevels)
        {
            NumberOfLevels = numberOfLevels;
         }

      public void OpenDoor()
        {
            DoorIsOpen = true;
        }

      public void CloseDoor()
        {
            DoorIsOpen = false;
        }

       public void GoUp(int desiredFloor)
        {
            if (!DoorIsOpen)
            {
                if (desiredFloor <= NumberOfLevels && desiredFloor > CurrentLevel)
                {
                    CurrentLevel = desiredFloor;
                }
            }
        }

       public void GoDown(int desiredFloor)
        {
            if (!DoorIsOpen)
            {
                if (desiredFloor >= 0 && desiredFloor < CurrentLevel)
                {
                    CurrentLevel = desiredFloor;
                }
            }
        }
    }

}