using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateCoolingSystem : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.CoolingComponent is null)
        {
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Cooling system is missing."));
        }
        else
        {
            if (computerParams.ProcessorComponent != null)
            {
                if (computerParams.CoolingComponent.TDP < computerParams.ProcessorComponent.TDP)
                    status.AddMessage(new BuildMessage(StatusType.WithWarnings, "Cooling system TDP is too small"));

                if (computerParams.ProcessorComponent.Socket != null)
                {
                    if (!computerParams.CoolingComponent.SupportedSockets.Contains(computerParams.ProcessorComponent.Socket))
                        status.AddMessage(new BuildMessage(StatusType.WithErrors, "Cooling system does not support the processor socket"));
                }
            }

            if (computerParams.PcFrameComponent != null && !computerParams.PcFrameComponent.CanAccommodateCoolingSystem(computerParams.CoolingComponent.Dimensions))
                status.AddMessage(new BuildMessage(StatusType.WithErrors, "Cooling system dimensions do not fit within the PC frame."));
        }

        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);

        return status;
    }
}