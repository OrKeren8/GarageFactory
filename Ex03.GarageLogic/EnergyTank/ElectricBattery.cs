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
            if(schema == null)
            {
                schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Battery Hours That Left", Type = typeof(float), IsRequired = true };
            }
            else
            {
                schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Battery Hours That Left", Value=};
            }

            return schema;
        }
    }
}
