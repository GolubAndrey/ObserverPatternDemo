using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        //Проростить логику датчиков
        private List<IObserver<WeatherInfo>> observers;
        
        public Action<WeatherData, WeatherInfo> NewUpdate;

        public WeatherData() => observers = new List<IObserver<WeatherInfo>>();
        public void Notify(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentException($"{nameof(info)} can't be null");
            }
            foreach (IObserver<WeatherInfo> observer in observers)
            {
                observer.Update(this,info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentException($"{nameof(observer)} can't be null");
            }
            NewUpdate += observer.Update;
            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentException($"{nameof(observer)} can't be null");
            }
            NewUpdate -= observer.Update;
            observers.Remove(observer);
        }

        public void GenerateInfo()
        {
            Random random = new Random();

            while (true)
            {
                WeatherInfo info = new WeatherInfo()
                {
                    Temperature = random.Next(-30, 30),
                    Humidity = random.Next(1, 100),
                    Pressure = random.Next(700, 800)
                };
                NewUpdate?.Invoke(this, info);
                Thread.Sleep(3000);
            }
        }
    }
}
