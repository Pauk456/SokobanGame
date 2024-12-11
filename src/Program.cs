using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SokobanGame;
using SokobanGame.src.Presenter;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new Presenter();
            presenter.startGame();
        }
    }
}