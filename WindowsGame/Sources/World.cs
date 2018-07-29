using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    public class World
    {
        public World(int width, int height)
        {
            windowWidth = width;
            windowHeight = height;

            playGrid = new PlayGrid(20, 15);
        }

        public void Initialize()
        {
            GLOBALS.Graphics.PreferredBackBufferWidth = windowWidth;
            GLOBALS.Graphics.PreferredBackBufferHeight = windowHeight;
            GLOBALS.Graphics.ApplyChanges();
        }

        public void LoadContent()
        {
            textureGame = UTILITIES.CreateBorderedTexture2D(Color.White, 5, Color.Black, 1450, 1950);
            textureScore = UTILITIES.CreateBorderedTexture2D(Color.White, 5, Color.Black, 525, 1900);

            playGrid.LoadContent();
        }

        public void Update()
        {
            playGrid.Update();
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(textureGame, new Rectangle(25, 25, textureGame.Width, textureGame.Height), null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);

            playGrid.Draw();
        }

        PlayGrid playGrid;
        private Texture2D textureGame;
        private Texture2D textureScore;
        private int windowWidth;
        private int windowHeight;
    }
}
