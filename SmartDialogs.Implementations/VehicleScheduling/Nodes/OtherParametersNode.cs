using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes;

public class OtherParametersNode : IDialogNode
{
    public string NodeName => "OtherParameters";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}