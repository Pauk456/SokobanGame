using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SokobanGame;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var game = new SokobanGame.Game1();
            game.Run();
        }
    }
}