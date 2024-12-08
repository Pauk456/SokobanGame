using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.GameObjects
{
    internal interface EmptySpace : IGameObject
    {
        public Position Pos { get; set; }
    }
}
