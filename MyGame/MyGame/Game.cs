using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace MyGame
{
    public class Game
    {
        public string[,] Map;
        public int MapWidth => Map.GetLength(0);
        public int MapHeight => Map.GetLength(1);
        public const float MapStartY = 0;
        public const float MapEndY = 750;
        public float Score;
        public Player player;
        public Queue<Obstacle> ObstaclesList;
        public delegate void EndGame();
        public event EndGame OnPlayerDead;
        private static readonly Random _random = new Random();
     
        public Game()
        {  
            Score = 0;
            Map = CreatureMap(GetMap());
            player = new Player();            
            ObstaclesList = new Queue<Obstacle>();
        }

        public static string GetMap()
            => PartOfMap.Maps[_random.Next(0, PartOfMap.Maps.Count)];

        public string[,] CreatureMap(string map)
        { 
            return CreateMap.CreatureMap(map);
        }

        public void AddObstacle(PointF position, bool deathOnCollide)
            => ObstaclesList.Enqueue(new Obstacle(position, deathOnCollide));
            
        public void Update()
        {           
            if (player.Physics.Position.Y <= MapStartY
                || player.Physics.Position.Y >= MapEndY)
            {
                OnPlayerDead();
            }

            foreach (var obstacle in ObstaclesList)
            {
                if (player.Physics.Position.X + player.Physics.Size.Width + 150 >
                    obstacle.Position.X
                    && player.Physics.Position.X - 150 < obstacle.Position.X + obstacle.ObstacleSizeX)
                {
                    var (item1, item2) = player.Physics.CheckCollision(player, obstacle);
                    if (item1)
                    {
                        if (item2)
                        {
                            Score = 0;
                            player.GravityValue = 6;
                            OnPlayerDead();
                            break;
                        }
                          
                        Score++;
                        if (Score > 6)
                            player.GravityValue = Score - 0.5f;
                        Map = CreatureMap(GetMap());
                        OnPlayerDead();
                        break;
                    }   
                }                                                 
            }
            
            var i = 0;
            foreach(var obstacle in ObstaclesList)
                if (obstacle.Position.X + 500 < player.Physics.Position.X)
                    i++;
            if (i != 0)
                for (var a = 0; a < i; a++)
                    ObstaclesList.Dequeue();
            player.Physics.Position.Y += player.GravityValue;
            MoveObstacle();
        }

        public void ChangeGravity() => player.GravityValue *= -1;

        public void MoveObstacle()
        {
            foreach (var obstacle in ObstaclesList)
                obstacle.Position.X -= 7 + Score;
        }
    }
}
 