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

        public Car(string i_LicenseNumber, List<Wheel> i_Wheels, EnergyTank i_EnergyTank) : base(i_LicenseNumber, i_Wheels, i_EnergyTank) { }

        public override void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            this.NumOfDoors = (int)i_Schema["Amount Of Doors"].Value;
            this.Color = (eColor)i_Schema["Color"].Value;
            base.Init(i_Schema);
        }

        public override Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = base.GetSchema();

            schema["Color"] = new FieldDescriptor { StringDescription = "Color", Type = typeof(eColor), IsRequired = true, Value = this.Color };
            schema["Amount Of Doors"] = new FieldDescriptor { StringDescription = "Amount Of Doors", Type = typeof(int), IsRequired = true, Value = this.NumOfDoors };

            return schema;
        }
    }
}
