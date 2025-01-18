using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public enum eMaintenanceStatus
    {
        InProgress,
        Fixed,
        Paid
    }
    public enum eMaintenanceStatusWithDefault
    {
        InProgress = eMaintenanceStatus.InProgress,
        Fixed = eMaintenanceStatus.Fixed,
        Paid = eMaintenanceStatus.Paid,
        All
    }

    public class MaintainedVehicle
    {
        public string OwnerName { get; private set; }
        public string PhoneNumber { get; private set; }
        public eMaintenanceStatus Status { get; private set; } = eMaintenanceStatus.InProgress;
        public Vehicle Vehicle {  get; private set; } 

        
        public MaintainedVehicle(Vehicle i_Vehicle)
        {
            Vehicle = i_Vehicle;
        }

        public void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            OwnerName = i_Schema["Owner Name"].Value.ToString();
            PhoneNumber = i_Schema["Phone Number"].Value.ToString();
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> schema = new Dictionary<string, FieldDescriptor>();

            schema["Owner Name"] = new FieldDescriptor { StringDescription = "Owner Name", Type = typeof(string), IsRequired = true, Value = this.OwnerName };
            schema["Phone Number"] = new FieldDescriptor { StringDescription = "Phone Number", Type = typeof(string), IsRequired = true, Value = this.PhoneNumber };
            var mergedSchema = schema.Concat(this.Vehicle.GetSchema()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            schema = mergedSchema;

            return schema;
        }

        public void ChangeStatus(eMaintenanceStatus i_Status)
        {
            Status=i_Status;
        }

    }

}

