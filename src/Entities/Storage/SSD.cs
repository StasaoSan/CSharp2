using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class SSD : BaseStorageDevice
{
    public SSD(ConnectionType connection, double capacity, int powerConsumption, int maxSpeed)
        : base(connection, capacity, powerConsumption)
    {
        MaxSpeed = maxSpeed;
    }

    public override ConnectionType ConnectionType
    {
        get => base.ConnectionType;
        set
        {
            if (value == ConnectionType.PCIe || value == ConnectionType.SATA)
            {
                base.ConnectionType = value;
            }
            else
            {
                throw new InvalidOperationException("Invalid connection type for SSD.");
            }
        }
    }

    public int MaxSpeed { get; init; }
    protected override BaseStorageDevice CreateClone()
    {
        return new SSD(ConnectionType, Capacity, PowerConsumption, MaxSpeed);
    }
}