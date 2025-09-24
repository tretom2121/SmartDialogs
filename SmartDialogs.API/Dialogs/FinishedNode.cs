using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public class FinishedNode : IDialogNode
{
    public string NodeName => "Finished";

    public DialogState GetNextState(DialogState currentState)
    {
        return currentState;
    }
}