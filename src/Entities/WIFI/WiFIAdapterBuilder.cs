using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiAdapterBuilder
{
    private WiFiStandard _wifiStandard;
    private bool _hasBluetoothModule;
    private PCIVershion _pciEVershion;
    private double _powerConsumption;

    public WiFiAdapterBuilder WithWiFiStandard(WiFiStandard wifiStandard)
    {
        _wifiStandard = wifiStandard;
        return this;
    }

    public WiFiAdapterBuilder WithBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public WiFiAdapterBuilder WithPciEVersion(PCIVershion pciEVershion)
    {
        _pciEVershion = pciEVershion;
        return this;
    }

    public WiFiAdapterBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(_wifiStandard, _hasBluetoothModule, _pciEVershion, _powerConsumption);
    }
}