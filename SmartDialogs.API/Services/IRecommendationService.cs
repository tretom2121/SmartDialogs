using SmartDialogs.API.Models;

namespace SmartDialogs.API.Services;

public interface IRecommendationService
{
    List<Parameter> GetRecommendations(Dictionary<string, object> currentParameters);
}