using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;

public class Motherboard : IComponent, ICloneable
{
    public Motherboard(ProcessorSocket processorSocket, int countPCI, int countSata, TypeDDR typeDDR, Chipset chipset, int countSlotRam, FormFactor formFactor, Bios bIOS)
    {
        Id = Guid.NewGuid();
        ProcessorSocket = processorSocket;
        CountPCI = countPCI;
        CountSata = countSata;
        TypeDDR = typeDDR;
        Chipset = chipset;
        CountSlotRam = countSlotRam;
        FormFactor = formFactor;
        BIOS = bIOS;
    }

    public Guid Id { get; }
    public ProcessorSocket ProcessorSocket { get; }
    public int CountPCI { get; }
    public int CountSata { get; }
    public TypeDDR TypeDDR { get; }
    public Chipset Chipset { get; }
    public int CountSlotRam { get; }
    public FormFactor FormFactor { get; }
    public Bios BIOS { get; }

    public object Clone()
    {
        return new Motherboard(ProcessorSocket, CountPCI, CountSata, TypeDDR, Chipset, CountSlotRam, FormFactor, BIOS);
    }
}