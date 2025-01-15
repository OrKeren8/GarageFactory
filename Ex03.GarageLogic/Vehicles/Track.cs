using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private bool m_IceLoad;
        private float m_MaxLoadVolume;
        private EnergyTank m_EnergyTank;

        public Track(string i_LicenseNumber) : base(i_LicenseNumber) { }


        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> trackSchema = base.GetSchema();

            trackSchema["Ice Load"] = new FieldDescriptor { StringDescription = "Ice Load", Type = typeof(bool), IsRequired = true };
            trackSchema["Max Load Volume"] = new FieldDescriptor { StringDescription = "Max Load Volume", Type = typeof(float), IsRequired = true };
            //trackSchema["Energy Tank"] = new FieldDescriptor { StringDescription = "Energy Tank", Type = typeof(EnergyTank), IsRequired = true };

            return trackSchema;
        }

    }

}