using Microsoft.ML;
using SmartDialogs.API.Models;

namespace SmartDialogs.API.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly MLContext _mlContext;
        // private readonly ITransformer _model; // the trained model would go here

        public RecommendationService()
        {
            _mlContext = new MLContext();
            // Load the trained model
            // _model = _mlContext.Model.Load("path/to/your/model.zip", out _);
        }

        public List<Parameter> GetRecommendations(Dictionary<string, object> currentParameters)
        {
            // use the trained model here

            return new List<Parameter>
            {
                new Parameter { Name = "NumberOfVehicles", Value = 10, DataType = "int" },
                new Parameter { Name = "MaxRouteDuration", Value = 120, DataType = "int" }
            };
        }
    }
}