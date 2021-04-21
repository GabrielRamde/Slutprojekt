using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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

        private Texture2D spelare;
        private Vector2 spelarepos = new Vector2(100, 500);

        private Texture2D hinder;
        private Vector2 hinderpos = new Vector2(450, 50);
        private Vector2 hinderpos2 = new Vector2(750, 50);
        private Vector2 hinderpos3 = new Vector2(1050, 50);
        private Vector2 hinderpos4 = new Vector2(1350, 50);

        float hinderposspeed = 0f;
        float range = 36f;
        float speed = 5f;

        private List<Sprite> sprites;
        private bool hasStarted = false;



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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Restart();
        }
        private void Restart()
        {
            spelare = Content.Load<Texture2D>("spelare");

            sprites = new List<Sprite>()
            {
                new spelare(spelare)
            }

            background = Content.Load<Texture2D>("spelplan"); // Bakgrund till spelet

            hinder = Content.Load<Texture2D>("hinder");

            hasStarted = false;
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
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                hasStarted = true;

            if (!hasStarted)
                return;
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    spelarepos.Y -= 6;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    spelarepos.Y += 6;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    spelarepos.X -= 6;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    spelarepos.X += 6;
                }
            }
            hinderposspeed = range * (float)Math.Sin(speed * gameTime.TotalGameTime.TotalSeconds);
            hinderpos.Y += hinderposspeed;
            hinderpos2.Y += hinderposspeed;
            hinderpos3.Y += hinderposspeed;
            hinderpos4.Y += hinderposspeed;

            for (int i = 0; i < .Count; i++)
            {
                var sprite = _sprites[i];

                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }

                if (sprite is spelare)
                {
                    var spelare = sprite as spelare;

                    if (spelare.HasDied)
                    {
                        Restart();
                    }
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(); //skriver ut hur stor min bakgrund ska vara och skärmen och hur den ska se ut
            Rectangle backgroundRec = new Rectangle();
            backgroundRec.Location = backgroundpos.ToPoint();
            backgroundRec.Size = new Point(w, h);
            spriteBatch.Draw(background, backgroundRec, Color.White);

            spriteBatch.Draw(spelare, spelarepos, Color.White);
            spriteBatch.Draw(hinder, hinderpos, Color.White);
            spriteBatch.Draw(hinder, hinderpos2, Color.White);
            spriteBatch.Draw(hinder, hinderpos3, Color.White);
            spriteBatch.Draw(hinder, hinderpos4, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
