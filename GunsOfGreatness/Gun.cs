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



        /* *******************************
        *                                *
        *         Not Implemented        *
        *                                * 
        ******************************** */

        float gunFireRate;
        float gunMultiShotSpread;
        float gunRandomShotSpread;
        float gunRecoilPower;
        float gunAmmoCount;
        float gunReloadSpeed;
        byte gunWeight; // gunWeight ( Higher weight = lower Speed)
        int gunDurability;
        byte gunShotsPerFire = 1;
        bool gunAutoFire;
        Color gunColor;
        Texture2D gunTexture;

        // Bullet modifiers
        int bulletDamage;
        float bulletKnockback;

        float bulletLifespan;
        float bulletSpeed;
        float bulletHomingSpeed;
        float bulletGravity;
        float bulletSineWaveStrength;

        byte bulletWidth;
        byte bulletHeight;
        
        bool bulletIsRicocheting;
        bool bulletIsPiercing;
        bool bulletIsIntangible;

        float bulletexplosionSize;
        int bulletexplosionDamage;

        Color bulletColor;
        Texture2D bulletTexture;

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

        void Fire()
        {

        }
        
    }
}
