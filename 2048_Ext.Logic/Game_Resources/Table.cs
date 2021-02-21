using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.IO;

namespace _2048_Ext.Logic.Game_Resources
{
    [Serializable()]
    public class Table
    {
        int rows;
        int columns;
        long score;
        Random rnd;
        int [,] table;

        /// <summary>
        /// dir_x => Direction Array in x
        /// dir_y => Direcion Array in y
        /// 
        /// => Direction: Down Left Up Right
        /// </summary>
        int[] dir_x = new int[4] { 1, 0, -1, 0 };
        int[] dir_y = new int[4] { 0, -1, 0, 1 };

        /// <summary>
        /// </summary>
        /// <param name="rows">
        /// Rows's Count of Table
        /// </param>
        /// <param name="columns">
        /// Column's Count of Table
        /// </param>
        public Table(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            score = 0;
            rnd = new Random();
            table = new int[ rows, columns ];

            CreateTable();
        }

        //Create a new instance of table
        public Table(
            Table table)
        {
            rows = table.rows;
            columns = table.columns;
            rnd = new Random();
            score = table.score;

            this.table = (int[,])table.table.Clone();
                   
        }

        public long Score { get => score; }

        public int this[int i, int j]
        {
            get => table[i, j];
        }

        /// <summary>
        /// Basicaly This method take a random number 
        /// between 1-3 and then 
        ///create two randoms number for row and column
        ///where those are 0 and assign them a random value (2, 4)
        /// </summary>
        private void CreateTable() 
        {
            //Count of Initial Values    
            int init_val_count = rnd.Next(1, 4);

            for (int i = 0; i < init_val_count; i++)
            {
                int new_row = 0;
                int new_column = 0;

                do
                {
                    new_row = rnd.Next(rows);
                    new_column = rnd.Next(columns);

                } while (table[new_row, new_column] != 0);

                //Set in table a number 2 or 4
                table[new_row, new_column] = 2 * rnd.Next(1, 3);
            }
        }

        /// <summary>
        /// If the table has moved
        /// it's necesary to add an element
        /// it can be 2=4
        /// </summary>
        private void AddElement()
        {
            int row = 0;
            int column = 0;

            do
            {
                row = rnd.Next(rows);
                column = rnd.Next(columns);

            } while (table[row, column] != 0);

            table[row, column] = 2 * rnd.Next(1, 3);
        }

        /// <summary>
        /// Move the whole array 
        /// using moveSingle
        /// </summary>
        /// <param name="dir">Direction</param>
        public void MoveTo(int dir)
        {
            bool haveToAddValue = false;
            //Down
            if (dir == 0)
                for (int i = 0; i < table.GetLength(1); i++)
                {
                    if (MoveSingle(0, i, table.GetLength(0) - 1, i, dir))
                        haveToAddValue = true;
                }
            //Left
            else if (dir == 1)
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    if (MoveSingle(i, table.GetLength(1) - 1, i, 0, dir))
                        haveToAddValue = true;
                }

            //Up
            else if (dir == 2)
                for (int i = 0; i < table.GetLength(1); i++)
                { 
                    if (MoveSingle(table.GetLength(0) - 1, i, 0, i, dir))
                        haveToAddValue = true;
                }

            //Right
            else
                for (int i = 0; i < table.GetLength(0); i++)
                { 
                    if (MoveSingle(i, 0, i, table.GetLength(1) - 1, dir))
                        haveToAddValue = true;
                }

            if (haveToAddValue)
                AddElement();
        }

        /// <summary>
        /// Move all numers from start(x,y) to end(x,y)
        /// and the equals add up 
        /// </summary>
        /// <param name="st_x">x Start </param>
        /// <param name="st_y">y Start</param>
        /// <param name="end_x">x End</param>
        /// <param name="end_y">y End</param>
        /// <param name="dir">direction</param>
        bool MoveSingle(int st_x, int st_y, int end_x, int end_y, int dir)
        {
            bool anyChange = false;

            //put the opposite direction
            dir = (dir + 2) % 4;

            //P1 and P2 are pointers
            int p1_x = end_x + dir_x[dir];
            int p1_y = end_y + dir_y[dir];
            int p2_x = end_x;
            int p2_y = end_y;


            while (p1_x >= 0 && p1_x < rows &&
                p1_y >= 0 && p1_y < columns)
            {
                if (table[p1_x, p1_y] == 0 || (p1_x == p2_x && p1_y == p2_y))
                {
                    p1_x+=dir_x[dir]; p1_y+=dir_y[dir];
                    continue;
                }

                if (table[p2_x, p2_y] == 0)
                {
                    table[p2_x, p2_y] = table[p1_x, p1_y];
                    table[p1_x, p1_y] = 0;

                    p1_x+=dir_x[dir]; p1_y+=dir_y[dir];
                    anyChange = true;
                    continue;
                }

                //If those are equals we can add them 
                //Increase the score
                //Move Point2 to Point1
                //Point1 change it to 0
                if (table[p1_x, p1_y] == table[p2_x, p2_y])
                {
                    score += table[p2_x, p2_y] += table[p1_x, p1_y];
                    table[p1_x, p1_y] = 0;
                    anyChange = true;

                    //Move the cursors
                    p1_x += dir_x[dir]; p1_y += dir_y[dir];
                    p2_x += dir_x[dir]; p2_y += dir_y[dir];
                    continue;
                }

                //If x != 0 and y != 0 and x != y
                p2_x += dir_x[dir]; p2_y += dir_y[dir];
            }

            return anyChange;
        }

        public bool DidILose()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //the game is still on
                    if (table[i, j] == 0)
                        return false;

                    for (int k = 1; k < dir_x.Length; k++)
                    {
                        int newI = i + dir_x[k];
                        int newJ = j + dir_y[k];

                        if (!ItsIn(newI, newJ))
                            continue;

                        if (table[i, j] == table[newI, newJ])
                            return false;
                    }
                }
            }
            return true;
        }

        bool ItsIn(int x, int y) => x >= 0 && x < rows && y >= 0 && y < columns;

        public void PrintArray()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j].ToString() + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
