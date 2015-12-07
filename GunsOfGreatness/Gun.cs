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
        public bool gunAutoFire = true;
        BulletModifiers bulletStats;

        public float gunMultiShotSpread = 10;
        public byte bulletsPerFire = 3;
        public float gunShotSpread = 10;

        /* *******************************
        *                                *
        *         Not Implemented        *
        *                                * 
        ******************************** */



        public float gunBulletSpeedVariaton;
        public float gunRecoilPower;
        public float gunAmmoCount;
        public float gunReloadSpeed;
        public byte gunWeight; // gunWeight ( Higher weight = lower Speed)
        public int gunDurability;


        public Color gunColor;
        public Texture2D gunTexture;


        // Private variables
        private float timeUntilFire;
        Random rand = new Random();



        /*
         * Other Possible variables
         * 
         * 
         * 
         * gunChargeShot
         * 
         * */

        public Gun()
        {
            GenerateGunStats();
        }

        void GenerateGunStats()
        {
            

            gunFireRate = (float)rand.NextDouble()*0.05f+0.05f;

            bulletStats.lifespan = (float)rand.NextDouble()*3+1;
            bulletStats.speed = rand.Next(250,750);




       //     bulletStats.gravity = (float)rand.NextDouble() -0.25f;

            bulletStats.width = (float)rand.NextDouble()*0.1f + 0.95f;
            bulletStats.height = (float)rand.NextDouble()*0.1f + 0.95f;

        }

        public void Update(float deltaTime, Vector2 shooterPosition ,float shooterDirection)
        {
            if (timeUntilFire > 0)
            {
                timeUntilFire -= deltaTime;
                if(timeUntilFire < 0)
                {
                    timeUntilFire = 0;
                }
            }

            if (timeUntilFire == 0)
            {
                if (gunAutoFire)
                {
                    if (InputManager.Fire.active)
                    {
                        Fire(shooterPosition, shooterDirection);
                    }
                }
                else
                {
                    if (InputManager.Fire.pressed)
                    {
                        Fire(shooterPosition, shooterDirection);
                    }
                }
            }
        }

        public void Fire(Vector2 position, float direction)
        {

            if (bulletsPerFire > 1)
            {
                for (float dir = (-gunMultiShotSpread * bulletsPerFire) / 2; dir < (gunMultiShotSpread * bulletsPerFire) / 2; dir += gunMultiShotSpread)
                {
                    ObjectManager.AddObject(new Bullet(bulletStats, position, gunShotSpread * ((float)rand.NextDouble() - 0.5f) + direction + dir));
                }
            }
            else
            {
                ObjectManager.AddObject(new Bullet(bulletStats, position,gunShotSpread *((float)rand.NextDouble()-0.5f) + direction));
            }
            timeUntilFire += gunFireRate;


        }
        
    }
}
