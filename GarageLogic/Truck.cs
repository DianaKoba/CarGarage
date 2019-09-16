namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System;

    public class Truck : Vehicle
    {
        private const float k_WheelsMaxAirPressure = 34;
        private const byte k_NumberOfWheels = 12;
        private const float k_FuelTankCapacity = 130;
        private readonly bool r_IsCarryingDangerousMaterials;
        private readonly float r_MaxCarriageWeightAllowed;
        private readonly eFuelTypes r_FuelType;

        public Truck(
            OwnerInfo i_Owner,
            string i_ModelName,
            string i_LicenseNumber,
            eFuelTypes i_FuelType, 
            bool i_IsDangerous,
            float i_MaxCarriage)
            : base(i_Owner, i_ModelName, i_LicenseNumber, k_FuelTankCapacity, k_WheelsMaxAirPressure, k_NumberOfWheels, eEngineTypes.Fuel)
        {
            r_IsCarryingDangerousMaterials = i_IsDangerous;
            r_MaxCarriageWeightAllowed = i_MaxCarriage;
            r_FuelType = i_FuelType;
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return r_IsCarryingDangerousMaterials;
            }
        }

        public float MaxCarriageWeightAllowed
        {
            get
            {
                return r_MaxCarriageWeightAllowed;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Maximum carriage weight allowed:{0}.{1}Carries dangerous materials: {2}.{1}{3}",
                r_MaxCarriageWeightAllowed,
                Environment.NewLine,
                r_IsCarryingDangerousMaterials, 
                base.ToString());
        }
    }
}
