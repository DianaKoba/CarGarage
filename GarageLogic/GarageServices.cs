namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System;

    public class GarageServices
    {
        private readonly Dictionary<string, Vehicle> m_Vehicles;

        public GarageServices()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        private Vehicle getVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle;

            if (!m_Vehicles.TryGetValue(i_LicenseNumber, out vehicle))
            {
                throw new ArgumentException("The vehicle you are looking for doesn't exist in the garage.");
            }

            return vehicle;
        }

        public bool IsVehicleExists(string i_LicenseNumber, out Vehicle o_Vehicle)
        {
            bool vehicleExists = true;

            try
            {
                o_Vehicle = getVehicle(i_LicenseNumber);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            return vehicleExists;
        }

        public void RefuelVehicle(Vehicle i_Vehicle, float i_FuelToAdd)
        {
            if (i_Vehicle.EngineType == eEngineTypes.Electric)
            {
                throw new ArgumentException("This vehicle has electric engine and cannot be refueld!");
            }

            if (i_Vehicle.FuelType != i_Vehicle.FuelType)
            {
                throw new ArgumentException(string.Format(
                    "You have tried to refuel this vehicle with {0}, while this vehicle uses {1}, cannot be done.",
                    i_Vehicle.FuelType,
                    i_Vehicle.FuelType));
            }

            i_Vehicle.Energy = i_FuelToAdd;
        }

        public void RechargeVehicle(Vehicle i_Vehicle, float i_TimeToAdd)
        {
            if (i_Vehicle.EngineType == eEngineTypes.Fuel)
            {
                throw new ArgumentException("This vehicle has fuel engine and cannot be recharged!");
            }

            i_Vehicle.Energy = i_TimeToAdd;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            Vehicle vehicle = getVehicle(i_LicenseNumber);
            vehicle.Status = i_NewStatus;
        }

        public List<string> ListOfAllLicenseNumberInTheGarage()
        {
            return ListOfAllLicenseNumberInTheGarage(eVehicleStatus.None);
        }

        public List<string> ListOfAllLicenseNumberInTheGarage(eVehicleStatus i_Filter)
        {
            List<string> listOfLicenseNumber = new List<string>();

            foreach (Vehicle vehicle in m_Vehicles.Values)
            {
                if (i_Filter == eVehicleStatus.None || vehicle.Status == i_Filter)
                {
                    listOfLicenseNumber.Add(vehicle.LicenseNumber);
                }
            }

            if (listOfLicenseNumber.Count == 0)
            {
                throw new Exception("There are no vehicles to display.");
            }

            return listOfLicenseNumber;
        }

        public List<string> ListOfLicenseNumbersByStatus(eVehicleStatus i_VehiclesStatus)
        {
            List<string> listOfLicenseNumbers = new List<string>();

            foreach (Vehicle vehicle in m_Vehicles.Values)
            {
                if (vehicle.Status == i_VehiclesStatus)
                {
                    listOfLicenseNumbers.Add(vehicle.LicenseNumber);
                }
            }

            if (listOfLicenseNumbers.Count == 0)
            {
                throw new Exception("There are no vehicles to display.");
            }

            return listOfLicenseNumbers;
        }

        public void InflateWheelsToMax(Vehicle i_Vehicle)
        {
            i_Vehicle.InfalteWheelsToMax();
        }

        public void SetWheelsInfo(string i_LicenseNumber, string i_ManufacturerName, float i_WheelsCurrentAirPressure)
        {
            Vehicle vehicle = getVehicle(i_LicenseNumber);

            vehicle.SetWheelsInfo(i_WheelsCurrentAirPressure, i_ManufacturerName);
        }
    }
}
