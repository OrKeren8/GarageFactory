using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_Name;
        private string m_LicenseNumber;
        private string m_ModelName;
        private List<Wheel> m_Wheels;
        private EnergyTank m_EnergyTank;

        public virtual Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["License number"] = m_LicenseNumber.ToString();
            info["Name"] = m_Name;
            info["Model name"] = m_ModelName.ToString();
            
            info.Concat(m_EnergyTank.GetInfo());
            info.Concat(m_Wheels[0].GetInfo());

            return info;
        }
    }
}
