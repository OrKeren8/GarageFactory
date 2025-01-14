namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A1,
        A2,
        B1,
        B2
    }


    internal class Motorcycle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private EnergyTank m_EnergyTank;

        ///can have fuel tank or electric battry
        ///שניהם צריכים לעבוד בצורה זהה
        ///כרגע מימשנו אותם שונה 
        ///fueltank.addFuel()
        ///ElectricBattery.AddTime()
        ///

        ///factory pattern: one file create all of the object in the program
        ///someone use them: garage
        ///i want to fuel a car
        ///
        ///garage:
        /// if(car.electric: add electicity
        /// else{
        ///     car.fuel 
        /// rather we want:
        /// car.FillEnergyTank(this function will use the energyTank.AddEnergy) 
        ///fillEnergy will call the EnergyTank.addAnergy -> 
    }
}
