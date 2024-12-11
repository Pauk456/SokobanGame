using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SokobanGame.src.Presenter;
using SokobanGame.src.View;
using SokobanGame.src.Model;
using SokobanGame.src.Model.GameObjects;
using System.Reflection;

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

            redraw();
        }

        private GameObjectDraw[,] getDrawMap()
        {
            GameObjectDraw[,] drawMap = new GameObjectDraw[mapData.SizeX, mapData.SizeY];
            for (int x = 0; x < mapData.SizeX; x++)
            {
                for (int y = 0; y < mapData.SizeY; y++)
                {
                    var obj = mapData.peekObj(x, y);
                    if (obj is Box && ((Box)obj).OnPlaceForBox)
                    {
                        drawMap[x, y] = GameObjectDraw.BoxOnPlaceForBox;
                    }
                    else if (obj is Box)
                    {
                        drawMap[x, y] = GameObjectDraw.Box;
                    }
                    else if (obj is Storekeeper)
                    {
                        drawMap[x, y] = GameObjectDraw.Storekeeper;
                    }
                    else if (obj is Wall)
                    {
                        drawMap[x, y] = GameObjectDraw.Wall;
                    }
                    else if (obj is PlaceForBox)
                    {
                        drawMap[x, y] = GameObjectDraw.PlaceForBox;
                    }
                    else
                    {
                        drawMap[x, y] = GameObjectDraw.EmptySpace;
                    }
                }
            }
            return drawMap;
        }

        public void redraw()
        {
            view.UpdateMapData(getDrawMap());
        }

        public void startGame()
        {
            model.startGame();
            view.Run();
        }

        public void setLevel(int level)
        {
            mapData = LevelBuilder.buildLevel(currentLevel);
            model.setMapData(mapData);
        }

        public void modelTickHeandler(Event e)
        {
            switch (e)
            {
                case Event.GameOn:
                    redraw();
                    break;
                case Event.Win:
                {
                    model.stopGame();
                    redraw();
                    nextLevel();
                    model.startGame();
                    break;
                }
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
