namespace Ex03.GarageLogic
{
    public class FuelEngine : VehicleEngine
    {
        private readonly eFuelTypes r_FuelType;

        public FuelEngine(eFuelTypes i_FuelType, float i_MaxFuelCapacity)
            : base(i_MaxFuelCapacity, eEngineTypes.Fuel)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelTypes FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
    }
}
