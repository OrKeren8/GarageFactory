namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Blue,
        Black,
        White,
        Gray
    }

    public class Car
    {
        private eColor m_Color;
        private int m_Doors;
        private EnergyTank m_EnergyTank;
        public Car(EnergyTank i_EnergyTank, eColor i_Color, int i_Doors)
        {
            m_EnergyTank = i_EnergyTank;
            m_Color = i_Color;
            m_Doors = i_Doors;
        }
    }
}
