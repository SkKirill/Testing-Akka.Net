namespace TestingAkka.XUnitTests.Utilites
{
    public sealed class TemperatureRecorded
    {
        public TemperatureRecorded(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
