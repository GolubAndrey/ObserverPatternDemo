using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            WeatherInfo weatherInfo = new WeatherInfo();
            weatherInfo.Temperature = 20;
            weatherInfo.Pressure = 750;
            weatherInfo.Humidity = 65;

            StatisticReport statisticReport = new StatisticReport(weatherData);
            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport(weatherData);

            weatherData.Notify(weatherData, weatherInfo);

            statisticReport.Report();
            currentConditionsReport.Report();

            weatherInfo.Temperature = 30;
            weatherInfo.Pressure = 760;
            weatherInfo.Humidity = 75;

            weatherData.Notify(weatherData, weatherInfo);

            statisticReport.Report();
            currentConditionsReport.Report();

            Console.ReadLine();
        }
    }
}
