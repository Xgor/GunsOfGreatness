using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GunsOfGreatness
{



    static class LevelManager
    {

        /*
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
        */

        enum TileTypes : byte { Air = 1, Solid, AboveColl };
        static int mapWidth;
        static int mapHeight;
        static int tileWidth;
        static int tileHeight;


        static List<byte> levelCollisionList; 

//        TileTypes

        public static void SetLevel(string fileName)
        {
            Clear();

            string xmlText = System.IO.File.ReadAllText(fileName);
            XmlReader xmlReader = XmlReader.Create(new StringReader(xmlText));

            while (xmlReader.Read())
            {
                if (xmlReader.Name == "map" && (xmlReader.NodeType == XmlNodeType.Element))
                {
                    Console.WriteLine("Hmm");
                    mapWidth = int.Parse(xmlReader.GetAttribute("width"));
                    mapHeight = int.Parse(xmlReader.GetAttribute("height"));
                }

                if (xmlReader.Name == "tileset" && (xmlReader.NodeType == XmlNodeType.Element))
                {
                    Console.WriteLine("Hmm");
                    tileWidth = byte.Parse(xmlReader.GetAttribute("tilewidth"));
                    tileHeight = byte.Parse(xmlReader.GetAttribute("tileheight"));
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "tile"))
                {
                    levelCollisionList.Add(byte.Parse(xmlReader.GetAttribute("gid")));
                }
                             
            }
            

        }
        public static void Clear()
        {
            if (levelCollisionList == null)
            {
                levelCollisionList = new List<byte>();
            }
            levelCollisionList.Clear();
        }

                    
        public static bool CollisionCheck(Vector2 objectPos)
        {
            int collIdentifier = 0;

            collIdentifier += (int)Math.Floor(  objectPos.X / tileWidth);
            collIdentifier += (int)Math.Floor( objectPos.Y / tileHeight)*mapWidth;

     //       Console.WriteLine(Math.Floor( / objectPos.X).ToString() + "," + Math.Floor(tileHeight / objectPos.Y).ToString());
            if (collIdentifier < 0 || collIdentifier > mapWidth*mapHeight-1)
            {
                return false;
            }

            if (levelCollisionList[collIdentifier] == 2)
            {
                return false;
            }

            return true;

        }
            

        public static void Draw(SpriteBatch spriteBatch)
        {
 //           spriteBatch.Draw(TextureManager.GetTexture("collTileset"),Vector2.Zero,Color.White);
            
            Rectangle sourceRect = new Rectangle();
            Vector2 position;
            sourceRect.Width = tileWidth;
            sourceRect.Height = tileHeight;
            for (int y = 0; y < mapHeight; y++ )
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (levelCollisionList[y * mapWidth + x] > 1)
                    {
                        position.X = x * tileWidth;
                        position.Y = y * tileHeight;
                        sourceRect.X = tileWidth * (levelCollisionList[y * mapWidth + x] - 1);
                        spriteBatch.Draw(TextureManager.GetTexture("collTileset"), position, sourceRect, Color.White);
                    }
                }
            }
            
                    
        }


    }
}
