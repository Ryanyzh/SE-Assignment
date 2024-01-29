using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class TerminatedState : SeasonPassState
    {
        protected SeasonPass seasonPass;

        public TerminatedState(SeasonPass seasonPass)
        {
            this.seasonPass = seasonPass;
        }

        public void Apply()
        {
            Console.WriteLine("Cannot apply with a terminated pass.");
        }

        public void Renew()
        {
            Console.WriteLine("Cannot renew a terminated pass.");
        }

        public void Expire()
        {
            Console.WriteLine("Cannot expire a terminated pass.");
        }

        public void Terminate(string reason)
        {
            Console.WriteLine("Season pass is already terminated.");
        }

        public void TransferToVehicle(Vehicle newVehicle)
        {
            Console.WriteLine("Cannot transfer a terminated pass.");
        }
    }
}
