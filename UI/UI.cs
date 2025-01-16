using Ex03.GarageLogic;
using System.Collections.Generic;
using Utils;
using System;
using System.Runtime.CompilerServices;

namespace UI
{
    public class UI
    {
        private VehicleFactory ClassFactory = new VehicleFactory();
        private Garage VehicleGarage = new Garage();

        
        public void ApplicationMainLoop()
        {
            bool exit = false;
            Menu.eMenuSelect userChoice;


            while (!exit)
            {
                userChoice = getUserMenuSelection();
                System.Console.Clear();
                switch(userChoice) {
                    case Menu.eMenuSelect.Exit:
                        exit = true;
                        break;
                    case Menu.eMenuSelect.EnterNewVehicleToGarage:
                        addVehicleToGarage();
                        break;
                    case Menu.eMenuSelect.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case Menu.eMenuSelect.InflateVehicleTiresToMaximum:
                        //FillWheelsToTheMax();
                        break;
                    case Menu.eMenuSelect.ShowAllVehicleLicenseNumber:
                        showAllLicensedNumber();
                        break;
                }
            }
        }

        private void printMainMenu()
        {
            //TODO: should print the strings from the menu.
            Console.WriteLine("Hello! Please choose one of the following option:");
            //Console.WriteLine($"{Menu.eMenuSelect.EnterNewVehicleToGarage.GetHashCode()}. Enter new vehicle to the garage");
            Console.WriteLine($"{Menu.eMenuSelect.ShowAllVehicleLicenseNumber.GetHashCode()}. Show all vehicle's license number, with filtering option"); //need to add function that returned all of the vehicle in the garage
            Console.WriteLine($"{Menu.eMenuSelect.ChangeVehicleStatus.GetHashCode()}. Change vehicle status"); // need to check
            Console.WriteLine($"{Menu.eMenuSelect.InflateVehicleTiresToMaximum.GetHashCode()}. Inflate the vehicle's tires to maximum pressure"); //need to check
            Console.WriteLine($"{Menu.eMenuSelect.RefuelFuelVehicle.GetHashCode()}. Refuel a vehicle powered by fuel"); //TODO: I created fuelVehicleUI but need to complete
            Console.WriteLine($"{Menu.eMenuSelect.ChargeElectricVehicle.GetHashCode()}. Charge electric vehicle"); //TODO: I created chargeVehicleUI but need to complete
            //Console.WriteLine($"{Menu.eMenuSelect.GetDetailsOfVehicleByLicenseNumber.GetHashCode()}. Retrieve complete details of a vehicle by its license number");
            Console.WriteLine($"{Menu.eMenuSelect.Exit.GetHashCode()}. Exit");
            Console.WriteLine();
        }

        private void freezeScreenTillEnter()
        {
            Console.WriteLine("\n\nEnter to close the program");
            Console.ReadLine();
        }

        private Menu.eMenuSelect getUserMenuSelection()
        {
            Menu.eMenuSelect userChoice;

            printMainMenu();
            GetValidDataFromUser(out userChoice, StringValidator.CheckStringOfEnum<Menu.eMenuSelect>);
            
            return userChoice;
        }

        private void printVehicleInfo(string i_LicenseNumber)
        {
            ///prints all of the data of a specific vehicle by its license number

            //Dictionary<string, string> vehicleInfo = m_Garage.GetVehicleData(i_LicenseNumber);
            
            //printDictionary(vehicleInfo);
        }

        private void printDictionary(Dictionary<string, string> i_VehicleInfo)
        {
            foreach (KeyValuePair<string, string> item in i_VehicleInfo)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private void addVehicleToGarage()
        {
            string vehicleLicenseNumber;

            Console.WriteLine("Please enter license number of the vehicle you want to add to the garage");
            vehicleLicenseNumber = Console.ReadLine();
            if (!VehicleGarage.IsVehicleExist(vehicleLicenseNumber))
            {
                
                createNewVehicle(vehicleLicenseNumber);
                Console.WriteLine("Successfully added!");
            }
            else
            {
                Console.WriteLine("The Vehicle already exist");
                VehicleGarage.ChangeStatus(vehicleLicenseNumber, eMaintenanceStatus.InProgress);
                Console.WriteLine("The Status of the vehicle changed to - In Progress");
            }
        }

        private void createNewVehicle(string i_LicenseNumber)
        {
            eVehiclesTypes vehicleType = getVehiclaTypeFromUser();

            try
            {
                VehicleGarage.AddVehicle(ClassFactory.CreateVehicle(vehicleType, i_LicenseNumber));
                VehicleGarage.GetVehicleData(i_LicenseNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private eVehiclesTypes getVehiclaTypeFromUser()
        {
            eVehiclesTypes userTypeChoice;

            Console.WriteLine("Please enter your vehicle type:");
            Utils.General.PrintingStringList(ClassFactory.GetAllVehicleTypeNamesAndValues());
            GetValidDataFromUser(out userTypeChoice, StringValidator.CheckStringOfEnum<eVehiclesTypes>);

            
            return userTypeChoice;
        }

        private void showAllLicensedNumber()
        {
            eMaintenanceStatus wantedStatus;
            Console.WriteLine("please enter a wanted vehicles status, or press enter if you dont want to filter");
            GetValidDataFromUser(out wantedStatus, StringValidator.CheckStringOfEnum<eMaintenanceStatus>);
        }

        private void printStatusType()
        {

        }


        private void changeVehicleStatus()
        {
            string licenceNumber = getLicenseNumberFromUser();
            eMaintenanceStatus newStatus;
            
            Console.WriteLine("Please enter the status you want for your vehicle:");
            GetValidDataFromUser(out newStatus, StringValidator.CheckStringOfEnum<eMaintenanceStatus>);

            VehicleGarage.ChangeStatus(licenceNumber, newStatus);
            Console.WriteLine($"Status successfully chanwantedChange to {newStatus}!");
        }

        /*private void FillWheelsToTheMax(wantedChange        {
            string licenceNumber = getLicenseNumberFromUser();

            VehicleGarage.FillWheelsToTheMax(licenceNumber);
            Console.WriteLine("Your wheels successfully filled!");
        }*/

        private string getLicenseNumberFromUser()
        {
            string licenceNumber;

            Console.WriteLine("Please enter the license Number:");
            GetValidDataFromUser(out licenceNumber, StringValidator.IsValidLicenseNumber);

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

        /// <summary>
        /// Continuously prompts the user until valid data is provided.
        /// </summary>
        /// <typeparam name="T">The type of data to collect.</typeparam>
        /// <param name="o_OutVal">The validated output value.</param>
        /// <param name="ValidatorFunc">The validation function to apply.</param>
        private void GetValidDataFromUser<T>(out T o_OutVal, Func<string, (bool IsValid, T Value)> ValidatorFunc)
        {
            while (true)
            {
                string input = Console.ReadLine();

                var result = ValidatorFunc(input);

                if (result.IsValid)
                {
                    o_OutVal = result.Value;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        private void fuelVehicleUI()
        {
            string userLicensNumber = getLicenseNumberFromUser();
            eFuelType fuelTypeChoice;
            float fuelAmount;
            //CheckIfVechicleTypeIsByFuel(userLicensNumber); //TODO: need to add function that check if its run by fuel
            Console.WriteLine("Please enter your fuel type:");
            Utils.General.PrintingStringList(ClassFactory.GetAllFueledType());
            GetValidDataFromUser(out fuelTypeChoice, StringValidator.CheckStringOfEnum<eFuelType>);
            Console.WriteLine("Please enter the amount of the fuel you want:");
            fuelAmount = float.Parse(Console.ReadLine());
            VehicleGarage.FuelVehicle(userLicensNumber, fuelTypeChoice, fuelAmount);
            Console.WriteLine("Successfully fueled");
        }

        private void chargeVehicleUI()
        {
            string userLicensNumber = getLicenseNumberFromUser();
            float amountOfMinutes;
            //CheckIfVehicleTypeIsByBattery(userLicensNumber); //TODO: need to add function that check if its run by battery
            Console.WriteLine("Please enter how many minutes you want to charge:");
            amountOfMinutes = float.Parse(Console.ReadLine());
            VehicleGarage.ChargeElectricBattery(userLicensNumber, amountOfMinutes);
            Console.WriteLine("Successfully charged");
        }
    }

}

