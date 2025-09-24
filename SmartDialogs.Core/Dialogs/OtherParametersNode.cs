using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Dialogs;

public class OtherParametersNode : IDialogNode
{
    public string NodeName => "OtherParameters";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}