using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class Vehicle
    {
        public string LicensePlateNumber { get; set; }
        public string IUNumber { get; set; }
        public string VehicleType { get; set; }

        public List<ParkingRecord> parkingRecordList = new List<ParkingRecord>();

        // Constructor
        public Vehicle(string licensePlateNumber, string iUNumber, string vehicleType)
        {
            LicensePlateNumber = licensePlateNumber;
            IUNumber = iUNumber;
            VehicleType = vehicleType;
        }

        // Method to provide license plate number
        public string ProvideLicensePlateNumber()
        {
            return LicensePlateNumber;
        }

        // Method to identify the vehicle
        public string IdentifyVehicle()
        {
            return $"{LicensePlateNumber} ({VehicleType})";
        }

        public string saveVehicleDetails()
        {
            return $"{{LicensePlateNumber: {LicensePlateNumber}, IUNumber: {IUNumber}, VehicleType: {VehicleType}}}";
        }
    }
}
