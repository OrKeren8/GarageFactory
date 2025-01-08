using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public struct VehicleData
    {
        public string LicenseNumber { get; set; }
        public string ModelName { get; set; }
        public string OwnerName { get; set; }
        public eMaintenanceStatus GarageStatus { get; set; }
        public WheelInfo WheelsInfo { get; set; }
        public float FuelStatus { get; set; }
        public eEnergyType FuelType { get; set; }

    }

    public class Vehicle
    {
        private string m_Name;
        private string m_LicenseNumber;
        private string m_ModelName;
        private string m_OwnerName;
        private eMaintenanceStatus m_GarageStatus;
        private float M_EnergyPercentageLeft;
        private List<Wheel> m_Wheels;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }
        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
        public float EnergyPercentageLeft
        {
            get { return M_EnergyPercentageLeft; }
            set { M_EnergyPercentageLeft = value; }
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        public eMaintenanceStatus GarageStatus
        {
            get { return m_GarageStatus; }
            set { m_GarageStatus = value; }
        }
    }

   
}
