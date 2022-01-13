using System;
using System.Threading;


namespace IntroductionProjectServer
{
    class Program 
    {
        private static bool isRunning = false;
        static void Main(string[] args)
        {
            
            Console.Title = "IntroductionProjectServer";

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(5, 25565);
           
        }
        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TPS} ticks per second.");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning)
            {
                while(_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();
                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MSPT);

                    if(_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
