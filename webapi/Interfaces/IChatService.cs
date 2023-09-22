namespace webapi.Interfaces
{
    public interface IChatService
    {
        Task<string> ProcessUserMessageAsync(string userMessage);
        Task<string> GetChatbotResponseAsync();
    }
}
