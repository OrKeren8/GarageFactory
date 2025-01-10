namespace Ex03.GarageLogic
{
    public enum eMaintenanceStatus
    {
        InProgress,
        Fixed,
        Paid
    }
    internal class MaintainedVehicle
    {
        string m_OwnerName;
        string m_PhoneNumber;
        eMaintenanceStatus m_Status;
        Vehicle m_Vehicle;

        public MaintainedVehicle(string i_OwnerName,
                                 string i_PhoneNumber, 
                                 Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = eMaintenanceStatus.InProgress;
            m_Vehicle = i_Vehicle;
        }

        public void ChangeStatus(eMaintenanceStatus i_Status)
        {
            m_Status=i_Status;
        }
    }

}

