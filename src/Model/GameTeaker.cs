using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using SokobanGame.src.GameObjects;


namespace SokobanGame.src.Model
{
    internal class GameTeaker
    {
        public delegate void GameTickerDelegate(Event e);

        public event GameTickerDelegate EventTicker;

        private static readonly int timerInterval = 500;

        private long TeakCount;

        private ConcurrentQueue<Command> commandQueue;

        private MapData mapData;

        private MoveLogic moveLogic;

        private WinLogic winLogic;

        public GameTeaker(MapData mapData)
        {
            TeakCount = 0;
            commandQueue = new ConcurrentQueue<Command>();

            this.mapData = mapData;
            moveLogic = new MoveLogic(mapData);
            winLogic = new WinLogic(mapData);
        }

        public void start()
        {
            var tm = new TimerCallback(gameTick);
            var timer = new Timer(tm, null, 0, timerInterval);
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
                }
            }

            if(EventTicker != null)
            {
                EventTicker(_event);
            }
        }

        public void stopTimer()
        {
            throw new NotImplementedException();
        }

        public void resumeTimer()
        {
            throw new NotImplementedException();
        }
    }
}
