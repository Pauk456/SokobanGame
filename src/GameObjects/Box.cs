using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.src.GameObjects
{
    public class Box : GameObject
    { 
        public Box()
        {
            OnPlaceForBox = false;
        }
        public bool OnPlaceForBox { get; set; }
    }
}
