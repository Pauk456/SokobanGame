using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SokobanGame.src.Presenter;
using SokobanGame.src.View;

namespace SokobanGame.src.Presenter
{
    internal class Presenter
    {
        private Model.Model model;

        private View.View view;

        private MapData mapData;

        private int currentLevel;

        public Presenter() 
        {
            currentLevel = 1;

            mapData = LevelBuilder.buildLevel(currentLevel);
            model = new Model.Model(mapData);
            view = new View.View();

            model.EventModel += modelTickHeandler;
            view.CommandEvent += viewCommandHeandler;

            view.UpdateMapData(mapData);
        }

        public void redraw()
        {
            view.UpdateMapData(mapData); // заглушка
        }

        public void startGame()
        {
            model.startGame();
            view.Run();
        }

        public void setLevel(int level)
        {
            mapData = LevelBuilder.buildLevel(currentLevel);
        }

        public void modelTickHeandler(Event e)
        {
            switch(e)
            {
                case Event.GameOn:
                    redraw(); break;
                case Event.Win:
                    nextLevel(); break;
            }
        }

        private void nextLevel()
        {
            currentLevel++;
            setLevel(currentLevel);
        }

        public void viewCommandHeandler(Command e) 
        {
            model.nextMove(e);
        }
    }
}
