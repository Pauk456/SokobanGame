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

        private int TeakCount;

        private ConcurrentQueue<Command> commandQueue;

        private MapData mapData;

        private MoveChecker moveChecker;

        private EventChecker eventChecker;

        public GameTeaker(MapData mapData)
        {
            TeakCount = 0;
            commandQueue = new ConcurrentQueue<Command>();

            this.mapData = mapData;
            moveChecker = new MoveChecker(mapData);
            eventChecker = new EventChecker(mapData);

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
                Position newPos = mapData.Storekeeper.move(command);

                if (moveChecker.isThisMoveCorrect(newPos))
                {
                    mapData.Storekeeper.Pos = newPos;
                    _event = eventChecker.eventHendler(command, newPos);
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
