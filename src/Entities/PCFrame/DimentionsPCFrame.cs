using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;

public struct DimentionsPCFrame : IEquatable<DimentionsPCFrame>
{
    public DimentionsPCFrame(double width, double height, double depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }

    public static bool operator ==(DimentionsPCFrame left, DimentionsPCFrame right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DimentionsPCFrame left, DimentionsPCFrame right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is DimentionsPCFrame dimensions)
        {
            return Equals(dimensions);
        }

        return false;
    }

    public bool Equals(DimentionsPCFrame other)
    {
        return Width == other.Width && Height == other.Height && Depth == other.Depth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height, Depth);
    }
}
