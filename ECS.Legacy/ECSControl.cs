namespace ECS.Legacy
{
    public class ECSControl
    {
        private int _threshold;
        private int _currentTemp;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECSControl(int thr, ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
            _currentTemp = 0;
        }

        public void Regulate()
        {
            _currentTemp = _tempSensor.GetTemp();
            if (_currentTemp < _threshold)
            {
                _heater.TurnOn();
                _window.Open();
            }

            if(_currentTemp > _threshold)
            {
                _heater.TurnOff();
                _window.Close();
            }


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
