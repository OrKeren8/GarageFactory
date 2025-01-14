using System.Collections.Generic;
using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string Manufacturer { get; private set; }
        public float CurrAirPressure {  get; private set; }
        public float MaxAirPressure {  get; private set; }

        public Dictionary<string, string> GetInfo()
        {
            var info = new Dictionary<string, string>();
            
            info["Manufacturer"] = Manufacturer;
            info["Air Pressure"] = CurrAirPressure.ToString();

            return info;
        }

        public void FillAir(float i_AditionalPressure)
        {
            //this function fill the wheel with extra air if maximum pressure does not exceed
            if (CurrAirPressure + i_AditionalPressure > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(MaxAirPressure, 0);
            }
            else
            {
                CurrAirPressure += i_AditionalPressure;
            }

        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> wheelSchema = new Dictionary<string, FieldDescriptor>();

            wheelSchema["Manufacturer"] = new FieldDescriptor { StringDescription = "Manufacturer", Type = typeof(string), IsRequired = true };
            wheelSchema["Curr Air Pressure"] = new FieldDescriptor { StringDescription = "Curr Air Pressure", Type = typeof(float), IsRequired = false };
            wheelSchema["Max Air Pressure"] = new FieldDescriptor { StringDescription = "Max Air Pressure", Type = typeof(float), IsRequired = false };

            return wheelSchema;
        }
    }
}
