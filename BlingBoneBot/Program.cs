using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Diagnostics;
using System.Timers;


namespace BlingBoneBot
{
    class Program
    {
        private static string accessToken = "";
        private static readonly TelegramBotClient botClient = new TelegramBotClient(accessToken);
        
        private static string blingyDingyGroupID = "";
        private static int bedTimeHour = 23;

        // Random Frog List
        static List<string> uglyFrogStickers = new List<string>();
        static Random rnd = new Random();
        static int randomFrog = rnd.Next(uglyFrogStickers.Count);

        static void Main(string[] args)
        {
            // Getting all ugly frogs and putting them into a list to randomly select
            uglyFrogStickers.Add("CAADBAADZj0AAnrRWwamey84lXdwzwI");
            uglyFrogStickers.Add("CAADBAADEQ4AAnrRWwZZyqx4aM84TwI");
            uglyFrogStickers.Add("CAADBAAD9Q0AAnrRWwaim8djGnYxPAI");
            uglyFrogStickers.Add("CAADBAAD6hMAAnrRWwbaJnXW0KcRqQI");
            uglyFrogStickers.Add("CAADBAADEhQAAnrRWwbRfw3ebmOXRgI");
            uglyFrogStickers.Add("CAADBAADCw4AAnrRWwZKTo8Om5qu5AI");
            uglyFrogStickers.Add("CAADBAADgw4AAnrRWwaCxy8EtZSqTwI");
            uglyFrogStickers.Add("CAADBAADXAUAAlMDUREwv143fGWkmQI");


            BedTimeSchedule();
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Thread.Sleep(999000);


        }

        private static void BedTimeSchedule()
        {

            var runAt = DateTime.Today + TimeSpan.FromHours(bedTimeHour);

            if (runAt <= DateTime.Now)
            {
                SendGoodNight();
            }
            else
            {
                var delay = runAt - DateTime.Now;
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(_ => SendGoodNight());
            }

        }

        private static void SendGoodNight()
        {
            botClient.SendTextMessageAsync(
            chatId: blingyDingyGroupID,
            text: "GO TO SLEEP!!~~ (づ｡◕‿‿◕｡)づ ");

            botClient.SendAnimationAsync(
                chatId: blingyDingyGroupID,
                animation: "https://i.imgur.com/q3e87zR.gif"
                ); // Cat & Shaq GIF

            botClient.SendStickerAsync(
            chatId: blingyDingyGroupID,
            sticker: "CAADBAADYggAAsHKsAO-vakd5YxL3wI"); // Snoopy Sleeping

        }



        static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                String userText = e.Message.Text.ToString().ToLower();
                if (userText.Contains("ugly frog") == true)
                {
                    await botClient.SendStickerAsync(
                      chatId: e.Message.Chat,
                      sticker: uglyFrogStickers[randomFrog]); // Random frog
                }
            }

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                String userText = e.Message.Text.ToString().ToLower();
                if (userText.Contains("good night") == true)
                {
                    await botClient.SendStickerAsync(
                      chatId: e.Message.Chat,
                      sticker: "CAADBAADYggAAsHKsAO-vakd5YxL3wI"); // Snoopy Sleeping
                }
            }
        }
    }
}

    






