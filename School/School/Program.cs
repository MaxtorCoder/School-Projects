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
            var quaternion = new Quaternion(-1342313228738384923);
            Console.WriteLine(quaternion.ToString());

            // Start();
            // while (true)
            // {
            //     Console.Write("Wilt u overniew? (Ja, Nee): ");
            //     var keuze = Console.ReadLine().ToLower();
            //     if (keuze == "ja")
            //         Start();
            //     else
            //         Exit();
            // }
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

    public class Quaternion
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        const float multiplier = 0.00000095367432f;
        public Quaternion(long compressedQuaternion)
        {
            X = (compressedQuaternion >> 42) * 0.00000047683716f;
            Y = (compressedQuaternion << 22 >> 43) * multiplier;
            Z = (int)(compressedQuaternion << 43 >> 43) * multiplier;

            W = (X * X) + (Y * Y) + (Z * Z);

            if (Math.Abs(W - 1.0f) >= multiplier)
                W = (float)Math.Sqrt(1.0f - W);
            else
                W = 0;
        }

        public override string ToString() => $"{X} {Y} {Z} {W}";
    }
}
