using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
