﻿using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{

    public class Vehicle
    {
        public string LicenseNumber { get; private set; }
        private string ModelName { get; set; }
        public List<Wheel> Wheels { get; set; }
        public EnergyTank EnergyTank { get; set; } = null;

        public Vehicle(string i_LicenseNumber, List<Wheel> i_Wheels, EnergyTank i_EnergyTank) 
        {
            LicenseNumber = i_LicenseNumber;
            Wheels = i_Wheels;
            EnergyTank = i_EnergyTank;
        }

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            ModelName = i_Schema["Model Name"].Value.ToString();
            foreach (Wheel wheel in Wheels)
            {
                wheel.Init(i_Schema);
            }
            EnergyTank.Init(i_Schema);
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();
            
            schema["Model Name"] = new FieldDescriptor { StringDescription = "Model Name", Type = typeof(string), IsRequired = true, Value=this.ModelName};
            var mergedSchema = schema.Concat(Wheels[0].GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var mergedSchemanewer = mergedSchema.Concat(EnergyTank.GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            schema = mergedSchemanewer;

            return schema;
        }
    }
}
