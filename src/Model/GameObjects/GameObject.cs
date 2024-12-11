using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public abstract class GameObject
    {
        public abstract int getPriority();
        public GameObject(int x, int y)
        {
            Position = new Position(x, y);
        }
        public Position Position { get; set; }
    }
}
