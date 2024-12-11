using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public abstract class MoveableObject : GameObject
    {
        public MoveableObject(int x, int y) : base(x, y) { }
        public Position tryMove(Command command)
        {
            switch (command)
            {
                case Command.Left: return new Position(Position.X - 1, Position.Y);
                case Command.Right: return new Position(Position.X + 1, Position.Y);
                case Command.Top: return new Position(Position.X, Position.Y - 1);
                case Command.Bottom: return new Position(Position.X, Position.Y + 1);

                default: throw new ArgumentException("Not supported command");
            }
        }

        public void move(Position pos)
        {
            Position = pos;
        }
    }
}
