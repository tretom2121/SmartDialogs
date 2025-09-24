using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Dialogs;

public interface IDialogNode
{
    string NodeName { get; }
    DialogState GetNextState(DialogState currentState);
}