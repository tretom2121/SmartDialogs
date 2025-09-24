using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.DutySchedule.Nodes
{
    public class SelectShiftNode : IDialogNode
    {
        public string NodeName => "SelectShift";

        public DialogState GetNextState(DialogState currentState)
        {
            return new DialogState { CurrentState = "Confirm" };
        }
    }
}