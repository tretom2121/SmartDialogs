using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes;

public class CostParametersNode : IDialogNode
{
    public string NodeName => "CostParameters";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}