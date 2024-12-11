using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public class Storekeeper : MoveableObject
    {
        public Storekeeper(int x, int y) : base(x, y) { }

        private static int priorityToDraw = 1;
        public override int getPriority()
        {
            return priorityToDraw;
        }
    }
}
