using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        public readonly eEnergyTankType EnergyTankType = eEnergyTankType.ElectricBattery;

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Battery Capacity"] = base.m_MaxCapacity.ToString();
            info["Current Battery Precentage"] = $"{base.m_CurrAmount.ToString()} %";

            return info;
        }
        public override eEnergyTankType GetType()
        {
            return this.EnergyTankType;
        }


    }
}
