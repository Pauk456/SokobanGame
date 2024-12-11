using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SokobanGame.src.Model;

namespace SokobanGame.src.Model.GameObjects
{
    public class Box : MoveableObject
    {
        public Box(int x, int y) : base(x, y)
        {
            OnPlaceForBox = false;
        }
        public bool OnPlaceForBox { get; private set; }

        public void updateStatus(MapData mapData)
        {
            OnPlaceForBox = false;

            foreach (PlaceForBox placeForBoxPos in mapData.PlaceForBoxes)
            {
                if (placeForBoxPos.Position.Equals(Position))
                {
                    OnPlaceForBox = true;
                    break;
                }
            }
        }

        private static int priorityToDraw = 3;
        public override int getPriority()
        {
            return priorityToDraw;
        }
    }
}
