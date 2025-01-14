using System.Collections.Generic;
using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrAirPressure;
        private float m_MaxAirPressure;

        public Dictionary<string, string> GetInfo()
        {
            var info = new Dictionary<string, string>();
            
            info["Manufacturer"] = m_Manufacturer;
            info["Air Pressure"] = m_CurrAirPressure.ToString();

            return info;
        }

        public void FillAir(float i_AditionalPressure)
        {
            //this function fill the wheel with extra air if maximum pressure does not exceed
            if (m_CurrAirPressure + i_AditionalPressure > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0);
            }
            else
            {
                m_CurrAirPressure += i_AditionalPressure;
            }

        }

        public virtual Dictionary<string, FieldDescriptor> GetWheelSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();

            schema["Manufacturer"] = new FieldDescriptor { StringDescription = "Manufacturer", Type = typeof(string), IsRequired = true };
            schema["Curr Air Pressure"] = new FieldDescriptor { StringDescription = "Curr Air Pressure", Type = typeof(float), IsRequired = false };
            schema["Max Air Pressure"] = new FieldDescriptor { StringDescription = "Max Air Pressure", Type = typeof(float), IsRequired = false };

            return schema;
        }
    }
}
