using SokobanGame.src.GameObjects;
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

        public Model()
        { 
            mapData = LevelBuilder.buildLevel(0);
            gameTeaker = new GameTeaker(mapData);
            gameTeaker.EventTicker += OnTick;
        }

        public void setNewLevel(int level)
        {
            mapData = LevelBuilder.buildLevel(level);
        }

        private void OnTick(Event e)
        {
            if(e == Event.Win)
            {
                stopGame();
            }

            if(EventModel != null)
            {
                EventModel(e);
            }
        }

        public List<GameObject> getMap()
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
