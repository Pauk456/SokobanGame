using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.GameObjects
{
    internal class Box : MovableGameObjects
    {
        public Box(int x, int y) : base(x, y) { }
        public bool OnPlaceForBox { get; set; }
        public Position Pos { get; set; }
    }
}
