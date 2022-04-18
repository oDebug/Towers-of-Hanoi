/*LeaderBoardClass.cs
 *Made by Chris Meier and Zach Ascoli 
 *Completed on 4/29/10
 *Copyright (c) WI, 2010
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame3
{
    /// <summary>/// Class that holds 1 score, 1 moves amount, 1 time amount, and someone's initials. This is usually used as an array in the engine/// </summary>
    class LeaderBoardClass
    {
        public int score,            
            moves,
            time;
        public string initials;
        public string sTime;
        public LeaderBoardClass()
        {
            this.time = 0;
            this.moves = 0;
            this.score = 0;
            this.initials = "XX";
        }
        /// <summary>
        /// Loads the information needed in the leaderboards (time, moves, initials)
        /// </summary>
        /// <param name="sTime">Time into string</param>
        /// <param name="moves">The amount of moves</param>
        /// <param name="init">The user's initials</param>
        public void LoadIt(string sTime, int moves, string init) // Loads the info needed in the leaderboard
        {            
            this.sTime = sTime;
            this.moves = moves;
            this.initials = init;
        }

        public void CalculateScore() // Calculates the score (900 - moves) + (600 - time)
        {
            this.time = Convert.ToInt32(this.sTime);            
            this.score = (300 - this.moves) + (600 - this.time);
        }

    }
}
