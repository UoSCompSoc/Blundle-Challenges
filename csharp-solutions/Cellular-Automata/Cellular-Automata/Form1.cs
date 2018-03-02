using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        public enum tileType { white, black};

        public Graphics visual;
        public Brush blackBrush;
        public Brush whiteBrush;
        public Brush antBrush;

        public float tileWidth;
        public float tileHeight;
        public int antX;
        public int antY;
        public int antAngle;
        public int steps;
        public const int tilesAccross = 100;
        public const int tilesUpDown = 100;

        public tileType[,] grid = new tileType[tilesAccross, tilesUpDown];

        public Form1()
        {
            InitializeComponent();

            visual = picBoxWorld.CreateGraphics();
            blackBrush = Brushes.Black;
            whiteBrush = Brushes.White;
            antBrush = Brushes.Red;

            tileWidth = picBoxWorld.Width / tilesAccross;
            tileHeight = picBoxWorld.Height / tilesUpDown;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            setupSimulation();
        }

        private void timerAntStep_Tick(object sender, EventArgs e)
        {
            if(steps < Convert.ToInt32(txtBoxSteps.Text))
            {
                Console.WriteLine("Step: " + steps);
                if (grid[antX, antY] == tileType.white)
                {
                    grid[antX, antY] = tileType.black;
                    updateAntLocation(-90);
                }
                else
                {
                    grid[antX, antY] = tileType.white;
                    updateAntLocation(90);
                }
                drawWorld();
                steps += 1;
            }
            else
            {
                timerAntStep.Stop();
            }
        }

        private void updateAntLocation(int degreeTurn)
        {
            if(antAngle == 0 && degreeTurn < 0)
            {
                antAngle = 270;
            }
            else if(antAngle == 270 && degreeTurn > 0)
            {
                antAngle = 0;
            }
            else
            {
                antAngle += degreeTurn;
            }

            switch(antAngle)
            {
                case 0:
                    antY -= 1;
                    break;
                case 90:
                    antX += 1;
                    break;
                case 180:
                    antY += 1;
                    break;
                case 270:
                    antX -= 1;
                    break;
                default:
                    Console.WriteLine("An error occurred updating the location of the ant : unrecognised movement direction");
                    break;
            }
        }

        private void setupSimulation()
        {
            antX = tilesAccross / 2;
            antY = tilesUpDown / 2;
            antAngle = 0;
            steps = 0;
            for (int i = 0; i < tilesAccross; i++)
            {
                for (int j = 0; j < tilesUpDown; j++)
                {
                    grid[i, j] = tileType.white;
                }
            }
            drawWorld();
            timerAntStep.Start();
        }

        private void drawWorld()
        {
            for (int i = 0; i < tilesAccross; i++)
            {
                for (int j = 0; j < tilesUpDown; j++)
                {
                    switch(grid[i,j])
                    {
                        case tileType.black:
                            visual.FillRectangle(blackBrush, i * tileWidth, j * tileHeight, tileWidth, tileHeight);
                            break;
                        case tileType.white:
                            visual.FillRectangle(whiteBrush, i * tileWidth, j * tileHeight, tileWidth, tileHeight);
                            break;
                        default:
                            Console.WriteLine("An error occurred rendering the world");
                            break;
                    }
                }
            }
            visual.FillRectangle(antBrush, antX * tileWidth, antY * tileHeight, tileWidth, tileHeight);
        }

    }
}
