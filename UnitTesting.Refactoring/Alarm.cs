namespace UnitTesting.Refactoring
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor _sensor = new Sensor();
        private readonly OnBoardComputer _onBoardComputer = new OnBoardComputer();

        public bool AlarmOn { get; private set; }
        public double LastTyrePressure { get; private set; }

        public Alarm()
        {
            Check();
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
                _onBoardComputer.ShowWarning($"Dangerous tyre pressure: {psiPressureValue}");
            }

            _onBoardComputer.ShowInfo($"Tyre pressure: {psiPressureValue}");
            LastTyrePressure = psiPressureValue;
        }
    }
}
