using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ComputerParams
{
    public Bios? BIOSComponent { get; set; }
    public CoolingSystem.CoolingSystem? CoolingComponent { get; set; }
    public RAM.Ram? RAMComponent { get; set; }
    public ICollection<BaseStorageDevice> StorageComponents { get; } = new List<BaseStorageDevice>();
    public XMPProfile? XMPProfileComponent { get; set; }
    public GPU.GPU? GpuComponent { get; set; }
    public PCFrame.PCFrame? PcFrameComponent { get; set; }
    public PowerSupply.PowerSupply? PowerSupplyComponent { get; set; }
    public WiFiAdapter? WiFiAdapterComponent { get; set; }
    public Processor.Processor? ProcessorComponent { get; set; }
    public Motherboard.Motherboard? MotherboardComponent { get; set; }
}