namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public abstract class ComponentValidator : IValidator
{
    private IValidator? _nextValidator;

    protected IValidator? NextValidator
    {
        get { return _nextValidator; }
        set { _nextValidator = value; }
    }

    public IValidator SetNext(IValidator validator)
    {
        NextValidator = validator;
        return validator;
    }

    public virtual BuildStatus.BuildStatus Validate(ComputerParams computerParams)
    {
        if (NextValidator != null)
            return NextValidator.Validate(computerParams);
        return new BuildStatus.BuildStatus();
    }
}