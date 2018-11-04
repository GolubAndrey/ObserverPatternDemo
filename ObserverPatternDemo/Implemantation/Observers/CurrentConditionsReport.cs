using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private int temperature;
        private int humidity;
        private int pressure;
        private IObservable<WeatherInfo> observable;

        public CurrentConditionsReport(IObservable<WeatherInfo> observable)
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
            temperature = info.Temperature;
            humidity = info.Humidity;
            pressure = info.Pressure;
        }

        public void Report() => Console.WriteLine($"Current weather values: temperature " +
            $"- {temperature}, humidity - {humidity}, pressure " +
            $"- {pressure}");
    }
}