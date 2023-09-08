using EFCore_Sample.EntityModels.Phrase;
using EFCore_Sample.Helpers;
using EFCore_Sample.Models;
using Quartz;
using Telegram.Bot;
using Telegram.Bot.Polling;

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
          //      foreach(var phrase in phrases)
          //      {
          //          Console.WriteLine($"id: {phrase.id}, text: {phrase.text}");
          //      }
                int maxId = phrases.Select(e => e.id).Max(); 

                Random random = new Random();
                id = random.Next(maxId);

                var t = await _bot.SendTextMessageAsync(ConfigurationApp.BotId, phrases[id].text); //  "@channelname or chat_id", "text message");

        //        await Task.Delay(10000);

        //        var cts = new CancellationTokenSource();
        //        var cancellationToken = cts.Token;
        //        var receiverOptions = new ReceiverOptions
        //        {
        //            AllowedUpdates = { },
        //        };
                /*
                _bot.StartReceiving(
                    TGBotHelper.HandleUpdateAsync,
                    TGBotHelper.HandleErrorAsync,
                    receiverOptions,
                    cancellationToken
                );
                */
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /*
         * to get Employees
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                EmployeeEntity employeeEntity = new EmployeeEntity(_context);
                var employees = employeeEntity.GetData();
                foreach(var emp in  employees)
                {
                    Console.WriteLine($"id: {emp.id}, name: {emp.firstName}, second name: {emp.secondName}");
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        */
    }
}
