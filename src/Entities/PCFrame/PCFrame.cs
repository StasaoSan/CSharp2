using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;

public class PCFrame : IComponent, ICloneable
{
    public PCFrame(DimentionsGPU maxGraphicsCardSize, ICollection<FormFactor> supportedMotherboardFormFactors, DimentionsPCFrame dimensions)
    {
        Id = Guid.NewGuid();
        MaxGraphicsCardSize = maxGraphicsCardSize;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public Guid Id { get; }
    public DimentionsGPU MaxGraphicsCardSize { get; }
    public ICollection<FormFactor> SupportedMotherboardFormFactors { get; }
    public DimentionsPCFrame Dimensions { get; }

    public bool CanAccommodateGraphicsCard(DimentionsGPU graphicsCardSize)
    {
        return graphicsCardSize.Width <= MaxGraphicsCardSize.Width
               && graphicsCardSize.Height <= MaxGraphicsCardSize.Height;
    }

    public bool CanAccommodateCoolingSystem(DimentionsCoolingSystem coolingSystemSize)
    {
        return coolingSystemSize.Width <= Dimensions.Width
               && coolingSystemSize.Height <= Dimensions.Height
               && coolingSystemSize.Length <= Dimensions.Depth;
    }

    public bool SupportsMotherboardFormFactor(FormFactor formFactor)
    {
        return SupportedMotherboardFormFactors.Contains(formFactor);
    }

    public object Clone()
    {
        return new PCFrame(MaxGraphicsCardSize, SupportedMotherboardFormFactors, Dimensions);
    }
}
