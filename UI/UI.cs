using Ex03.GarageLogic;
using System.Collections.Generic;
using System;
using static Utils.Exceptions;


namespace UI
{
    public class UI
    {
        private VehicleFactory VehicleFactory = new VehicleFactory();

        
        public void ApplicationMainLoop()
        {
            bool exit = false;
            Menu.eMenuSelect userChoice;


            while (!exit)
            {
                try
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
                            FillWheelsToTheMax();
                            break;
                        case Menu.eMenuSelect.ShowAllVehicleLicenseNumber:
                            showAllLicensedNumber();
                            break;
                        case Menu.eMenuSelect.ChargeElectricVehicle:
                            this.chargeVehicleBattery();
                            break;
                        case Menu.eMenuSelect.GetDetailsOfVehicleByLicenseNumber:
                            this.printVehicleInfo();
                            break;
                        case Menu.eMenuSelect.RefuelFuelVehicle:
                            this.fuelVehicle();
                            break;
                    }
                }
                catch (AppException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void printMainMenu()
        {
            //TODO: should print the strings from the menu.
            Console.WriteLine("Hello! Please choose one of the following option:");
            Console.WriteLine($"{Menu.eMenuSelect.EnterNewVehicleToGarage.GetHashCode()}. Enter new vehicle to the garage");
            Console.WriteLine($"{Menu.eMenuSelect.ShowAllVehicleLicenseNumber.GetHashCode()}. Show all vehicle's license number, with filtering option"); //need to add function that returned all of the vehicle in the garage
            Console.WriteLine($"{Menu.eMenuSelect.ChangeVehicleStatus.GetHashCode()}. Change vehicle status"); // need to check
            Console.WriteLine($"{Menu.eMenuSelect.InflateVehicleTiresToMaximum.GetHashCode()}. Inflate the vehicle's tires to maximum pressure"); //need to check
            Console.WriteLine($"{Menu.eMenuSelect.RefuelFuelVehicle.GetHashCode()}. Refuel a vehicle powered by fuel"); //TODO: I created fuelVehicleUI but need to complete
            Console.WriteLine($"{Menu.eMenuSelect.ChargeElectricVehicle.GetHashCode()}. Charge electric vehicle"); //TODO: I created chargeVehicleUI but need to complete
            Console.WriteLine($"{Menu.eMenuSelect.GetDetailsOfVehicleByLicenseNumber.GetHashCode()}. Retrieve complete details of a vehicle by its license number");
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

        private void printVehicleInfo()
        {
            ///prints all of the data of a specific vehicle by its license number
            string licenseNumber = getLicenseNumberFromUser();
            Dictionary<string, FieldDescriptor> schema = this.VehicleFactory.Garage.GetVehicleData(licenseNumber);

            foreach (FieldDescriptor field in schema.Values)
            {
                Console.WriteLine($"{field.StringDescription}: {field.Value}");
            }
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
            if (!VehicleFactory.Garage.IsVehicleExist(vehicleLicenseNumber))
            {
                
                createNewVehicle(vehicleLicenseNumber);
                Console.WriteLine("Successfully added!");
            }
            else
            {
                Console.WriteLine("The Vehicle already exist");
                VehicleFactory.Garage.ChangeStatus(vehicleLicenseNumber, eMaintenanceStatus.InProgress);
                Console.WriteLine("The Status of the vehicle changed to - In Progress");
            }
        }

        private void createNewVehicle(/*out bool checkIfValid,*/ string i_LicenseNumber)
        {
            eVehiclesTypes vehicleType = getVehiclaTypeFromUser();
            Dictionary<string, FieldDescriptor> vehicleSchema;


            vehicleSchema = VehicleFactory.CreateVehicle(vehicleType, i_LicenseNumber);
            fillSchemaData(vehicleSchema);
            VehicleFactory.InitVehicle(i_LicenseNumber, vehicleSchema);
        }

        private void fillSchemaData(Dictionary<string, FieldDescriptor> o_Schema)
        {
            foreach (var key in o_Schema.Keys)
            {
                if (o_Schema[key].IsRequired)
                {
                    Console.WriteLine($"Please enter the value for {o_Schema[key].StringDescription}: ");
                    if (o_Schema[key].Type.IsEnum)
                    {
                        Console.WriteLine("Available options:");
                        int i = 0;
                        foreach (var enumValue in Enum.GetNames(o_Schema[key].Type))
                        {
                            Console.WriteLine($"{i}. {enumValue}");
                            i++;
                        }
                    }
                    while (true)
                    {
                        string input = Console.ReadLine();

                        (bool, object) result = StringValidator.tryCastToType(input, o_Schema[key].Type);

                        if (result.Item1)
                        {
                            o_Schema[key].Value = result.Item2;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    }
                }
            }
        }

        private eVehiclesTypes getVehiclaTypeFromUser()
        {
            eVehiclesTypes userTypeChoice;

            Console.WriteLine("Please enter your vehicle type:");
            Utils.General.PrintingStringList(Utils.General.GetStringListOfENum<eVehiclesTypes>());
            GetValidDataFromUser(out userTypeChoice, StringValidator.CheckStringOfEnum<eVehiclesTypes>);

            
            return userTypeChoice;
        }

        private void showAllLicensedNumber()
        {
            eMaintenanceStatusWithDefault wantedStatus;
            List<string> filteredLicenseNumbers;

            Console.WriteLine("please enter a wanted vehicles status");
            Console.WriteLine("Vehicle status are:");
            Utils.General.PrintingStringList(Utils.General.GetStringListOfENum<eMaintenanceStatusWithDefault>());
            GetValidDataFromUser(out wantedStatus, StringValidator.CheckStringOfEnum<eMaintenanceStatusWithDefault>);
            filteredLicenseNumbers = VehicleFactory.Garage.GetAllLicenseNumbers(wantedStatus);
            Utils.General.PrintingStringList(filteredLicenseNumbers);
        }   

        private void printStatusType()
        {

        }


        private void changeVehicleStatus()
        {
            string licenceNumber = getLicenseNumberFromUser();
            eMaintenanceStatus newStatus;
            
            Console.WriteLine("Please enter the status you want for your vehicle:");
            Utils.General.PrintingStringList(Utils.General.GetStringListOfENum<eMaintenanceStatus>());
            GetValidDataFromUser(out newStatus, StringValidator.CheckStringOfEnum<eMaintenanceStatus>);

            VehicleFactory.Garage.ChangeStatus(licenceNumber, newStatus);
            Console.WriteLine($"Status successfully chanwantedChange to {newStatus}!");
        }

        private void FillWheelsToTheMax() 
        { 
            string licenceNumber = getLicenseNumberFromUser();

            this.VehicleFactory.Garage.FillWheelsToTheMax(licenceNumber);
            Console.WriteLine("Your wheels successfully filled!");
        }

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

        private void fuelVehicle()
        {
            string licensNumber = getLicenseNumberFromUser();
            float fuelAmount;
            eFuelType fuelTypeChoice;


            if (this.VehicleFactory.Garage.IsFueledVehicle(licensNumber))
            {
                Console.WriteLine("Please enter your fuel type:");
                Utils.General.PrintingStringList(Utils.General.GetStringListOfENum<eFuelType>());
                GetValidDataFromUser(out fuelTypeChoice, StringValidator.CheckStringOfEnum<eFuelType>);
                Console.WriteLine("Please enter the amount of the fuel you want in litters:");
                this.GetValidDataFromUser(out fuelAmount, StringValidator.IsFloat);
                VehicleFactory.Garage.FuelVehicle(licensNumber, fuelTypeChoice, fuelAmount);
                Console.WriteLine("Successfully fueled");
            }
            else
            {
                Console.WriteLine("Selected vehicle is not a fueled one ...");
            }
        }

        private void chargeVehicleBattery()
        {
            string licensNumber = getLicenseNumberFromUser();
            float amountOfMinutes;

            if (this.VehicleFactory.Garage.IsElectricVehicle(licensNumber))
            {
                Console.WriteLine("Please enter how many minutes you want to charge:");
                this.GetValidDataFromUser(out amountOfMinutes, StringValidator.IsFloat);
                VehicleFactory.Garage.ChargeElectricBattery(licensNumber, amountOfMinutes);
                Console.WriteLine("Successfully charged");
            }
            else
            {
                Console.WriteLine("Selected vehicle is not an electric one ...");
            }            
        }
    }

}

