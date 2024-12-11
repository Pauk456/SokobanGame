using SokobanGame.src.GameObjects;
using SokobanGame.src.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SokobanGame.src.Model.GameTeaker;

namespace SokobanGame.src.Model
{
    internal class Model : IModel
    { 
        private MapData mapData;

        private GameTeaker gameTeaker;

        public delegate void ModelDelegate(Event e);

        public event ModelDelegate EventModel;

        public Model(MapData mapData)
        { 
            this.mapData  = mapData;
            gameTeaker = new GameTeaker(mapData);
            gameTeaker.EventTicker += OnTick;
        }

        public void startGame()
        {
            gameTeaker.start();
        }

        private void OnTick(Event e)
        {
            if(e == Event.Win)
            {
                stopGame();
            }

            EventModel?.Invoke(e);
        }

        public GameObject[,] getMap()
        {
            return mapData.Map;
        }

        public void nextMove(Command command)
        {
            gameTeaker.addMoveInQueue(command);
        }

        public void resumeGame()
        {
            gameTeaker.resumeTimer();
        }

        public void stopGame()
        {
            gameTeaker.stopTimer();
        }
    }
}
