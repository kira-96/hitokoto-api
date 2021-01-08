using System;

namespace Hitokoto.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    var hitokoto = HitokotoHelper.GetHitokoto();

                    Console.WriteLine(hitokoto.Result.Content);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
