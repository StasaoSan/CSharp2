using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiAdapter : IComponent, ICloneable
{
    public WiFiAdapter(WiFiStandard wifiStandard, bool hasBluetoothModule, PCIVershion pciEVershion, double powerConsumption)
    {
        Id = Guid.NewGuid();
        WiFiStandard = wifiStandard;
        HasBluetoothModule = hasBluetoothModule;
        PciEVershion = pciEVershion;
        PowerConsumption = powerConsumption;
    }

    public Guid Id { get; }
    public WiFiStandard WiFiStandard { get; }
    public bool HasBluetoothModule { get; }
    public PCIVershion PciEVershion { get; }
    public double PowerConsumption { get; }

    public object Clone()
    {
        return new WiFiAdapter(WiFiStandard, HasBluetoothModule, PciEVershion, PowerConsumption);
    }
}