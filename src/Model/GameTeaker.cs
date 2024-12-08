using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Concurrent;

namespace SokobanGame.src.Model
{
    internal class GameTeaker
    {
        private static readonly int timerInterval = 500;

        private int TeakCount;

        private ConcurrentQueue<Command> commandQueue;

        public GameTeaker()
        {
            commandQueue = new ConcurrentQueue<Command>();

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

            if (isCommand)
            {
                
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
