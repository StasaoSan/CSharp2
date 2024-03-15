using System;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public abstract class BaseStorageDevice : IComponent, ICloneable
{
    private ConnectionType connectionType;

    protected BaseStorageDevice(ConnectionType connectionType, double capacity, int powerConsumption)
    {
        Id = Guid.NewGuid();
        ConnectionType = connectionType;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
    }

    public Guid Id { get; }

    public virtual ConnectionType ConnectionType
    {
        get { return connectionType; }
        set { connectionType = value; }
    }

    public double Capacity { get; }
    public int PowerConsumption { get; }

    public object Clone()
    {
        return CreateClone();
    }

    protected abstract BaseStorageDevice CreateClone();
}