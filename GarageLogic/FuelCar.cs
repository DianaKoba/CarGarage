namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class FuelCar : Car
    {
        private const float k_FuelTankCapacity = 50f;
        private readonly eFuelTypes r_FuelType;

        public FuelCar(
            OwnerInfo i_Owner,
            string i_ModelName, 
            string i_LicenseNumber, 
            eColors i_Color, 
            eNumberOfDoors i_NumOfDoors, 
            eFuelTypes i_FuelType)
            : base(i_Owner, i_ModelName, i_LicenseNumber, k_FuelTankCapacity, i_Color, i_NumOfDoors, eEngineTypes.Fuel)
        {
            r_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            return string.Format(
                "Car Info:{0}Fuel type: {1}.{0}{2}",
                Environment.NewLine,
                r_FuelType,
                base.ToString());
        }
    }
}