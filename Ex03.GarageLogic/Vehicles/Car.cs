using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Blue,
        Black,
        White,
        Gray
    }

    public class Car : Vehicle
    {
        private eColor Color {  get; set; }
        private int NumOfDoors {  get; set; }
        public void InitCar( eColor i_Color,
                        int i_NumOfDoors,
                        string i_LicenseNumber,
                        string i_ModelName,
                        List<Wheel> i_Wheels,
                        EnergyTank i_EnergyTank) : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyTank)
        {
            Color = i_Color;
            NumOfDoors = i_NumOfDoors;
        }

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = base.GetInfo();

            info["Color"] = Color.ToString();
            info["Amount of doors:"] = NumOfDoors.ToString();

            return info;
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> carSchema = base.GetSchema();

            carSchema["Color"] = new FieldDescriptor { StringDescription = "Color", Type = typeof(eColor), IsRequired = true};
            carSchema["Amount of doors"] = new FieldDescriptor { StringDescription = "Amount of doors", Type = typeof(int), IsRequired = true };

            return carSchema;
        }
    }
}
