using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;

public class PCFrameBuilder
{
    private DimentionsGPU _maxGraphicsCardSize;
    private ICollection<FormFactor>? _supportedMotherboardFormFactors;
    private DimentionsPCFrame _dimensions;

    public PCFrameBuilder WithGPUDimentions(DimentionsGPU dimentionsGPU)
    {
        _maxGraphicsCardSize = dimentionsGPU;
        return this;
    }

    public PCFrameBuilder WithSupportedMotherboardFormFactor(ICollection<FormFactor> supportedFormFactors)
    {
        _supportedMotherboardFormFactors = supportedFormFactors;
        return this;
    }

    public PCFrameBuilder WithPCFrameDimentions(DimentionsPCFrame dimentions)
    {
        _dimensions = dimentions;
        return this;
    }

    public PCFrame Build()
    {
        if (_supportedMotherboardFormFactors is null)
            throw new ArgumentException("MotherboardFormFactor supports is null");
        return new PCFrame(_maxGraphicsCardSize, _supportedMotherboardFormFactors, _dimensions);
    }
}