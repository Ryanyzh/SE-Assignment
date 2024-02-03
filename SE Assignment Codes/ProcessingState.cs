using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ProcessingState : SeasonPassState
    {
        protected SeasonPass seasonPass;

        public ProcessingState(SeasonPass seasonPass)
        {
            this.seasonPass = seasonPass;
        }

        public void Apply()
        {
            Console.WriteLine("Season pass application is already being processed.");

        }

        public void Renew()
        {
            Console.WriteLine("Cannot renew while processing application.");
        }

        public void Expire()
        {
            Console.WriteLine("Cannot expire while processing application.");
        }

        public void Terminate(string reason)
        {
            Console.WriteLine($"Cannot terminate while processing application. Your reason: {reason}");
        }

        public void TransferToVehicle(Vehicle newVehicle)
        {
            Console.WriteLine("Cannot transfer while processing application.");
        }
    }
}
