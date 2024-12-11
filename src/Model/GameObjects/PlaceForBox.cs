using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model.GameObjects
{
    public class PlaceForBox : GameObject
    {
        public PlaceForBox(int x, int y) : base(x, y) { }

        private static int priorityToDraw = 4;
        public override int getPriority() 
        {
            return priorityToDraw;
        }
    }
}
