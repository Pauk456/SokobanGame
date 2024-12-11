using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SokobanGame.src.Model.GameObjects;

namespace SokobanGame.src.Model
{
    public class MapData
    {
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        private List<PlaceForBox> placeForBoxes;
        public List<PlaceForBox> PlaceForBoxes
        { 
            get
            {
                if(placeForBoxes == null)
                {
                    initPlaceForBoxes();
                }
                return placeForBoxes;
            }

            private set 
            {
                placeForBoxes = value;
            } 
        }

        private PriorityQueue<GameObject, int>[,] Map;

        public MapData(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            Map = new PriorityQueue<GameObject, int>[sizeX, sizeY];
        }

        private List<PlaceForBox> initPlaceForBoxes()
        {
            placeForBoxes = new List<PlaceForBox>();
            foreach (var priorityQueue in Map)
            {
                foreach (var obj in priorityQueue.UnorderedItems)
                {
                    if (obj.Element is PlaceForBox)
                    {
                        placeForBoxes.Add((PlaceForBox)obj.Element);
                    }
                }
            }
            return placeForBoxes;
        }
        public List<Box> Boxes
        {
            get
            {
                var boxes = new List<Box>();

                foreach (var priorityQueue in Map)
                {
                    foreach (var obj in priorityQueue.UnorderedItems)
                    {
                        if (obj.Element is Box)
                        {
                            boxes.Add((Box)obj.Element);
                        }
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
                foreach (var priorityQueue in Map)
                {
                    foreach (var obj in priorityQueue.UnorderedItems)
                    {
                        if (obj.Element is Storekeeper)
                        {
                            return (Storekeeper)obj.Element;
                        }
                    }
                }

                throw new Exception("storekeeper lost");
            }
            private set { }
        }
        public GameObject peekObj(int x, int y)
        {
            if(Map[x, y].Count == 0)
            {
                var emptySpace = new EmptySpace(x, y);
                Map[x, y].Enqueue(emptySpace, emptySpace.getPriority());
            }
            return Map[x, y].Peek();
        }
        public GameObject peekObj(Position pos)
        {
            return peekObj(pos.X, pos.Y);
        }
        public void addObj(int x, int y, GameObject gameObject)
        {
            if(Map[x, y] == null)
            {
                Map[x, y] = new PriorityQueue<GameObject, int>();
            }

            Map[x, y].Enqueue(gameObject, gameObject.getPriority());
        }
        public void addObj(Position pos, GameObject gameObject)
        {
            addObj(pos.X, pos.Y, gameObject);
        }

        public void rmObj(Position pos)
        {
            Map[pos.X, pos.Y].Dequeue();
        }
    }
}
