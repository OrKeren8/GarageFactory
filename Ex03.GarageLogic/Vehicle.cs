using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal struct VehicleData
    {
        public string LicenseNumber { get; set; }
        public string ModelName { get; set; }
        public string OwnerName { get; set; }
        public eMaintenanceStatus GarageStatus { get; set; }
        public WheelInfo WheelsInfo { get; set; }
        public float FuelStatus { get; set; }
        public eEnergyType FuelType { get; set; }

    }

    internal class Vehicle
    {
        private string m_Name;
        private string m_LicenseNumber;
        private float M_EnergyPercentageLeft;
        private List<Wheel> m_Wheels;
    }
}
