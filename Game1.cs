/*Game1.cs
 *Made by Chris Meier and Zach Ascoli 
 *Completed on 4/29/10
 *Copyright (c) WI, 2010
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using WindowsGame3.ImageF;
using WindowsGame3.Stacks;

namespace WindowsGame3
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields
        GraphicsDeviceManager graphics;
        GraphicsDevice graphDev;
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont font;
        bool helpHovering;
        bool highHovering;
        bool quitHovering,
            resetHovering;
        bool hoverBeep;
        bool oldbeep;
        bool playSound;
        public Texture2D bottom,
            nail,
            nail2,
            nail3,
            piece1,
            piece2,
            piece3,
            piece4,
            piece5,
            piece6,
            help,
            highscores,
            bQuit,
            bReset,
            helpScreen,
            leaderboard,
            winner;
        public Texture2D helpO;
        public Texture2D highscoresO;
        public Texture2D bQuitO;
        public Texture2D bResetO;
        string sTime,
            textString;
        bool gameIsAllowed;
        
        

        Image image,
            image2,
            image3,
            image4,
            image5,
            image6,
            image7,
            image8,
            image9n,
            image10n,
            imageHelp,
            imageHighscores,
            imageQuit,
            imageReset,
            imageHelpscreen,
            imageLeaderboard,
            imagewinner,
            imageHelpO,
            imageHighscoresO,
            imageQuitO,
            imageResetO;
        Rectangle rectangle,
            rectangle2,
            rectangle3,
            rectangle4,
            rectangle5,
            rectangle6,
            rectangle7,
            rectangle8,
            rectangleButton,
            rectangleHighScores,
            recHelpScreen;            
        Vector2 bottomPos,
            nailPos,
            nailPos2,
            nailPos3,
            piece1Pos,
            piece2Pos,
            piece3Pos,
            piece4Pos,
            piece5Pos,
            piece6Pos,
            helpPos,
            helpScreenPos,
            highscoresPos,
            quitPos,
            resetPos,
            bottomOr,
            nailOr,
            piece1Or,
            piece2Or,
            piece3Or,
            piece4Or,
            piece5Or,
            piece6Or,            
            highscoresOr,
            quitOr;
        bool helpScreenOpen,
            leaderboardOpen;
        int musicCount;

        Color color;
        float fFloat;        
        double winTimer;

        MouseState oldMouse;

        
        StackCount stack1,
            stack2,
            stack3;
        Vector2 timeVec,
            movesVec;
        double timer;
        bool gameHasStarted;
        int moves;
        MouseState mouseState;
        KeyboardState keyb;
        LeaderBoardClass[] lBoardClass = new LeaderBoardClass[6];        
        bool went = false;
        AudioEngine audioEngine;
        WaveBank waveBank;
        WaveBank waveBank2;
        WaveBank waveBank3; 
        SoundBank soundBank;
        SoundBank soundBank2;
        SoundBank soundBank3;
        string[] spacing = new string[5];
        string[] spacing2 = new string[5];
        DataHandling dataHandling;
        KeyboardState oldKeyboardState;
        KeyboardState currentKeyBState;
        

        #endregion

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphDev = graphics.GraphicsDevice;
            this.content = new ContentManager(this.Services);
            this.image = new Image();
            this.image2 = new Image();
            this.image3 = new Image();
            this.image4 = new Image();
            this.image5 = new Image();
            this.image6 = new Image();
            this.image7 = new Image();
            this.image8 = new Image();
            this.image10n = new Image();
            this.image9n = new Image();
            this.stack1 = new StackCount();
            this.stack2 = new StackCount();
            this.stack3 = new StackCount();
            this.timeVec = new Vector2(160, 577.3f);
            this.movesVec = new Vector2(630, 577.3f);
            this.timer = 0.0f;
            this.gameHasStarted = false;
            this.moves = 0;
            this.imageHelp = new Image();
            this.imageHighscores = new Image();
            this.imageQuit = new Image();
            this.imageReset = new Image();
            this.imageHelpscreen = new Image();
            this.imageLeaderboard = new Image();
            this.imagewinner = new Image();
            this.imageHelpO = new Image();
            this.imageHighscoresO = new Image();
            this.imageQuitO = new Image();
            this.imageResetO = new Image();
            dataHandling = new DataHandling();
            for(int i = 0; i < 6; i++)
            {
                this.lBoardClass[i] = new LeaderBoardClass();
            }
            
            this.went = false;
            this.textString = "";
            this.gameIsAllowed = false;
            
            Content.RootDirectory = "Content";
        } //Calls the constructors
        
        protected override void Initialize()
        {
            this.LoadGraphicsContent(true);
            this.image.Initialize();
            this.image2.Initialize();
            this.image3.Initialize();
            this.image4.Initialize();
            this.image5.Initialize();
            this.image6.Initialize();
            this.image7.Initialize();
            this.image8.Initialize();
            this.image9n.Initialize();
            this.image10n.Initialize();
            this.imageHelp.Initialize();
            this.imageHighscores.Initialize();
            this.imageQuit.Initialize();
            this.imageReset.Initialize();
            this.imageHelpscreen.Initialize();
            this.imageLeaderboard.Initialize();
            this.imagewinner.Initialize();
            this.imageHelpO.Initialize();
            this.imageHighscoresO.Initialize();
            this.imageQuitO.Initialize();
            this.imageResetO.Initialize();
            IsMouseVisible = true;
            mouseState = new MouseState();
            oldMouse = new MouseState();
            this.musicCount = 1;

            
            this.stack1.Piece1(true);
            this.stack1.Piece2(true);
            this.stack1.Piece3(true);
            this.stack1.Piece4(true);
            this.stack1.Piece5(true);
            this.stack1.Piece6(true);

            this.stack2.Piece1(false);
            this.stack2.Piece2(false);
            this.stack2.Piece3(false);
            this.stack2.Piece4(false);
            this.stack2.Piece5(false);
            this.stack2.Piece6(false);

            this.stack3.Piece1(false);
            this.stack3.Piece2(false);
            this.stack3.Piece3(false);
            this.stack3.Piece4(false);
            this.stack3.Piece5(false);
            this.stack3.Piece6(false);

            

            base.Initialize();
        } //Initializes all classes
        
        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                this.spriteBatch = new SpriteBatch(this.graphics.GraphicsDevice);
                this.graphDev = graphics.GraphicsDevice;
                graphics.PreferredBackBufferWidth = 756;
                graphics.PreferredBackBufferHeight = 756;
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
                font = Content.Load<SpriteFont>("font");

                oldbeep = false;                

                int screenWidth = graphDev.PresentationParameters.BackBufferWidth;
                int screenHeight = graphDev.PresentationParameters.BackBufferHeight;

                this.rectangle = new Rectangle(0, 0, screenWidth, screenHeight);
                this.rectangle2 = new Rectangle(0, 0, 25, 450); //Nail
                this.rectangle3 = new Rectangle(0, 0, 140, 60); //1
                this.rectangle4 = new Rectangle(0, 0, 165, 60); //2
                this.rectangle5 = new Rectangle(0, 0, 195, 60); //3
                this.rectangle6 = new Rectangle(0, 0, 220, 60); //4
                this.rectangle7 = new Rectangle(0, 0, 250, 60); //5
                this.rectangle8 = new Rectangle(0, 0, 275, 60); //6               
                this.rectangleButton = new Rectangle(0, 0, 140, 60);
                this.rectangleHighScores = new Rectangle(0, 0, 150, 60);
                this.recHelpScreen = new Rectangle(0, 0, 504, 504);                


                this.color = Color.White;
                this.fFloat = 0.0f;

                this.bottomPos = new Vector2(0f, 550f);
                this.nailPos = new Vector2(100f, 500f);
                this.nailPos2 = new Vector2(300f, 500f);
                this.nailPos3 = new Vector2(500f, 500f);
                this.piece1Pos = new Vector2(145f, 242f);
                this.piece2Pos = new Vector2(145f, 302f);
                this.piece3Pos = new Vector2(145f, 362f);
                this.piece4Pos = new Vector2(145f, 422f);
                this.piece5Pos = new Vector2(145f, 482f);
                this.piece6Pos = new Vector2(145f, 542f);
                this.highscoresPos = new Vector2(240, 670);
                this.quitPos = new Vector2(580, 670);
                this.resetPos = new Vector2(60, 670);
                this.helpScreenPos = new Vector2(0, 0);
                this.helpPos = new Vector2(415, 670);

                this.bottomOr = new Vector2(0f, 50f);
                this.nailOr = new Vector2(13f, 450f);
                this.piece1Or = new Vector2(70f, 60f);
                this.piece2Or = new Vector2(82.5f, 60f);
                this.piece3Or = new Vector2(97.5f, 60f);
                this.piece4Or = new Vector2(110f, 60f);
                this.piece5Or = new Vector2(125f, 60f);
                this.piece6Or = new Vector2(137.5f, 60f);
                this.highscoresOr = new Vector2(0, 0);
                this.quitOr = Vector2.Zero;

                try
                {
                    dataHandling.Load();

                    for (int i = 0; i < 5; i++)
                    {
                        lBoardClass[i].score = dataHandling.score[i];
                        lBoardClass[i].moves = dataHandling.moves[i];
                        lBoardClass[i].time = dataHandling.time[i];
                        lBoardClass[i].initials = dataHandling.inits[i];
                    }
                }
                catch (Exception ex) {} 
                this.helpScreenOpen = false;
                this.leaderboardOpen = false;
                

                #region (Textures)
                this.bottom = Content.Load<Texture2D>("Background");
                this.image.LoadGraphicsContent(this.spriteBatch, this.bottom, new Vector2(0,0), this.rectangle, this.color, this.fFloat, new Vector2(0,0));

                this.piece1 = Content.Load<Texture2D>("Piece1");
                this.image3.LoadGraphicsContent(this.spriteBatch, this.piece1, this.piece1Pos, this.rectangle3, this.color, this.fFloat, this.piece1Or);

                this.piece2 = Content.Load<Texture2D>("Piece2");
                this.image4.LoadGraphicsContent(this.spriteBatch, this.piece2, this.piece2Pos, this.rectangle4, this.color, this.fFloat, this.piece2Or);

                this.piece3 = Content.Load<Texture2D>("Piece3");
                this.image5.LoadGraphicsContent(this.spriteBatch, this.piece3, this.piece3Pos, this.rectangle5, this.color, this.fFloat, this.piece3Or);

                this.piece4 = Content.Load<Texture2D>("Piece4");
                this.image6.LoadGraphicsContent(this.spriteBatch, this.piece4, this.piece4Pos, this.rectangle6, this.color, this.fFloat, this.piece4Or);

                this.piece5 = Content.Load<Texture2D>("Piece5");
                this.image7.LoadGraphicsContent(this.spriteBatch, this.piece5, this.piece5Pos, this.rectangle7, this.color, this.fFloat, this.piece5Or);

                this.piece6 = Content.Load<Texture2D>("Piece6");
                this.image8.LoadGraphicsContent(this.spriteBatch, this.piece6, this.piece6Pos, this.rectangle8, this.color, this.fFloat, this.piece6Or);

                this.highscores = Content.Load<Texture2D>("HIGHSCORES");
                this.imageHighscores.LoadGraphicsContent(this.spriteBatch, this.highscores, this.highscoresPos, this.rectangleHighScores, this.color, this.fFloat, this.highscoresOr);

                this.bQuit = Content.Load<Texture2D>("QUIT");
                this.imageQuit.LoadGraphicsContent(this.spriteBatch, this.bQuit, this.quitPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);

                this.bReset = Content.Load<Texture2D>("RESET");
                this.imageReset.LoadGraphicsContent(this.spriteBatch, this.bReset, this.resetPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);

                this.helpScreen = Content.Load<Texture2D>("helpscreen2");
                this.imageHelpscreen.LoadGraphicsContent2(this.spriteBatch, this.helpScreen, this.helpScreenPos, this.recHelpScreen, this.color, this.fFloat, this.quitOr, new Vector2(1.5f,1.5f));

                this.help = Content.Load<Texture2D>("HELP");
                this.imageHelp.LoadGraphicsContent(this.spriteBatch, this.help, this.helpPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);

                this.leaderboard = Content.Load<Texture2D>("Leaderboard");
                this.imageLeaderboard.LoadGraphicsContent(this.spriteBatch, this.leaderboard, new Vector2(0, 0), this.rectangle, this.color, this.fFloat, new Vector2(0, 0));

                this.winner = Content.Load<Texture2D>("win");
                this.imagewinner.LoadGraphicsContent(this.spriteBatch, this.winner, new Vector2(0, 0), this.rectangle, this.color, this.fFloat, new Vector2(0, 0));

                this.helpO = Content.Load<Texture2D>("HELPO");
                this.imageHelpO.LoadGraphicsContent(this.spriteBatch, this.helpO, this.helpPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);

                this.highscoresO = Content.Load<Texture2D>("HIGHSCORESO");
                this.imageHighscoresO.LoadGraphicsContent(this.spriteBatch, this.highscoresO, this.highscoresPos, this.rectangleHighScores, this.color, this.fFloat, this.highscoresOr);

                this.bQuitO = Content.Load<Texture2D>("QUITO");
                this.imageQuitO.LoadGraphicsContent(this.spriteBatch, this.bQuitO, this.quitPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);

                this.bResetO = Content.Load<Texture2D>("RESETO");
                this.imageResetO.LoadGraphicsContent(this.spriteBatch, this.bResetO, this.resetPos, this.rectangleButton, this.color, this.fFloat, this.quitOr);
                #endregion

                #region (Audio)
                audioEngine = new AudioEngine("Content/SoundEffects2.xgs");
                waveBank = new WaveBank(audioEngine, "Content/myWaveBank.xwb");
                waveBank2 = new WaveBank(audioEngine, "Content/myWaveBank2.xwb");
                waveBank3 = new WaveBank(audioEngine, "Content/WinWaveBank.xwb");
                soundBank = new SoundBank(audioEngine, "Content/mySoundBank.xsb");
                soundBank2 = new SoundBank(audioEngine, "Content/SoundBank.xsb");
                soundBank3 = new SoundBank(audioEngine, "Content/WinBank.xsb");
                #endregion

                soundBank2.PlayCue("Ambient2");
                
            }
        } //Loads the Images and sets them to objects
        
        protected override void UnloadGraphicsContent(bool UnloadAllContent)
        {            
            if (UnloadAllContent)
            {
                this.content.Unload();
            }
        }  

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (gameIsAllowed)
            {
                ProcessKeyboard();
            }
            this.mouseState = Mouse.GetState();
            
                BeepButton();

                OrangeHover();

            Buttons();

            if (helpScreenOpen)
            {
                keyb = Keyboard.GetState();
                if (keyb.IsKeyDown(Keys.Enter)) // Closes the help screen
                {
                    this.helpScreenOpen = false;
                }
            }

            if (leaderboardOpen)
            {
                keyb = Keyboard.GetState();
                if (keyb.IsKeyDown(Keys.Enter))
                {
                    this.leaderboardOpen = false;
                }
            }

            if (gameHasStarted)
            {
                timer += gameTime.ElapsedGameTime.TotalMilliseconds;                
            }
            
            if (GameWin())
            {
                
                winTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
                gameHasStarted = false;
                lBoardClass[5].LoadIt(this.sTime, this.moves, this.textString);
                lBoardClass[5].CalculateScore();
                this.HighScoreCheck();
                if (musicCount != 0)
                {
                    for (int i = 0; i < musicCount; i++)
                    {
                        soundBank3.PlayCue("TheMonstersWithout");
                        musicCount = 0;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    dataHandling.LoadStuff(i, lBoardClass[i].score, lBoardClass[i].time, lBoardClass[i].moves, lBoardClass[i].initials);
                }
                dataHandling.Save();                
                
            }
            
            this.oldMouse = this.mouseState;
            sTime = ((int)timer / 1000).ToString();

            UpdateKey();

            audioEngine.Update();

            base.Update(gameTime);
        } //Calls the Update Methods
       
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            this.spriteBatch.Draw(this.bottom, this.rectangle, Color.White);
            this.image3.Draw(gameTime);
            this.image4.Draw(gameTime);
            this.image5.Draw(gameTime);
            this.image6.Draw(gameTime);
            this.image7.Draw(gameTime);
            this.image8.Draw(gameTime);
            this.spriteBatch.DrawString(font, ((int)timer / 1000).ToString(), timeVec, Color.Goldenrod);
            this.spriteBatch.DrawString(font, moves.ToString(), movesVec, Color.Goldenrod);
            this.imageHighscores.Draw(gameTime);
            this.imageQuit.Draw(gameTime);
            this.imageReset.Draw(gameTime);
            this.imageHelp.Draw(gameTime);
            if (!gameIsAllowed)
            {
                this.spriteBatch.DrawString(font, "ENTER \nYOUR \nINITIALS \nTO PLAY: " + textString, new Vector2(188, 25), new Color(245, 173, 1));
            }

            if (GameWin())
            {                
                    this.imagewinner.Draw(gameTime);
            }

            if (helpScreenOpen)
            {
                this.imageHelpscreen.Draw(gameTime);
            }
            if (helpHovering)
            {
                this.imageHelpO.Draw(gameTime);
            }
            if (highHovering)
            {
                this.imageHighscoresO.Draw(gameTime);
            }
            if (quitHovering)
            {
                this.imageQuitO.Draw(gameTime);
            }
            if (resetHovering)
            {
                this.imageResetO.Draw(gameTime);
            }


            #region (leaderBoardOpen)
            if (leaderboardOpen)
            {

                for (int i = 0; i < 5; i++)
                {
                    if (lBoardClass[i].score < 10)
                    {
                        spacing[i] = "              ";
                    }
                    else if (lBoardClass[i].score > 99)
                    {
                        spacing[i] = "           ";
                    }
                    else if (lBoardClass[i].score > 9 && lBoardClass[i].score < 100)
                    {
                        spacing[i] = "            ";
                    }

                    if (lBoardClass[i].time < 10) //one-digit
                    {
                        spacing2[i] = "            ";
                    }
                    else if (lBoardClass[i].score > 99) //3-digit
                    {
                        spacing2[i] = "        ";
                    }
                    else if (lBoardClass[i].score > 9 && lBoardClass[i].score < 100)//2-digit
                    {
                        spacing2[i] = "           ";
                    }
                    
                }
                this.imageLeaderboard.Draw(gameTime);
                this.spriteBatch.DrawString(font, lBoardClass[0].initials + "    " + lBoardClass[0].score.ToString() + spacing[0] + lBoardClass[0].time.ToString() + spacing2[0] + lBoardClass[0].moves.ToString(), new Vector2(200, 140), Color.Black);
                this.spriteBatch.DrawString(font, lBoardClass[1].initials + "    " + lBoardClass[1].score.ToString() + spacing[1] + lBoardClass[1].time.ToString() + spacing2[1] + lBoardClass[1].moves.ToString(), new Vector2(200, 250), Color.Black);
                this.spriteBatch.DrawString(font, lBoardClass[2].initials + "    " + lBoardClass[2].score.ToString() + spacing[2] + lBoardClass[2].time.ToString() + spacing2[2] + lBoardClass[2].moves.ToString(), new Vector2(200, 358), Color.Black);
                this.spriteBatch.DrawString(font, lBoardClass[3].initials + "    " + lBoardClass[3].score.ToString() + spacing[3] + lBoardClass[3].time.ToString() + spacing2[3] + lBoardClass[3].moves.ToString(), new Vector2(200, 466), Color.Black);
                this.spriteBatch.DrawString(font, lBoardClass[4].initials + "    " + lBoardClass[4].score.ToString() + spacing[4] + lBoardClass[4].time.ToString() + spacing2[4] + lBoardClass[4].moves.ToString(), new Vector2(200, 575), Color.Black);
                this.spriteBatch.DrawString(font, "Press \"R\" to reset your leaderboards", new Vector2(100,20), new Color(255, 173, 1));
            }
            #endregion
            
            this.spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        } //Draws all Images

        #region (Process Keyboards)

        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            
            if (keybState.IsKeyDown(Keys.R))
            {
                for (int i = 0; i < 5; i++)
                {
                    lBoardClass[i].score = 0;
                    lBoardClass[i].moves = 0;
                    lBoardClass[i].time = 0;
                    lBoardClass[i].initials = "XX";
                    for (int c = 0; c < 5; c++)
                    {
                        dataHandling.LoadStuff(c, lBoardClass[c].score, lBoardClass[c].time, lBoardClass[c].moves, lBoardClass[c].initials);
                    }
                    dataHandling.Save();
                }
            }

            if (keybState.IsKeyDown(Keys.D1)) //Piece 1
            {
                ProcessKeyboard1();
            }
            if (keybState.IsKeyDown(Keys.D2)) //Piece 2
            {
                ProcessKeyboard2();
            }
            if (keybState.IsKeyDown(Keys.D3)) //Piece 3
            {
                ProcessKeyboard3();
            }
            if (keybState.IsKeyDown(Keys.D4)) //Piece 4
            {
                ProcessKeyboard4();
            }
            if (keybState.IsKeyDown(Keys.D5)) //Piece 5
            {
                ProcessKeyboard5();
            }
            if (keybState.IsKeyDown(Keys.D6)) //Piece 6
            {
                ProcessKeyboard6();
            }

            
            
        }//Decides what piece the user is holding down        

        private void ProcessKeyboard1()
        {
            if (!GameWin())
            {
            KeyboardState keybState = Keyboard.GetState();            

            if (keybState.IsKeyDown(Keys.K))
            {
                if (stack2.piece1IsThere == false) //If the key they are holding down is K and there is no smaller piece, then draw the image on that stack, record that the piece is now there, and change the old location to false
                {
                    this.piece1Pos = new Vector2(379f, 242f);
                    this.image3.LoadGraphicsContent(this.spriteBatch, this.piece1, this.piece1Pos, this.rectangle3, this.color, this.fFloat, this.piece1Or);
                    stack2.piece1IsThere = true;
                    this.gameHasStarted = true;
                    this.moves++;
                    if (stack1.piece1IsThere == true)
                    {
                        stack1.piece1IsThere = false;
                    }
                    else if (stack3.piece1IsThere == true)
                    {
                        stack3.piece1IsThere = false;
                    }
                    soundBank.PlayCue("Sound");
                }
            }
            else if (keybState.IsKeyDown(Keys.J))
            {
                if (stack1.piece1IsThere == false)
                {
                    this.piece1Pos = new Vector2(145f, 242f);
                    this.image3.LoadGraphicsContent(this.spriteBatch, this.piece1, this.piece1Pos, this.rectangle3, this.color, this.fFloat, this.piece1Or);
                    stack1.piece1IsThere = true;
                    this.gameHasStarted = true;
                    this.moves++;
                    if (stack2.piece1IsThere == true)
                    {
                        stack2.piece1IsThere = false;
                    }
                    else if (stack3.piece1IsThere == true)
                    {
                        stack3.piece1IsThere = false;
                    }
                    soundBank.PlayCue("Sound");
                }
            }
            else if (keybState.IsKeyDown(Keys.L))
            {
                if (stack3.piece1IsThere == false)
                {
                    this.piece1Pos = new Vector2(613f, 242f);
                    this.image3.LoadGraphicsContent(this.spriteBatch, this.piece1, this.piece1Pos, this.rectangle3, this.color, this.fFloat, this.piece1Or);
                    stack3.piece1IsThere = true;
                    this.gameHasStarted = true;
                    this.moves++;
                    if (stack1.piece1IsThere == true)
                    {
                        stack1.piece1IsThere = false;
                    }
                    else if (stack2.piece1IsThere == true)
                    {
                        stack2.piece1IsThere = false;
                    }
                    soundBank.PlayCue("Sound");
                }

            }
                }
        }//If the key they are holding is 1, then finds out what stack they want

        private void ProcessKeyboard2()
        {
            if (!GameWin())
            {
                KeyboardState keybState = Keyboard.GetState();

                if (keybState.IsKeyDown(Keys.K))
                {
                    if ((stack1.piece2IsThere == true && stack1.piece1IsThere == false) || (stack3.piece2IsThere == true && stack3.piece1IsThere == false))
                    {
                        if (stack2.piece1IsThere == false)
                        {
                            this.piece2Pos = new Vector2(379f, 302f);
                            this.image4.LoadGraphicsContent(this.spriteBatch, this.piece2, this.piece2Pos, this.rectangle4, this.color, this.fFloat, this.piece2Or);
                            stack2.piece2IsThere = true;
                            this.moves++;
                            if (stack1.piece2IsThere == true)
                            {
                                stack1.piece2IsThere = false;
                            }
                            else if (stack3.piece2IsThere == true)
                            {
                                stack3.piece2IsThere = false;
                            }
                            soundBank.PlayCue("Sound1");
                        }

                    }
                }
                else if (keybState.IsKeyDown(Keys.J))
                {
                    if ((stack2.piece2IsThere == true && stack2.piece1IsThere == false) || (stack3.piece2IsThere == true && stack3.piece1IsThere == false))
                    {
                        if (stack1.piece1IsThere == false)
                        {
                            this.piece2Pos = new Vector2(145f, 302f);
                            this.image4.LoadGraphicsContent(this.spriteBatch, this.piece2, this.piece2Pos, this.rectangle4, this.color, this.fFloat, this.piece2Or);
                            stack1.piece2IsThere = true;
                            this.moves++;
                            if (stack2.piece2IsThere == true)
                            {
                                stack2.piece2IsThere = false;
                            }
                            else if (stack3.piece2IsThere == true)
                            {
                                stack3.piece2IsThere = false;
                            }
                            soundBank.PlayCue("Sound1");
                        }

                    }
                }
                else if (keybState.IsKeyDown(Keys.L))
                {
                    if ((stack2.piece2IsThere == true && stack2.piece1IsThere == false) || (stack1.piece2IsThere == true && stack1.piece1IsThere == false))
                    {
                        if (stack3.piece1IsThere == false)
                        {
                            this.piece2Pos = new Vector2(613f, 302f);
                            this.image4.LoadGraphicsContent(this.spriteBatch, this.piece2, this.piece2Pos, this.rectangle4, this.color, this.fFloat, this.piece2Or);
                            stack3.piece2IsThere = true;
                            this.moves++;
                            if (stack1.piece2IsThere == true)
                            {
                                stack1.piece2IsThere = false;
                            }
                            else if (stack2.piece2IsThere == true)
                            {
                                stack2.piece2IsThere = false;
                            }
                            soundBank.PlayCue("Sound1");
                        }
                    }
                }
            }
        } // If the key they are holding is 2 AND piece 1 is not above it, then...

        private void ProcessKeyboard3()
        {
            if (!GameWin())
            {
                KeyboardState keybState = Keyboard.GetState();

                if (keybState.IsKeyDown(Keys.K))
                {
                    if ((stack1.piece3IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false) ||
                        (stack3.piece3IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false))
                    {
                        if (stack2.piece1IsThere == false && stack2.piece2IsThere == false)
                        {
                            this.piece3Pos = new Vector2(379f, 362f);
                            this.image5.LoadGraphicsContent(this.spriteBatch, this.piece3, this.piece3Pos, this.rectangle5, this.color, this.fFloat, this.piece3Or);
                            stack2.piece3IsThere = true;
                            this.moves++;
                            if (stack1.piece3IsThere == true)
                            {
                                stack1.piece3IsThere = false;
                            }
                            else if (stack3.piece3IsThere == true)
                            {
                                stack3.piece3IsThere = false;
                            }
                            soundBank.PlayCue("Sound2");
                        }
                    }

                }
                else if (keybState.IsKeyDown(Keys.J))
                {
                    if ((stack2.piece3IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false) || //On stack 2, If Piece 3 is there and piece 1 & 2 is not there
                        (stack3.piece3IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false)) //On stack 3, If Piece 3 is there and piece 1 & 2 is not there
                    {
                        if (stack1.piece1IsThere == false && stack1.piece2IsThere == false)
                        {
                            this.piece3Pos = new Vector2(145f, 362f);
                            this.image5.LoadGraphicsContent(this.spriteBatch, this.piece3, this.piece3Pos, this.rectangle5, this.color, this.fFloat, this.piece3Or);
                            stack1.piece3IsThere = true;
                            this.moves++;
                            if (stack2.piece3IsThere == true)
                            {
                                stack2.piece3IsThere = false;
                            }
                            else if (stack3.piece3IsThere == true)
                            {
                                stack3.piece3IsThere = false;
                            }
                            soundBank.PlayCue("Sound2");
                        }
                    }

                }
                else if (keybState.IsKeyDown(Keys.L))
                {
                    if ((stack1.piece3IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false) ||
                        (stack2.piece3IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false))
                    {
                        if (stack3.piece1IsThere == false && stack3.piece2IsThere == false)
                        {
                            this.piece3Pos = new Vector2(613f, 362f);
                            this.image5.LoadGraphicsContent(this.spriteBatch, this.piece3, this.piece3Pos, this.rectangle5, this.color, this.fFloat, this.piece3Or);
                            stack3.piece3IsThere = true;
                            this.moves++;
                            if (stack1.piece3IsThere == true)
                            {
                                stack1.piece3IsThere = false;
                            }
                            else if (stack3.piece3IsThere == true)
                            {
                                stack2.piece3IsThere = false;
                            }
                            soundBank.PlayCue("Sound2");
                        }
                    }
                }
            }
        }

        private void ProcessKeyboard4()
        {
            if (!GameWin())
            {
                KeyboardState keybState = Keyboard.GetState();

                if (keybState.IsKeyDown(Keys.K))
                {
                    if ((stack1.piece4IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false) ||
                        (stack3.piece4IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false))
                    {
                        if (stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false)
                        {
                            this.piece4Pos = new Vector2(379f, 422f);
                            this.image6.LoadGraphicsContent(this.spriteBatch, this.piece4, this.piece4Pos, this.rectangle6, this.color, this.fFloat, this.piece4Or);
                            stack2.piece4IsThere = true;
                            this.moves++;
                            if (stack1.piece4IsThere == true)
                            {
                                stack1.piece4IsThere = false;
                            }
                            else if (stack3.piece4IsThere == true)
                            {
                                stack3.piece4IsThere = false;
                            }
                            soundBank.PlayCue("Sound3");
                        }
                    }
                }
                else if (keybState.IsKeyDown(Keys.J))
                {
                    if ((stack2.piece4IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false) ||
                        (stack3.piece4IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false))
                    {
                        if (stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false)
                        {
                            this.piece4Pos = new Vector2(145f, 422f);
                            this.image6.LoadGraphicsContent(this.spriteBatch, this.piece4, this.piece4Pos, this.rectangle6, this.color, this.fFloat, this.piece4Or);
                            stack1.piece4IsThere = true;
                            this.moves++;
                            if (stack2.piece4IsThere == true)
                            {
                                stack2.piece4IsThere = false;
                            }
                            else if (stack3.piece4IsThere == true)
                            {
                                stack3.piece4IsThere = false;
                            }
                            soundBank.PlayCue("Sound3");
                        }
                    }
                }
                else if (keybState.IsKeyDown(Keys.L))
                {
                    if ((stack1.piece4IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false) ||
                        (stack2.piece4IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false))
                    {
                        if (stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false)
                        {
                            this.piece4Pos = new Vector2(613f, 422f);
                            this.image6.LoadGraphicsContent(this.spriteBatch, this.piece4, this.piece4Pos, this.rectangle6, this.color, this.fFloat, this.piece4Or);
                            stack3.piece4IsThere = true;
                            this.moves++;
                            if (stack1.piece4IsThere == true)
                            {
                                stack1.piece4IsThere = false;
                            }
                            else if (stack2.piece4IsThere == true)
                            {
                                stack2.piece4IsThere = false;
                            }
                            soundBank.PlayCue("Sound3");
                        }
                    }

                }
            }
        }

        private void ProcessKeyboard5()
        {
            if (!GameWin())
            {
                KeyboardState keybState = Keyboard.GetState();

                if (keybState.IsKeyDown(Keys.K))
                {
                    if ((stack1.piece5IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false) ||
                        (stack3.piece5IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false))
                    {
                        if (stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false)
                        {
                            this.piece5Pos = new Vector2(379f, 482f);
                            this.image7.LoadGraphicsContent(this.spriteBatch, this.piece5, this.piece5Pos, this.rectangle7, this.color, this.fFloat, this.piece5Or);
                            stack2.piece5IsThere = true;
                            this.moves++;
                            if (stack1.piece5IsThere == true)
                            {
                                stack1.piece5IsThere = false;
                            }
                            else if (stack3.piece5IsThere == true)
                            {
                                stack3.piece5IsThere = false;
                            }
                            soundBank.PlayCue("Sound4");
                        }
                    }
                }
                else if (keybState.IsKeyDown(Keys.J))
                {
                    if ((stack2.piece5IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false) ||
                        (stack3.piece5IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false))
                    {
                        if (stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false)
                        {
                            this.piece5Pos = new Vector2(145f, 482f);
                            this.image7.LoadGraphicsContent(this.spriteBatch, this.piece5, this.piece5Pos, this.rectangle7, this.color, this.fFloat, this.piece5Or);
                            stack1.piece5IsThere = true;
                            this.moves++;
                            if (stack2.piece5IsThere == true)
                            {
                                stack2.piece5IsThere = false;
                            }
                            else if (stack3.piece5IsThere == true)
                            {
                                stack3.piece5IsThere = false;
                            }
                            soundBank.PlayCue("Sound4");
                        }
                    }
                }
                else if (keybState.IsKeyDown(Keys.L))
                {
                    if ((stack1.piece5IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false) ||
                        (stack2.piece5IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false))
                    {
                        if (stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false)
                        {
                            this.piece5Pos = new Vector2(613f, 482f);
                            this.image7.LoadGraphicsContent(this.spriteBatch, this.piece5, this.piece5Pos, this.rectangle7, this.color, this.fFloat, this.piece5Or);
                            stack3.piece5IsThere = true;
                            this.moves++;
                            if (stack1.piece5IsThere == true)
                            {
                                stack1.piece5IsThere = false;
                            }
                            else if (stack2.piece5IsThere == true)
                            {
                                stack2.piece5IsThere = false;
                            }
                            soundBank.PlayCue("Sound4");
                        }
                    }

                }
            }
        }

        private void ProcessKeyboard6()
        {
            if (!GameWin())
            {
                KeyboardState keybState = Keyboard.GetState();

                if (keybState.IsKeyDown(Keys.K))//STACK 2
                {
                    if ((stack1.piece6IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false && stack1.piece5IsThere == false) ||
                        (stack3.piece6IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false && stack3.piece5IsThere == false))
                    {
                        if (stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false && stack2.piece5IsThere == false)
                        {
                            this.piece6Pos = new Vector2(379f, 542f);
                            this.image8.LoadGraphicsContent(this.spriteBatch, this.piece6, this.piece6Pos, this.rectangle8, this.color, this.fFloat, this.piece6Or);
                            stack2.piece6IsThere = true;
                            this.moves++;
                            if (stack1.piece6IsThere == true)
                            {
                                stack1.piece6IsThere = false;
                            }
                            else if (stack3.piece6IsThere == true)
                            {
                                stack3.piece6IsThere = false;
                            }
                            soundBank.PlayCue("Sound5");
                        }
                    }

                }
                else if (keybState.IsKeyDown(Keys.J))//STACK 1
                {
                    if ((stack2.piece6IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false && stack2.piece5IsThere == false) ||
                        (stack3.piece6IsThere == true && stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false && stack3.piece5IsThere == false))
                    {
                        if (stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false && stack1.piece5IsThere == false)
                        {
                            this.piece6Pos = new Vector2(145f, 542f);
                            this.image8.LoadGraphicsContent(this.spriteBatch, this.piece6, this.piece6Pos, this.rectangle8, this.color, this.fFloat, this.piece6Or);
                            stack1.piece6IsThere = true;
                            this.moves++;
                            if (stack2.piece6IsThere == true)
                            {
                                stack2.piece6IsThere = false;
                            }
                            else if (stack3.piece6IsThere == true)
                            {
                                stack3.piece6IsThere = false;
                            }
                            soundBank.PlayCue("Sound5");
                        }
                    }
                }
                else if (keybState.IsKeyDown(Keys.L))//STACK 3
                {
                    if ((stack1.piece6IsThere == true && stack1.piece1IsThere == false && stack1.piece2IsThere == false && stack1.piece3IsThere == false && stack1.piece4IsThere == false && stack1.piece5IsThere == false) ||
                        (stack2.piece6IsThere == true && stack2.piece1IsThere == false && stack2.piece2IsThere == false && stack2.piece3IsThere == false && stack2.piece4IsThere == false && stack2.piece5IsThere == false))
                    {
                        if (stack3.piece1IsThere == false && stack3.piece2IsThere == false && stack3.piece3IsThere == false && stack3.piece4IsThere == false && stack3.piece5IsThere == false)
                        {
                            this.piece6Pos = new Vector2(613f, 542f);
                            this.image8.LoadGraphicsContent(this.spriteBatch, this.piece6, this.piece6Pos, this.rectangle8, this.color, this.fFloat, this.piece6Or);
                            stack3.piece6IsThere = true;
                            this.moves++;
                            if (stack1.piece6IsThere == true)
                            {
                                stack1.piece6IsThere = false;
                            }
                            else if (stack2.piece6IsThere == true)
                            {
                                stack2.piece6IsThere = false;
                            }
                            soundBank.PlayCue("Sound5");
                        }
                    }
                }
            }
        }

        #endregion

        private bool GameWin()
        {
            bool gameWin = false;
            if ((stack2.piece1IsThere && stack2.piece2IsThere && stack2.piece3IsThere &&
                stack2.piece4IsThere && stack2.piece5IsThere && stack2.piece6IsThere) ||
                (stack3.piece1IsThere && stack3.piece2IsThere && stack3.piece3IsThere &&
                stack3.piece4IsThere && stack3.piece5IsThere && stack3.piece6IsThere))
            {
                gameWin = true;
                
                return gameWin;
            }
            else
            {
                return gameWin;
            }
            
        } // Checks to see if the game has finished. It will return a bool value.

        private void Buttons()
        {
            mouseState = Mouse.GetState();

            if ((mouseState.LeftButton == ButtonState.Pressed) && (oldMouse.LeftButton == ButtonState.Released)) // if left-click is down and LAST updates left click was up, then...
            {
                if (!leaderboardOpen && !helpScreenOpen)
                {
                    #region (HighScores)
                    if (gameIsAllowed)
                    {
                        if (mouseState.X <= 390 && mouseState.Y <= 730 &&
                            mouseState.X >= 240 && mouseState.Y >= 670)
                        {
                            this.leaderboardOpen = true;
                        }
                    }
                    #endregion

                    #region (Quit)

                    if (mouseState.X <= 720 && mouseState.Y <= 730 &&
                        mouseState.X >= 580 && mouseState.Y >= 670)
                    {
                        this.Exit();
                    }
                    #endregion

                    #region (Reset)
                    if (gameIsAllowed)
                    {
                        if (mouseState.X <= 200 && mouseState.Y <= 730 &&
                            mouseState.X >= 60 && mouseState.Y >= 670)   //Reset Button
                        {

                            this.piece1Pos = new Vector2(145f, 242f);
                            this.piece2Pos = new Vector2(145f, 302f);
                            this.piece3Pos = new Vector2(145f, 362f);
                            this.piece4Pos = new Vector2(145f, 422f);
                            this.piece5Pos = new Vector2(145f, 482f);
                            this.piece6Pos = new Vector2(145f, 542f);

                            // Drawa the pieces back on stack 1
                            this.image3.LoadGraphicsContent(this.spriteBatch, this.piece1, this.piece1Pos, this.rectangle3, this.color, this.fFloat, this.piece1Or);
                            this.image4.LoadGraphicsContent(this.spriteBatch, this.piece2, this.piece2Pos, this.rectangle4, this.color, this.fFloat, this.piece2Or);
                            this.image5.LoadGraphicsContent(this.spriteBatch, this.piece3, this.piece3Pos, this.rectangle5, this.color, this.fFloat, this.piece3Or);
                            this.image6.LoadGraphicsContent(this.spriteBatch, this.piece4, this.piece4Pos, this.rectangle6, this.color, this.fFloat, this.piece4Or);
                            this.image7.LoadGraphicsContent(this.spriteBatch, this.piece5, this.piece5Pos, this.rectangle7, this.color, this.fFloat, this.piece5Or);
                            this.image8.LoadGraphicsContent(this.spriteBatch, this.piece6, this.piece6Pos, this.rectangle8, this.color, this.fFloat, this.piece6Or);

                            this.moves = 0;
                            this.gameHasStarted = false;
                            this.timer = 0.0f;
                            this.went = false;
                            this.winTimer = 0;
                            this.musicCount = 1;
                            gameIsAllowed = false;

                            // Resets the pieces database
                            this.stack1.Piece1(true);
                            this.stack1.Piece2(true);
                            this.stack1.Piece3(true);
                            this.stack1.Piece4(true);
                            this.stack1.Piece5(true);
                            this.stack1.Piece6(true);

                            this.stack2.Piece1(false);
                            this.stack2.Piece2(false);
                            this.stack2.Piece3(false);
                            this.stack2.Piece4(false);
                            this.stack2.Piece5(false);
                            this.stack2.Piece6(false);

                            this.stack3.Piece1(false);
                            this.stack3.Piece2(false);
                            this.stack3.Piece3(false);
                            this.stack3.Piece4(false);
                            this.stack3.Piece5(false);
                            this.stack3.Piece6(false);

                        }
                    }

                    #endregion

                    #region (Help)


                    if (mouseState.X <= 555 && mouseState.Y <= 730 &&
                        mouseState.X >= 415 && mouseState.Y >= 670)   //Help Button
                    {
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            helpScreenOpen = true;
                        }                        
                    }
                    

                    #endregion
                }

            }
            
            
            oldMouse = mouseState;
        } // Code for the buttons on-screen

        private void HighScoreCheck()
        {

            for (int i = 0; i < 5; i++)
            {
                // Checking to see if user's final score is > than i's final score
                if ((lBoardClass[5].score > lBoardClass[i].score) && !went)
                {
                    int y = 4; // [4] is the 5th place spot on the leaderboards
                    while (y != i) // While [4] does not equal the place that the user beat Ex: user beat 3rd place (array[2])
                    {
                        lBoardClass[y].score = lBoardClass[(y - 1)].score; // yth place = (y-1)th place Ex. 5th place's scores = 4th place's scores
                        lBoardClass[y].moves = lBoardClass[(y - 1)].moves;
                        lBoardClass[y].time = lBoardClass[(y - 1)].time;
                        lBoardClass[y].initials = lBoardClass[(y - 1)].initials;

                        y = (y - 1); // Drops down the the next place Ex. y is now 4th place.
                    }
                    // if user got 3rd place, then it will set old 3rd place's scores to the new higher 3rd place scores
                    lBoardClass[i].moves = lBoardClass[5].moves;
                    lBoardClass[i].time = lBoardClass[5].time;
                    lBoardClass[i].score = lBoardClass[5].score;
                    lBoardClass[i].initials = lBoardClass[5].initials;

                    went = true; // prevents from looping more than we need to
                }

            }
        } // Checks winner's score against the leaderboard scores (top 5)

        private void UpdateKey()
        {
            oldKeyboardState = currentKeyBState;
            currentKeyBState = Keyboard.GetState();

            Keys[] pressedKeys;
            pressedKeys = currentKeyBState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (oldKeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && textString.Length > 0) // backspace (only works if there are letters there)
                    {
                        textString = textString.Remove(textString.Length - 1, 1);
                    }
                    else if (key == Keys.Space && textString.Length < 2) // spacebar (only works if there aren't 2 letters)
                    {
                        textString = textString.Insert(textString.Length, " ");
                    }
                    else if (textString.Length < 2)
                    {
                        if (key.ToString().Length < 2) // Only lets 1 character string in. Otherwise, when you press Enter, it would actually write "Enter".
                        {
                            textString += key.ToString();
                        }
                    }
                    if (key == Keys.Enter && textString.Length == 2) // If user hits Enter and there are two initials, then the game can continue
                    {
                        gameIsAllowed = true;
                    }                
                }
            }
        } // Code that handles the user's initials for the leaderboards

        private void BeepButton()
        {
            if (!leaderboardOpen && !helpScreenOpen)
            {
                int x;

                if ((mouseState.X <= 555 && mouseState.Y <= 730 && // Help coordinates
                    mouseState.X >= 415 && mouseState.Y >= 670) ||
                    (mouseState.X <= 390 && mouseState.Y <= 730 && // HighScore coordinates
                     mouseState.X >= 240 && mouseState.Y >= 670) ||
                    (mouseState.X <= 720 && mouseState.Y <= 730 && // Quit button coordinates
                     mouseState.X >= 580 && mouseState.Y >= 670) ||
                    (mouseState.X <= 200 && mouseState.Y <= 730 && // Reset coordinates
                     mouseState.X >= 60 && mouseState.Y >= 670))
                {
                    hoverBeep = true;
                }
                else
                {
                    hoverBeep = false;
                }

                if ((hoverBeep) && !oldbeep)
                {
                    x = 1;
                    while (x == 1) // Makes it so that it beeps only once during hovering
                    {
                        soundBank.PlayCue("hoverSound");
                        x = 0;
                    }
                }

                oldbeep = hoverBeep;
            }
        }  // Code that handles the beeping when the user hovers over a button

        private void OrangeHover()
        {
            mouseState = Mouse.GetState();
            if (!leaderboardOpen && !helpScreenOpen) // Only do it if the leaderboards and help screen are not open
            {
                #region (Hovering)
                if ((mouseState.X <= 555 && mouseState.Y <= 730 &&
                    mouseState.X >= 415 && mouseState.Y >= 670))   //Help Button
                {
                    helpHovering = true;

                }
                else
                {
                    helpHovering = false;
                }

                if (mouseState.X <= 390 && mouseState.Y <= 730 && // High scores button
                    mouseState.X >= 240 && mouseState.Y >= 670) 
                {
                    highHovering = true;
                }
                else
                {
                    highHovering = false;
                }

                if (mouseState.X <= 720 && mouseState.Y <= 730 && // Quit button
                    mouseState.X >= 580 && mouseState.Y >= 670)
                {
                    this.quitHovering = true;
                }
                else
                {
                    this.quitHovering = false;
                }

                if (mouseState.X <= 200 && mouseState.Y <= 730 &&
                    mouseState.X >= 60 && mouseState.Y >= 670)   //Reset Button
                {
                    this.resetHovering = true;
                }
                else
                {
                    this.resetHovering = false;
                }
                #endregion
            }
            else
            {
                helpHovering = false; // If the leaderboards OR the help screen is open, then it's NEVER hovering over a button
            }
        } // Code that turns the buttons orange when the mose hovers over them
        
    }
}
