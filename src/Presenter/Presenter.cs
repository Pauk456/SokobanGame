using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SokobanGame.src.View;

namespace SokobanGame.src.Presenter
{
    internal class Presenter
    {
        private Model.Model model;

        private View.View view;

        private int currentLevel;

        public Presenter() 
        {
            currentLevel = 1;

            model = new Model.Model();
            view = new View.View();

            model.EventModel += modelTickHeandler;
            view.CommandEvent += viewCommandHeandler;
        }

        public void redraw()
        {
            
        }

        public void startGame()
        {
            model.startGame();
        }

        public void setLevel(int level)
        {
            model.setNewLevel(level);
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

        }
    }
}
