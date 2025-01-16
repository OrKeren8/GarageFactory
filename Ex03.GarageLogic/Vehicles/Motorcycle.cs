﻿using System.Collections.Generic;
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
        private eLicenseType LicenseType {  get; set; }
        private float EngineVolume {  get; set; }

        public Motorcycle(  string i_LicenseNumber,
                            List<Wheel> i_Wheels, 
                            EnergyTank i_EnergyTank) : base(   i_LicenseNumber,
                                                                i_Wheels,
                                                                i_EnergyTank) { }

        public override void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.LicenseType = (eLicenseType)i_Schema["License Type"].Value;
            this.EngineVolume = (float)i_Schema["Engine Volume"].Value;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> motorcycleSchema = base.GetSchema();

            motorcycleSchema["License type"] = new FieldDescriptor { StringDescription = "License type", Type = typeof(eLicenseType), IsRequired = true };
            motorcycleSchema["Engine volume"] = new FieldDescriptor { StringDescription = "Engine volume", Type = typeof(int), IsRequired = true };

            return motorcycleSchema;
        }
    }
}
