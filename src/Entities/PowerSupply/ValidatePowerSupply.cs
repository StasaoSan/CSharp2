using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidatePowerSupply : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        var status = new BuildStatus.BuildStatus();
        if (computerParams.PowerSupplyComponent is null)
            throw new ArgumentException("PowerSupply cant be null");

        int totalPowerNeeded = 0;
        totalPowerNeeded += computerParams.GpuComponent?.PowerConsumption ?? 0;
        totalPowerNeeded += computerParams.ProcessorComponent?.PowerConsumtion ?? 0;
        totalPowerNeeded += computerParams.RAMComponent?.PowerConsumption ?? 0;
        totalPowerNeeded += computerParams.StorageComponents?.Sum(storageDevice => storageDevice.PowerConsumption) ?? 0;

        if (totalPowerNeeded > computerParams.PowerSupplyComponent.PeakLoad && computerParams.ProcessorComponent?.PowerConsumtion > computerParams.PowerSupplyComponent.PeakLoad)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Insufficient power supply for the current configuration."));
        else if (totalPowerNeeded > computerParams.PowerSupplyComponent.PeakLoad && computerParams.ProcessorComponent?.PowerConsumtion <= computerParams.PowerSupplyComponent.PeakLoad)
            status.AddMessage(new BuildMessage(StatusType.WithWarnings, "There is only enough power to start the system"));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}