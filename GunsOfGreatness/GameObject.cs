using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Utilities;

namespace GunsOfGreatness
{
    class GameObject
    {
        public const float DIRECTION_RIGHT = 0 , DIRECTION_DOWNRIGHT = 45     ,
                           DIRECTION_DOWN = 90   , DIRECTION_DOWNLEFT = 135     ,
                           DIRECTION_LEFT = 180, DIRECTION_UPLEFT = 225   ,
                           DIRECTION_UP = 270, DIRECTION_UPRIGHT = 315;



        protected Vector2 v_position;
        protected float objectDirection;
        protected Texture2D sprite;
        static Texture2D tempSprite;

        public void SetDirection(float direction) { objectDirection = direction; }

        public void SetPosition(Vector2 position) { v_position = position; }
        public void SetPosition(float x, float y) { v_position = new Vector2(x, y); }

        public void Move(Vector2 position) { v_position += position; }
        public void Move(float x, float y) { v_position += new Vector2(x, y); }

        public void SetTexture(ContentManager contentManager, string assetName)
        {
            sprite = contentManager.Load<Texture2D>(assetName);
        }

        public void MoveDirection(float speed)
        {
           
            double directionRad = ( Math.PI / 180) * objectDirection;
            v_position.X += speed* (float)Math.Cos(directionRad);
            v_position.Y += speed * (float)Math.Sin(directionRad);
        }

        // Update method (return false to remove from ObjectManager
        public virtual bool Update(float deltaTime)
        {
            return true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null)
            {
                spriteBatch.Draw(sprite, v_position, Color.White);
            }
            else
            {

                spriteBatch.Draw(TextureManager.GetTexture("temp"), v_position, Color.White);
            }

        }
    }
}
