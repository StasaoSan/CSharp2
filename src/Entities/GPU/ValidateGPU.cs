using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateGPU : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.GpuComponent != null && computerParams.PcFrameComponent != null && !computerParams.PcFrameComponent.CanAccommodateGraphicsCard(computerParams.GpuComponent.Dimentions))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Dimentions is not comparable"));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}