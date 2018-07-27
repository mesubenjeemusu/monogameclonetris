using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    public class GLOBALS
    {
        static public GraphicsDeviceManager Graphics;
        static public SpriteBatch SpriteBatch;
        static public Textures Textures;
    }

    public class Textures
    {
        public Textures() { }
        public Texture2D RedSquareTexture;
        public Texture2D OrangeSquareTexture;
        public Texture2D YellowSquareTexture;
        public Texture2D GreenSquareTexture;
        public Texture2D PurpleSquareTexture;
        public Texture2D PinkSquareTexture;
        public Texture2D BlueSquareTexture;
    }
}
