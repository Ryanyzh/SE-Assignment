using System;
using System.Collections.Generic;
using System.Linq;
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

        private SeasonPassState processingState;

        private SeasonPassState validState;

        private SeasonPassState expiredState;

        private SeasonPassState terminatedState;

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

            state = new ProcessingState(this); // Initial state: Processing
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

        // Method to refund unused months
        public double RefundUnusedMonths()
        {
            // Logic to refund unused months
            return 0.0; // Sample implementation
        }
    }
}
