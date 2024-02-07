using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class SeasonPass
    {
        public int PassNumber { get; set; }
        public User User { get; set; }
        public DateTime StartMonth { get; set; }
        public DateTime EndMonth { get; set; }
        public string PaymentMode { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Type { get; set; }

        // State
        private SeasonPassState state;

        public SeasonPassState ProcessingState { get; set; }
        public SeasonPassState ValidState { get; set; }
        public SeasonPassState ExpiredState { get; set; }
        public SeasonPassState TerminatedState { get; set; }
        public ExitedState ExitedState { get; set; }

        // Constructor
        public SeasonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type)
        {
            PassNumber = passNumber;
            User = user;
            StartMonth = startMonth;
            EndMonth = endMonth;
            PaymentMode = paymentMode;
            Vehicle = vehicle;
            Type = type;

            ProcessingState = new ProcessingState(this);
            ValidState = new ValidState(this);
            ExpiredState = new ExpiredState(this);
            TerminatedState = new TerminatedState(this);
            ExitedState = new ExitedState(this);

            state = ProcessingState; // Initial state: Processing
        }

        public void Apply()
        {
            state.Apply();
        }

        public void Renew()
        {
            state.Renew();
        }
        public void Expire()
        {
            state.Expire();
        }
        public void Terminate(string reason)
        {
            state.Terminate(reason);
        }
        public void TransferToVehicle(Vehicle newVehicle)
        {
            state.TransferToVehicle(newVehicle);
        }

        // State transition methods
        public void setState (SeasonPassState state)
        {
            this.state = state;
        }


        // Getters and setters for state
        public SeasonPassState State
        {
            get { return state; }
            set { state = value; }
        }
       

        // Method to calculate parking charge
        public double CalculateCharge(DateTime entry, DateTime exit)
        {
            // Logic to calculate parking charge
            return 0.0; // Sample implementation
        }
    }
}
