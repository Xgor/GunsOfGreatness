using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GunsOfGreatness
{

    public struct BulletModifiers
    {
        /* *******************************
        *                                *
        *         Implemented            *
        *                                * 
        ******************************** */
        public float lifespan;
        public float speed;
        public float gravity;

  //      public float acceleration;
        // public float maxSpeed


        //       bulletMinspeed

        /* *******************************
         *                                *
         *         Not Implemented        *
         *                                * 
         ******************************** */







        public float width;
        public float height;

        //       bulletAcceleration
        //       bulletMaxspeed
        //       bulletMinspeed

        // Not Implemented
        /*
        // Bullet modifiers
        public int bulletDamage;
        public float bulletKnockback;


        public float bulletHomingSpeed;

        public float bulletSineWaveStrength;



        public bool bulletIsRicocheting;
        public bool bulletIsPiercing;
        public bool bulletIsIntangible;

        public float bulletexplosionSize;
        public int bulletexplosionDamage;

        public Color bulletColor;
        public Texture2D bulletTexture;
        

        

        bulletDeceleration
        
        bulletDestroyOutsideScreen
        bullet element damage
        bulletDeterioration
        bulletBlocksOtherBullets
        
        bulletBoomerangSpeed
        
        bulletMagnetizingEnemies
        
        bulletSplashBulletAmount;
        
        BulletProcs (Slowdown, Freeze, Poison, Fear)
        */
    }

    class Bullet : GameObject
    {
        float vSpeed = 0;

        float aliveTime = 0.5f;
        BulletModifiers bulletStats;
        
        /*
        public Bullet(Vector2 position,float direction)
        {
            objectDirection = direction;
            v_position = position;
            SetSprite("bullet");
    //        depth = -10;
        }
        */

        public Bullet(BulletModifiers gunBulletStats,Vector2 position, float direction)
        {
            objectDirection = direction;
            v_position = position;
            bulletStats = gunBulletStats;
            aliveTime = bulletStats.lifespan;

            scale = new Vector2(bulletStats.width, bulletStats.height); 

            SetSprite("bullet");
        }
        
        public override bool Update(float deltaTime)
        {
            
            aliveTime -= deltaTime;
            MoveDirection(bulletStats.speed * deltaTime);
            
            // Gravity Modifier
            vSpeed += bulletStats.gravity;
            Move(0, vSpeed);

            if (aliveTime < 0)
            {
                return false;
            }

            return LevelManager.CollisionCheck(v_position);
        }
    }
}
