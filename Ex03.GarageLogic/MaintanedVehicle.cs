namespace Ex03.GarageLogic
{

    public enum eMaintenanceStatus
    {
        InProgress,
        Fixed,
        Paid

    }

    internal class MaintanedVehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eMaintenanceStatus m_Status;
        private Vehicle m_Vehicle;

        public MaintanedVehicle(string i_OwnerName, 
                                string i_OwnerPhoneNumber, 
                                Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Status = eMaintenanceStatus.InProgress;
            m_Vehicle = i_Vehicle;
        }
    }
}
