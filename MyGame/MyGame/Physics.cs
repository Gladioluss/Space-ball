using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public class Physics
    {
        public PointF Position;
        public SizeF Size;
        public PointF Start;

        public Physics(PointF position, SizeF size)
        {
            Start = new PointF(400, 350);
            Position = position;
            Size = size;
        }

        public Tuple<bool, bool>  CheckCollision(Player player, Obstacle obstacle)
        {
            var collisionX = player.Physics.Position.X + player.Physics.Size.Width >=
                             obstacle.Position.X &&
                             obstacle.Position.X + obstacle.Size.Width >=
                             player.Physics.Position.X;

            var collisionY = player.Physics.Position.Y + player.Physics.Size.Height >=
                             obstacle.Position.Y &&
                             obstacle.Position.Y + obstacle.Size.Height >=
                             player.Physics.Position.Y;

            return Tuple.Create(collisionX && collisionY, obstacle.DeathOnCollide);
        }
    }
}