using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GunsOfGreatness
{
    class Gun
    {
        /* *******************************
        *                                *
        *         Implemented            *
        *                                * 
        ******************************** */

        public float gunFireRate;

        private float timeUntilFire;

        /* *******************************
        *                                *
        *         Not Implemented        *
        *                                * 
        ******************************** */


        public float gunMultiShotSpread;
        public float gunRandomShotSpread;
        public float gunRecoilPower;
        public float gunAmmoCount;
        public float gunReloadSpeed;
        public byte gunWeight; // gunWeight ( Higher weight = lower Speed)
        public int gunDurability;
        public byte gunShotsPerFire = 1;
        public bool gunAutoFire;
        public Color gunColor;
        public Texture2D gunTexture;

        // Bullet modifiers
        public int bulletDamage;
        public float bulletKnockback;

        public float bulletLifespan;
        public float bulletSpeed;
        public float bulletHomingSpeed;
        public float bulletGravity;
        public float bulletSineWaveStrength;

        public byte bulletWidth;
        public byte bulletHeight;

        public bool bulletIsRicocheting;
        public bool bulletIsPiercing;
        public bool bulletIsIntangible;

        public float bulletexplosionSize;
        public int bulletexplosionDamage;

        public Color bulletColor;
        public Texture2D bulletTexture;

        /*
         * Other Possible variables
         * 
         * 
         * bullet element damage
         * 
         * bulletAcceleration
         * bulletMaxspeed
         * bulletDeceleration
         * 
         * bulletAccuracy
         * gunChargeShot
         * 
         * bulletDestroyOutsideScreen
         * 
         * bulletDeterioration
         * bulletBlocksOtherBullets
         * 
         * bulletBoomerangSpeed
         * 
         * bulletMagnetizingEnemies
         * 
         * bulletSplashBulletAmount;
         * 
         * BulletProcs (Slowdown, Freeze, Poison, Fear)
         * 
         * */

        public Gun()
        {

        }

        public void Update(float deltaTime, float direction)
        {
            if (timeUntilFire > 0)
            {
                timeUntilFire -= deltaTime;
                if(timeUntilFire < 0)
                {
                    timeUntilFire = 0;
                }
            }

            if (InputManager.Fire && timeUntilFire == 0)
            {
                Fire(direction);
            }
        }

        public void Fire(float direction)
        {
            timeUntilFire += gunFireRate;
        }
        
    }
}
