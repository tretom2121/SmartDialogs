using System.Text.Json;
using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Models;

namespace SmartDialogs.Implementations.VehicleScheduling.Nodes
{
    public class OtherParametersNode : IDialogNode
    {
        public string NodeName => "OtherParameters";

        public DialogState GetNextState(DialogState currentState)
        {
            var likeCount = 0;
            if (currentState.Parameters.TryGetValue("likeCount", out var likeCountValue))
            {
                if (likeCountValue is JsonElement likeCountElement)
                {
                    try
                    {
                        likeCount = likeCountElement.GetInt32();
                    }
                    catch (FormatException) { throw new ArgumentException("'likeCount' is not a valid number."); }
                }
            }

            var vehicleCount = 0;
            if (currentState.Parameters.TryGetValue("vehicleCount", out var vehicleCountValue))
            {
                if (vehicleCountValue is JsonElement vehicleCountElement)
                {
                    try
                    {
                        vehicleCount = vehicleCountElement.GetInt32();
                    }
                    catch (FormatException) { throw new ArgumentException("'vehicleCount' is not a valid number."); }
                }
            }

            if (likeCount < 3 || vehicleCount > 10)
            {
                return new DialogState { CurrentState = "CostParameters", Parameters = currentState.Parameters };
            }

            return new DialogState { CurrentState = "Finished", Parameters = currentState.Parameters };
        }
    }
}