namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public interface IValidator
{
    BuildStatus.BuildStatus Validate(ComputerParams computerParams);
    IValidator SetNext(IValidator validator);
}
