namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class HDDBuilder
{
    private ConnectionType _connection;
    private double _capacity;
    private int _spinSpeed;
    private int _powerConsumption;

    public HDDBuilder WithConnection(ConnectionType connection)
    {
        _connection = connection;
        return this;
    }

    public HDDBuilder WithCapacity(double capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HDDBuilder WithSpinSpeed(int spinSpeed)
    {
        _spinSpeed = spinSpeed;
        return this;
    }

    public HDDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HDD Build()
    {
        return new HDD(_connection, _capacity, _spinSpeed, _powerConsumption);
    }
}
