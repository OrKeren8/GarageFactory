﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
namespace Ex03.GarageLogic
{

    public enum eFuelType
    {
        Solar,
        Octan95,
        Octan96,
        Octan98
    }

    public class FuelTank : EnergyTank
    {
        private eFuelType m_FuelType;
        private readonly eEnergyTankType EnergyTankType = eEnergyTankType.FuelTank;
        private Dictionary<string, FieldDescriptor> Schema { get; set; } = null;


        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            m_FuelType = (eFuelType)i_Schema["Fuel Type"].Value;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            
            if (Schema == null)
            {
                Schema = base.GetSchema();

                Schema["Fuel Type"] = new FieldDescriptor { StringDescription = "Fuel Type", Type = typeof(eFuelType), IsRequired = false };
                Schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Fuel Amount In Litters", Type = typeof(float), IsRequired = true };
            }

            return Schema;
        }

        public eFuelType EnergyType
        {
            get { return m_FuelType; }
        }

        
        public override void Fill(float i_FuelAmount, eFuelType i_FuelType)
        {
            ///this funciton adds fuel to the tank as requested
            ///as long as the tank is not over flows
            m_FuelType = i_FuelType;
            base.Fill(i_FuelAmount);
        }

        public override eEnergyTankType GetType()
        {
            return this.EnergyTankType;
        }
    }
}
