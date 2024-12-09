using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.GameObjects
{
    internal abstract class GameObject
    {
        public GameObject(int x, int y)
        {
            Pos = new Position(x, y);
        }
        public Position Pos { get; set; } 
    }
}
