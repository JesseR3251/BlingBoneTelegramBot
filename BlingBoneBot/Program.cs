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
        private List<String> 

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
            {
                String userText = e.Message.Text.ToString().ToLower();
                if (userText.Contains("hey") == true)
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "What the fuck do yo' want? ヾ(●ω●)ノ ");
                Task.Delay(3000);
                    Bot.SendStickerAsync(e.Message.Chat.Id, "CAADAgADggAD0lqIAcrj5QvkZIUPAg"); // Gun Pepe
                
                //CAADAgADSioAAktqAwABYJfJOAN1P1MC

            }

            //if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Sticker)
            //{
            //    Bot.GetChatAsync(e.Message.Chat.Id);
            //    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Sticker Received");

            //}

          //  Bot.SendStickerAsync(e.Message.Chat.Id, "CAADAgADSioAAktqAwABYJfJOAN1P1MC"); Nasty Pepe
        }



    }
}
