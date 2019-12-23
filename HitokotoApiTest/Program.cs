using System;
using HitokotoApi;

namespace HitokotoApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool canExit = false;

            while (!canExit)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    var hitokoto = HitokotoUtils.GetHitokoto();

                    Console.WriteLine(hitokoto.Result.Content);
                }
                else if (key == ConsoleKey.Escape)
                {
                    canExit = true;
                    break;
                }
            }
        }
    }
}
