using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RAMBuilder
{
    private int _size;
    private List<FrequencyAndVoltage> _supportedFrequencies = new();
    private List<XMPProfile> _xmpProfiles = new();
    private RAMFormFactor _formFactor;
    private TypeDDR _ddrType;
    private int _powerConsumption;

    public RAMBuilder WithSize(int size)
    {
        _size = size;
        return this;
    }

    public RAMBuilder AddSupportedFrequency(FrequencyAndVoltage frequency)
    {
        _supportedFrequencies.Add(frequency);
        return this;
    }

    public RAMBuilder AddXMPProfile(XMPProfile profile)
    {
        _xmpProfiles.Add(profile);
        return this;
    }

    public RAMBuilder WithFormFactor(RAMFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RAMBuilder WithDDRVersion(TypeDDR ddrType)
    {
        _ddrType = ddrType;
        return this;
    }

    public RAMBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(_size, _supportedFrequencies, _xmpProfiles, _formFactor, _ddrType, _powerConsumption);
    }
}