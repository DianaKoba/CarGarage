namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System;

    public abstract class Vehicle
    {
        protected readonly string r_LicenseNumber;
        protected readonly string r_Model;
        protected readonly byte r_NumOfWheels;
        protected readonly float r_MaxAirPressure;
        protected eVehicleStatus m_Status;
        protected float m_PercentageOfEnergy;
        protected VehicleEngine m_Engine = null;
        protected List<Wheel> m_WheelsList;
        protected OwnerInfo m_Owner = new OwnerInfo();

        public Vehicle(
            OwnerInfo i_Owner,
            string i_ModelName,
            string i_LicenseNumber,
            float i_MaxEnergyCapacity,
            float i_MaxAirPressure,
            byte i_NumOfWheels, 
            eEngineTypes i_EngineType)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Model = i_ModelName;
            r_NumOfWheels = i_NumOfWheels;
            r_MaxAirPressure = i_MaxAirPressure;
            allocateWheels();
            m_Engine = new VehicleEngine(i_MaxEnergyCapacity, i_EngineType);
            m_Status = eVehicleStatus.BeingFixed;
            m_Owner.Name = i_Owner.Name;
            m_Owner.PhoneNumber = i_Owner.PhoneNumber;
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        public eEngineTypes EngineType
        {
            get
            {
                return m_Engine.Type;
            }
        }

        public eFuelTypes FuelType
        {
            get
            {
                return m_Engine.FuelType;
            }

            set
            {
                m_Engine.FuelType = value;
            }
        }

        public float AirPressure
        {
            get
            {
                return m_WheelsList[0].CurrentAirPressure;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public float Energy
        {
            get
            {
                return m_Engine.Energy;
            }

            set
            {
                m_Engine.Energy = value;
                m_PercentageOfEnergy = (m_Engine.Energy / m_Engine.MaxEnergy) * 100;
            }
        }

        protected void allocateWheels()
        {
            m_WheelsList = new List<Wheel>(r_NumOfWheels);
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(r_MaxAirPressure));
            }
        }

        public void SetWheelsInfo(float i_CurrentAirPressure, string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.Manufacturer = i_ManufacturerName;
                wheel.Inflate(i_CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            return string.Format(
                "License number: {1}{0}Model: {2}{0}Status: {3}{0}{4}{0}{5}{0}{6}{0}{7}% of {8} capacity if full.",
                Environment.NewLine,                    
                r_LicenseNumber,
                r_Model,
                m_Status,
                m_Owner.ToString(),
                m_WheelsList[0].ToString(),
                m_Engine.ToString(),
                m_PercentageOfEnergy,
                m_Engine.Type.ToString());
        }

        public void InfalteWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.InflateToMax();
            }
        }
    }
}
