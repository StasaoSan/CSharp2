using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuildStatus;

public class BuildStatus
{
    public StatusType StatusType
    {
        get
        {
            StatusType type = StatusType.Success;
            foreach (BuildMessage item in Messages)
            {
                if (item.MessageType == StatusType.WithErrors)
                {
                    type = StatusType.WithErrors;
                    break;
                }

                if (item.MessageType == StatusType.WithWarnings)
                    type = StatusType.WithWarnings;
            }

            return type;
        }
    }

    public ICollection<BuildMessage> Messages { get; } = new List<BuildMessage>();

    public void AddMessage(BuildMessage message)
    {
        Messages.Add(message);
    }
}