/*DataHandling.cs
 *Made by Chris Meier and Zach Ascoli 
 *Completed on 4/29/10
 *Copyright (c) WI, 2010
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame3
{
    class DataHandling
    {
        public int[] c = new int[5];
        public int[] score = new int[5];
        public int[] moves = new int[5];
        public int[] time = new int[5];
        public string[] inits = new string[5];

        public DataHandling()
        {
            for (int i = 0; i < 5; i++)
            {
                this.c[i] = 0;
                this.score[i] = 0;
                this.moves[i] = 0;
                this.time[i] = 0;
                this.inits[i] = "XX"; // XX is the placeholder for an empty spot on the leaderboards.
            }
        }

        /// <summary>
        /// Loads info to the DataHandling class
        /// </summary>
        /// <param name="c">The "for" loop variable.</param>
        /// <param name="score">Score integer.</param>
        /// <param name="time">Time integer.</param>
        /// <param name="moves">Moves integer.</param>
        /// <param name="initial">Player's initials string.</param>
        public void LoadStuff(int c, int score, int time, int moves, string initial)
        {
            this.c[c] = c;
            this.score[c] = score;
            this.time[c] = time;
            this.moves[c] = moves;
            this.inits[c] = initial;
        }

        public void Save()
        {
            FileStream fileStream = new FileStream("Lboards.txt", FileMode.Create, FileAccess.Write); 
            StreamWriter writer = new StreamWriter(fileStream);

            {
                writer.WriteLine("[Scores]"); // Tag

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("{0}", this.score[i].ToString()); // Writes the scores in a text file
                }

                writer.WriteLine("[Moves]");

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("{0}", this.moves[i].ToString());
                }

                writer.WriteLine("[Time]");

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("{0}", this.time[i].ToString());
                }

                writer.WriteLine("[Initials]");

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("{0}", inits[i]);
                }
            }
            writer.Close();
            fileStream.Close();

        }

        public void Load()
        {
            FileStream inFile = new FileStream("Lboards.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(inFile);
            string temp;
            bool readingScores = false;
            bool readingMoves = false;
            bool readingTime = false;
            bool readingInit = false;
            temp = streamReader.ReadLine();

            if (temp == "[Scores]") // reads the tag
            {
                readingScores = true;                
            }            
            
            while (readingScores) // reads the scores from the text file
            {
                for (int i = 0; i < 5; i++)
                {
                    temp = streamReader.ReadLine();
                    this.score[i] = Convert.ToInt32(temp); 
                }
                readingScores = false;
            }
            temp = streamReader.ReadLine();
            if (temp == "[Moves]")
            {
                readingMoves = true;
            }
            while (readingMoves)
            {
                for (int i = 0; i < 5; i++)
                {
                    temp = streamReader.ReadLine();
                    this.moves[i] = Convert.ToInt32(temp);
                }
                readingMoves = false;
            }
            temp = streamReader.ReadLine();
            if (temp == "[Time]")
            {
                readingTime = true;
            }
            while (readingTime)
            {
                for (int i = 0; i < 5; i++)
                {
                    temp = streamReader.ReadLine();
                    this.time[i] = Convert.ToInt32(temp);
                }
                readingTime = false;
            }
            temp = streamReader.ReadLine();
            if (temp == "[Initials]")
            {
                readingInit = true;
            }
            while (readingInit)
            {
                for (int i = 0; i < 5; i++)
                {
                    temp = streamReader.ReadLine();
                    this.inits[i] = temp;
                }
                readingInit = false;
            }

        }
    }
}
