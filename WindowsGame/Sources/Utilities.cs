using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    public class UTILITIES
    {
        static public Texture2D CreateUniformColoredTexture2D(Color color, int width, int height)
        {
            Texture2D texture = new Texture2D(GLOBALS.Graphics.GraphicsDevice, width, height);

            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.White;
            }

            texture.SetData(data);
            return texture;
        }

        static public Texture2D CreateBorderedTexture2D(Color borderColor, int padding, Color fillColor, int width, int height)
        {
            Texture2D texture = new Texture2D(GLOBALS.Graphics.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int curIndex = (i * width) + j;
                    if ((i >= 0 && i < padding) || (i >= (height - padding) && i < height))
                    {
                        data[curIndex] = borderColor;
                    }
                    else if ((j >= 0 && j < padding) || (j >= (width - padding) && j < width))
                    {
                        data[curIndex] = borderColor;
                    }
                    else
                    {
                        data[curIndex] = fillColor;
                    }
                }
            }

            texture.SetData(data);
            return texture;
        }
    }
}
