using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.GameObjects
{
    internal abstract class MovableGameObjects : GameObject
    {
        public MovableGameObjects(int x, int y) : base(x, y) { }
        public Position Pos { get; set; }
        public Position move(Command command)
        {
            switch (command)
            {
                case Command.Left: return new Position(Pos.X - 1, Pos.Y);
                case Command.Right: return new Position(Pos.X + 1, Pos.Y);
                case Command.Top: return new Position(Pos.X, Pos.Y - 1);
                case Command.Bottom: return new Position(Pos.X, Pos.Y + 1);
                default: throw new ArgumentException("Not supported command");
            }
        }
    }
}
