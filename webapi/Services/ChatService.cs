using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class ChatService : IChatService
    {
        private readonly DataContext _context;
        private readonly ChatbotService _chatbotService; // Add a reference to ChatbotService
        private string botResponse;

        public ChatService(DataContext context, ChatbotService chatbotService)
        {
            _context = context;
            _chatbotService = chatbotService; // Inject ChatbotService
        }

        public async Task<string> ProcessUserMessageAsync(string userMessage)
        {
            // Save the user's message to the database
            var userMessageEntity = new Chat { DateTime = DateTime.Now, Text = userMessage };
            _context.Chats.Add(userMessageEntity);
            await _context.SaveChangesAsync();

            // Get the chatbot's response using the injected ChatbotService
            botResponse = await _chatbotService.ProcessUserMessageAsync(userMessage);

            // Save the chatbot's response to the database
            var chatbotMessageEntity = new Chat { DateTime = DateTime.Now, Text = botResponse };
            _context.Chats.Add(chatbotMessageEntity);
            await _context.SaveChangesAsync();

            return botResponse;
        }

        public async Task<string> GetChatbotResponseAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(botResponse))
                {
                    return "Chatbot's response not found.";
                }

                return botResponse;
            }
            catch (Exception ex)
            {
                return $"An 500 error occurred: {ex.Message}";
            }
        }


    }
}