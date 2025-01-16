using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private bool m_IceLoad;
        private float m_MaxLoadVolume;
        private Dictionary<string, FieldDescriptor> Schema { get; set; } = null;


        public Track(string i_LicenseNumber, List<Wheel> i_Wheels, EnergyTank i_EnergyTank) : base(i_LicenseNumber, i_Wheels, i_EnergyTank) { }

        public override void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.m_IceLoad = (bool)i_Schema["Ice Load"].Value;
            this.m_MaxLoadVolume = (float)i_Schema["Max Load Volume"].Value;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            if(Schema == null)
            {
                Dictionary<string, FieldDescriptor> Schema = base.GetSchema();

                Schema["Ice Load"] = new FieldDescriptor { StringDescription = "Ice Load", Type = typeof(bool), IsRequired = true };
                Schema["Max Load Volume"] = new FieldDescriptor { StringDescription = "Max Load Volume", Type = typeof(float), IsRequired = true };
            }

            return Schema;
        }

    }

}