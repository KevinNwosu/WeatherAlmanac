using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class MockRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records;
        public MockRecordRepository()
        {
            _records = new List<DateRecord>();
            DateRecord bogus  = new DateRecord();
            bogus.Date = new DateTime(2021, 11, 18);
            bogus.HighTemp = 82;
            bogus.LowTemp = 40;
            bogus.Humidity = 29M;
            bogus.Description = "Random ass weather";
            _records.Add(bogus);
            DateRecord bogus2 = new DateRecord();
            bogus2.Date = new DateTime(2021, 7, 18);
            bogus2.HighTemp = 95;
            bogus2.LowTemp = 70;
            bogus2.Humidity = 65M;
            bogus2.Description = "Hot ass hell";
            _records.Add(bogus2);
        }
        public Result<DateRecord> Add(DateRecord record)
        {
            _records.Add(record);
            Result<DateRecord> result = new Result<DateRecord>();
            result.Data = record;
            result.Success = true;
            result.Message = "";
            return result;
            //todo: add record to private field
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            result.Data = record;
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == record.Date)
                {
                    _records[i] = record;
                }
            }
            return result;
        }

        public Result<List<DateRecord>> GetAll()
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<DateRecord>(_records);
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == date)
                {
                    result.Data = _records[i];
                    result.Success = true;
                    result.Message = "";
                    _records.Remove(_records[i]);
                }
            }
            return result;
        }
    }
}
