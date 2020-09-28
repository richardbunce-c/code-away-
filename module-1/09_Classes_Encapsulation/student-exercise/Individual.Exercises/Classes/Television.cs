using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; }
        public int CurrentChannel { get; private set; } = 3;
        public int CurrentVolume { get; private set; } = 2;

        public void TurnOff()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }

        public void ChangeChannel(int newChannel)
        {
            if ((IsOn) && (CurrentChannel >= 3) && (CurrentChannel <= 18))
            {
                CurrentChannel = newChannel;
            }
        }

        public void ChannelUp()
        {
            if (IsOn)
            {
                if (CurrentChannel == 18)
                {
                    CurrentChannel = 3;
                }
                else
                {
                    CurrentChannel += 1;
                }
            }
        }

        public void ChannelDown()
        {
            if (IsOn)
            {
                if (CurrentChannel == 3)
                {
                    CurrentChannel = 18;
                }
                else
                {
                    CurrentChannel -= 1;
                }
            }
        }

        public void RaiseVolume()
        {
            if (IsOn && (CurrentVolume < 10))
            {
                CurrentVolume += 1;
            }
        }

        public void LowerVolume()
        {
            if (IsOn && (CurrentVolume > 0))
            {
                CurrentVolume -= 1;
            }

        }
    }
}