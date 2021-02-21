using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2048_Ext.Logic;
using _2048_Ext.Logic.Game_Resources;

namespace _2048_Ext.Visual
{
    
    public partial class GameFrm : Form
    {
        Game game;
        bool leftArrowPressed;
        bool rightArrowPressed;
        bool upArrowPressed;
        bool downArrowPressed;
        bool undo;

        Label[,] tableOfLabels;
        Dictionary<string, Color> colors = new Dictionary<string, Color>()
        {
            { "0", Color.Gray },
            { "2",Color.LightYellow},
            { "4", Color.LightSalmon},
            { "8", Color.LightSeaGreen},
            { "16", Color.LightGreen},
            { "32", Color.LightCoral},
            { "64", Color.LightCyan},
            { "128", Color.Aqua},
            { "256", Color.Aquamarine},
            { "512", Color.BlueViolet},
            { "1024", Color.Coral},
            { "2048", Color.Gold},
            { "4096", Color.DarkRed},
            { "8196", Color.DarkGreen},
            { "16384", Color.AliceBlue},
            { "32768", Color.Azure},
            { "65536", Color.Bisque},
        };

        public GameFrm(Game game)
        {
            this.game = game;
            tableOfLabels = new Label[game.Rows, game.Columns];

            InitializeComponent();

            leftArrowPressed = false;
            rightArrowPressed = false;
            upArrowPressed = false;
            downArrowPressed = false;
            undo = false;

            Width = 40 * game.Columns + 35;
            Height = 40 * game.Columns + 150;

            gameGBox.Width = 40 * game.Columns;
            gameGBox.Height = 40 * game.Rows;

            CreateTable();
        }


        void Updatelabel(Label label)
        {
            label.BackColor = label.Text == ""?colors["0"]: colors[label.Text];

            //Font Height
            if (label.Text.Length == 1)
                label.Font = new Font(label.Font.Name, 20);
            else if (label.Text.Length == 2)
                label.Font = new Font(label.Font.Name, 15);
            else if (label.Text.Length == 3)
                label.Font = new Font(label.Font.Name, 10);
            else
                label.Font = new Font(label.Font.Name, 8);
        }
        public void RefreshTable()
        {
            scoreLbl.Text = $"SCORE \n {game.Score}";
            bestLbl.Text = $"BEST \n {game.Best}";

            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    tableOfLabels[i, j].Text = game[i,j] == 0 ? "" : game[i,j].ToString();
                    Updatelabel(tableOfLabels[i, j]);
                }
            }
        }

        #region Create Table Methods
        /// <summary>
        /// Add the cell to the game 
        /// Name of a cell => Cell{x}{y}
        /// </summary>
        public void CreateTable()
        {
            Text += $"        Hello, {game.PlayerName}";   
            scoreLbl.Text = $"SCORE \n {game.Score}";
            bestLbl.Text = $"BEST \n {game.Best}";

            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    AddCell(game[i, j], i, j);
                }
            }
        }
        /// <summary>
        /// Create a panel in a position 
        /// in a group box
        /// <paramref name="num"/>
        /// Value of The Cell
        /// <paramref name="x"/>
        /// x Position where the cell gonna be
        /// <paramref name="y"/>
        /// y Position where the cell gonna be
        /// </summary>
        void AddCell(int num, int x, int y)
        { 
            Label cellLbl = new Label();

            cellLbl.ForeColor = Color.Black;

            //Cell
            cellLbl.BackColor = colors[num.ToString()];
            cellLbl.Size = new Size(40, 40);
            cellLbl.BorderStyle = BorderStyle.Fixed3D;
            cellLbl.Location = new Point(40 * y, 40 * x);

            //Value
            cellLbl.Text = num == 0 ? "" : num.ToString();

            //Font
            if (cellLbl.Text.Length == 1)
                cellLbl.Font = new Font(cellLbl.Font.Name, 20);
            else if (cellLbl.Text.Length == 2)
                cellLbl.Font = new Font(cellLbl.Font.Name, 15);
            else if (cellLbl.Text.Length == 3)
                cellLbl.Font = new Font(cellLbl.Font.Name, 10);
            else
                cellLbl.Font = new Font(cellLbl.Font.Name, 8);

            tableOfLabels[x, y] = cellLbl;
            gameGBox.Controls.Add(cellLbl);
        }

        #endregion

        private void GameFrm_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (upArrowPressed)
            {
                upArrowPressed = false;
                game.Move(2);
            }
            else if (downArrowPressed)
            {
                downArrowPressed = false;
                game.Move(0);
            }
            else if (rightArrowPressed)
            {
                rightArrowPressed = false;
                game.Move(3);
            }
            else if (leftArrowPressed)
            {
                leftArrowPressed = false;
                game.Move(1);
            }
            else if (undo)
            {
                undo = false;
                game.Undo();
            }

            RefreshTable();
            Refresh();

            if (game.DidILose())
            {
                
                string message = "You Lose";
                MessageBox.Show(message);
                Close();
            }
        }

        private void GameFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Up == e.KeyCode)
                upArrowPressed = true;
            else if (Keys.Down == e.KeyCode)
                downArrowPressed = true;
            else if (Keys.Left == e.KeyCode)
                leftArrowPressed = true;
            else if (Keys.Right == e.KeyCode)
                rightArrowPressed = true;
            else if (Keys.U == e.KeyCode)
                undo = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveAndExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Save();
            Close();
        }
    }
}
