using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes;

public class FinishedNode : IDialogNode
{
    public string NodeName => "Finished";

    public DialogState GetNextState(DialogState currentState)
    {
        return currentState;
    }
}