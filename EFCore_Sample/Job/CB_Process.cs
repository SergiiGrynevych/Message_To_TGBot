using EFCore_Sample.EntityModels.Phrase;
using EFCore_Sample.Models;
using Quartz;
using Telegram.Bot;

namespace EFCore_Sample.Job
{
    [DisallowConcurrentExecution]
    public class CB_Process : IJob
    {
        AppDBContext _context { get; set; }
        ITelegramBotClient _bot { get; set; }
        public CB_Process(AppDBContext context
            , ITelegramBotClient bot) 
        { 
            this._context = context;
            this._bot = bot;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                int id;
                PhraseEntity phraseEntity = new PhraseEntity(_context);
                var phrases = phraseEntity.GetData();
                int maxId = phrases.Select(e => e.id).Max(); 

                Random random = new Random();
                id = random.Next(maxId);

                var t = await _bot.SendTextMessageAsync(ConfigurationApp.BotId, phrases[id].text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
