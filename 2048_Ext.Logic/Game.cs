using _2048_Ext.Logic.Game_Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _2048_Ext.Logic
{
    [Serializable()]
    public class Game
    {
        int rows;
        int columns;
        long best;
        Table table;
        Stack<Table> tables;


        public Game()
        {
            tables = new Stack<Table>();
        }

        public string PlayerName { get; protected set; }
        public int Rows { get => rows; }
        public int Columns { get => columns; }

        public long Score { get => table.Score; }
        public long Best { get => Math.Max(best, Score);}

        public int this[int i , int j]
        {
            get => table[i, j];
        }


        public void NewGame(
            string name, 
            int rows, 
            int columns)
        {
            PlayerName = name;
            this.rows = rows;
            this.columns = columns;
            best = GetTheBest();

            table = new Table(rows, columns);
            tables.Push(table);
        }

        public void LoadGame(Game game)
        {
            PlayerName = game.PlayerName;
            rows = game.rows;
            columns = game.columns;
            best = game.best;
            table = game.table;
            tables = game.tables;
        }

        private int GetTheBest()
        {
            if (!Directory.Exists($"Saves\\{PlayerName}\\{rows}x{columns}"))
                Directory.CreateDirectory($"Saves\\{PlayerName}\\{rows}x{columns}");

            FileStream fs = new FileStream(
                $"Saves\\{PlayerName}\\{rows}x{columns}\\BestScores.txt",
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite
                );
            
            StreamReader sr = new StreamReader(fs);
            string stringBest = sr.ReadLine();

            sr.Close();

            if (stringBest == null)
                stringBest = "0";
            return int.Parse(stringBest);

        }


        public void Undo()
        {
            if (tables.Count == 0) return;

            table = tables.Pop();
        }
        public bool DidILose() => table.DidILose();
        public void PrintTable()
        {
            table.PrintArray();
        }


        public void Move(int dir)
        {
            tables.Push(new Table(table));
            table.MoveTo(dir);
        }

        public void Save()
        {
            best = Math.Max(best, Score);
            if (!Directory.Exists(
                $"Saves\\{PlayerName}\\{rows}x{columns}"))
                Directory.CreateDirectory(
                    $"Saves\\{PlayerName}\\{rows}x{columns}");
            
            //Save the best Score
            FileStream saveFileStreamBest = new FileStream(
                $"Saves\\{PlayerName}\\{rows}x{columns}\\BestScores.txt",
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite);

            StreamWriter toSaveBest = new StreamWriter(
                saveFileStreamBest);
            toSaveBest.Write(best.ToString());

            toSaveBest.Close();
            saveFileStreamBest.Close();


            //To save the game
            FileStream saveGameFile = new FileStream(
            $"Saves\\{PlayerName}\\{rows}x{columns}\\Game.txt",
            FileMode.OpenOrCreate,
            FileAccess.Write
            );

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveGameFile,this);

            saveGameFile.Close();
        }

        public bool Load(string path)
        {
            FileStream loadGameFile = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            Game gameLoaded = new Game();
            gameLoaded = (Game)bf.Deserialize(loadGameFile);

            loadGameFile.Close();

            LoadGame(gameLoaded);
            
            return true;
        }

    }
}
