using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiAdapterParams
{
    public WiFiStandard WiFiStandard { get; }
    public bool HasBluetoothModule { get; }
    public PCIVershion PciEVershion { get; }
    public double PowerConsumption { get; }
}