using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Dialogs;

public interface IDialogChain
{
    DialogState GetNextState(DialogState currentState);
}