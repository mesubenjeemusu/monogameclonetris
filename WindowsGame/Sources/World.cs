using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class World
    {
        public World(int width, int height)
        {
            windowWidth = width;
            windowHeight = height;

            playGrid = new PlayGrid(10, 10);
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

        Piece blockI;
        PlayGrid playGrid;
        private Texture2D textureGame;
        private Texture2D textureScore;
        private int windowWidth;
        private int windowHeight;
    }
}
