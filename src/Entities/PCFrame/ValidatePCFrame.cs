using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidatePCFrame : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.PcFrameComponent is null)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "PC frame is missing."));

        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);

        return status;
    }
}