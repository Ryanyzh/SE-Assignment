using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ExpiredState : SeasonPassState
    {
        protected SeasonPass seasonPass;

        public ExpiredState(SeasonPass seasonPass)
        {
            this.seasonPass = seasonPass;
        }

        public void Apply()
        {
            // seasonPass.Apply(); --> GOT ERROR
        }

        public void Renew()
        {
            // seasonPass.Renew(); --> GOT ERROR
        }

        public void Expire()
        {
            Console.WriteLine("Season pass is already expired.");
        }

        public void Terminate(string reason)
        {
            Console.WriteLine($"Terminating the expired season pass: {reason}");
            seasonPass.State = new TerminatedState(seasonPass);
        }

        public void TransferToVehicle(Vehicle newVehicle)
        {
            Console.WriteLine("Cannot transfer an expired season pass.");
        }
    }
}
