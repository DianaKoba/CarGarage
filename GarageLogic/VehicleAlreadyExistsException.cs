namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VehicleAlreadyExistsException : Exception
    {
        private string m_VehicleID;

        public string VehicleID
        {
            get
            {
                return m_VehicleID;
            }
        }

        public VehicleAlreadyExistsException(string i_VehicleID)
            : base(string.Format("Error. Vehicle with the same ID <{0}> already exists in the garage.", i_VehicleID))
        {
            m_VehicleID = i_VehicleID;
        }
    }
}
