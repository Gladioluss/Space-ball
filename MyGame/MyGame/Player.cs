using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public class Player
    {
        public Physics Physics;
        public readonly Image _PlayerImage;
        public float GravityValue;

        public Player()
        {
            _PlayerImage = Properties.Resources.ball2;
            Physics = new Physics(new PointF(400, 350), new SizeF(40, 40));
            GravityValue = 6;
        }
    }
}