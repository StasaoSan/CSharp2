using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

public class XMPBuilder
{
    private string? _timings;
    private double _voltage;
    private double _frequency;

    public XMPBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public XMPBuilder WithVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XMPBuilder WithFrequency(double frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XMPProfile Build()
    {
        if (_timings is null)
            throw new ArgumentException("Error: Time must be set (XMPBuilder.cs)");
        return new XMPProfile(_timings, _voltage, _frequency);
    }
}
