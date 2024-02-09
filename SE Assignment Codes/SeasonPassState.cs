using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    interface SeasonPassState
    {
        void Apply();
        void Renew();
        void Expire();
        void Terminate(string reason); //possibly 
        void TransferToVehicle(Vehicle newVehicle);
    }
}
