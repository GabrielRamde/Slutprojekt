using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int w;
        public static int h;

        private Texture2D background;
        private Vector2 backgroundpos = new Vector2(0, 0);

        private bool hasStarted = false, timerIsActive, gameIsPaused = false;
        float timer = 0;
        private SpriteFont font;

        private Spelare spelare;

        private List<Bas> gameObjects = new List<Bas>();

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //skärmstorlek på spelet
            h = graphics.PreferredBackBufferHeight = 1080;
            w = graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            timerIsActive = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D spelareTexture = Content.Load<Texture2D>("spelare");

            background = Content.Load<Texture2D>("spelplan"); // Bakgrund till spelet

            Texture2D hinderTexture = Content.Load<Texture2D>("hinder");

            font = Content.Load<SpriteFont>("File"); // Text för nedräkning

            spelare = new Spelare(spelareTexture, new Vector2(100, 500), new Point(70, 70));

            gameObjects.Add(new Hinder(hinderTexture, new Vector2(450, 50), new Point(100, 100)));
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(750, 50), new Point(100, 100)));
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(1050, 50), new Point(100, 100)));
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(1350, 50), new Point(100, 100)));
            gameObjects.Add(new Bas(hinderTexture, new Vector2(1635, 440), new Point(270, 200), Relation.win, false));

            gameObjects.Add(spelare);

            Restart();
        }
        private void Restart()
        {

            spelare.Reset();




            hasStarted = true;
            timer = 0;
            gameIsPaused = false;
            timerIsActive = true;
        }
        private void Win()
        {
            timerIsActive = false;
            gameIsPaused = true;
            

        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, "file.txt");
                StreamWriter sw = new StreamWriter(filepath);
                sw.WriteLine("You Suck");
                sw.Close();
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Restart();
            }
    
            if(!gameIsPaused)
            {
                foreach (Bas item in gameObjects)
                {
                    item.Update(gameTime);

                    if (!(item is Spelare))
                    {
                        if (spelare.Hitbox.Intersects(item.Hitbox))
                        {
                            switch (item.relation)
                            {
                                case Relation.none:
                                    break;
                                case Relation.player:
                                    break;
                                case Relation.win:
                                    Win();
                                    break;
                                case Relation.respawn:
                                    Restart();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                if (timerIsActive)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(); //skriver ut hur stor min bakgrund ska vara och skärmen och hur den ska se ut
            Rectangle backgroundRec = new Rectangle();
            backgroundRec.Location = backgroundpos.ToPoint();
            backgroundRec.Size = new Point(w, h);
            spriteBatch.Draw(background, backgroundRec, Color.White);

            foreach (Bas item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
            if(gameIsPaused)
            {
                spriteBatch.DrawString(font, timer.ToString(), new Vector2(950, 540), Color.Black);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
