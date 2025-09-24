using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public class WelcomeNode : IDialogNode
{
    public string NodeName => "Welcome";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "SelectGoal", Parameters = currentState.Parameters };
    }
}