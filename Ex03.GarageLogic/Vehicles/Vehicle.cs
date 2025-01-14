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

        public List<FieldDescriptor> GetObjectData()
        {
            return new List<FieldDescriptor> {
                    new FieldDescriptor { Name = "Name", Type = typeof(string), IsRequired = true },
                    new FieldDescriptor { Name = "License number", Type = typeof(string), IsRequired = true },
                    new FieldDescriptor { Name = "Model name", Type = typeof(string), IsRequired = false }
                };
        }
    }
}
