using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.DutySchedule.Nodes
{
    public class SelectDateNode : IDialogNode
    {
        public string NodeName => "SelectDate";

        public DialogState GetNextState(DialogState currentState)
        {
            return new DialogState { CurrentState = "SelectShift" };
        }
    }
}