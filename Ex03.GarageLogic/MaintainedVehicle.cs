namespace Ex03.GarageLogic
{
    public enum eMaintenanceStatus
    {
        InProgress,
        Fixed,
        Paid
    }
    public class MaintainedVehicle
    {
        public string OwnerName { get; private set; }
        public string PhoneNumber { get; private set; }
        public eMaintenanceStatus Status { get; private set; }
        public Vehicle Vehicle {  get; private set; } 

        
        public MaintainedVehicle(Vehicle i_Vehicle)
        {
            Vehicle = i_Vehicle;
        }

        public void initMaintainedVehicle(  string i_OwnerName,
                                            string i_PhoneNumber)
        {
            OwnerName = i_OwnerName;
            PhoneNumber = i_PhoneNumber;
            Status = eMaintenanceStatus.InProgress;
        }

        public void ChangeStatus(eMaintenanceStatus i_Status)
        {
            Status=i_Status;
        }
    }

}

