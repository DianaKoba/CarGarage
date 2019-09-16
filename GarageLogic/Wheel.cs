namespace Ex03.GarageLogic
{
    using System;

    public class Wheel
    {
        private const byte k_MinAirPressure = 0;
        private readonly float r_MaxAirPressure;
        private string m_Manufacturer = null;
        private float m_CurrentAirPressure;

        public Wheel()
        { 
        }

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure; 
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if (value >= 0 && value <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(value, k_MinAirPressure, r_MaxAirPressure);
                }
            }
        }

        public void Inflate(float i_AirToInflate)
        {
            if (m_CurrentAirPressure + i_AirToInflate <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(i_AirToInflate, 0, (float)(r_MaxAirPressure - m_CurrentAirPressure));
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
                "Wheels Info:{0}Max air pressure: {1}, Current air pressure: {2}, Manufatorer name: {3}.",
                Environment.NewLine,
                r_MaxAirPressure,
                m_CurrentAirPressure,
                m_Manufacturer);
        }
    }
}
