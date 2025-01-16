using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        public readonly eEnergyTankType EnergyTankType = eEnergyTankType.ElectricBattery;

        //public ElectricBattery(float i_Capacity) : base(i_Capacity){}

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

        

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> electricTankSchema = new Dictionary<string, FieldDescriptor>();

            electricTankSchema["Battery Capacity"] = new FieldDescriptor { StringDescription = "Battery Maximum Capacity In Hours", Type = typeof(float), IsRequired = true }; //not sure if needed because its 100
            electricTankSchema["Current Battery Precentage"] = new FieldDescriptor { StringDescription = "Current Battery Hours That Left", Type = typeof(float), IsRequired = true };
            return electricTankSchema;
        }
    }
}
