namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    public struct VehicleBasicInfo
    {
        public string ModelName;
        public string LicenseNumber;
        public Wheel WheelsInfo;
        public OwnerInfo OwnerInfo;
        public eVehicleTypes VehicleType;
        public eFuelTypes FuelType;
    }
}
