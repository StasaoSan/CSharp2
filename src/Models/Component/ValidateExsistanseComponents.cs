using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateExsistanseComponents : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.MotherboardComponent is null)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Motherboard is missing."));

        if (computerParams.ProcessorComponent is null)
        {
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Processor is missing."));
        }
        else
        {
            if (computerParams.ProcessorComponent.Socket == null)
                status.AddMessage(new BuildMessage(StatusType.WithErrors, "Processor Socket is missing."));
        }

        if (computerParams.BIOSComponent is null)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "BIOS is missing."));

        if (computerParams.RAMComponent is null)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "RAM is missing."));

        if (computerParams.CoolingComponent is null)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Cooling system is missing."));

        if (computerParams.GpuComponent is null && (computerParams.ProcessorComponent is null ||
                                                    computerParams.ProcessorComponent.IsBuiltVideoCore == false))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "GPU is missing."));

        if (!computerParams.StorageComponents.Any())
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Storage is missing."));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}