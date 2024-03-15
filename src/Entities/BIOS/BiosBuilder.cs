using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BiosBuilder
{
    private string? _version;
    private TypeBios _typeBios;
    private ICollection<string> _availableProcessors = new List<string>();

    public BiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder WithTypeBios(TypeBios typeBios)
    {
        _typeBios = typeBios;
        return this;
    }

    public BiosBuilder WithAvaliableProcessors(ICollection<string> avaliableProcessors)
    {
        _availableProcessors = avaliableProcessors;
        return this;
    }

    public Bios Build()
    {
        return new Bios(_version, _typeBios, _availableProcessors);
    }
}