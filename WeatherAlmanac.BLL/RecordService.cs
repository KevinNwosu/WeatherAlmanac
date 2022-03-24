using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.BLL
{
    public class RecordService : IRecordService
    {
        private IRecordRepository _repo;
        public RecordService(IRecordRepository implementation)
        {
            _repo = implementation;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            _repo.Add(record);
            Result<DateRecord> result = new Result<DateRecord>();
            result.Message = "";
            result.Success = true;
            result.Data = record;
            return result;
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            Result<DateRecord> result = _repo.Edit(record);
            return result;
            //todo: pass through to IRecordrepository, only if date exists in repository.
        }

        public Result<DateRecord> Get(DateTime date)
        {
            List<DateRecord> records = _repo.GetAll().Data;
            Result<DateRecord> result = new Result<DateRecord>();
            if (date.Ticks > DateTime.Now.Ticks)
            {
                result.Success = false;
                result.Message = "Date is in the future!";
            }
            else
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Date == date)
                    {
                        result.Success = true;
                        result.Message = "";
                        result.Data = records[i];
                        break;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "No data for that date.";
                    }
                }
            }
            return result;
        }

        public Result<List<DateRecord>> LoadRange(DateTime start, DateTime end)
        {
            //todo:check to see that start is before end date
            //todo:filter records from repository to get all based on date range
            //todo: if no records found, return success false with ot found message
            List<DateRecord> records = _repo.GetAll().Data;
            List<DateRecord> orderedRecord = records.OrderBy(d => d.Date).ToList();
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            List<DateRecord> list = new List<DateRecord>();
            for (int i = 0; i < orderedRecord.Count; i++)
            {
                if (orderedRecord[i].Date <= end && orderedRecord[i].Date >= start)
                {
                    DateRecord dateRecord = new DateRecord();
                    dateRecord = orderedRecord[i];
                    list.Add(dateRecord);
                }

            }
            result.Data = list;
            result.Success = true;
            result.Message = "";
            return result;
        }
        public Result<DateRecord> Remove(DateTime date)
        {
            Result<DateRecord> result = _repo.Remove(date);
            return result;
        }
    }
}
