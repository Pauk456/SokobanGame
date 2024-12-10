using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal class WinLogic
    {
        private MapData mapData;
        public WinLogic(MapData mapData)
        {
            this.mapData = mapData;
        }

        public bool isWin()
        {
            foreach (Box box in mapData.Boxes)
            {
                if (box.OnPlaceForBox == false)
                    return false;
            }

            return true;
        }
    }
}
