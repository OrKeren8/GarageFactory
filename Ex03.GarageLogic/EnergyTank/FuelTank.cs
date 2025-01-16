using System.Collections.Generic;
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

        /*public FuelTank(float i_FuelCapacity, eFuelType i_EnergyType) : base(i_FuelCapacity)
        {
            m_EnergyType = i_EnergyType;
        }*/

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            m_FuelType = (eFuelType)i_Schema["Fuel Type"].Value;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> fuelTankSchema = new Dictionary<string, FieldDescriptor>();

            fuelTankSchema["Fuel Type"] = new FieldDescriptor { StringDescription = "Fuel Type", Type = typeof(eFuelType), IsRequired = true };
            fuelTankSchema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current fuel Amount in litters", Type = typeof(float), IsRequired = true };
            return fuelTankSchema;
        }

        public eFuelType EnergyType
        {
            get { return m_FuelType; }
        }

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Tank Capacity"] = base.m_MaxCapacity.ToString();
            info["Current Fuel Amount Left"] = $"{base.m_CurrAmount.ToString()} liters";
            info["Fuel Type"] = m_FuelType.ToString();

            return info;
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
