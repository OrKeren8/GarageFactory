using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string Name { get; set; }
        public string LicenseNumber { get; private set; }
        private string ModelName { get; set; }
        private List<Wheel> Wheels { get; set; }
        private EnergyTank EnergyTank { get; set; }

        public virtual Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["License number"] = LicenseNumber.ToString();
            info["Name"] = Name;
            info["Model name"] = ModelName.ToString();

            info.Concat(EnergyTank.GetInfo());
            info.Concat(Wheels[0].GetInfo());

            return info;
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();
         
            schema["License number"] = new FieldDescriptor { StringDescription = "License number", Type = typeof(string), IsRequired = true },
            schema["Model name"] = new FieldDescriptor { StringDescription = "Model name", Type = typeof(string), IsRequired = false }

            return schema;
        }
    }
}
