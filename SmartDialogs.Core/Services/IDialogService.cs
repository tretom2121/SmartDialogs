using SmartDialogs.Core.Models;

namespace SmartDialogs.Core.Services;

public interface IDialogService
{
    DialogState GetInitialState();
    DialogState GetNextState(DialogState currentState);
}