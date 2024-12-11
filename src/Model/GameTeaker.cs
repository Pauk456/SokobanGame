using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using SokobanGame.src.Presenter;
using System.Timers;


namespace SokobanGame.src.Model
{
    internal class GameTeaker
    {
        public delegate void GameTickerDelegate(Event e);

        public event GameTickerDelegate EventTicker;

        private static readonly int timerInterval = 150;

        private long TeakCount;

        private ConcurrentQueue<Command> commandQueue;

        private MapData mapData;

        private MoveLogic moveLogic;

        private WinLogic winLogic;

        private System.Threading.Timer timer;

        public GameTeaker(MapData mapData)
        {
            TeakCount = 0;
            commandQueue = new ConcurrentQueue<Command>();

            this.mapData = mapData;
            setMapData(mapData);
        }

        public void start()
        {
            var tm = new TimerCallback(gameTick);
            timer = new System.Threading.Timer(tm, null, 0, timerInterval);
        }
        public void setMapData(MapData mapData)
        {
            moveLogic = new MoveLogic(mapData);
            this.winLogic = new WinLogic(mapData);
        }
        public void addMoveInQueue(Command command)
        {
            commandQueue.Enqueue(command);
        }

        private void gameTick(object obj)
        {
            TeakCount++;

            Command command;
            bool isCommand = commandQueue.TryDequeue(out command);
            Event _event = Event.GameOn;

            if (isCommand)
            {
                moveLogic.move(command);
                if(winLogic.isWin())
                {
                   _event = Event.Win;
                   commandQueue.Clear();
                }
            }

            if(EventTicker != null)
            {
                EventTicker(_event);
            }
        }

        public void stopTimer()
        {
            timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void resumeTimer()
        {
            timer?.Change(0, timerInterval);
        }
    }
}
