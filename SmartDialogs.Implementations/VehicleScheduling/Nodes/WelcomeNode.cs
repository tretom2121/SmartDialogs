using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes;

public class WelcomeNode : IDialogNode
{
    public string NodeName => "Welcome";

    public DialogState GetNextState(DialogState currentState)
    {
        return new DialogState { CurrentState = "SelectGoal", Parameters = currentState.Parameters };
    }
}