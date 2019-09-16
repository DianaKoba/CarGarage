namespace Ex03.GarageLogic
{
    using System;

    public class VehicleEngine
    {
        private const byte k_MinEnergyCapacity = 0;
        private readonly float r_MaxEnergyCapacity;
        private readonly eEngineTypes r_Type;
        private float m_CurrentEnergy;
        private eFuelTypes m_FuelType = eFuelTypes.None;

        public VehicleEngine(float i_MaxEnergyCapacity, eEngineTypes i_EngineType)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            r_Type = i_EngineType;
        }

        public eEngineTypes Type
        {
            get
            {
                return r_Type;
            }
        }

        public eFuelTypes FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                if (r_Type == eEngineTypes.Fuel)
                {
                    m_FuelType = value;
                }
                else
                {
                    throw new ArgumentException("Cant set a fuel type to electric engine!");
                }
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
        }

        public float Energy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                if (m_CurrentEnergy + value <= r_MaxEnergyCapacity)
                {
                    m_CurrentEnergy += value;
                }
                else
                {
                    throw new ValueOutOfRangeException(value, k_MinEnergyCapacity, (float)(r_MaxEnergyCapacity - m_CurrentEnergy));
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Engine Info:{0}Max Capacity: {1}, Current capacity: {2}.",
                Environment.NewLine,
                r_MaxEnergyCapacity,
                m_CurrentEnergy);
        }
    }
}