using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A1,
        A2,
        B1,
        B2
    }


    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private EnergyTank m_EnergyTank;

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> motorcycleSchema = base.GetSchema();

            motorcycleSchema["License Type"] = new FieldDescriptor { StringDescription = "License Type", Type = typeof(eLicenseType), IsRequired = true };
            motorcycleSchema["Engine Volume"] = new FieldDescriptor { StringDescription = "Engine Volume", Type = typeof(int), IsRequired = true };
            //motorcycleSchema["Energy Tank"] = new FieldDescriptor { StringDescription = "Energy Tank", Type = typeof(EnergyTank), IsRequired = true };

            return motorcycleSchema;
        }
    }
}
