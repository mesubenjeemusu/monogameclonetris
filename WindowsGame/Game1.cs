using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        World gameWorld = new World(1500, 2000);

        public Game1()
        {
            GLOBALS.Graphics = new GraphicsDeviceManager(this);
            GLOBALS.Textures = new Textures();
            Content.RootDirectory = "Content";

            //GLOBALS.Graphics.PreferredBackBufferHeight = 2000;
            //GLOBALS.Graphics.PreferredBackBufferWidth = 1500;
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
            gameWorld.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            GLOBALS.SpriteBatch = new SpriteBatch(GraphicsDevice);

            //textureGame = UTILITIES.CreateUniformColoredTexture2D(Color.White, 1400, 1900);
            //texturePlayArea = UTILITIES.CreateUniformColoredTexture2D(Color.Black, 900, 1890);
            //textureScore = UTILITIES.CreateUniformColoredTexture2D(Color.Black, 460, 1890);

            gameWorld.LoadContent();
            

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic 
            gameWorld.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            GLOBALS.SpriteBatch.Begin(SpriteSortMode.FrontToBack);

            gameWorld.Draw();

            GLOBALS.SpriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
