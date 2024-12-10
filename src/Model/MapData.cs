using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using SokobanGame.src.GameObjects;

namespace SokobanGame.src.Model
{
    public class MapData
    {
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public GameObject[,] Map {  get; private set; }
        public MapData(int sizeX, int sizeY) 
        {
            SizeX = sizeX;
            SizeY = sizeY;

            Map = new GameObject[SizeX, SizeY];
        }

        public List<Box> Boxes
        {
            get
            {
                var boxes = new List<Box>();

                foreach (var obj in Map)
                {
                    if (obj is Box)
                    {
                        boxes.Add((Box)obj);
                    }
                }

                return boxes;
            }
            private set { }
        }

        public Storekeeper Storekeeper
        {
            get
            {
                foreach (var obj in Map)
                {
                    if (obj is Storekeeper)
                    {
                        return (Storekeeper)obj;
                    }
                }

                throw new Exception("storekeeper lost");
            }
            private set { }
        }

        public Position findStorekeeperPos()
        {
            for(int x = 0; x < Map.GetLength(0); x++)
            {
                for(int y = 0; y < Map.GetLength(1); y++)
                {
                    var obj = Map[x, y];
                    if (obj is Storekeeper)
                    {
                        return new Position(x, y);
                    }
                }
            }

            throw new Exception("storekeeper lost");
        }
    }
}
