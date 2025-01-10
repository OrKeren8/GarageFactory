using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        
        public ElectricBattery(float i_BaterryCapacity) : base(i_BaterryCapacity)
        {
        }
        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Battery Capacity"] = base.m_MaxCapacity.ToString();
            info["Current Battery Precentage"] = base.m_CurrAmount.ToString();

            return info;
        }
    }
}
