namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_ValueToExamine;
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_ValueToExamine, float i_MinValue, float i_MaxValue)
        {
            r_ValueToExamine = i_ValueToExamine;
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                string message = string.Format("The value {0} is out of range! ({1}-{2})", r_ValueToExamine, r_MinValue, r_MaxValue);

                return message;
            }
        }
    }
}
