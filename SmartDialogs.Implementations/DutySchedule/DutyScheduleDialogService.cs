using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;
using SmartDialogs.Core.Services;

namespace SmartDialogs.Implementations.DutySchedule
{
    public class DutyScheduleDialogService(IDialogChain dialogChain) : IDialogService
    {
        public DialogState GetInitialState() => new() { CurrentState = "SelectDate" };
        public DialogState GetNextState(DialogState currentState) => dialogChain.GetNextState(currentState);
        public DialogState PreviewNextState(DialogState currentState) => dialogChain.GetNextState(currentState);
    }
}