using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public class CostParametersNode : IDialogNode
{
    public string NodeName => "CostParameters";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}