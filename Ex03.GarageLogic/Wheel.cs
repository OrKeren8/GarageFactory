using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrAirPressure;
        float m_MaxAirPressure;


        public void FillAir(float i_AditionalPressure)
        {
            //this function fill the wheel with extra air if maximum pressure does not exceed
            if (m_CurrAirPressure + i_AditionalPressure > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0);
            }
            else
            {
                m_CurrAirPressure += i_AditionalPressure;
            }

        }
    }
}
