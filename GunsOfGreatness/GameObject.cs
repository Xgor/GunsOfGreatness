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

        protected Rectangle sourceRect;
        
//        protected 

        public void SetDirection(float direction) { objectDirection = direction; }

        public void SetPosition(Vector2 position) { v_position = position; }
        public void SetPosition(float x, float y) { v_position = new Vector2(x, y); }

        public void Move(Vector2 position) 
        {
            if (LevelManager.CollisionCheck(v_position + position))
            {
                v_position += position;
            }
       }
        
        public void Move(float x, float y) 
        {
            if (LevelManager.CollisionCheck(v_position + new Vector2(x, y)))
            {
                v_position += new Vector2(x, y);
            }
        }

        protected float rotation = 0;
        protected Vector2 origin = Vector2.Zero;

        protected Vector2 scale = Vector2.One;
        protected float depth = 0;

        
        public void SetSprite(ContentManager contentManager, string assetName)
        {
            sprite = contentManager.Load<Texture2D>(assetName);
            sourceRect = sprite.Bounds;
            origin = sprite.Bounds.Center.ToVector2();
        }

        public void SetSprite(string textureKey)
        {
            sprite = TextureManager.GetTexture(textureKey);
            sourceRect = sprite.Bounds;
            origin = sprite.Bounds.Center.ToVector2();
        }

        public void SetSprite(Texture2D texture)
        {
            sprite = texture;
            sourceRect = sprite.Bounds;
            origin = sprite.Bounds.Center.ToVector2();
        }


        public void SetSprite(string textureKey, Rectangle textRect)
        {
            sprite = TextureManager.GetTexture(textureKey);
            sourceRect = textRect;
            origin = sprite.Bounds.Center.ToVector2();
        }

        public void SetSprite(Texture2D texture, Rectangle textRect)
        {
            sprite = texture;
            sourceRect = textRect;
            origin = sprite.Bounds.Center.ToVector2();
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
         //       spriteBatch.Draw(sprite, v_position, sourceRect, Color.White);
                spriteBatch.Draw(
                    sprite, v_position, sourceRect, Color.White, 
                    rotation,origin,scale,SpriteEffects.None,depth);
            
            }
            else
            {
                origin = TextureManager.GetTexture("temp").Bounds.Center.ToVector2();
                sourceRect = TextureManager.GetTexture("temp").Bounds;
                spriteBatch.Draw(TextureManager.GetTexture("temp"), v_position, sourceRect, Color.White,
                    rotation, origin,scale, SpriteEffects.None, depth);
            }

        }
    }
}
