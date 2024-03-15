using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class FactoryHomeComputer : IFactoryComputer
{
    public ComputerParams Create()
    {
        var build = new ComputerParams();
        var supportedFrequencies = new List<double> { 10.0, 12.0, 14.0 };
        var commonSocket = new ProcessorSocket("478");
        bool xmpSupport = true;

        build.BIOSComponent = new BiosBuilder()
            .WithTypeBios(TypeBios.Intel)
            .WithVersion("123")
            .WithAvaliableProcessors(new List<string> { "Intel i3", "Intel i5" })
            .Build();

        build.CoolingComponent = new CoolingSystemBuilder()
            .WithSize(new DimentionsCoolingSystem(3, 5, 10))
            .WithMaxTDP(200)
            .AddSupportedSocket(commonSocket)
            .Build();

        build.GpuComponent = new GPUBuilder()
            .WithDimensions(new DimentionsGPU(10, 5))
            .WithChipFrequency(12)
            .WithPowerConsumption(10)
            .WithPCIVersion(PCIVershion.V5)
            .Build();

        build.MotherboardComponent = new MotherboardBuilder()
            .WithSocket(commonSocket)
            .WithChipset(new Chipset(supportedFrequencies, xmpSupport))
            .WithCountSata(8)
            .WithCountPCI(4)
            .WithFormFactor(FormFactor.AT)
            .WithCountSlotRam(4)
            .WithBIOS(build.BIOSComponent)
            .WithTypeDDR(TypeDDR.DDR4)
            .Build();

        build.PcFrameComponent = new PCFrameBuilder()
            .WithGPUDimentions(new DimentionsGPU(12, 8))
            .WithPCFrameDimentions(new DimentionsPCFrame(10, 20, 30))
            .WithSupportedMotherboardFormFactor(new List<FormFactor> { FormFactor.AT, FormFactor.ATX })
            .Build();

        build.PowerSupplyComponent = new PowerSupplyBuilder()
            .WithPeakLoad(400)
            .Build();

        build.ProcessorComponent = new ProcessorBuilder()
            .WithFrequency(3.7)
            .WithPowerConsumption(200)
            .WithModel("Intel i5")
            .WithSocket(commonSocket)
            .WithCountCore(10)
            .WithAvailableFrequencyMemory(supportedFrequencies)
            .WithTDP(100)
            .Build();

        build.RAMComponent = new RAMBuilder()
            .WithSize(10)
            .WithFormFactor(RAMFormFactor.DIMM)
            .WithPowerConsumption(10)
            .WithDDRVersion(TypeDDR.DDR4)
            .AddSupportedFrequency(new FrequencyAndVoltage(12, 0.3))
            .AddXMPProfile(new XMPProfile("12-20-34", 0.3, 12))
            .Build();

        build.StorageComponents.Add(new SSDBuilder().WithPowerConsumption(12)
            .WithCapacity(1024)
            .WithConnection(ConnectionType.SATA)
            .WithMaxSpeed(2000)
            .Build());

        build.WiFiAdapterComponent = new WiFiAdapterBuilder()
            .WithPowerConsumption(1)
            .WithBluetoothModule(false)
            .WithWiFiStandard(WiFiStandard.WiFI5)
            .WithPciEVersion(PCIVershion.V5)
            .Build();
        return build;
    }
}