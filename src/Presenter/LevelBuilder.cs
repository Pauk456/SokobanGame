using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Presenter
{
    internal static class LevelBuilder
    {
        public static MapData buildLevel(int level)
        {
            return buildLevel2();
        }

        private static void buildBorder(MapData mapData)
        {
            for (int x = 0; x < mapData.Map.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.Map.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x == (mapData.SizeX - 1) || y == (mapData.SizeY - 1))
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
            mapData.Map[3, 2] = new PlaceForBox();

            return mapData;
        }

        private static MapData buildLevel2()
        {
            MapData mapData = new MapData(40, 40);

            buildBorder(mapData);

            mapData.Map[5, 5] = new Storekeeper();

            mapData.Map[10, 10] = new Box();
            mapData.Map[12, 10] = new Box();
            mapData.Map[15, 15] = new Box();

            mapData.Map[8, 8] = new PlaceForBox();
            mapData.Map[14, 14] = new PlaceForBox();
            mapData.Map[17, 17] = new PlaceForBox();

            for (int x = 20; x < 30; x++)
            {
                mapData.Map[x, 20] = new Wall();
            }

            for (int y = 25; y < 35; y++)
            {
                mapData.Map[25, y] = new Wall();
            }

            return mapData;
        }
    }
}
