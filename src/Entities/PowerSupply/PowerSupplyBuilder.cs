namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupplyBuilder
{
    private double _peakLoad;

    public PowerSupplyBuilder WithPeakLoad(double peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(_peakLoad);
    }
}