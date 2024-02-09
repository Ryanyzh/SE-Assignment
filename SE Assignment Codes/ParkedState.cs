using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ParkedState : ValidState
    {
        public ParkedState(SeasonPass seasonPass) : base(seasonPass)
        {
        }

        public void Park()
        {
            Console.WriteLine("Vehicle is parked on campus.");
        }

        public void Exit()
        {
            seasonPass.State = seasonPass.ExitedState;
        }
    }
}
