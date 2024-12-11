using SokobanGame.src.Model.GameObjects;
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
        private bool moveRec(Command command, MoveableObject offsetObject, Position position)
        {
            var currentObject = mapData.peekObj(position);
            
            if (currentObject is Wall)
            {
                return false;
            }
            else if (currentObject is Box)
            {
                var box = (Box)currentObject;
                var newPos = box.tryMove(command);

                if (moveRec(command, box, newPos))
                {
                    mapData.rmObj(position);

                    mapData.addObj(position, offsetObject);
                    offsetObject.move(position);
                    if (offsetObject is Box)
                    {
                        ((Box)offsetObject).updateStatus(mapData);
                    }
                    

                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                mapData.addObj(position, offsetObject);
                offsetObject.move(position);

                if (offsetObject is Box)
                {
                    ((Box)offsetObject).updateStatus(mapData);
                }

                return true;
            }
        }

        public void move(Command command)
        {
            Position newPos = mapData.Storekeeper.tryMove(command);
            Position privPos = mapData.Storekeeper.Position;

            if (moveRec(command, mapData.Storekeeper, newPos))
            {
                mapData.rmObj(privPos);
            }
        }
    }
}
