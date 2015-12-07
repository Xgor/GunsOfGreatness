using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
namespace GunsOfGreatness
{
    static class ObjectManager
    {
        static List<GameObject> listAllObjects = new List<GameObject>();
        public static void Setup()
        {

        }
        public static void AddObject( GameObject gObject){ listAllObjects.Add(gObject); }
        public static void Clear() { listAllObjects.Clear(); }


        public static void Update(float deltaTime)
        {
            for (int i = 0; i < listAllObjects.Count(); i++)
            {
                if (!listAllObjects[i].Update(deltaTime))
                {
                    listAllObjects[i] = null;
                    listAllObjects.RemoveAt(i);
                }
            }
        }



        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < listAllObjects.Count(); i++)
            {
                listAllObjects[i].Draw(spriteBatch);
            }
        }

        public static void RemoveObject()
        {

        }
    }
}
