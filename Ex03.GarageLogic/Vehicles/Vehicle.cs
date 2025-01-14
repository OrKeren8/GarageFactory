using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        public string LicenseNumber { get; private set; }
        private string ModelName { get; set; }
        public List<Wheel> Wheels { get; set; }
        private EnergyTank EnergyTank { get; set; }


        public void InitVehicle( string i_LicenseNumber,
                        string i_MmodelName,
                        List<Wheel> i_Wheels,
                        EnergyTank i_EnergyTank)//most likly we need to give a schema
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_MmodelName;
            Wheels = i_Wheels;
            EnergyTank = i_EnergyTank;
        }

        public virtual Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["License number"] = LicenseNumber.ToString();
            info["Model name"] = ModelName.ToString();

            info.Concat(EnergyTank.GetInfo());
            info.Concat(Wheels[0].GetInfo());

            return info;
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();

            schema["License number"] = new FieldDescriptor { StringDescription = "License number", Type = typeof(string), IsRequired = true };
            schema["Model name"] = new FieldDescriptor { StringDescription = "Model name", Type = typeof(string), IsRequired = false };
            var mergedSchema = schema.Concat(Wheels[0].GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var mergedSchemanewer = schema.Concat(EnergyTank.GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            return mergedSchemanewer;
        }
    }
}
