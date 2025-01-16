using System;
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
        private eColor m_Color;
        private int m_NumOfDoors;

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

        private int NumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set
            {
                if (value< 2 || value> 5)
                {
                    throw new Utils.Exceptions.AppException("Not valid amount of car doors", Utils.Exceptions.eErrorCode.CarDoorsOutOfRange);
                }
            }
        }

        private eColor Color
        {
            get { return this.m_Color; }
            set
            {
                if (!Enum.IsDefined(typeof(eColor), value))
                {
                    throw new Utils.Exceptions.AppException("Not valid car color", Utils.Exceptions.eErrorCode.CarColorError);
                }
            }
        }

    }
}
