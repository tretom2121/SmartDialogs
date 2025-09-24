using SmartDialogs.API.Models;

namespace SmartDialogs.API.Dialogs;

public class SelectGoalNode : IDialogNode
{
    public string NodeName => "SelectGoal";

    public DialogState GetNextState(DialogState currentState)
    {
        var goal = currentState.Parameters["goal"].ToString();
        return goal == "MinimizeCosts" ? new DialogState { CurrentState = "CostParameters", Parameters = currentState.Parameters } : new DialogState { CurrentState = "OtherParameters", Parameters = currentState.Parameters };
    }
}