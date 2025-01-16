using System.Collections.Generic;
using Utils;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string Manufacturer { get; private set; }
        public float CurrAirPressure {  get; private set; }
        public float MaxAirPressure {  get; private set; }
        private Dictionary<string, FieldDescriptor> Schema { get; set; } = null;

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            Schema = i_Schema;
            this.Manufacturer = Schema["Manufacturer"].Value.ToString();
            this.CurrAirPressure = (float)Schema["Curr Air Pressure"].Value;
            this.MaxAirPressure = (float)Schema["Max Air Pressure"].Value;
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            if(Schema == null) 
            {
                Schema = new Dictionary<string, FieldDescriptor>();

                Schema["Manufacturer"] = new FieldDescriptor { StringDescription = "Wheels Manufacturer", Type = typeof(string), IsRequired = true };
                Schema["Curr Air Pressure"] = new FieldDescriptor { StringDescription = "Curr Air Pressure", Type = typeof(float), IsRequired = true };
                Schema["Max Air Pressure"] = new FieldDescriptor { StringDescription = "Max Air Pressure", Type = typeof(float), IsRequired = false };
            }

            return Schema;
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
                throw new Utils.Exceptions.ValueOutOfRangeException(MaxAirPressure, 0);
            }
            else
            {
                CurrAirPressure += i_AditionalPressure;
            }
        }
    }
}
