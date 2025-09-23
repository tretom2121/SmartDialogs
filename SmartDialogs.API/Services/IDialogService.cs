using SmartDialogs.API.Models;

namespace SmartDialogs.API.Services;

public interface IDialogService
{
    DialogState GetInitialState();
    DialogState GetNextState(DialogState currentState);
}