using System.Collections.Generic;
using System.Linq;
namespace Ex03.GarageLogic
{

    public enum eFuelType
    {
        Solar,
        Octan95,
        Octan96,
        Octan98
    }

    internal class FuelTank : EnergyTank
    {
        private eFuelType m_EnergyType;
        public FuelTank(float i_FuelCapacity, eFuelType i_EnergyType) : base(i_FuelCapacity)
        {
            m_EnergyType = i_EnergyType;
        }

        public eFuelType EnergyType
        {
            get { return m_EnergyType; }
        }

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Tank Capacity"] = base.m_MaxCapacity.ToString();
            info["Current Fuel Amount Left"] = $"{base.m_CurrAmount.ToString()} liters";
            info["Fuel Type"] = m_EnergyType.ToString();

            return info;
        }

        public override void Fill(float i_FuelAmount, eFuelType i_FuelType)
        {
            ///this funciton adds fuel to the tank as requested
            ///as long as the tank is not over flows
            m_EnergyType = i_FuelType;
            base.Fill(i_FuelAmount);
        }
        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> fuelTankSchema = new Dictionary<string, FieldDescriptor>();

            fuelTankSchema["Fuel Type"] = new FieldDescriptor { StringDescription = "Fuel Type", Type = typeof(eFuelType), IsRequired = true };
            return fuelTankSchema;
        }
    }
}
