using System;
using WeatherAlmanac;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.BLL;
using WeatherAlmanac.UI;

ConsoleIO ui = new ConsoleIO();
Controller menu = new Controller(ui);
ApplicationMode mode = menu.Setup(); //setup files chooses between live and mock
IRecordService service = RecordServiceFactory.GetRecordService(mode);
menu.Service = service;
menu.Run();