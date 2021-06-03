using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public  class Obstacle
    {
        public PointF Position;
        public SizeF Size;
        public readonly Image _obstacleImage;
        public float ObstacleSizeX, ObstacleSizeY;
        public static List<Obstacle> ObstaclesList;
        public bool DeathOnCollide;
        public static Random random = new Random();

        public Obstacle(PointF position, bool deathOnCollide)
        {
            _obstacleImage = Aa(deathOnCollide);
            ObstacleSizeX = 100;
            ObstacleSizeY = 100;
            Position = position;
            Size  = new SizeF(ObstacleSizeX, ObstacleSizeY);
            DeathOnCollide = deathOnCollide;
        }

        private Bitmap Aa(bool deathOnCollide)
        {
            if (!deathOnCollide)
                return Properties.Resources.pump;
            
            switch (random.Next(0,2))
            {
                case 0:
                    return Properties.Resources.resize;
                case 1:
                    return Properties.Resources.Asteroid;
            }
            
            return Properties.Resources.rock2;
        }

        public static IEnumerable<Obstacle> ReturnObstacles()
        {
            if (ObstaclesList.Count <= 0) yield break;
            foreach (var obstacle in ObstaclesList)
                yield return obstacle;
        }
    }
}