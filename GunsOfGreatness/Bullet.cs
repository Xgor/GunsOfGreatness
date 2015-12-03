using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GunsOfGreatness
{
    class Bullet : GameObject
    {
        float aliveTime = 0.5f;
        
        public Bullet(Vector2 position,float direction)
        {
            objectDirection = direction;
            v_position = position;
        }


        public override bool Update(float deltaTime)
        {
            
            aliveTime -= deltaTime;
            MoveDirection(400 * deltaTime);
            if (aliveTime < 0)
            {
                return false;
            }
            return true;
        }
    }
}
