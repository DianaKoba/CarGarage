namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FuelMotorcycle : Motorcycle
    {
        private const float k_FuelTankCapacity = 5.5f;
        private readonly eFuelTypes r_FuelType;

        public FuelMotorcycle(
            OwnerInfo i_Owner,
            string i_ModelName,
            string i_LicenseNumber,
            eLicenseTypes i_LicenseType,
            int i_EngineCapacity,
            eFuelTypes i_FuelType)
            : base(i_Owner, i_ModelName, i_LicenseNumber, k_FuelTankCapacity, i_LicenseType, i_EngineCapacity, eEngineTypes.Fuel)
        {
            r_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            return string.Format(
                "Motorcycle Info:{0}Fuel type: {1}.{0}{2}",
                Environment.NewLine,
                r_FuelType,
                base.ToString());
        }
    }
}
