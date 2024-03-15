using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;

public struct DimentionsGPU : IEquatable<DimentionsGPU>
{
    public DimentionsGPU(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; }
    public double Height { get; }

    public static bool operator ==(DimentionsGPU left, DimentionsGPU right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DimentionsGPU left, DimentionsGPU right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is DimentionsGPU other)
        {
            return Equals(other);
        }

        return false;
    }

    public bool Equals(DimentionsGPU other)
    {
        return Width == other.Width && Height == other.Height;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }
}