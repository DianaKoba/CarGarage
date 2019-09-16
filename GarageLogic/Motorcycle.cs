namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System;

    public class Motorcycle : Vehicle
    {
        private const float k_MaxAirPressure = 28;
        private const byte k_NumberOfWheels = 2;
        private readonly int r_EngineCapacity;
        private readonly eLicenseTypes r_LicenseType;

        public Motorcycle(
            OwnerInfo i_Owner,
            string i_ModelName, 
            string i_LicenseNumber,
            float i_MaxEnergyCapacity,
            eLicenseTypes i_LicenseType, 
            int i_EngineCapacity,
            eEngineTypes i_EngineType)
            : base(i_Owner, i_ModelName, i_LicenseNumber, i_MaxEnergyCapacity, k_MaxAirPressure, k_NumberOfWheels, i_EngineType)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public eLicenseTypes LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Engine capacity: {1}{0}.License type: {2}.{0}{3}",
                Environment.NewLine,
                r_EngineCapacity,
                r_LicenseType,
                base.ToString());
        }
    }
}
