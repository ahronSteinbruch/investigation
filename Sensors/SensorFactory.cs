
namespace investigation
{
    public static class SensorFactory
    {
        public static Sensor CreateSensor(SensorType type, IranianAgent agent)
        {
            return type switch
            {
                SensorType.Audio => new AudioSensor(),
                SensorType.Thermal => new ThermalSensor(SensorType.Thermal,agent),
                SensorType.Motion => new MotionSensor(SensorType.Motion), 
                SensorType.Magnetic => new MagneticSensor(SensorType.Magnetic,agent),
                SensorType.Signal => new SignalSensor(SensorType.Signal,agent),
                SensorType.Light => new LightSensor(SensorType.Light,agent),
                SensorType.Pulse => new PulseSensor(SensorType.Pulse), 
                _ => throw new ArgumentException($"Unknown sensor type: {type}")
            };
        }
    }
}