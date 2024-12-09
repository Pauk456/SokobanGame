using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal class EventChecker
    {
        private MapData mapData;
        public EventChecker(MapData mapData) 
        {
            this.mapData = mapData;
        }

        private void moveBoxes(Command command, Position newStorekeeperPos)
        {
            foreach (Box box in mapData.Boxes)
            {
                if(newStorekeeperPos == box.Pos)
                {
                    box.move(command);
                }
            }
        }

        private void updateBoxesState()
        {
            foreach (Box box in mapData.Boxes)
            {
                foreach(PlaceForBox placeForBox in mapData.PlaceForBoxes)
                {
                    box.OnPlaceForBox = box.Pos == placeForBox.Pos;
                }
            }
        }

        private bool isWin()
        {
            foreach (Box box in mapData.Boxes)
            {
                if(box.OnPlaceForBox == false)
                    return false;
            }

            return true;
        }

        public Event eventHendler(Command command, Position newStorekeeperPos) // Не самое удачное название
        {
            moveBoxes(command, newStorekeeperPos);
            updateBoxesState();

            return isWin() ? Event.Win : Event.GameOn;
        }
    }
}
