using WeatherAlmanac.Core.DTO;
namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordRepository
    {
        Result<List<DateRecord>> GetAll();
        Result<DateRecord> Add(DateRecord record);
        Result<DateRecord> Remove(DateTime record);
        Result<DateRecord> Edit(DateRecord record);
    }
}
