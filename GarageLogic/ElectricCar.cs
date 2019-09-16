namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ElectricCar : Car
    {
        private const float k_MaxBatteryCapacity = 2.8f;

        public ElectricCar(
            OwnerInfo i_Owner,
            string i_ModelName, 
            string i_LicenseNumber, 
            eColors i_Color, 
            eNumberOfDoors i_NumOfDoors)
            : base(i_Owner, i_ModelName, i_LicenseNumber, k_MaxBatteryCapacity, i_Color, i_NumOfDoors, eEngineTypes.Electric)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
