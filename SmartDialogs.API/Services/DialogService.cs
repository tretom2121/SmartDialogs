using SmartDialogs.API.Models;

namespace SmartDialogs.API.Services
{
    public class DialogService : IDialogService
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
            switch (currentState.CurrentState)
            {
                case "Welcome":
                    return new DialogState { CurrentState = "SelectGoal", Parameters = currentState.Parameters };
                case "SelectGoal":
                    var goal = currentState.Parameters["goal"].ToString();
                    if (goal == "MinimizeCosts")
                    {
                        return new DialogState { CurrentState = "CostParameters", Parameters = currentState.Parameters };
                    }
                    else
                    {
                        return new DialogState { CurrentState = "OtherParameters", Parameters = currentState.Parameters };
                    }
                default:
                    return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
            }
        }
    }
}