using System.Text.Json;
using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes;

public class OtherParametersNode : IDialogNode
{
    public string NodeName => "OtherParameters";

    public DialogState GetNextState(DialogState currentState)
    {
        if (currentState.Parameters.TryGetValue("likeCount", out var likeCountValue))
        {
            if (likeCountValue is JsonElement jsonElement)
            {
                try
                {
                    var likeCount = jsonElement.GetInt32();

                    if (likeCount < 3)
                    {
                        return new DialogState { CurrentState = "CostParameters", Parameters = currentState.Parameters };
                    }
                }
                catch (FormatException) { throw new ArgumentException("'likeCount' is not a valid number."); }
            }
        }

        return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
    }
}