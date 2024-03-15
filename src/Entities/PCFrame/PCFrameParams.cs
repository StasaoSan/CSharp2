using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.FormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;

public class PCFrameParams
{
    public DimentionsGPU MaxGraphicsCardSize { get; }
    public ICollection<FormFactor>? SupportedMotherboardFormFactors { get; }
    public DimentionsPCFrame Dimensions { get; }
}