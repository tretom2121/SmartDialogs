using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;
using SmartDialogs.Core.Services;

namespace SmartDialogs.Implementations.VehicleScheduling
{
    public class VehicleSchedulingDialogService(IDialogChain dialogChain) : IDialogService
    {
        public DialogState GetInitialState()
        {
            return new DialogState
            {
                CurrentState = "Welcome",
                Parameters = new Dictionary<string, object>()
            };
        }

        public DialogState GetNextState(DialogState currentState)
        {
            return dialogChain.GetNextState(currentState);
        }
    }
}