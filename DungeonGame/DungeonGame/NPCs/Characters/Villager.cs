using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.BackendDev;
using DungeonGame.ScreenManagement.Screens;

namespace DungeonGame.NPCs.Characters
{
    class Villager : NPC
    {
        Texture2D villagerTextureAtlas;
        Vector2 villagerPostion;
        Rectangle villagerRectangle;
        Rectangle[] textureSourcRects;

        bool moving;
        Vector2 target;

        int velocity = 3;

        List<PositionOnMap> path;

        public Villager()
        {
            // Generate random x and y value for the players position
            Random rn = new Random();
            int x = rn.Next(50);
            int y = rn.Next(30);
            // Set the players position to the newly random generated ones
            villagerPostion = new Vector2(x * 32, y * 32);
            // Create the villagers rectangle through which the program will later detect collisions.
            villagerRectangle = new Rectangle((int)villagerPostion.X, (int)villagerPostion.Y, 32, 48);
            // Create the array of source rectangles of textures from the villager texture atlas.
            textureSourcRects = new Rectangle[4];
            // set moving to false as when the player is created at that moment its not moving
            moving = false;

        }

        public override void LoadContent(ContentManager Content)
        {
            // Loads the texture atlas of the villager
            villagerTextureAtlas = Content.Load<Texture2D>("NPCTextures/jakeTextureAtlas");
            // Set the position of textures in a texture atlas to an array
            textureSourcRects[0] = new Rectangle(0, 0, 32, 48);
            textureSourcRects[1] = new Rectangle(32, 0, 32, 48);
            textureSourcRects[2] = new Rectangle(64, 0, 32, 48);
            textureSourcRects[3] = new Rectangle(96, 0, 32, 48);



            path = new List<PositionOnMap>();
            path.Add(new PositionOnMap(1, 10));
            path.Add(new PositionOnMap(7, 20));
            path.Add(new PositionOnMap(6, 16));



        }

        public List<PositionOnMap> PathFind()
        {
            List<PositionOnMap> pathToFollow = new List<PositionOnMap>();

            int tileX = (int)villagerPostion.X / 32;
            int tileY = (int)villagerPostion.Y / 32;





            return pathToFollow;
        }

        public override void Update(GameTime gameTime)
        {

            foreach(var x in path)
            {
                target.X = x.Row * 32;
                target.Y = x.Col * 32;

                if (Vector2.Distance(villagerPostion, target) < 0.1f)
                {// ((int)(villagerPostion.X / 32) != x.Row) && ((int)(villagerPostion.Y / 32) != x.Col)

                    Vector2 dist = new Vector2(0, 0);
                    dist.X = villagerPostion.X - target.X;
                    dist.Y = villagerPostion.Y - target.Y;

                    villagerPostion.X += dist.X;
                    villagerPostion.Y += dist.Y;


                }





            }


            /*
            if (!moving)
            {
                target = getNewTarget();
                moving = true;
            }
            if (moving)
            {
                if (target.X == Math.Floor(villagerPostion.X) && target.Y == Math.Floor(villagerPostion.Y))
                {
                    moving = false;
                    //target = getNewTarget();
                }
                else
                {
                    villagerPostion.X = Lerp(villagerPostion.X, target.X, 0.05f);
                    villagerPostion.Y = Lerp(villagerPostion.Y, target.Y, 0.05f);
                }
            }
            */



            villagerRectangle = new Rectangle((int)villagerPostion.X, (int)villagerPostion.Y, 32, 48);
        }
        Vector2 getNewTarget()
        {
            Random rn = new Random();
            int x = rn.Next(50);
            int y = rn.Next(30);
            return new Vector2((int)x * 32, (int)y * 32);
        }
        static float Lerp(float a, float b, float c)
        {
            if(a + 0.1 > b)
            {
                return a + (b - a) * c;
            }
            else
            {
                return b;
            }          
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(villagerTextureAtlas, villagerRectangle, textureSourcRects[0], Color.White);

            _spriteBatch.Draw(DevTexturesManger.Instance.redNode2px, target, Color.White);

            if (GameScreen.developerView)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, villagerRectangle, Color.Chocolate);
            }

        }



    }
}
