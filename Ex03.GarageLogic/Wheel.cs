using System.Collections.Generic;
using Utils;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string Manufacturer { get; private set; }
        public float CurrAirPressure { get; private set; } = 0;
        public float MaxAirPressure {  get; private set; }

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.Manufacturer = i_Schema["Manufacturer"].Value.ToString();
            this.MaxAirPressure = (float)i_Schema["Max Air Pressure"].Value;
            FillAir((float)i_Schema["Curr Air Pressure"].Value);
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();
            
            schema["Manufacturer"] = new FieldDescriptor { StringDescription = "Wheels Manufacturer", Type = typeof(string), IsRequired = true, Value=this.Manufacturer};
            schema["Curr Air Pressure"] = new FieldDescriptor { StringDescription = "Curr Air Pressure", Type = typeof(float), IsRequired = true, Value = this.CurrAirPressure };
            schema["Max Air Pressure"] = new FieldDescriptor { StringDescription = "Max Air Pressure", Type = typeof(float), IsRequired = false, Value = this.MaxAirPressure };

            return schema;
        }

        /// <summary>
        /// fill the wheel with extra air, only if maximum pressure does not exceed
        /// </summary>
        /// <param name="i_AditionalPressure">The amount of pressure to add in PSI</param>
        /// <exception cref="ValueOutOfRangeException">if the total pressure exceed the maximum</exception>
        public void FillAir(float i_AditionalPressure)
        {
            if (CurrAirPressure + i_AditionalPressure > MaxAirPressure)
            {
                throw new Utils.Exceptions.ValueOutOfRangeException(MaxAirPressure, 0, "Max air pressure exceed");
            }
            else
            {
                CurrAirPressure += i_AditionalPressure;
            }
        }
    }
}
