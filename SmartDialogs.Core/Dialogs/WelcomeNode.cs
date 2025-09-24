using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Dialogs;

public class WelcomeNode : IDialogNode
{
    public string NodeName => "Welcome";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "SelectGoal", Parameters = currentState.Parameters };
    }
}