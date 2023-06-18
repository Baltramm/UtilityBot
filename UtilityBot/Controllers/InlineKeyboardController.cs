using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UtilityBot.Services;

namespace UtilityBot.Controllers
{
    public class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
            
        }


        public async Task Handle(CallbackQuery? callbackQuery, Message message, CancellationToken ct)
        {
            _memoryStorage.GetSession(callbackQuery.From.Id).CodeBehavior = callbackQuery.Data;
            switch (callbackQuery.Data)
            {
                case "count":
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"Отправьте текст для подстчета количества символов", cancellationToken: ct, parseMode: ParseMode.Html);
                    break;
                case "sum":
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"Отправьте текст для подсчета суммы чисел в нем", cancellationToken: ct, parseMode: ParseMode.Html);
                    break;
                default:
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"Выберите нужную функцию бота", cancellationToken: ct, parseMode: ParseMode.Html);
                    break;
            }
        }
    }
}
