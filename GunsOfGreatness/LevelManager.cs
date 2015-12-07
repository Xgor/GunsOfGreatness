using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace GunsOfGreatness
{
    static class LevelManager
    {
        static List<Rectangle> levelCollisions;
        
        public static bool CollisionCheck(Rectangle objectCollider)
        {
            foreach (Rectangle levelCollider in levelCollisions)
            {
                if(objectCollider.Intersects(levelCollider))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Draw()
        {

        }



    }
}
