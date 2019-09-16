namespace Ex03.GarageLogic
{
    public class ElectricEngine : VehicleEngine
    {
        public ElectricEngine(float i_MaxElectricityCapacity)
            : base(i_MaxElectricityCapacity, eEngineTypes.Electric)
        {
        }
    }
}
