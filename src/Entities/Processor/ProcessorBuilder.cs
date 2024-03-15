using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processor;

public class ProcessorBuilder
{
    private string? _model;
    private double _frequency;
    private int _countCore;
    private ProcessorSocket? _socket;
    private bool _isBuiltVideoCore;
    private ICollection<double> _availableFrequencyMemory = new List<double>();
    private double _tdp;
    private int _power;

    public ProcessorBuilder WithModel(string model)
    {
        _model = model;
        return this;
    }

    public ProcessorBuilder WithFrequency(double frequency)
    {
        _frequency = frequency;
        return this;
    }

    public ProcessorBuilder WithCountCore(int countCore)
    {
        _countCore = countCore;
        return this;
    }

    public ProcessorBuilder WithSocket(ProcessorSocket socket)
    {
        _socket = socket;
        return this;
    }

    public ProcessorBuilder WithBuiltVideoCore(bool isBuiltVideoCore)
    {
        _isBuiltVideoCore = isBuiltVideoCore;
        return this;
    }

    public ProcessorBuilder WithAvailableFrequencyMemory(ICollection<double> availableFrequencyMemory)
    {
        _availableFrequencyMemory = availableFrequencyMemory;
        return this;
    }

    public ProcessorBuilder WithTDP(double tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ProcessorBuilder WithPowerConsumption(int power)
    {
        _power = power;
        return this;
    }

    public Processor Build()
    {
        if (string.IsNullOrEmpty(_model) || _socket == null)
        {
            throw new InvalidOperationException("Some required properties were not set.");
        }

        return new Processor(_model, _frequency, _countCore, _socket, _isBuiltVideoCore, _availableFrequencyMemory, _tdp, _power);
    }
}
