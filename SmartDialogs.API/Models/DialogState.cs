namespace SmartDialogs.API.Models
{
    public class DialogState
    {
        public string CurrentState { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}