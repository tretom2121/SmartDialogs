using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public class DialogChain(IEnumerable<IDialogNode> nodes) : IDialogChain
{
    public DialogState GetNextState(DialogState currentState)
    {
        var node = nodes.FirstOrDefault(n => n.NodeName == currentState.CurrentState);
        if (node != null)
        {
            return node.GetNextState(currentState);
        }
        
        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}