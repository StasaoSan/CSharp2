using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ValidateRAM : ComponentValidator
{
    public override BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        if (computerParams == null)
            throw new ArgumentNullException(nameof(computerParams));

        var status = new BuildStatus.BuildStatus();

        if (computerParams.RAMComponent == null)
            throw new AggregateException("RAM cant be null");

        if (computerParams.ProcessorComponent != null && !computerParams.ProcessorComponent.AvailableFrequencyMemory
                .Any(t => computerParams.RAMComponent.SupportedFrequencies.Any(p => p.Frequency == t)))
            status.AddMessage(new BuildMessage(StatusType.WithErrors, "RAM incomplete with Processor by frequency"));

        if (computerParams.MotherboardComponent != null && computerParams.RAMComponent.XMPProfiles.Count > 0)
        {
            if (!computerParams.MotherboardComponent.Chipset.SupportsXMP)
                status.AddMessage(new BuildMessage(StatusType.WithWarnings, "Motherboard does not support XMP"));
            else if (computerParams.ProcessorComponent != null && computerParams.XMPProfileComponent != null &&
                     !computerParams.ProcessorComponent.AvailableFrequencyMemory.Contains(computerParams
                         .XMPProfileComponent.Frequency))
                status.AddMessage(new BuildMessage(StatusType.WithWarnings, "Processor does not support the selected XMP profile's frequency"));
        }

        BuildStatus.BuildStatus nextStatus = base.Validate(computerParams);
        foreach (BuildMessage message in nextStatus.Messages)
            status.AddMessage(message);
        return status;
    }
}