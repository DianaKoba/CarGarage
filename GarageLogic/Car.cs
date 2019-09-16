namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        protected const float k_MaxAirPressure = 32f;
        protected const byte k_NumberOfWheels = 4;
        protected readonly eColors r_Color;
        protected readonly eNumberOfDoors r_NumberOfDoors;

        public Car(
            OwnerInfo i_Owner,
            string i_ModelName,
            string i_LicenseNumber,
            float i_MaxEnergyCapacity,
            eColors i_Color, 
            eNumberOfDoors i_NumOfDoors,
            eEngineTypes i_EngineType)
            : base(i_Owner, i_ModelName, i_LicenseNumber, i_MaxEnergyCapacity, k_MaxAirPressure, k_NumberOfWheels, i_EngineType)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumOfDoors;
        }

        public eColors Color
        {
            get
            {
                return r_Color;
            }
        }

        public eNumberOfDoors NumOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Number of wheels: {1}.{0}Color: {2}.{0}Number of doors: {3}.{0}{4}",
                Environment.NewLine,
                k_NumberOfWheels,
                r_Color,
                r_NumberOfDoors,
                base.ToString());
        }
    }
}
