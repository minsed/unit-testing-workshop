using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace UnitTesting.Refactoring
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        private const string OutputFilePath = @"C:\logs.json";

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
            else
            {
                _onBoardComputer.ShowInfo($"Tyre pressure: {psiPressureValue}");
            }

            var tyrePressure = new TyrePressure
            {
                Psi = psiPressureValue,
                CheckedOn = DateTime.UtcNow
            };

            var jsonData = File.Exists(OutputFilePath) ? File.ReadAllText(OutputFilePath) : string.Empty;
            var tyrePressureList =
                JsonConvert.DeserializeObject<List<TyrePressure>>(jsonData) ?? new List<TyrePressure>();
            tyrePressureList.Add(tyrePressure);
            jsonData = JsonConvert.SerializeObject(tyrePressureList);
            File.WriteAllText(OutputFilePath, jsonData);

            LastTyrePressure = psiPressureValue;
        }
    }
}
