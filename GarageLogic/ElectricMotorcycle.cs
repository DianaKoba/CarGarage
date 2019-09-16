namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryCapacity = 1.6f;

        public ElectricMotorcycle(
            OwnerInfo i_Owner,
            string i_ModelName,
            string i_LicenseNumber,
            eLicenseTypes i_LicenseType,
            int i_EngineCapacity)
            : base(i_Owner, i_ModelName, i_LicenseNumber, k_MaxBatteryCapacity, i_LicenseType, i_EngineCapacity, eEngineTypes.Electric)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
