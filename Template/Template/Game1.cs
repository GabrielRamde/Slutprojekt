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


        private Spelare spelare;
        private Texture2D hinder;

        float hinderposspeed = 0f;
        float range = 36f;
        float speed = 5f;

        private bool hasStarted = false;

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

            spelare = new Spelare(spelareTexture, new Vector2(100, 500), new Point(70, 70),;

            gameObjects.Add(new Hinder(hinderTexture, new Vector2(450, 50), new Point(100, 100)),;
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(750, 50), new Point(100, 100)),;
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(1050, 50), new Point(100, 100)),;
            gameObjects.Add(new Hinder(hinderTexture, new Vector2(1350, 50), new Point(100, 100)),;

            gameObjects.Add(spelare);

            Restart();
        }
        private void Restart()
        {
            

            

            

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

            foreach (Bas item in gameObjects)
            {
                item.Update(gameTime);
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

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
