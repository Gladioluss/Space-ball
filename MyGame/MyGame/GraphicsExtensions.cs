using System.Collections.Generic;
using  System.Drawing;
//using static MyGame.Obstacle;

namespace MyGame
{
    public static class GraphicsExtensions
    {
        public static void DrawPlayer(this Graphics graphics, Player player)
            => graphics.DrawImage(player._PlayerImage,
                player.Physics.Position.X,
                player.Physics.Position.Y,
                player.Physics.Size.Width + 15,
                player.Physics.Size.Height + 15);

        public static void DrawObstacle(this Graphics graphics, Obstacle obstacle)
            => graphics.DrawImage(obstacle._obstacleImage,
                obstacle.Position.X,
                obstacle.Position.Y,
                obstacle.Size.Width,
                obstacle.Size.Height);
    }
}