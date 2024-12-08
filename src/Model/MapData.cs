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
        public Storekeeper Storekeeper { get; set; }
        public List<Wall> Walls { get; set; }
        public List<Box> Boxes { get; set; }
        public List<PlaceForBox> PlaceForBoxes { get; set; }
        public List<EmptySpace> EmptySpaces { get; set; }
        public List<IGameObject> Map
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.Map = value;
            }
        }
    }
}
