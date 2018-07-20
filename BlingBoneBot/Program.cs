using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BlingBoneBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("687326924:AAHizZUCtchrimaqyjCew5CU2UmS1A-NmXw");

        static void Main(string[] args)
        {

            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                if (e.Message.Text == "Hey");
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "Fuck off bitch ヾ(●ω●)ノ ");
        }

        

    }
}
