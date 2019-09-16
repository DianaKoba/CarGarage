namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    public class GarageManager
    {
        #region Consts
        private const string k_WelcomMsg = "Hello, Welcome to the garage.";
        private const string k_SelectOperationMsg = "What would you like to do?";
        private const string k_InvlaidInputMsg = "Error! Invalid input.";
        private const string k_SelectVehicleTypeMsg = "Please select the type of the vehicle:";
        private const string k_SelectFuelTypeMsg = "Please select the fuel type:";
        private const string k_GoodByeMsg = "GoodBye. See you next time.";
        private const string k_SelectColorMsg = "Please choose the color of the car:";
        private const string k_SelectNumOfDoorsMsg = "Please choose the number of doors in the car:";
        private const string k_SelectLicenseTypeMsg = "Please select the license type:";
        private const string k_SuccessfulAdditionOfVehicleMsg = "Vehicle was successfuly added to the garage!";
        private const string k_YourSelectionMsg = "Your selection: ";
        private const string k_SelectMaxWeightMsg = "Please enter the MAX weight for this truck (KG): ";
        private const string k_SelectLitersEnergyLevelMsg = "Please enter the current energy level (liters): ";
        private const string k_SelectHoursEnergyLevelMsg = "Please enter the current energy level (Hours): ";
        private const string k_IsCarryingDangerousMaterialsMsg = "Does it carrying dangerous materials? (Y / N): ";
        private const string k_EnterLicenseNumberMsg = "Please enter the license number: ";
        private const string k_EnterModelNameMsg = "Please enter the model name: ";
        private const string k_EnterPhoneNumberMsg = "Please enter the phone number of the car owner (digits only!): ";
        private const string k_SelectEngineSizeMsg = "Please enter the size of the engine: ";
        private const string k_EnterOwnerNameMsg = "Please enter the name of the car owner (letters only!): ";
        private const string k_EnterCurrentAirPressureMsg = "Please enter the current air pressure of the wheels: ";
        private const string k_EnterManufacturerNameMsg = "Please enter the name of the wheels manufacturer: ";
        private const string k_IsStatusFilterWantedMsg = "Would you like to filter by status? (Y / N): ";
        private const string k_CantFuelElectricEngineMsg = "You can't fuel an electric vehicle!";
        private const string k_GeteFuelAmountMsg = "How much fuel to add (liters)? ";
        private const string k_CantChargeFuelEngineMsg = "You can't charge a fuel engine!";
        private const string k_GetPowerAmountMsg = "How much power to add (Hours)? ";
        private const string k_Y = "Y";
        private const string k_N = "N";
        private const string k_BeingFixedStatus = "Being fixed";
        private const string k_RepairedStatus = "Repaired";
        private const string k_PaidStatus = "Paid";
        #region UserOptions
        private const string k_EnterNewCarOption = "Enter a new car to the garage.";
        private const string k_PrintExistingVehiclesOption = "Print all the license number in the garage.";
        private const string k_UpdateVehicleStatusOption = "Update the status of an existing vehicle.";
        private const string k_PrintVehicleInfoOption = "Print the information of a specific vehicle.";
        private const string k_InflateVehicleTiresToMaxOption = "Infalte a vehicle's tires to max.";
        private const string k_FuelVehicleOption = "Fuel a vehicle.";
        private const string k_ChargeVehicleOption = "Charge an electric vehicle's battery.";
        private const string k_ExitOption = "Exit.";
        #endregion UserOptions
        #region VehiclTypes
        private const string k_Car = "Car.";
        private const string k_ElectricCar = "Electric Car.";
        private const string k_Motorcycle = "Motorcycle.";
        private const string k_ElectricMotorcycle = "Electric Motorcycle.";
        private const string k_Truck = "Truck.";
        #endregion VehicleTypes
        #endregion Consts

        #region Class members
        private eUserOptions m_UserAction = eUserOptions.None;
        private Dictionary<eUserOptions, string> m_UserOptionsDict;
        private Dictionary<eVehicleTypes, string> m_VehicleTypesDict;
        private VehicleBasicInfo m_VehicleBasicInfo;
        private Vehicle m_Vehicle = null;
        private Dictionary<eColors, string> m_CarColorDict;
        private Dictionary<eNumberOfDoors, string> m_NumOfDoorsDict;
        private Dictionary<eFuelTypes, string> m_FuelTypesDict;
        private Dictionary<eVehicleStatus, string> m_VehicleStatusDict;
        private CarBasicInfo m_CarBasicInfo;
        private Dictionary<eLicenseTypes, string> m_LicenseTypeDict;
        private MotorcycleBasicInfo m_MotorcycleBasicInfo;
        private TruckBasicInfo m_TruckBasicInfo;
        private GarageServices m_GarageServices = new GarageServices();
        private OwnerInfo m_Owner = new OwnerInfo();
        #endregion Class members

        #region General Code

        public GarageManager()
        {
            m_UserOptionsDict = new Dictionary<eUserOptions, string>();
            m_UserOptionsDict.Add(eUserOptions.EnterNewCar, k_EnterNewCarOption);
            m_UserOptionsDict.Add(eUserOptions.PrintExistingVehicles, k_PrintExistingVehiclesOption);
            m_UserOptionsDict.Add(eUserOptions.PrintVehicleInfo, k_PrintVehicleInfoOption);
            m_UserOptionsDict.Add(eUserOptions.UpdateVehicleStatus, k_UpdateVehicleStatusOption);
            m_UserOptionsDict.Add(eUserOptions.InflateVehicleTiresToMax, k_InflateVehicleTiresToMaxOption);
            m_UserOptionsDict.Add(eUserOptions.FuelVehicle, k_FuelVehicleOption);
            m_UserOptionsDict.Add(eUserOptions.ChargeVehicle, k_ChargeVehicleOption);
            m_UserOptionsDict.Add(eUserOptions.Exit, k_ExitOption);

            m_VehicleTypesDict = new Dictionary<eVehicleTypes, string>();
            m_VehicleTypesDict.Add(eVehicleTypes.FuelMotorcycle, eVehicleTypes.FuelMotorcycle.ToString());
            m_VehicleTypesDict.Add(eVehicleTypes.ElectricMotorcycle, eVehicleTypes.ElectricMotorcycle.ToString());
            m_VehicleTypesDict.Add(eVehicleTypes.FuelCar, eVehicleTypes.FuelCar.ToString());
            m_VehicleTypesDict.Add(eVehicleTypes.ElectricCar, eVehicleTypes.ElectricCar.ToString());
            m_VehicleTypesDict.Add(eVehicleTypes.Truck, eVehicleTypes.Truck.ToString());

            m_CarColorDict = new Dictionary<eColors, string>();
            m_CarColorDict.Add(eColors.Green, eColors.Green.ToString());
            m_CarColorDict.Add(eColors.Silver, eColors.Silver.ToString());
            m_CarColorDict.Add(eColors.White, eColors.White.ToString());
            m_CarColorDict.Add(eColors.Black, eColors.Black.ToString());

            m_NumOfDoorsDict = new Dictionary<eNumberOfDoors, string>();
            m_NumOfDoorsDict.Add(eNumberOfDoors.Two, eNumberOfDoors.Two.ToString());
            m_NumOfDoorsDict.Add(eNumberOfDoors.Three, eNumberOfDoors.Three.ToString());
            m_NumOfDoorsDict.Add(eNumberOfDoors.Four, eNumberOfDoors.Four.ToString());
            m_NumOfDoorsDict.Add(eNumberOfDoors.Five, eNumberOfDoors.Five.ToString());

            m_LicenseTypeDict = new Dictionary<eLicenseTypes, string>();
            m_LicenseTypeDict.Add(eLicenseTypes.A1, eLicenseTypes.A1.ToString());
            m_LicenseTypeDict.Add(eLicenseTypes.B1, eLicenseTypes.B1.ToString());
            m_LicenseTypeDict.Add(eLicenseTypes.AA, eLicenseTypes.AA.ToString());
            m_LicenseTypeDict.Add(eLicenseTypes.BB, eLicenseTypes.BB.ToString());

            m_FuelTypesDict = new Dictionary<eFuelTypes, string>();
            m_FuelTypesDict.Add(eFuelTypes.Octan95, eFuelTypes.Octan95.ToString());
            m_FuelTypesDict.Add(eFuelTypes.Octan96, eFuelTypes.Octan96.ToString());
            m_FuelTypesDict.Add(eFuelTypes.Octan98, eFuelTypes.Octan98.ToString());
            m_FuelTypesDict.Add(eFuelTypes.Diesel, eFuelTypes.Diesel.ToString());

            m_VehicleStatusDict = new Dictionary<eVehicleStatus, string>();
            m_VehicleStatusDict.Add(eVehicleStatus.BeingFixed, k_BeingFixedStatus);
            m_VehicleStatusDict.Add(eVehicleStatus.Repaired, k_RepairedStatus);
            m_VehicleStatusDict.Add(eVehicleStatus.Paid, k_PaidStatus);
        }

        public void Start()
        {
            welcomeNewUser();
            m_UserAction = (eUserOptions)getUserSelection(
                m_UserOptionsDict,
                k_SelectOperationMsg,
                (byte)eUserOptions.Min,
                (byte)eUserOptions.Max);
            while (m_UserAction != eUserOptions.Exit)
            {
                startSelectedOperation();
                m_UserAction = (eUserOptions)getUserSelection(
                    m_UserOptionsDict,
                    k_SelectOperationMsg,
                    (byte)eUserOptions.Min,
                    (byte)eUserOptions.Max);
            }

            Console.WriteLine(k_GoodByeMsg);
            Console.ReadLine();
        }

        private void welcomeNewUser()
        {
            Console.WriteLine(k_WelcomMsg);
        }

        private void startSelectedOperation()
        {
            switch (m_UserAction)
            {
                case eUserOptions.EnterNewCar:
                    {
                        handleNewVehicle();
                        break;
                    }

                case eUserOptions.PrintExistingVehicles:
                    {
                        displayAllLicenseNumber();
                        break;
                    }

                case eUserOptions.PrintVehicleInfo:
                    {
                        printVehicleInfo();
                        break;
                    }

                case eUserOptions.UpdateVehicleStatus:
                    {
                        updateVehicleStatus();
                        break;
                    }

                case eUserOptions.FuelVehicle:
                    {
                        fuelVehicle();
                        break;
                    }

                case eUserOptions.ChargeVehicle:
                    {
                        chargeElectricVehicle();
                        break;
                    }

                case eUserOptions.InflateVehicleTiresToMax:
                    {
                        inflateTires();
                        break;
                    }

                case eUserOptions.Exit:
                    {
                        break;
                    }
            }
        }

        private byte getUserSelection<T1, T2>(Dictionary<T1, T2> i_Collection, string i_Msg, byte i_Min, byte i_Max)
        {
            byte selection;
            bool isValidInput;
            bool isValidSelection = false;

            if(i_Min == 0)
            {
                i_Min++; // Dont accetp '0' as selection!
            }

            do
            {
                showUserOptions(i_Collection, i_Msg);
                isValidInput = byte.TryParse(Console.ReadLine(), out selection);
                if (!isValidInput)
                {
                    Console.WriteLine(k_InvlaidInputMsg);
                    continue;
                }

                isValidSelection = verifySelection(selection, i_Min, i_Max);
                if (!isValidSelection)
                {
                    Console.WriteLine(k_InvlaidInputMsg);
                }
            }
            while (!isValidInput || !isValidSelection);

            return selection;
        }

        private void showUserOptions<T1, T2>(Dictionary<T1, T2> i_Collection, string i_Msg)
        {
            Console.WriteLine();
            Console.WriteLine(i_Msg);
            foreach (KeyValuePair<T1, T2> item in i_Collection)
            {
                Console.WriteLine("{0}. {1}", Convert.ToInt32(item.Key), item.Value.ToString());
            }

            Console.WriteLine();
            Console.Write(k_YourSelectionMsg);
        }

        private bool verifySelection(byte i_Selection, byte i_Min, byte i_Max)
        {
            bool isValidSelection = true;

            if (i_Selection < i_Min || i_Selection > i_Max)
            {
                isValidSelection = false;
            }

            return isValidSelection;
        }

        private float getVerifiedPositiveNumericalInput(string i_Msg)
        {
            bool isValidInput;
            float value;

            Console.Write(i_Msg);
            isValidInput = float.TryParse(Console.ReadLine(), out value);
            if (!isValidInput || value < 0)
            {
                throw new FormatException(k_InvlaidInputMsg);
            }

            return value;
        }

        #endregion General Code

        #region 1. Handle a new vehicle
        private void handleNewVehicle()
        {
            getNewVehicleInfoFromUser();
            try
            {
                insertNewVehicleToTheGarage();
                Console.WriteLine(k_SuccessfulAdditionOfVehicleMsg);
            }
            catch (VehicleAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getNewVehicleInfoFromUser()
        {
            m_VehicleBasicInfo.VehicleType = getVehicleTypeFromUser();
            switch (m_VehicleBasicInfo.VehicleType)
            {
                case eVehicleTypes.FuelCar:
                    {
                        m_VehicleBasicInfo.WheelsInfo = new Wheel(32);
                        setVehicleBasicInfo();
                        setFuelType();
                        getNewCarInfo(k_SelectLitersEnergyLevelMsg);
                        break; 
                    }

                case eVehicleTypes.ElectricCar:
                    {
                        m_VehicleBasicInfo.WheelsInfo = new Wheel(32);
                        setVehicleBasicInfo();
                        m_VehicleBasicInfo.FuelType = eFuelTypes.None;
                        getNewCarInfo(k_SelectHoursEnergyLevelMsg);
                        break;
                    }

                case eVehicleTypes.FuelMotorcycle:
                    {
                        m_VehicleBasicInfo.WheelsInfo = new Wheel(28);
                        setVehicleBasicInfo();
                        setFuelType();
                        getNewMotorcycleInfo(k_SelectLitersEnergyLevelMsg);
                        break;
                    }

                case eVehicleTypes.ElectricMotorcycle:
                    {
                        m_VehicleBasicInfo.WheelsInfo = new Wheel(28);
                        setVehicleBasicInfo();
                        m_VehicleBasicInfo.FuelType = eFuelTypes.None;
                        getNewMotorcycleInfo(k_SelectHoursEnergyLevelMsg);
                        break;
                    }

                case eVehicleTypes.Truck:
                    {
                        m_VehicleBasicInfo.WheelsInfo = new Wheel(34);
                        setVehicleBasicInfo();
                        setFuelType();
                        getNewTruckInfo(k_SelectLitersEnergyLevelMsg);
                        break;
                    }
            }

            m_Vehicle.SetWheelsInfo(m_VehicleBasicInfo.WheelsInfo.CurrentAirPressure, m_VehicleBasicInfo.WheelsInfo.Manufacturer);
        }

        private eVehicleTypes getVehicleTypeFromUser()
        {
            return (eVehicleTypes)getUserSelection(
                m_VehicleTypesDict,
                k_SelectVehicleTypeMsg,
                (byte)eVehicleTypes.Min,
                (byte)eVehicleTypes.Max);
        }

        private void insertNewVehicleToTheGarage()
        {
            try
            {
                m_GarageServices.AddVehicleToGarage(m_Vehicle);
            }
            catch (Exception)
            {
                throw new VehicleAlreadyExistsException(m_VehicleBasicInfo.LicenseNumber);
            }
        }
        #region Motorcycle
        private void getNewMotorcycleInfo(string i_Msg)
        {
            getMotorcycleBasicInfo();
            switch (m_VehicleBasicInfo.VehicleType)
            {
                case eVehicleTypes.ElectricMotorcycle:
                    {
                        m_Vehicle = new ElectricMotorcycle(
                                m_VehicleBasicInfo.OwnerInfo,
                                m_VehicleBasicInfo.ModelName,
                                m_VehicleBasicInfo.LicenseNumber,
                                m_MotorcycleBasicInfo.LicenseType,
                                m_MotorcycleBasicInfo.EngineCapacity);
                        break;
                    }

                case eVehicleTypes.FuelMotorcycle:
                    {
                        m_Vehicle = new FuelMotorcycle(
                                m_VehicleBasicInfo.OwnerInfo,
                                m_VehicleBasicInfo.ModelName,
                                m_VehicleBasicInfo.LicenseNumber,
                                m_MotorcycleBasicInfo.LicenseType,
                                m_MotorcycleBasicInfo.EngineCapacity,
                                m_VehicleBasicInfo.FuelType);
                        break;
                    }
            }

            setCurrentEnergyLevel(i_Msg);
        }

        private void getMotorcycleBasicInfo()
        {
            setLicenseType();
            setEngineCapacity();
        }

        private void setEngineCapacity()
        {
            bool isValueOK;

            do
            {
                isValueOK = true;
                try
                {
                    m_MotorcycleBasicInfo.EngineCapacity = (int)getVerifiedPositiveNumericalInput(k_SelectEngineSizeMsg);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    isValueOK = false;
                }
            }
            while(!isValueOK);
        }

        private void setLicenseType()
        {
            m_MotorcycleBasicInfo.LicenseType = (eLicenseTypes)getUserSelection(
                m_LicenseTypeDict,
                k_SelectLicenseTypeMsg,
                (byte)eLicenseTypes.Min,
                (byte)eLicenseTypes.Max);
        }
        #endregion Motorcycle
        #region Car
        private void getNewCarInfo(string i_Msg)
        {
            getCarBasicInfo();
            switch (m_VehicleBasicInfo.VehicleType)
            {
                case eVehicleTypes.ElectricCar:
                    {
                        m_Vehicle = new ElectricCar(
                            m_VehicleBasicInfo.OwnerInfo,
                            m_VehicleBasicInfo.ModelName,
                            m_VehicleBasicInfo.LicenseNumber,
                            m_CarBasicInfo.Color,
                            m_CarBasicInfo.NumOfDoors);
                        break;
                    }

                case eVehicleTypes.FuelCar:
                    {
                        m_Vehicle = new FuelCar(
                            m_VehicleBasicInfo.OwnerInfo,
                            m_VehicleBasicInfo.ModelName,
                            m_VehicleBasicInfo.LicenseNumber,
                            m_CarBasicInfo.Color,
                            m_CarBasicInfo.NumOfDoors,
                            m_VehicleBasicInfo.FuelType);
                        break;
                    }
            }

            setCurrentEnergyLevel(i_Msg);
        }

        private void getCarBasicInfo()
        {
            getCarColor();
            getNumOfDoors();
        }

        private void getNumOfDoors()
        {
            m_CarBasicInfo.NumOfDoors = (eNumberOfDoors)getUserSelection(m_NumOfDoorsDict, k_SelectNumOfDoorsMsg, (byte)eNumberOfDoors.Min, (byte)eNumberOfDoors.Max);
        }

        private void getCarColor()
        {
            m_CarBasicInfo.Color = (eColors)getUserSelection(m_CarColorDict, k_SelectColorMsg, (byte)eColors.Min, (byte)eColors.Max);
        }
        #endregion Car
        #region Truck
        private void getNewTruckInfo(string i_Msg)
        {
            getTruckBasicInfo();
            m_Vehicle = new Truck(
                m_VehicleBasicInfo.OwnerInfo,
                m_VehicleBasicInfo.ModelName,
                m_VehicleBasicInfo.LicenseNumber,
                m_VehicleBasicInfo.FuelType,
                m_TruckBasicInfo.IsCarryingDangerousMaterials,
                m_TruckBasicInfo.MaxCarriageWeightAllowed);
            setCurrentEnergyLevel(i_Msg);
        }

        private void getTruckBasicInfo()
        {
            setDangerousMaterials();
            setMaxCarriage();
        }

        private void setMaxCarriage()
        {
            bool isValueOK;

            do
            {
                isValueOK = true;
                try
                {
                    m_TruckBasicInfo.MaxCarriageWeightAllowed = getVerifiedPositiveNumericalInput(k_SelectMaxWeightMsg);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    isValueOK = false;
                }
            }
            while(!isValueOK);
        }

        private void setDangerousMaterials()
        {
            bool isValidInput;
            string input;

            do
            {
                isValidInput = true;
                Console.Write(k_IsCarryingDangerousMaterialsMsg);
                input = Console.ReadLine();
                if (input.ToUpper() == k_Y)
                {
                    m_TruckBasicInfo.IsCarryingDangerousMaterials = true;
                }
                else if (input.ToUpper() == k_N)
                {
                    m_TruckBasicInfo.IsCarryingDangerousMaterials = false;
                }
                else
                {
                    isValidInput = false;
                }
            }
            while (!isValidInput);
        }
        #endregion Truck
        #region Vehicle General
        private void setFuelType()
        {
            m_VehicleBasicInfo.FuelType = (eFuelTypes)getUserSelection(
                m_FuelTypesDict,
                k_SelectFuelTypeMsg,
                (byte)eFuelTypes.Min,
                (byte)eFuelTypes.Max);
        }

        private void setCurrentEnergyLevel(string i_Msg)
        {
            bool isValidInput;
            bool isEnergyLevelOK = false;
            float energyLevel;

            while (!isEnergyLevelOK)
            {
                do
                {
                    Console.Write(i_Msg);
                    isValidInput = float.TryParse(Console.ReadLine(), out energyLevel);
                    if (!isValidInput)
                    {
                        Console.WriteLine(k_InvlaidInputMsg);
                    }
                }
                while (!isValidInput);

                try
                {
                    m_Vehicle.Energy = energyLevel;
                    isEnergyLevelOK = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    isEnergyLevelOK = false;
                }
            } // While (!IsFuelLevelOK)
        }

        private void setVehicleBasicInfo()
        {
            setOwnerDetails();
            setModelName();
            setLicenseNumber();
            setWheelsInfo();
        }

        private void setLicenseNumber()
        {
            m_VehicleBasicInfo.LicenseNumber = string.Empty;
            do
            {
                Console.Write(k_EnterLicenseNumberMsg);
                m_VehicleBasicInfo.LicenseNumber = Console.ReadLine();
            }
            while (m_VehicleBasicInfo.LicenseNumber == string.Empty);
        }

        private void setModelName()
        {
            m_VehicleBasicInfo.ModelName = string.Empty;
            do
            {
                Console.Write(k_EnterModelNameMsg);
                m_VehicleBasicInfo.ModelName = Console.ReadLine();
            }
            while (m_VehicleBasicInfo.ModelName == string.Empty);
        }

        private void setOwnerDetails()
        {
            m_VehicleBasicInfo.OwnerInfo = new OwnerInfo();
            setOwnerName();
            setOwnerPhoneNumber();
        }

        private void setOwnerPhoneNumber()
        {
            string userInput;
            bool isValidInput;

            do
            {
                isValidInput = true;
                Console.Write(k_EnterPhoneNumberMsg);
                if ((userInput = Console.ReadLine()) == string.Empty)
                {
                    isValidInput = false;
                }
                else
                {
                    foreach (char c in userInput)
                    {
                        if (!char.IsDigit(c))
                        {
                            isValidInput = false;
                            Console.WriteLine(k_InvlaidInputMsg);
                            break;
                        }
                    }
                }
            }
            while (!isValidInput);

            m_VehicleBasicInfo.OwnerInfo.PhoneNumber = userInput;
        }

        private void setOwnerName()
        {
            string userInput;
            bool isValidInput;

            do
            {
                isValidInput = true;
                Console.Write(k_EnterOwnerNameMsg);
                if ((userInput = Console.ReadLine()) == string.Empty)
                {
                    isValidInput = false;
                }
                else
                {
                    foreach (char c in userInput)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            isValidInput = false;
                            Console.WriteLine(k_InvlaidInputMsg);
                            break;
                        }
                    }
                }
            }
            while (!isValidInput);

            m_VehicleBasicInfo.OwnerInfo.Name = userInput;
        }

        private void setWheelsInfo()
        {
            setManafacturerName();
            setCurrentAirPressure();
        }

        private void setCurrentAirPressure()
        {
            float airPressure = 0f;
            bool isValidInput;
            bool isValidAirPressure = false;

            while (!isValidAirPressure)
            {
                do
                {
                    Console.Write(k_EnterCurrentAirPressureMsg);
                    isValidInput = float.TryParse(Console.ReadLine(), out airPressure);
                }
                while (!isValidInput);

                isValidAirPressure = true;
                try
                {
                    m_VehicleBasicInfo.WheelsInfo.CurrentAirPressure = airPressure;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    isValidAirPressure = false;
                }
            }
        }

        private void setManafacturerName()
        {
            m_VehicleBasicInfo.WheelsInfo.Manufacturer = string.Empty;
            do
            {
                Console.Write(k_EnterManufacturerNameMsg);
                m_VehicleBasicInfo.WheelsInfo.Manufacturer = Console.ReadLine();
            }
            while (m_VehicleBasicInfo.WheelsInfo.Manufacturer == string.Empty);
        }

        #endregion Vehicle General
        #endregion Handle a new vehicle

        #region 2. Display license number
        private void displayAllLicenseNumber()
        {
            List<string> licenseList = null;
            if (isFilterWanted())
            {
                eVehicleStatus filter = getDesiredFilter();
                try
                {
                    licenseList = m_GarageServices.ListOfAllLicenseNumberInTheGarage(filter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    licenseList = m_GarageServices.ListOfAllLicenseNumberInTheGarage();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (licenseList != null)
            {
                printList(licenseList);
            }
        }

        private void printList(List<string> i_List)
        {
            int i = 1;

            foreach (string str in i_List)
            {
                Console.WriteLine("{0}. {1}", i, str);
                i++;
            }
        }

        private bool isFilterWanted()
        {
            bool result = false;
            bool isValidInput;
            string input;

            do
            {
                isValidInput = true;
                Console.Write(k_IsStatusFilterWantedMsg);
                input = Console.ReadLine();
                if (input.ToUpper() == k_Y)
                {
                    result = true;
                }
                else if (input.ToUpper() == k_N)
                {
                    result = false;
                }
                else
                {
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return result;
        }

        private eVehicleStatus getDesiredFilter()
        {
            eVehicleStatus result = (eVehicleStatus)getUserSelection(
                m_VehicleStatusDict,
                "Please select the status to filter by:",
                (byte)eVehicleStatus.Min,
                (byte)eVehicleStatus.Max);

            return result;
        }
        #endregion Display license number

        #region 3. Print all info on a vehicle
        private void printVehicleInfo()
        {
            Vehicle vehicle = null;

            do
            {
                setLicenseNumber();
            }
            while (!verifyExistingLicenseNumber(out vehicle));

            Console.WriteLine("The information is:{0}{1}", Environment.NewLine, vehicle.ToString());
        }
        #endregion 3. Print all info on a vehicle

        #region 4. Update vehicle status
        private void updateVehicleStatus()
        {
            Vehicle vehicle = null;
            eVehicleStatus newStatus;

            do
            {
                setLicenseNumber();
            }
            while (!verifyExistingLicenseNumber(out vehicle));

            printVehicleCurrentStatus(vehicle);
            newStatus = (eVehicleStatus)getUserSelection(
                                            m_VehicleStatusDict,
                                            "Please select the next status for this vehicle:",
                                            (byte)eVehicleStatus.Min,
                                            (byte)eVehicleStatus.Max);
            m_GarageServices.UpdateVehicleStatus(vehicle.LicenseNumber, newStatus);
            printVehicleCurrentStatus(vehicle);
        }

        private bool verifyExistingLicenseNumber(out Vehicle o_Vehicle)
        {
            bool isValidLicenseNumber;

            o_Vehicle = null;
            try
            {
                isValidLicenseNumber = m_GarageServices.IsVehicleExists(m_VehicleBasicInfo.LicenseNumber, out o_Vehicle);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                isValidLicenseNumber = false;
            }

            return isValidLicenseNumber;
        }

        private void printVehicleCurrentStatus(Vehicle vehicle)
        {
            Console.WriteLine("The current status of the vehicle is: {0}", vehicle.Status.ToString());
        }
        #endregion

        #region 5. Fuel Vehicle
        private void fuelVehicle()
        {
            Vehicle vehicle = null;

            do
            {
                setLicenseNumber();
            }
            while (!verifyExistingLicenseNumber(out vehicle));

            if (vehicle.EngineType == eEngineTypes.Fuel)
            {
                Console.WriteLine("Fuel amount BEFORE: {0}", vehicle.Energy);
                float fuelAmount = getFuelAmount();
                m_GarageServices.RefuelVehicle(vehicle, fuelAmount);
                Console.WriteLine("Fuel amount AFTER: {0}", vehicle.Energy);
            }
            else
            {
                Console.WriteLine(k_CantFuelElectricEngineMsg);
            }
        }

        private float getFuelAmount()
        { 
            bool isValueOK;
            float value = 0;

            do
            {
                isValueOK = true;
                try
                {
                    value = getVerifiedPositiveNumericalInput(k_GeteFuelAmountMsg);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    isValueOK = false;
                }
            }
            while(!isValueOK);

            return value;
        }
        #endregion Fuel Vehicle

        #region 6. Charge electric vehicle
        private void chargeElectricVehicle()
        {
            Vehicle vehicle = null;

            do
            {
                setLicenseNumber();
            }
            while (!verifyExistingLicenseNumber(out vehicle));

            if (vehicle.EngineType == eEngineTypes.Electric)
            {
                Console.WriteLine("Power level BEFORE: {0}", vehicle.Energy);
                float powerLevel = getPowerToAdd();
                m_GarageServices.RechargeVehicle(vehicle, powerLevel);
                Console.WriteLine("Power level AFTER: {0}", vehicle.Energy);
            }
            else
            {
                Console.WriteLine(k_CantChargeFuelEngineMsg);
            }
        }

        private float getPowerToAdd()
        {
            bool isValueOK;
            float value = 0;

            do
            {
                isValueOK = true;
                try
                {
                    value = getVerifiedPositiveNumericalInput(k_GetPowerAmountMsg);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    isValueOK = false;
                }
            }
            while(!isValueOK);

            return value;
        }
        #endregion 6. Charge electric vehicle

        #region 7. Inflate tires to max
        private void inflateTires()
        {
            Vehicle vehicle = null;

            do
            {
                setLicenseNumber();
            }
            while (!verifyExistingLicenseNumber(out vehicle));

            Console.WriteLine("Tires pressure BEFORE: {0}", vehicle.AirPressure);
            m_GarageServices.InflateWheelsToMax(vehicle);
            Console.WriteLine("Tires pressure AFTER: {0}", vehicle.AirPressure);
        }
        #endregion 7. Inflate tires to max
    }
}
