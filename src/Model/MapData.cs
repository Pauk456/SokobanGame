using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SokobanGame.src.GameObjects;

namespace SokobanGame.src.Model
{
    // Сделать так чтобы лист который мы возвращаем нельзя было изменять и добавление было только через MapData
    internal class MapData
    {
        public MapData(int sizeX, int sizeY) 
        {
            SizeX = sizeX;
            SizeY = sizeY;

            Walls = new List<Wall>();
            Boxes = new List<Box>();
            PlaceForBoxes = new List<PlaceForBox>();
            EmptySpaces = new List<EmptySpace>();
        }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public Storekeeper Storekeeper { get; set; }
        public List<Wall> Walls { get; set; }
        public List<Box> Boxes { get; set; }
        public List<PlaceForBox> PlaceForBoxes { get; set; }
        public List<EmptySpace> EmptySpaces { get; set; }
        public List<GameObject> Map
        {
            get
            {
                List<GameObject> list = new List<GameObject>();
                list.AddRange(EmptySpaces);
                list.AddRange(PlaceForBoxes);
                list.AddRange(Boxes);
                list.AddRange(Walls);
                list.Add(Storekeeper);
                return list;
            }
            private set { }
        }
    }
}
