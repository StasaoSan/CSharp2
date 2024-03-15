using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public struct DimentionsCoolingSystem : IEquatable<DimentionsCoolingSystem>
{
    public DimentionsCoolingSystem(int width, int height, int length)
    {
        Width = width;
        Height = height;
        Length = length;
    }

    public int Width { get; }
    public int Height { get; }
    public int Length { get; }

    public static bool operator ==(DimentionsCoolingSystem left, DimentionsCoolingSystem right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DimentionsCoolingSystem left, DimentionsCoolingSystem right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is DimentionsCoolingSystem dimentions)
        {
            return Equals(dimentions);
        }

        return false;
    }

    public bool Equals(DimentionsCoolingSystem other)
    {
        return Width == other.Width && Height == other.Height && Length == other.Length;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height, Length);
    }
}