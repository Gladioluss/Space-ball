using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyGame
{
    public partial class Form1 : Form
    {
        Game game;
        private readonly Timer _timer = new Timer();
        private Label labelScore;


        public Form1()
        {
            InitializeComponent();
            Initialize();
            _timer.Interval = 1;
            _timer.Tick += Update;
            BackgroundImage = Properties.Resources.backGround2;
            Height = game.MapHeight*104;
            Width = game.MapWidth*100;
            KeyUp += InputCheck;
            Paint += OnRepaint;          
            game.OnPlayerDead += EndGame;

            labelScore = new Label
            {
                Text = "Score: 0",
                Location = new Point(0, 0),
                Size = new Size(20, 20)
            };
            Controls.Add(labelScore);
        }
       
        public void Initialize()
        {
            game = new Game();
            if (game.ObstaclesList.Any())
                game.ObstaclesList.Clear();
            CreateMapPart();
            _timer.Start();
        }

        public void CreateMapPart()
        {
            for (var x = 0; x < game.MapWidth; x++)
            for (var y = 0; y < game.MapHeight; y++)
            {
                if (game.Map[x, y] == "cube")
                    game.AddObstacle(new PointF(x * 100, y * 100), true);
                if (game.Map[x, y] == "pump")
                    game.AddObstacle(new PointF(x * 100, y * 100), false);
            }
        }

        public void OnRepaint(object sender, PaintEventArgs e) 
        {
            if (game.ObstaclesList.Count > 0)
                
                foreach (var obstacle in game.ObstaclesList)
                    if(obstacle.Position.X - 30 * game.MapWidth < game.player.Physics.Position.X)
                    e.Graphics.DrawObstacle(obstacle);
            e.Graphics.DrawPlayer(game.player);
        }

        public void InputCheck(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Space:
                    game.ChangeGravity();
                    break;  
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            game.Update();
            labelScore.Text = game.Score.ToString();
            Invalidate();
        }

        public void EndGame()  
        {
            game.player.Physics.Position = game.player.Physics.Start;
            game.ObstaclesList.Clear();
            CreateMapPart();
        }
    }
}