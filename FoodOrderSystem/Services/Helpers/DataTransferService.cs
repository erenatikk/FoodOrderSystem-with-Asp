namespace FoodOrderSystem.Services.Helpers
{
    public class DataTransferService : IDataTransferService
    {
        private readonly Dictionary<string, string> data;

        public DataTransferService()
        {
            data = new();
        }

        public void AddData(string key, string value)
        {
            data[key] = value;
        }

        public string ReadData(string key)
        {
            string? value;
            data.TryGetValue(key, out value);
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }
}
