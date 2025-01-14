using Ex03.GarageLogic;
using System.Collections.Generic;
using System;

namespace UI
{
    public class UI
    {
        private VehicleFactory m_ClassFactory = new VehicleFactory();
        private Garage m_Garage = new Garage();

        public UI()
        {
        }

        public void StartGragageUI()
        {
        }

        private void printVehicleInfo(string i_LicenseNumber)
        {
            ///prints all of the data of a specific vehicle by its license number

            Dictionary<string, string> vehicleInfo = m_Garage.GetVehicleData(i_LicenseNumber);
            
            printDictionary(vehicleInfo);
        }

        private void printDictionary(Dictionary<string, string> i_VehicleInfo)
        {
            foreach (KeyValuePair<string, string> item in i_VehicleInfo)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private void printMainMenu()
        {
            Console.WriteLine("Hello! Please choose one of the following option:");
            Console.WriteLine("1. Enter new vehicle to the garage");
            Console.WriteLine("2. Show all vehicle's license number, with filtering option");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate the vehicle's tires to maximum pressure");
            Console.WriteLine("5. Refuel a vehicle powered by fuel");
            Console.WriteLine("6. Charge electric vehicle");
            Console.WriteLine("7. Retrieve complete details of a vehicle by its license number");

        }
        private Menu.eMenuSelect getUserSelection()
        {
            Menu.eMenuSelect userSelection;
            string userStringChoice;
            int userIntChoice;

            printMainMenu();
            userStringChoice = Console.ReadLine();
            while (!StringValidator.CheckUserMainMenuSelection(userStringChoice))
            {
                Console.WriteLine("Wrong selection, please try again:");
                userStringChoice = Console.ReadLine();
            }
            userIntChoice = int.Parse(userStringChoice);
            userSelection = (Menu.eMenuSelect)userIntChoice;
            return userSelection;
        }

        private void addVehicleToGarageNewOrOld()
        {
            string vehicleLicenseNumber;

            Console.WriteLine("Please enter license number of the vehicle you want to add to the garage");
            vehicleLicenseNumber = Console.ReadLine();
            if (!m_Garage.IsVehicleExist(vehicleLicenseNumber))
            {
                //List(Properties) = m_Garage.GetVehicleData(vehicleLicenseNumber); //TODO: i dont understand what this do?
                //Vehicle newUserVehicle = getDataFromUser(prope);
                m_Garage.AddNewVehicle(newVehicle);
                Console.WriteLine("Successfully added!");
            }
            else
            {
                Console.WriteLine("The Vehicle already exist");
                m_Garage.ChangeStatus(vehicleLicenseNumber, eMaintenanceStatus.InProgress);
                Console.WriteLine("The Status of the vehicle changed to - In Progress");
            }
        }

        private void showAllLicensedNumber()
        {
            eMaintenanceStatus wantedStatus;
            string wantedStatusString;
            
            Console.WriteLine("please enter a wanted vehicles status");
            wantedStatusString = Console.ReadLine();
            //TODO: there is a problem if the string does not look like the wanted status string
            wantedStatus = (eMaintenanceStatus)Enum.Parse(typeof(eMaintenanceStatus), wantedStatusString);
            printLicenseNumberFiltered(m_Garage.GetAllLicenseNumbersFiltered(wantedStatus), wantedStatusString);
        }

        private void printLicenseNumberFiltered(List<string> licenseNumberByFilter, string i_wantedStatusString)
        {
            Console.WriteLine($"All the license number of the status: {i_wantedStatusString} are:");
            foreach (string licenseNumber in licenseNumberByFilter)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private void changeVehicleStatus()
        {
            string licenceNumber = getLicenseNumberFromUser();
            eMaintenanceStatus wantedChangeStatus;
            string wantedChangeStatusString;
            
            Console.WriteLine("Please enter the status you want for your vehicle:");
            wantedChangeStatusString = Console.ReadLine();
            while (!StringValidator.IsValidStatus(wantedChangeStatusString))
            {
                Console.WriteLine("Wrong input, please try again");
                wantedChangeStatusString = Console.ReadLine();
            }
            wantedChangeStatus = (eMaintenanceStatus)Enum.Parse(typeof(eMaintenanceStatus), wantedChangeStatusString);
            m_Garage.ChangeStatus(licenceNumber, wantedChangeStatus);
            Console.WriteLine($"Status successfully changed to {wantedChangeStatus}!");
        }

        private void FillWheelsToTheMax()
        {
            string licenceNumber = getLicenseNumberFromUser();

            m_Garage.FillWheelsToTheMax(licenceNumber);
            Console.WriteLine("Your wheels successfully filled!");
        }

        private string getLicenseNumberFromUser()
        {
            string licenceNumber;

            Console.WriteLine("Please enter the license Number:");
            licenceNumber = Console.ReadLine();
            while (!StringValidator.IsValidLicenseNumber(licenceNumber))
            {
                Console.WriteLine("License number is not valid, please try again");
                licenceNumber = Console.ReadLine();
            }

            return licenceNumber;
        }

        private void PrintWheels(List<Wheel> i_WheelsToPrint)
        {
            Console.WriteLine("The wheels details are:");
            foreach (Wheel currWheel in i_WheelsToPrint)
            {
                Console.WriteLine($"Manufacturer: {currWheel.Manufacturer}");
                Console.WriteLine($"Current Air Pressure Status: {currWheel.CurrAirPressure}");
            }
        }
    }
}
