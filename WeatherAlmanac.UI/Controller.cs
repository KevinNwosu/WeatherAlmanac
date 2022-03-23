using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.UI
{
    public class Controller
    {
        private ConsoleIO _ui;
        public IRecordService Service { get; set; }
        
        public Controller(ConsoleIO ui)
        {
            _ui = ui;
        }
        public ApplicationMode Setup()
        {
            _ui.Display("Welcome to the Weather Almanac.");
            _ui.Display("================================");
            _ui.Display("What mode would you like to run in?");
            _ui.Display("");
            _ui.Display("1. Live");
            _ui.Display("2. Test");
            int mode = _ui.GetInt("Select Mode ", 2, 0); 
            if(mode == 1)
            {
                return ApplicationMode.LIVE;
            }
            else if (mode == 2)
            {
                return ApplicationMode.TEST;
            }
            else
            {
                return ApplicationMode.TEST;
            }
        }

        public void Run()
        {
            bool running = true;
            
            while(running)
            {
                switch (GetMenuChoice())
                {
                    case 1:
                        LoadRecord();
                        break;
                    case 2:
                        ViewRecordsByDateRange();
                        break;
                    case 3:
                        AddRecord();
                        break;
                    case 4:
                        EditRecord();
                        break;
                    case 5:
                        DeleteRecord();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        _ui.Error("Invalid menu option");
                        break;
                }
            }
        }
        public int GetMenuChoice()
        {
            DisplayMenu();
            return _ui.GetInt("Enter Choice: ", 6, 0);
        }
        public void DisplayMenu()
        {
            _ui.Display("Main Menu");
            _ui.Display("==========================");
            _ui.Display("1. Load a Record");
            _ui.Display("2. View Records by Date Range");
            _ui.Display("3. Add Record");
            _ui.Display("4. Edit Record");
            _ui.Display("5. Delete Record");
            _ui.Display("6. Quit");
            _ui.Display("");
        }
        public void LoadRecord()
        {
            Console.Clear();
            _ui.Display("Load Record");
            _ui.Display("===========================");
            bool isSuccess = DateTime.TryParse(_ui.PromptUser("Enter Record Date in mm/dd/yyyy: "), out DateTime date);
            Result<DateRecord> result = Service.Get(date);
            _ui.Display(result.Message);
            _ui.Display(result.Data.ToString());
        }
        public void ViewRecordsByDateRange()
        {
            Console.Clear();
            _ui.Display("Load Records by Date Range");
            _ui.Display("===============================");
            DateTime startDate = DateTime.Parse(_ui.PromptUser("Enter a start date: "));
            DateTime endDate = DateTime.Parse(_ui.PromptUser("Enter an end date: "));
            Result<List<DateRecord>> result = Service.LoadRange(startDate, endDate);
            foreach (DateRecord record in result.Data)
            {
                _ui.Display(record.ToString());
            }
        }
        public void AddRecord()
        {
            _ui.Display("Add Record");
            _ui.Display("============================");
            DateTime date = DateTime.Parse(_ui.PromptUser("Date: "));
            int highTemp = _ui.GetInt("High: ", 140, -50);
            int lowTemp = _ui.GetInt("Low: ", 140, -50);
            int humidity = _ui.GetInt("Humidity: ", 100, -1);
            string description = _ui.PromptUser("Description: ");
            DateRecord dateRecord = new DateRecord();
            dateRecord.Date = date;
            dateRecord.HighTemp = highTemp;
            dateRecord.LowTemp = lowTemp;
            dateRecord.Humidity = humidity;
            dateRecord.Description = description;
            Result<DateRecord> result = new Result<DateRecord>();
            result = Service.Add(dateRecord);
            _ui.Display(result.Data.ToString());
        }
        public void EditRecord()
        {
            _ui.Display("Edit Record");
        }
        public void DeleteRecord()
        {
            _ui.Display("Delete Record");
        }
        public void Quit()
        {
            _ui.Display("Are you sure you want to quit (y/n): ");
            //make string collection consoleIO
        }
    }
}
