using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;

public class MotherboardParams
{
    public ProcessorSocket? ProcessorSocket { get; }
    public int CountPCI { get; }
    public int CountSata { get; }
    public TypeDDR TypeDDR { get; }
    public Chipset? Chipset { get; }
    public int CountSlotRam { get; }
    public FormFactor FormFactor { get; }
    public Bios? BIOS { get; }
}