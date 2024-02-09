using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ExitedState : ValidState
    {
        public ExitedState(SeasonPass seasonPass) : base(seasonPass)
        {
        }

        public void Exit()
        {
            Console.WriteLine("Vehicle has already exited.");
        }
    }
}
