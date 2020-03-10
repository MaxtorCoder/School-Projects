using System;
using System.Collections.Generic;
using System.Text;

namespace EmoKonijn
{
    public class Konijn
    {
        private string Gezicht { get; set; }

        public Konijn(string gezicht)
        {
            Gezicht += " ()_()\n";
            switch (gezicht)
            {
                case "verbaasd":
                    Gezicht += " (?.?)";
                    break;
                case "dood":
                    Gezicht += " (x.x)";
                    break;
                case "annoyed":
                    Gezicht += " (>.<)";
                    break;
                case "blij":
                    Gezicht += " (^.^)";
                    break;
            }
            Gezicht += "\n'(\")(\")'\n";
        }

        public string GetKonijn() => Gezicht;
    }
}
