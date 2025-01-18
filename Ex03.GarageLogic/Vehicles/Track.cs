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
            base.Init(i_Schema);
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = base.GetSchema();
            
            schema["Ice Load"] = new FieldDescriptor { StringDescription = "Ice Load", Type = typeof(bool), IsRequired = true, Value=this.m_IceLoad };
            schema["Max Load Volume"] = new FieldDescriptor { StringDescription = "Max Load Volume", Type = typeof(float), IsRequired = true, Value=this.m_MaxLoadVolume};

            return schema;
        }

        private float MaxLoadVolume
        {
            get { return this.m_MaxLoadVolume; }
            set
            {
                if (value <= 0)
                {
                    throw new Utils.Exceptions.AppException("Not valid load volume", Utils.Exceptions.eErrorCode.TrackPrepertyError);
                }
                else
                {
                    this.m_MaxLoadVolume=value;
                }
            }
        }

    }

}