using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_4.Builder;
using static Lab_4.Singleton;
using static Lab_4.Bridge;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton (Одинак)
            Console.WriteLine("Singleton(Одинак)");
            Logger logger = Logger.Instance;
            logger.AddLog("Log entry 1");
            logger.AddLog("Log entry 2");
            var log = logger.GetLog();
            Console.WriteLine("Log Entries:");
            foreach (var entry in log)
            {
                Console.WriteLine(entry);
            }

            // Singleton (Одинак) для налаштувань
            Console.WriteLine("Налаштування:");
            Settings settings = Settings.Instance;
            settings.SetSetting("Window Size", "1024x768");
            settings.SetSetting("Language", "English");
            var windowSize = settings.GetSetting("Window Size");
            var language = settings.GetSetting("Language");
            Console.WriteLine($"Window Size: {windowSize}, Language: {language}");

            // Builder (Будівник) для створення персонажа
            Console.WriteLine("\nBuilder (Будiвник)");
            CharacterBuilder characterBuilder = new CharacterBuilder("Warrior");
            var warrior = characterBuilder.SetStrength(10).SetAgility(5).SetIntelligence(3).Build();
            Console.WriteLine("Character: " + warrior.Name);
            Console.WriteLine("Strength: " + warrior.Strength);
            Console.WriteLine("Agility: " + warrior.Agility);
            Console.WriteLine("Intelligence: " + warrior.Intelligence);

            // Builder (Будівник) для генерації SQL-запитів
            SQLQueryBuilder sqlBuilder = new SQLQueryBuilder("Products");
            var query = sqlBuilder.Where("Category = 'Electronics'").OrderBy("Price").Build();
            Console.WriteLine("SQL Query: " + query);

            // Bridge (Міст) для виведення повідомлень
            Console.WriteLine("\nBridge (Мiст)");
            IMessageFormatter textFormatter = new TextMessageFormatter();
            IMessageSender emailSender = new EmailMessageSender();
            MessageService emailMessageService = new MessageService(textFormatter, emailSender);
            emailMessageService.Send("Hello, this is an email message.");

            IMessageFormatter htmlFormatter = new HtmlMessageFormatter();
            IMessageSender smsSender = new SmsMessageSender();
            MessageService smsMessageService = new MessageService(htmlFormatter, smsSender);
            smsMessageService.Send("Hello, this is an SMS message.");

            // Bridge (Міст) для керування пристроями
            IDevice tv = new TV();
            RemoteControl tvRemoteControl = new TVRemoteControl(tv);
            tvRemoteControl.TurnOn();
            tvRemoteControl.TurnOff();

            Console.ReadKey();
        }
    }
}
