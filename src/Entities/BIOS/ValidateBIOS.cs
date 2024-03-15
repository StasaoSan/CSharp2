using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateBIOS : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.BIOSComponent == null || computerParams.ProcessorComponent == null) return status;
        if (!computerParams.BIOSComponent.AvailableProcessors.Contains(computerParams.ProcessorComponent.Model))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "BIOS is not compatible with processor."));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);

        return status;
    }
}