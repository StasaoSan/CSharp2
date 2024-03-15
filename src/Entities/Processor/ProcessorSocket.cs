using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

public class ProcessorSocket
{
    public ProcessorSocket(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override bool Equals(object? obj)
    {
        return obj is ProcessorSocket socket &&
               Name == socket.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}