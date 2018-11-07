using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private int totalTemperature;
        private int totalHumidity;
        private int totalPressure;
        private int counter;
        private IObservable<WeatherInfo> observable;

        public StatisticReport(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentException($"{nameof(observable)} can't be null");
            }
            this.observable = observable;
            observable.Register(this);
        }
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentException($"{nameof(sender)} can't be null");
            }
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentException($"{nameof(info)} can't be null");
            }
            totalTemperature += info.Temperature;
            totalHumidity += info.Humidity;
            totalPressure += info.Pressure;
            counter++;

            Report();
        }

        public void Report() => Console.WriteLine($"----------------------------------\nAverage weather values: average temperature " +
            $"- {totalTemperature / counter}, average humidity - {totalHumidity / counter}, average pressure " +
            $"- {totalPressure / counter}\n-----------------------------");

    }
}
