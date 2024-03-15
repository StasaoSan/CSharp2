namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

public interface IFactory<TProduct, TParams>
{
    TProduct Create(TParams parameters);
}
