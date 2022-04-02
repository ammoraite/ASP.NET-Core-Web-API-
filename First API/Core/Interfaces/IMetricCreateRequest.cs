namespace First_API.Interfaces
{
    public interface IMetricCreateRequest
    {
        public int Value { get; set; }
        public int Time { get; set; }
    }
}
