using System.Collections.Generic;
using System.Linq;

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
        private int m_Doors;
        public Car(eColor i_Color, int i_Doors)
        {
            m_Color = i_Color;
            m_Doors = i_Doors;
        }

        public override Dictionary<string, string> GetInfo()
        {
            Dictionary<string, string> info = base.GetInfo();

            info["Color"] = m_Color.ToString();
            info["Amount of doors:"] = m_Doors.ToString();

            return info;
        }

        public override List<FieldDescriptor> GetSchema()
        {
            List<FieldDescriptor> carListSchema = base.GetSchema();

            carListSchema.Add(new FieldDescriptor { StringDescription = "Color", Type = typeof(eColor), IsRequired = true });
            carListSchema.Add(new FieldDescriptor { StringDescription = "Doors", Type = typeof(int), IsRequired = true });
            return carListSchema;
            
        }
    }
}
