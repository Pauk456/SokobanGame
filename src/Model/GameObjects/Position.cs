using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x; Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(Object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Position other = (Position)obj;
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
