using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Dialogs;

public class FinishedNode : IDialogNode
{
    public string NodeName => "Finished";

    public DialogState GetNextState(DialogState currentState)
    {
        return currentState;
    }
}