using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        private float m_EngineVolume;

        public Motorcycle(  string i_LicenseNumber,
                            List<Wheel> i_Wheels, 
                            EnergyTank i_EnergyTank) : base(   i_LicenseNumber,
                                                                i_Wheels,
                                                                i_EnergyTank) { }

        public override void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.LicenseType = (eLicenseType)i_Schema["License Type"].Value;
            this.EngineVolume = (float)(i_Schema["Engine Volume"].Value);
            base.Init(i_Schema);
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = base.GetSchema();
            
            schema["License Type"] = new FieldDescriptor { StringDescription = "License Type", Type = typeof(eLicenseType), IsRequired = true, Value=this.LicenseNumber};
            schema["Engine Volume"] = new FieldDescriptor { StringDescription = "Engine Volume", Type = typeof(float), IsRequired = true, Value = this.EngineVolume };

            return schema;
        }

        private eLicenseType LicenseType
        {
            get { return this.m_LicenseType; }
            set
            {
                if ((!Enum.IsDefined(typeof(eLicenseType), value)))
                {
                    throw new Utils.Exceptions.AppException("Not valid motorcycle license type", Utils.Exceptions.eErrorCode.MototrCyclePrepertyError);
                }
                else
                {
                    this.m_LicenseType = value;
                }
            }
        }

        private float EngineVolume
        {
            get { return this.m_EngineVolume; }
            set
            {
                if (value <= 0)
                {
                    throw new Utils.Exceptions.AppException("Not valid engine volume", Utils.Exceptions.eErrorCode.MototrCyclePrepertyError);
                }
                else
                {
                    this.m_EngineVolume = value;
                }
            }
        }
    }
}
