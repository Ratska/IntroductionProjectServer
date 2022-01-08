using System;

namespace IntroductionProjectServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IntroductionProjectServer";

            Server.Start(5, 25565);
            Console.ReadKey();
        }
    }
}
