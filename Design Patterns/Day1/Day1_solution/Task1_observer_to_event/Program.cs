namespace Task1_observer_to_event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //publisher
            var weatherData = new WeatherData();
            //subscribers
            var currentDisplay = new CurrentConditionsDisplay();
            var statisticsDisplay = new StatisticsDisplay();
            var forecastDisplay = new ForecastDisplay();
            var heatIndexDisplay = new HeatIndexDisplay();

            //register subscribers to the event
            weatherData.MeasurementsChangedEvent += currentDisplay.Update;
            weatherData.MeasurementsChangedEvent += statisticsDisplay.Update;
            weatherData.MeasurementsChangedEvent += forecastDisplay.Update;
            weatherData.MeasurementsChangedEvent += heatIndexDisplay.Update;

            //firing the event
            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);
        }
    }

    #region Observable (Publisher)
    public class WeatherData
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        public float Temperature { get { return _temperature; } }
        public float Humidity { get { return _humidity; } }
        public float Pressure { get { return _pressure; } }

        public event Action<float, float, float> MeasurementsChangedEvent;

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this._temperature = temperature;
            this._humidity = humidity;
            this._pressure = pressure;
            MeasurementsChanged();
        }

        public void MeasurementsChanged()
        {
            MeasurementsChangedEvent.Invoke(_temperature, _humidity, _pressure);
        }
    }
    #endregion

    #region Observer (Subscribers)
    //subscriber 1
    public class ForecastDisplay
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;

        public void Update(float temperature, float humidity, float pressure)
        {
            _lastPressure = _currentPressure;
            _currentPressure = pressure;
            Display();
        }
        public void Display()
        {
            Console.Write("Forecast: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if (_currentPressure < _lastPressure)
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }
    }

    //subscriber 2
    public class HeatIndexDisplay
    {
        private float _heatIndex = 0.0f;

        public void Update(float temperature, float humidity, float pressure)
        {
            float t = temperature;
            float rh = humidity;
            _heatIndex = (float)
                ((16.923 + (0.185212 * t)) + (5.37941 * rh) - (0.100254 * t * rh) + (0.00941695 * (t * t)) +
                (0.00728898 * (rh * rh)) + (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 * (rh * rh * rh)) +
                (0.00000142721 * (t * t * t * rh)) + (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                (0.000000000843296 * (t * t * rh * rh * rh)) - (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Heat index is " + _heatIndex + "\n");
        }
    }
    //subscriber 3
    public class StatisticsDisplay
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200;
        private float _tempSum = 0.0f;
        private int _numReadings;

        public void Update(float temperature, float humidity, float pressure)
        {
            float temp = temperature;
            _tempSum += temp;
            _numReadings++;

            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            Display();
        }
        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + (_tempSum / _numReadings)
                + "/" + _maxTemp + "/" + _minTemp);
        }
    }
    //subscriber 4
    public class CurrentConditionsDisplay
    {
        private float _temperature;
        private float _humidity;
        public void Update(float temperature, float humidity, float pressure)
        {
            this._temperature = temperature;
            this._humidity = humidity;
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature
                + "F degrees and " + _humidity + "% humidity");
        }
    }
    #endregion
}