using pr9.Classes;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace pr9
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        readonly string Token = "";
        TelegramBotClient TelegramBotClient;
        List<Users> Users = new List<Users>();
        Timer Timer;
        List<string> Messages = new List<string>()
        {
            "Здравствуйте!" +
            "\nРады приветсвовать вас в Телеграм-боте Напоминатор" +
            "\nНаш бот создан для того, чтобы напоминать вам о важных событиях и мероприятиях. С ним вы точно не пропустите ничего важного!" +
            "\nНе забудьте добавить бота в список своих контактов и настроить уведомления. Тогда вы всегда будете в курсе событий!",

            "Укажите дату и время напоминания в следующем формате:" +
            "\n<i><b>12:51 26.04.2025</b>" +
            "\nНапомни о том что я хотел сходить в магазин.</i>",

            "Кажется, что то не получилось." +
            "Укажите дату и время напоминания в следующем формате:" +
            "\n<i><b>12:51 26.04.2025</b>" +
            "\nНапомни о том что я хотел сходить в магазин.</i>",

            "",
            "Задачи пользователя не найдены.",
            "Событие удалено.",
            "Все события удалены."
        };

        public bool CheckFormatDateTime(string value, out DateTime time)
        {
            return DateTime.TryParse(value, out time);
        }
        private static ReplyKeyboardMarkup GetButtons()
        {
            List<KeyboardButton> keyboardButtons = new List<KeyboardButton>();
            keyboardButtons.Add(new KeyboardButton("Удалить все задачи"));

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    keyboardButtons 
                }
            };
        }
        public static InlineKeyboardMarkup DeleteEvent(string Message)
        {
            List<InlineKeyboardButton> inlineKeyboards = new List<InlineKeyboardButton>();
            inlineKeyboards.Add(new InlineKeyboardButton("Удалить", Message));
            return new InlineKeyboardMarkup(inlineKeyboards);
        }
    } 
}
