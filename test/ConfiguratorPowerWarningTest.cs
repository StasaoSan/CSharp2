using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
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
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfiguratorPowerWarningTest
{
    public static IEnumerable<object[]> CompatibleComponentsData
    {
        get
        {
            var supportedFrequencies = new List<double> { 10.0, 12.0, 14.0 };
            var commonSocket = new ProcessorSocket("478");
            bool xmpSupport = true;

            Bios bios = new BiosBuilder()
                .WithTypeBios(TypeBios.Intel)
                .WithVersion(ConstantsComputer.BiosVershion)
                .WithAvaliableProcessors(new List<string> { "Intel i7", "Intel i5" })
                .Build();

            CoolingSystem coolingSystem = new CoolingSystemBuilder()
                .WithSize(new DimentionsCoolingSystem(
                    ConstantsComputer.CoolingSystemWidth,
                    ConstantsComputer.CoolingSystemHeight,
                    ConstantsComputer.CoolingSystemLength))
                .WithMaxTDP(ConstantsComputer.MaxTDP2)
                .AddSupportedSocket(commonSocket)
                .Build();

            GPU gpu = new GPUBuilder()
                .WithDimensions(new DimentionsGPU(ConstantsComputer.GPUWidth, ConstantsComputer.GPUHeight))
                .WithChipFrequency(ConstantsComputer.FrequencyGPU)
                .WithPowerConsumption(ConstantsComputer.GPUConsumption)
                .WithPCIVersion(PCIVershion.V5)
                .Build();

            Motherboard motherboard = new MotherboardBuilder()
                .WithSocket(commonSocket)
                .WithChipset(new Chipset(supportedFrequencies, xmpSupport))
                .WithCountSata(ConstantsComputer.SATACount)
                .WithCountPCI(ConstantsComputer.PCICount)
                .WithFormFactor(FormFactor.AT)
                .WithCountSlotRam(ConstantsComputer.RAMSlotCount)
                .WithBIOS(bios)
                .WithTypeDDR(TypeDDR.DDR4)
                .Build();

            PCFrame pcFrame = new PCFrameBuilder()
                .WithGPUDimentions(new DimentionsGPU(ConstantsComputer.MaxGPUWidth, ConstantsComputer.MaxGPUHeight))
                .WithPCFrameDimentions(new DimentionsPCFrame(ConstantsComputer.PCFrameWidth, ConstantsComputer.PCFrameHeight, ConstantsComputer.PCFrameDepth))
                .WithSupportedMotherboardFormFactor(new List<FormFactor> { FormFactor.AT, FormFactor.ATX })
                .Build();

            PowerSupply powerSupply = new PowerSupplyBuilder()
                .WithPeakLoad(ConstantsComputer.PeakLoad2)
                .Build();

            Processor processor = new ProcessorBuilder()
                .WithFrequency(ConstantsComputer.ProcessorFrequency)
                .WithPowerConsumption(ConstantsComputer.ProcessorConsumption)
                .WithModel("Intel i7")
                .WithSocket(commonSocket)
                .WithCountCore(ConstantsComputer.ProcessorCoreCount)
                .WithAvailableFrequencyMemory(supportedFrequencies)
                .WithTDP(ConstantsComputer.ProcessorTDP)
                .Build();

            Ram ram = new RAMBuilder()
                .WithSize(ConstantsComputer.RAMAvaliableSize)
                .WithFormFactor(RAMFormFactor.DIMM)
                .WithPowerConsumption(ConstantsComputer.RAMConsumption)
                .WithDDRVersion(TypeDDR.DDR4)
                .AddSupportedFrequency(new FrequencyAndVoltage(ConstantsComputer.RAMFrequency2, ConstantsComputer.RAMVoltage))
                .AddXMPProfile(new XMPProfile(ConstantsComputer.XMPTimings, ConstantsComputer.XMPVoltage, ConstantsComputer.XMPFrequency))
                .Build();

            SSD ssd = new SSDBuilder()
                .WithPowerConsumption(ConstantsComputer.SSDConsumtion)
                .WithCapacity(ConstantsComputer.SSDCapacity)
                .WithConnection(ConnectionType.SATA)
                .WithMaxSpeed(ConstantsComputer.SSDMaxSpeed)
                .Build();

            WiFiAdapter wifiAdapter = new WiFiAdapterBuilder()
                .WithPowerConsumption(ConstantsComputer.WiFiConsumption)
                .WithBluetoothModule(false)
                .WithWiFiStandard(WiFiStandard.WiFI5)
                .WithPciEVersion(PCIVershion.V5)
                .Build();

            yield return new object[]
            {
                bios, coolingSystem, gpu, motherboard,
                pcFrame, powerSupply, processor, ram,
                ssd, wifiAdapter,
            };
        }
    }

    [Theory]
    [MemberData(nameof(CompatibleComponentsData))]
    public void TestComputerConfiguratorWarning(
        Bios bios,
        CoolingSystem coolingSystem,
        GPU gpu,
        Motherboard motherboard,
        PCFrame pcFrame,
        PowerSupply powerSupply,
        Processor processor,
        Ram ram,
        SSD ssd,
        WiFiAdapter wifiAdapter)
    {
        var configurator = new ComputerConfigurator();

        configurator.AddComponent(bios);
        configurator.AddComponent(coolingSystem);
        configurator.AddComponent(gpu);
        configurator.AddComponent(motherboard);
        configurator.AddComponent(pcFrame);
        configurator.AddComponent(powerSupply);
        configurator.AddComponent(processor);
        configurator.AddComponent(ram);
        configurator.AddComponent(ssd);
        configurator.AddComponent(wifiAdapter);

        BuildStatus status = configurator.ValidateBuild();

        BuildMessage? warningMessage = status.Messages.FirstOrDefault(m => m.MessageType == StatusType.WithWarnings && m.MessageText == "There is only enough power to start the system");
        Assert.NotNull(warningMessage);
    }
}