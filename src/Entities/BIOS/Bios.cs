using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class Bios : IComponent, ICloneable
{
    private readonly string? _version;
    private readonly TypeBios _typeBios;
    public Bios(string? version, TypeBios typeBios, ICollection<string> availableProcessors)
        : this(version, typeBios)
    {
        AvailableProcessors = availableProcessors;
    }

    private Bios(string? version, TypeBios typeBios)
    {
        Id = Guid.NewGuid();
        _version = version;
        _typeBios = typeBios;
    }

    public Guid Id { get; }
    public ICollection<string> AvailableProcessors { get; } = new List<string>();

    public object Clone()
    {
        return new Bios(_version, _typeBios, new List<string>(AvailableProcessors));
    }
}