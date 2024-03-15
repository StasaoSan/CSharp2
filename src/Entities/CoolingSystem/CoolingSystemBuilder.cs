using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystemBuilder
{
    private readonly List<ProcessorSocket> _supportedSockets = new();
    private DimentionsCoolingSystem? _size;
    private double _maxTDP;

    public CoolingSystemBuilder WithSize(DimentionsCoolingSystem size)
    {
        _size = size;
        return this;
    }

    public CoolingSystemBuilder AddSupportedSocket(ProcessorSocket socket)
    {
        _supportedSockets.Add(socket);
        return this;
    }

    public CoolingSystemBuilder WithMaxTDP(double maxTDP)
    {
        _maxTDP = maxTDP;
        return this;
    }

    public CoolingSystem Build()
    {
        if (!_size.HasValue)
        {
            throw new InvalidOperationException("Size must be specified.");
        }

        return new CoolingSystem(_size.Value, _maxTDP, _supportedSockets);
    }
}