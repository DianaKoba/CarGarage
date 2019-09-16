namespace Ex03.GarageLogic
{
    using System;

    public class OwnerInfo
    {
        private string m_Name = string.Empty;
        private string m_PhoneNumber = string.Empty;

        public OwnerInfo(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public OwnerInfo()
        {
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set 
            {
                m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Owner Info:{0}Name: {1}, Phone number: {2}.",
                Environment.NewLine,
                m_Name,
                m_PhoneNumber);
        }
    }
}
