namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class SSDBuilder
{
    private ConnectionType _connection;
    private double _capacity;
    private int _powerConsumption;
    private int _maxSpeed;

    public SSDBuilder WithConnection(ConnectionType connection)
    {
        _connection = connection;
        return this;
    }

    public SSDBuilder WithCapacity(double capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SSDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SSDBuilder WithMaxSpeed(int maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public SSD Build()
    {
        return new SSD(_connection, _capacity, _powerConsumption, _maxSpeed);
    }
}