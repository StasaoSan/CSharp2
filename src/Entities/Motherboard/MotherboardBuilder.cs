using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;

public class MotherboardBuilder
{
    private ProcessorSocket? _socket;
    private Bios? _bios;
    private int _countPCI;
    private int _countSata;
    private TypeDDR _typeDDR;
    private Chipset? _chipset;
    private int _countSlotRam;
    private FormFactor _formFactor;

    public MotherboardBuilder WithSocket(ProcessorSocket socket)
    {
        this._socket = socket;
        return this;
    }

    public MotherboardBuilder WithCountPCI(int countPCI)
    {
        this._countPCI = countPCI;
        return this;
    }

    public MotherboardBuilder WithCountSata(int countSata)
    {
        this._countSata = countSata;
        return this;
    }

    public MotherboardBuilder WithTypeDDR(TypeDDR typeDDR)
    {
        this._typeDDR = typeDDR;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        this._chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithCountSlotRam(int countSlotRam)
    {
        this._countSlotRam = countSlotRam;
        return this;
    }

    public MotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        this._formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBIOS(Bios bios)
    {
        this._bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        if (_socket is null || _bios is null || _chipset is null)
        {
            throw new InvalidOperationException("Some required properties were not set.");
        }

        return new Motherboard(_socket, _countPCI, _countSata, _typeDDR, _chipset,  _countSlotRam, _formFactor, _bios);
    }
}