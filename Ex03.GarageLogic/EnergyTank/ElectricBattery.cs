using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        public readonly eEnergyTankType EnergyTankType = eEnergyTankType.ElectricBattery;

        public override eEnergyTankType GetType()
        {
            return this.EnergyTankType;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();

            schema = base.GetSchema();
            schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Battery Hours That Left", Type = typeof(float), IsRequired = true, Value = this.CurrAmount };
            schema["Energy Tank Max Amount"].StringDescription = "Battery Max Time In Houres";

            return schema;
        }
    }
}
