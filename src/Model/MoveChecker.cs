using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal class MoveChecker
    {
        private MapData mapData;
        public MoveChecker(MapData mapData) 
        {
            this.mapData = mapData;
        }

        public bool isThisMoveCorrect(Position position)
        {
            foreach (Wall wall in mapData.Walls)
            {
                if(position == wall.Pos)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
