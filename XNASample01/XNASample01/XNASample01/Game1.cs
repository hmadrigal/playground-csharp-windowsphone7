using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace XNASample01
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D bigblurp;
        Vector2 bigblurpPosition;
        SpriteFont slackeyFont;

        #region FPS
#if DEBUG
        private float fps;
        private float updateInterval = 1.0f;
        private float timeSinceLastUpdate = 0.0f;
        private float framecount = 0f;
#endif
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            #region FPS
#if DEBUG
            //Do not synch our Draw method with the Vertical Retrace of our monitor
            graphics.SynchronizeWithVerticalRetrace = false;
            //Do not call our Update method at the default rate of 1/60 of a second.
            IsFixedTimeStep = false;
#endif
            #endregion
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
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
            this.bigblurpPosition = new Vector2(100f, 100f);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.bigblurp = Content.Load<Texture2D>("bigblurp");
            this.slackeyFont = Content.Load<SpriteFont>("Slackey");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            #region FPS
#if DEBUG
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            framecount++;
            timeSinceLastUpdate += elapsed;
            if (timeSinceLastUpdate > updateInterval)
            {
                fps = framecount / timeSinceLastUpdate; //mean fps over updateInterval
                System.Diagnostics.Debug.WriteLine("FPS: {0} - RT: {1} - GT: {2}", fps, gameTime.TotalGameTime.TotalSeconds, gameTime.ElapsedGameTime.TotalSeconds);
                framecount = 0;
                timeSinceLastUpdate -= updateInterval;
            }
#endif
            #endregion
            GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(this.bigblurp, this.bigblurpPosition,Color.White);
            spriteBatch.Draw(this.bigblurp, this.bigblurpPosition, new Rectangle(0, 0, 100, 91), Color.White, 0f, Vector2.Zero, -1f, SpriteEffects.FlipVertically, 0f);
            spriteBatch.DrawString(this.slackeyFont, "Hello World", this.bigblurpPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
