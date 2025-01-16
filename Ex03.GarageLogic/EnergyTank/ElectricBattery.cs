using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        public readonly eEnergyTankType EnergyTankType = eEnergyTankType.ElectricBattery;

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Battery Capacity"] = base.MaxCapacity.ToString();
            info["Current Battery Precentage"] = $"{base.CurrAmount.ToString()} %";

            return info;
        }
        public override eEnergyTankType GetType()
        {
            return this.EnergyTankType;
        }

        

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = base.GetSchema();

            schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Battery Hours That Left", Type = typeof(float), IsRequired = true };
            return schema;
        }
    }
}
