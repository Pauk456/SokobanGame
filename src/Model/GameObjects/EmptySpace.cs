using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public class EmptySpace : GameObject
    {
        public EmptySpace(int x, int y) : base(x, y) { }

        private static int priorityToDraw = 100;
        public override int getPriority()
        {
            return priorityToDraw;
        }
    }
}
