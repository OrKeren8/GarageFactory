using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private bool m_IceLoad;
        private float m_MaxLoadVolume;

        public Track(string i_LicenseNumber, List<Wheel> i_Wheels, EnergyTank i_EnergyTank) : base(i_LicenseNumber, i_Wheels, i_EnergyTank) { }

        public override void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.m_IceLoad = (bool)i_Schema["Ice Load"].Value;
            this.m_MaxLoadVolume = (float)i_Schema["Max Load Volume"].Value;
        }

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