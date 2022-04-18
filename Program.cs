/*Program.cs
 *Made by Chris Meier and Zach Ascoli 
 *Completed on 4/22/10
 *Copyright (c) WI, 2010
 */
using System;

namespace WindowsGame3
{
    static class Program
    {

        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}

