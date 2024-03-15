using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

public class XMPFactory : IFactory<XMPProfile, XMPParams>
{
    public XMPProfile Create(XMPParams parameters)
    {
        if (parameters is null || parameters.Timings is null)
            throw new AggregateException("parameter cant be null");
        return new XMPProfile(parameters.Timings, parameters.Voltage, parameters.Frequency);
    }
}