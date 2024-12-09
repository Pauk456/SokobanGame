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

        private static MapData buildLevel1()
        {
            MapData mapData = new MapData(6, 6);

            mapData.Storekeeper = new Storekeeper(1, 1);

            mapData.Boxes.Add(new Box(2, 2));
            mapData.PlaceForBoxes.Add(new PlaceForBox(4, 4));

            mapData.Walls.Add(new Wall(0, 0));
            mapData.Walls.Add(new Wall(1, 0));
            mapData.Walls.Add(new Wall(2, 0));
            mapData.Walls.Add(new Wall(3, 0));
            mapData.Walls.Add(new Wall(4, 0));
            mapData.Walls.Add(new Wall(5, 0));

            mapData.Walls.Add(new Wall(0, 1));
            mapData.Walls.Add(new Wall(0, 2));
            mapData.Walls.Add(new Wall(0, 3));
            mapData.Walls.Add(new Wall(0, 4));
            mapData.Walls.Add(new Wall(0, 5));

            mapData.Walls.Add(new Wall(5, 1));
            mapData.Walls.Add(new Wall(5, 2));
            mapData.Walls.Add(new Wall(5, 3));
            mapData.Walls.Add(new Wall(5, 4));
            mapData.Walls.Add(new Wall(5, 5));

            mapData.Walls.Add(new Wall(1, 5));
            mapData.Walls.Add(new Wall(2, 5));
            mapData.Walls.Add(new Wall(3, 5));
            mapData.Walls.Add(new Wall(4, 5));

            addEmptySpace(mapData);

            return mapData;
        }

        private static void addEmptySpace(MapData mapData)
        {
            Storekeeper storekeeper = mapData.Storekeeper;

            for (int x = 0; x < mapData.SizeX; x++)
                for (int y = 0; y < mapData.SizeY; y++)
                    foreach (Wall wall in mapData.Walls)
                        foreach (Box box in mapData.Boxes)
                            foreach (PlaceForBox placeForBox in mapData.PlaceForBoxes)
                            {
                                Position position = new Position(x, y);
                                if (  !(position == placeForBox.Pos || 
                                        position == box.Pos ||
                                        position == wall.Pos ||
                                        position == storekeeper.Pos))
                                {
                                    mapData.EmptySpaces.Add(new EmptySpace(x, y));
                                }
                            }
        }
    }
}
