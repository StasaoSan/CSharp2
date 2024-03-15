using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiAdapterFactory : IFactory<WiFiAdapter, WiFiAdapterParams>
{
    public WiFiAdapter Create(WiFiAdapterParams parameters)
    {
        if (parameters is null)
            throw new ArgumentException("parameters cant be null");
        return new WiFiAdapter(parameters.WiFiStandard, parameters.HasBluetoothModule, parameters.PciEVershion, parameters.PowerConsumption);
    }
}