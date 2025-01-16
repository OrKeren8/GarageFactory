using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{

    public class Vehicle
    {
        public string LicenseNumber { get; private set; }
        private string ModelName { get; set; }
        public List<Wheel> Wheels { get; set; }
        public EnergyTank EnergyTank { get; set; } = null;

        private Dictionary<string, FieldDescriptor> Schema { get; set; } = null;
        

        public Vehicle(string i_LicenseNumber, List<Wheel> i_Wheels, EnergyTank i_EnergyTank) 
        {
            LicenseNumber = i_LicenseNumber;
            Wheels = i_Wheels;
            EnergyTank = i_EnergyTank;
        }

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            LicenseNumber = i_Schema["License Number"].Value.ToString();
            ModelName = i_Schema["Model Name"].Value.ToString();
            foreach (Wheel wheel in Wheels)
            {
                wheel.Init(i_Schema);
            }
            EnergyTank.Init(i_Schema);
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            
            if(Schema == null)
            {
                Schema = new Dictionary<string, FieldDescriptor>();

                Schema["Model name"] = new FieldDescriptor { StringDescription = "Model name", Type = typeof(string), IsRequired = false };
                var mergedSchema = Schema.Concat(Wheels[0].GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                var mergedSchemanewer = mergedSchema.Concat(EnergyTank.GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                Schema = mergedSchema;
            }

            return Schema;
        }
    }
}
