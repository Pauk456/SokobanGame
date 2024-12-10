using SokobanGame.src.GameObjects;
using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal class MoveLogic
    {
        private MapData mapData;
        public MoveLogic(MapData mapData) 
        {
            this.mapData = mapData;
        }

        private Position nextPosition(Position position, Command command)
        {
            switch (command)
            {
                case Command.Left: return new Position(position.X - 1, position.Y);
                case Command.Right: return new Position(position.X + 1, position.Y);
                case Command.Top: return new Position(position.X, position.Y - 1);
                case Command.Bottom: return new Position(position.X, position.Y + 1);
                default: throw new ArgumentException("Not supported command");
            }
        }

        private bool moveBoxes(Command command, GameObject offsetObject, Position position)
        {
            var currentObject = mapData.Map[position.X, position.Y];

            if (currentObject is Wall)
            {
                return false;
            }
            else if (currentObject is Box)
            {
                var box = (Box)currentObject;

                if(box.OnPlaceForBox || !moveBoxes(command, box, nextPosition(position, command)))
                    return false;

            }

            if(currentObject is PlaceForBox && offsetObject is Box)
            {
                var box = (Box)currentObject;
                box.OnPlaceForBox = true;
            }

            mapData.Map[position.X, position.Y] = offsetObject;

            return true;
        }

        public void move(Command command)
        {
            Position privPos = mapData.findStorekeeperPos();

            if (moveBoxes(command, mapData.Storekeeper, privPos))
            {
                mapData.Map[privPos.X, privPos.Y] = new EmptySpace();
            }
        }
    }
}
