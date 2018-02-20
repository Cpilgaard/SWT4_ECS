namespace ECS.Legacy
{
    public class ECS
    {
        private int _threshold;
        private int _currentTemp;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, ITempSensor tempSensor, IHeater heater)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _currentTemp = 0;
        }

        public void Regulate()
        {
            _currentTemp = _tempSensor.GetTemp();
            if (_currentTemp < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _currentTemp;
        }

    }
}
