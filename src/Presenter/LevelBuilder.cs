using System;
using System.IO;
using SokobanGame.src.Model;
using SokobanGame.src.Model.GameObjects;

namespace SokobanGame.src.Presenter
{
    internal static class LevelBuilder
    {
        public static MapData buildLevel(int level)
        {
            return buildLevelFromFile("../../../Content/Levels/level" + level + ".txt");
        }

        private static void buildBorder(MapData mapData)
        {
            for (int x = 0; x < mapData.SizeX; x++)
            {
                for (int y = 0; y < mapData.SizeY; y++)
                {
                    if (x == 0 || y == 0 || x == (mapData.SizeX - 1) || y == (mapData.SizeY - 1))
                    {
                        mapData.addObj(x, y, new Wall(x, y));
                    }
                    else
                    {
                        mapData.addObj(x, y, new EmptySpace(x, y));
                    }
                }
            }
        }
        private static MapData buildTestLevel()
        {
            var mapData = new MapData(6, 6);

            buildBorder(mapData);

            mapData.addObj(2, 2, new Storekeeper(2, 2));
            mapData.addObj(3, 3, new Box(3, 3));
            mapData.addObj(3, 2, new PlaceForBox(3, 2));

            return mapData;
        }

        private static MapData buildLevelFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            int sizeX = lines[0].Length;
            int sizeY = lines.Length;

            var mapData = new MapData(sizeX, sizeY);

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    char tile = lines[y][x];
                    switch (tile)
                    {
                        case '1':
                            mapData.addObj(x, y, new Storekeeper(x, y));
                            break;
                        case '2':
                            mapData.addObj(x, y, new Box(x, y));
                            break;
                        case '3':
                            mapData.addObj(x, y, new PlaceForBox(x, y));
                            break;
                        case '4':
                            mapData.addObj(x, y, new EmptySpace(x, y));
                            break;
                        case '5':
                            mapData.addObj(x, y, new Wall(x, y));
                            break;
                        default:
                            throw new Exception("Error in reading map file");
                    }
                }
            }

            return mapData;
        }
    }
}
