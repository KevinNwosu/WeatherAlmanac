using WeatherAlmanac.Core.DTO;
namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordService
    {
        Result<List<DateRecord>> LoadRange(DateTime start, DateTime end);
        Result<DateRecord> Get(DateTime date);
        Result<DateRecord> Add(DateRecord record);
        Result<DateRecord> Remove(DateTime date);
        Result<DateRecord> Edit(DateRecord record);
    }
}
