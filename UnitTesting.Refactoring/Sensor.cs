using System;

namespace UnitTesting.Refactoring
{
    public class Sensor
    {
        private const double Offset = 16;
        private readonly Random _randomPressureSampleSimulator = new Random();

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
    }
}
