using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

public class BuildMessage
{
    public BuildMessage(StatusType type, string text, IComponent? relatedComponent = null)
    {
        MessageType = type;
        MessageText = text;
        RelatedComponent = relatedComponent;
    }

    public StatusType MessageType { get; set; }
    public string MessageText { get; set; }
    public IComponent? RelatedComponent { get; set; }
}