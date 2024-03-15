using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateMotherboard : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        var status = new BuildStatus.BuildStatus();
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        if (computerParams.ProcessorComponent is not null && computerParams.MotherboardComponent is not null && !computerParams.MotherboardComponent.ProcessorSocket.Equals(computerParams.ProcessorComponent.Socket))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Processor socket is not compatible with motherboard socket."));
        if (computerParams.MotherboardComponent?.TypeDDR != computerParams.RAMComponent?.DDRType)
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "RAM is not compatible with motherboard type ddr."));
        if (computerParams.MotherboardComponent is not null && computerParams.PcFrameComponent is not null && (!computerParams.PcFrameComponent.SupportedMotherboardFormFactors.Contains(computerParams.MotherboardComponent.FormFactor)))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "Motherboard cant fit to PC frame form factors"));
        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}