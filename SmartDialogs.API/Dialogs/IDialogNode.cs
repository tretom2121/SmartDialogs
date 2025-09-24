using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public interface IDialogNode
{
    string NodeName { get; }
    DialogState GetNextState(DialogState currentState);
}