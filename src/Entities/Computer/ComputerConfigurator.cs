using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ComputerConfigurator
{
    private readonly List<IValidator> _validators;
    private ComputerParams _paramsComputer = new ComputerParams();

    public ComputerConfigurator()
    {
        _validators = new List<IValidator>
        {
            new ValidatePCFrame(),
            new ValidateBIOS(),
            new ValidateExsistanseComponents(),
            new ValidateMotherboard(),
            new ValidateCoolingSystem(),
            new ValidatePowerSupply(),
            new ValidateGPU(),
            new ValidateRAM(),
            new ValidateCountPCI(),
        };

        for (int i = 0; i < _validators.Count - 1; i++)
            _validators[i].SetNext(_validators[i + 1]);
    }

    public void AddComponent(IComponent component)
    {
        switch (component)
        {
            case BIOS.Bios bios:
                _paramsComputer.BIOSComponent = bios;
                break;
            case CoolingSystem.CoolingSystem cooling:
                _paramsComputer.CoolingComponent = cooling;
                break;
            case GPU.GPU gpu:
                _paramsComputer.GpuComponent = gpu;
                break;
            case Motherboard.Motherboard motherboard:
                _paramsComputer.MotherboardComponent = motherboard;
                break;
            case PCFrame.PCFrame pcFrame:
                _paramsComputer.PcFrameComponent = pcFrame;
                break;
            case PowerSupply.PowerSupply powerSupply:
                _paramsComputer.PowerSupplyComponent = powerSupply;
                break;
            case Processor.Processor processor:
                _paramsComputer.ProcessorComponent = processor;
                break;
            case RAM.Ram ram:
                _paramsComputer.RAMComponent = ram;
                break;
            case BaseStorageDevice storage:
                if (_paramsComputer.StorageComponents is null)
                    throw new ArgumentException("Storage cant be null");
                _paramsComputer.StorageComponents.Add(storage);
                break;
            case WiFiAdapter wiFiAdapter:
                _paramsComputer.WiFiAdapterComponent = wiFiAdapter;
                break;
            case XPM.XMPProfile xmpProfile:
                _paramsComputer.XMPProfileComponent = xmpProfile;
                break;
        }
    }

    public void Build(IFactoryComputer factory)
    {
        if (factory == null)
            throw new ArgumentNullException(nameof(factory));

        _paramsComputer = factory.Create();
    }

    public void UpdateStorages(ICollection<BaseStorageDevice> storageDevices)
    {
        if (storageDevices == null)
            throw new ArgumentNullException(nameof(storageDevices));

        _paramsComputer.StorageComponents.Clear();
        foreach (BaseStorageDevice device in storageDevices)
            _paramsComputer.StorageComponents.Add(device);
    }

    public BuildStatus.BuildStatus ValidateBuild()
    {
        var status = new BuildStatus.BuildStatus();

        if (_validators.Any())
            status = _validators.First().Validate(_paramsComputer);

        return status;
    }
}