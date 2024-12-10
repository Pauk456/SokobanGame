using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal static class LevelBuilder
    {
        public static MapData buildLevel(int level)
        {
            return buildLevel1();
        }

        private static void buildBorder(MapData mapData)
        {
            for (int x = 0; x < mapData.Map.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.Map.GetLength(1); y++)
                {
                    if (x == 0 || y == 0)
                    {
                        mapData.Map[x, y] = new Wall();
                    }
                    else
                    {
                        mapData.Map[x, y] = new EmptySpace();
                    }
                }
            }
        }

        private static MapData buildLevel1()
        {
            MapData mapData = new MapData(6, 6);

            buildBorder(mapData);
            
            mapData.Map[2, 2] = new Storekeeper();
            mapData.Map[3, 3] = new Box();
            mapData.Map[4, 5] = new PlaceForBox();
    
            return mapData;
        }
    }
}
