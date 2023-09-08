using EFCore_Sample.Models;
using Telegram.Bot.Types;
using Telegram.Bot;
using Quartz;

namespace EFCore_Sample.Helpers
{
    [DisallowConcurrentExecution]
    public static class TGBotHelper
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                var answer = "answer"; //OpenAI.callOpenAI(botClient, tokens, question, engine, temperature, topP, frequencyPenalty, presencePenalty).Normalize();

                if (!string.IsNullOrEmpty(answer))
                {
                    var chatId = update.Message.Chat.Id;
                    await botClient.SendTextMessageAsync(chatId, answer);
                }
            }
            catch (Exception e)
            {
                botClient.SendTextMessageAsync(ConfigurationApp.BotId, e.Message);
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
      //      await botClient.SendTextMessageAsync(ConfigurationApp.BotId, exception.Message);
        }
    }
}
