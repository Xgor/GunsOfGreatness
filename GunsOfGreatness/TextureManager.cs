using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GunsOfGreatness
{
    static class TextureManager
    {
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static void LoadTextures(ContentManager contentManager)
        {
            textures.Add("temp", contentManager.Load<Texture2D>("tempBox"));
        }

        public static Texture2D GetTexture(string texture)
        {
            if(textures.ContainsKey(texture))
            {
                return textures[texture];
            }
            else
            {
                return textures["temp"];
            }
        }
        /*
        public static void LoadTextures(SpriteBatch spriteBatch)
        {

        }
         */
    }
}
