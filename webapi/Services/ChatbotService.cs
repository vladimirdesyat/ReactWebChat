using LLama.Common;
using LLama;
using webapi.Interfaces;

namespace webapi.Services
{
    public class ChatbotService : IChatService
    {
        private readonly string modelPath;
        private string botResponse;
        private readonly StatelessExecutor ex;
        private readonly InferenceParams inferenceParams;
        public ChatbotService()
        {
            modelPath = Path.Combine(AppContext.BaseDirectory, "llama-2-7b-guanaco-qlora.ggmlv3.q5_0.bin");
            ex = new StatelessExecutor(new LLamaModel(new ModelParams(modelPath, contextSize: 256, gpuLayerCount: 15)));
            inferenceParams = new InferenceParams() { Temperature = 0.6f, AntiPrompts = new List<string> { }, MaxTokens = 50 };
        }
        public async Task<string> ProcessUserMessageAsync(string userMessage)
        {
            try
            {
                botResponse = string.Join("", ex.Infer(userMessage, inferenceParams));
                return botResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while processing the user message: {ex.Message}", ex);
            }
        }

        public async Task<string> GetChatbotResponseAsync()
        {

            return await Task.FromResult(string.Empty);
        }
    }
}
