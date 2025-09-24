using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public interface IDialogChain
{
    DialogState GetNextState(DialogState currentState);
}