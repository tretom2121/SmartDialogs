using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Services
{
    public class DialogService : IDialogService
    {
        private readonly IDialogChain DialogChain;

        public DialogService(IDialogChain dialogChain)
        {
            DialogChain = dialogChain;
        }

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
            return DialogChain.GetNextState(currentState);
        }
    }
}