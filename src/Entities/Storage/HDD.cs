using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class HDD : BaseStorageDevice
{
    public HDD(ConnectionType connection, double capacity, int spinSpeed, int powerConsumption)
        : base(connection, capacity, powerConsumption)
    {
        SpinSpeed = spinSpeed;
    }

    public override ConnectionType ConnectionType
    {
        get => base.ConnectionType;
        set
        {
            if (value == ConnectionType.PATA || value == ConnectionType.SATA)
            {
                base.ConnectionType = value;
            }
            else
            {
                throw new InvalidOperationException("Invalid connection type for HDD.");
            }
        }
    }

    public int SpinSpeed { get; init; }
    protected override BaseStorageDevice CreateClone()
    {
        return new HDD(ConnectionType, Capacity, SpinSpeed, PowerConsumption);
    }
}