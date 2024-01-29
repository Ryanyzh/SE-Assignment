using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ValidState : SeasonPassState
    {
        protected SeasonPass seasonPass;

        public ValidState(SeasonPass seasonPass)
        {
            this.seasonPass = seasonPass;
        }

        public void Apply()
        {
            Console.WriteLine("Cannot apply for a new pass, already valid.");
        }

        public void Renew()
        {
            // seasonPass.Renew(); --> GOT ERROR
        }

        public void Expire()
        {
            Console.WriteLine("Expiring the season pass.");
            seasonPass.State = new ExpiredState(seasonPass);
        }

        public void Terminate(string reason)
        {
            Console.WriteLine($"Terminating the season pass: {reason}");
            seasonPass.State = new TerminatedState(seasonPass);
        }

        public void TransferToVehicle(Vehicle newVehicle)
        {
            seasonPass.Vehicle = newVehicle;
            Console.WriteLine($"Season pass transferred to vehicle: {newVehicle.LicensePlateNumber}");
        }
    }
}
