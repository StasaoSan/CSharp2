using System;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class FrequencyAndVoltage
{
    public FrequencyAndVoltage(double frequency, double voltage)
    {
        Frequency = frequency;
        Voltage = voltage;
    }

    public double Frequency { get; }
    public double Voltage { get; }

    public override bool Equals(object? obj)
    {
        if (obj is FrequencyAndVoltage other)
        {
            return Frequency == other.Frequency && Voltage == other.Voltage;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Frequency, Voltage);
    }
}
