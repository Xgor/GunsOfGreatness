using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GunsOfGreatness
{

    class Player : GameObject
    {
        const float HSPEED_ACCELERATION = 7.0f;
        const float HSPEED_DECELERATION = 10.0f;
        const float HSPEED_MAXSPEED = 6.0f;

        float hSpeed;
    //    float vSpeed;

        protected float aimDirection;

        Gun mainGun = new Gun();
        /*
                public void Draw(SpriteBatch spriteBatch)
                {
                    spriteBatch.Draw(sprite, v_position, Color.White);
                }

                public Player()
                {

                }
        */

        bool Deceleration(float deltaTime)
        {
            if(hSpeed == 0)
            {
                return true;
            }
            else if (hSpeed > 0)
            {
                if (hSpeed > HSPEED_DECELERATION * deltaTime)
                {
                    hSpeed -= HSPEED_DECELERATION * deltaTime;
                }
                else
                {
                    hSpeed = 0;
                }
                return false;
            }
            else
            {
                if (hSpeed < -HSPEED_DECELERATION * deltaTime)
                {
                    hSpeed += HSPEED_DECELERATION * deltaTime;
                }
                else
                {
                    hSpeed = 0;
                }
                return false;
            }

        }

        public override bool Update(float deltaTime)
        {


            if (InputManager.Left.active)
            {
                if (InputManager.Down.active)
                {
                    aimDirection = DIRECTION_DOWNLEFT;
                }
                else if (InputManager.Up.active)
                {
                    aimDirection = DIRECTION_UPLEFT;
                }
                else
                {
                    aimDirection = DIRECTION_LEFT;
                }

                if(hSpeed > 0)
                {
                    Deceleration(deltaTime);
                }
                hSpeed -= HSPEED_ACCELERATION * deltaTime;
            }
            else if (InputManager.Right.active)
            {
                if (InputManager.Down.active)
                {
                    aimDirection = DIRECTION_DOWNRIGHT;
                }
                else if (InputManager.Up.active)
                {
                    aimDirection = DIRECTION_UPRIGHT;
                }
                else
                {
                    aimDirection = DIRECTION_RIGHT;
                }

                if (hSpeed < 0)
                {
                    Deceleration(deltaTime);
                }
                hSpeed += HSPEED_ACCELERATION * deltaTime;
            }
            else if (InputManager.Up.active)
            {
                aimDirection = DIRECTION_UP;
                Deceleration(deltaTime);
            }
            else if (InputManager.Down.active)
            {
                aimDirection = DIRECTION_DOWN;
                Deceleration(deltaTime);
            }
            else
            {
                Deceleration(deltaTime);
            }
           


            hSpeed =MathHelper.Clamp(hSpeed, -HSPEED_MAXSPEED, HSPEED_MAXSPEED);
            Move(hSpeed * Vector2.UnitX);

            mainGun.Update(deltaTime,v_position, aimDirection);

            return true;
        }


        
    }


}
