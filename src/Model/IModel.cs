using SokobanGame.src.GameObjects;
using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.Model
{
    internal interface IModel
    {
        public void startGame();
        public void nextMove(Command command);
        public void stopGame();
        public void resumeGame();
        public GameObject[,] getMap();
    }
}
