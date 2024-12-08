using SokobanGame.src.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal interface IModel
    {
        public void nextMove();
        public void stopGame();
        public void resumeGame();
        public List<IGameObject> getMap();
    }
}
