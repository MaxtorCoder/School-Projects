using System;
using System.Collections.Generic;

namespace EmoKonijn
{
    class Program
    {
        static Dictionary<uint, Konijn> Konijntjes = new Dictionary<uint, Konijn>()
        {
            [1] = new Konijn("blij"),
            [2] = new Konijn("verbaasd"),
            [3] = new Konijn("dood"),
            [4] = new Konijn("annoyed"),
        };

        static void Main(string[] args)
        {
            Start();
            while (true)
            {
                Console.Write("Wilt u overniew? (Ja, Nee): ");
                var keuze = Console.ReadLine().ToLower();
                if (keuze == "ja")
                    Start();
                else
                    Exit();
            }
        }

        static void Start()
        {
            foreach (var konijn in Konijntjes)
                Console.WriteLine($"{konijn.Key}:\n{konijn.Value.GetKonijn()}");

            Console.Write("Welk konijn wilt u hebben? (1, 2, 3, 4): ");
            var keuze = uint.Parse(Console.ReadLine());

            Console.WriteLine(Konijntjes[keuze].GetKonijn());
        }

        static void Exit() => Environment.Exit(0);
    }
}
