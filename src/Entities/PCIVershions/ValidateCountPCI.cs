using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateCountPCI : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();

        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        int count = computerParams.MotherboardComponent?.CountPCI ?? 0;

        count -= computerParams.StorageComponents.Count(t => t is SSD ssd && ssd.ConnectionType == ConnectionType.PCIe);
        if (count < 0)
            status.AddMessage(new BuildMessage(StatusType.WithWarnings, "PCI count is less"));
        if (count < 1 && computerParams.GpuComponent != null)
            status.AddMessage(new BuildMessage(StatusType.WithWarnings, "PCI count is less"));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}