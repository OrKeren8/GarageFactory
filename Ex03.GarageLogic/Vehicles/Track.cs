using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private bool m_IceLoad;
        private float m_MaxLoadVolume;
        private EnergyTank m_EnergyTank;

        public override List<FieldDescriptor> GetSchema()
        {
            List<FieldDescriptor> trackListSchema = base.GetSchema();

            trackListSchema.Add(new FieldDescriptor { StringDescription = "Ice Load", Type = typeof(bool), IsRequired = true });
            trackListSchema.Add(new FieldDescriptor { StringDescription = "Max Load Volume", Type = typeof(float), IsRequired = true });
            trackListSchema.Add(new FieldDescriptor { StringDescription = "Energy Tank", Type = typeof(EnergyTank), IsRequired = true });
            return trackListSchema;

        }

    }

}