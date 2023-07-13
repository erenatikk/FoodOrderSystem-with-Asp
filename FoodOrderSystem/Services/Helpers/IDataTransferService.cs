namespace FoodOrderSystem.Services.Helpers
{
    public interface IDataTransferService
    {
        void AddData(string key, string value);
        string ReadData(string key);
    }
}
