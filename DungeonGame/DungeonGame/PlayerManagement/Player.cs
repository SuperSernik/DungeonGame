using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using DungeonGame.BackendDev;
using DungeonGame.ScreenManagement.Screens;
using System.Reflection.Metadata;
using DungeonGame.ItemManagement.Items;
using DungeonGame.InventoryManagement;
using DungeonGame.ScreenManagement.Overlays;

namespace DungeonGame.PlayerManagement
{
    public class Player
    {
        // PLAYER vars
        private Texture2D playerTileSet;
        public Vector2 playerPosition, playerPositionORIGIN;
        public Rectangle playerRect;
        private int playerWidth = 32;
        private int playerHeight = 48;
        private bool PlayerMoving;
        public float playerVelocity;

        public int playerPurse;
        public int playerHealth;


        // PLAYER COLLISIONS vars
        public Rectangle playerCollisionBoxRect;
        private Texture2D playerCollisionBoxTexture;

        private Rectangle playerTOP;
        private Rectangle playerBOTTOM;
        private Rectangle playerLEFT;
        private Rectangle playerRIGHT;

        private Color topCOLOR;
        private Color bottomCOLOR;
        private Color leftCOLOR;
        private Color rightCOLOR;

        // ANIMATION vars
        private float timer;
        private int threshold;
        Rectangle[] sourceRectangles;
        byte prevAnimationIndex;
        byte currAnimationIndex;

        //ITEMS vars

        public Item CurrentItemHeld = ItemManager.pistol;


        // MAP vars
        char[,] visableMap;

        // MISC vars
        Texture2D redNode;
        Texture2D whitePixel;


        public Player()
        {
        }

        public Rectangle HitBox
        {
            get { return playerCollisionBoxRect; }
        }

        public void LoadContent(ContentManager Content)
        {
            // loads the texture atlas for the player
            sourceRectangles = new Rectangle[5];
            playerTileSet = Content.Load<Texture2D>("PlayerTextures/redRectTextureAtlas");
            //playerPosition = new Vector2((ScreenManager.Instance.Resolution.X / 2) - 16, (ScreenManager.Instance.Resolution.Y / 2) - 16);
            playerPosition = playerStartPos();
            playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerWidth, playerHeight);
            playerVelocity = 3f;
            // loads the texture of the hitbox for the player
            playerCollisionBoxTexture = Content.Load<Texture2D>("DevAidTextures/blueBox2px");
            playerCollisionBoxRect = playerRect;

            timer = 0;
            threshold = 100;
            currAnimationIndex = 0;

            redNode = Content.Load<Texture2D>("DevAidTextures/redNode2px");
            whitePixel = Content.Load<Texture2D>("Fx/WhitePixel");

            playerPurse = 0000;
            playerHealth = 10;


        }

        Vector2 playerStartPos()
        {
            // spawns the player at the designated spawn point on the map
            TileSearch ts = new TileSearch();
            List<PositionOnMap> SpawnPos = ts.ReturnLocationsOfTilesFromBackground('@');
            PositionOnMap newPos;

            try
            {   // VALIDATION for the players location
                newPos = SpawnPos.ElementAt(0);
                return new Vector2(newPos.Col * 32, newPos.Row * 32 - 16);
            }
            catch
            {
                return (new Vector2((ScreenManager.Instance.Resolution.X / 2) - 16, (ScreenManager.Instance.Resolution.Y / 2) - 16));

            }


        }

        bool PlayerHasCollided(char[,] map, Rectangle playerSIDE)
        {// player collisions

            for (int i = 0; i < ScreenManager.MapDimentions.Y; i++) // 30
            {
                for (int j = 0; j < ScreenManager.MapDimentions.X; j++) // 50
                {
                    char tile = map[i, j];

                    if (tile == 'R')
                    {
                        if (new Rectangle(j * 32, i * 32, 32, 32).Intersects(playerSIDE))
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }


        public void Update(GameTime gameTime)
        {
            // the player sprite moves as they walk 
            // they also have an idle state
            // thats what this Animate(gT) refers to 
            Animate(gameTime);
            PlayerMoving = false;
            visableMap = ScreenManager.visibleMAP;
            // draws player hitbos
            DrawPlayerHitBox(playerTOP, playerBOTTOM, playerLEFT, playerRIGHT);

            // The collisions are programed so that if the player has clicked the button to move
            // and the player is currently not colliding with anything they can move in that direction
            // this means that if the player is colliding in say a corner with 2 side
            // they cant move in those sides' directions anymore
            // so they have to move in the other available directions to move out of being stuck.
            if (Keyboard.GetState().IsKeyDown(Globals.upKey) && !PlayerHasCollided(visableMap, playerTOP))
            {
                // move the player with constant velocity
                playerPosition.Y -= playerVelocity;
                sourceRectangles = GetSourceRects("Back");
                PlayerMoving = true;


            }
            if (Keyboard.GetState().IsKeyDown(Globals.downKey) && !PlayerHasCollided(visableMap, playerBOTTOM))
            {
                
                playerPosition.Y += playerVelocity;
                sourceRectangles = GetSourceRects("Idle");
                PlayerMoving = true;
            }

            if (Keyboard.GetState().IsKeyDown(Globals.leftKey) && !PlayerHasCollided(visableMap, playerLEFT))
            {
                playerPosition.X -= playerVelocity;
                sourceRectangles = GetSourceRects("Left");
                PlayerMoving = true;

            }
            if (Keyboard.GetState().IsKeyDown(Globals.rightKey) && !PlayerHasCollided(visableMap, playerRIGHT))
            {
                playerPosition.X += playerVelocity;
                sourceRectangles = GetSourceRects("Right");
                PlayerMoving = true;
            }

            // sets the origin of the player to the center of its texture
            playerPositionORIGIN = playerPosition + new Vector2(16, 24);


            if (!PlayerMoving)
            {   // if the player is not moving it player the idle animation
                sourceRectangles = GetSourceRects("Idle");
            }
            if (Keyboard.GetState().IsKeyDown(Globals.sprintKey))
            {   // if the player holds the sprint button the players
                // velocity increases
                playerVelocity = 7f;
            }
            else
            {
                playerVelocity = 3f;
            }


            // this makes sure that the players hitbox moves along with the player
            playerRect.X = (int)playerPosition.X;
            playerRect.Y = (int)playerPosition.Y;
            playerCollisionBoxRect = playerRect;

            playerTOP = new Rectangle(playerRect.X + 10, playerRect.Y + 16, 14, 1); // 14
            playerBOTTOM = new Rectangle(playerRect.X + 10, playerRect.Y + 46, 14, 1);
            //  This is where i set the rectangles  
            playerLEFT = new Rectangle(playerRect.X + 2, playerRect.Y + 26, 1, 14);       //    for the players collision system.
            playerRIGHT = new Rectangle(playerRect.X + 30, playerRect.Y + 26, 1, 14);



        }
        // draws players hibox
        void DrawPlayerHitBox(Rectangle playerTOP, Rectangle playerBOTTOM, Rectangle playerLEFT, Rectangle playerRIGHT)
        {
            // Retrieving the map.
            visableMap = ScreenManager.visibleMAP;
            topCOLOR = Color.White;
            bottomCOLOR = Color.White;
            leftCOLOR = Color.White;
            rightCOLOR = Color.White;

            // If the player collides, set the corresponding side to red.
            if (PlayerHasCollided(visableMap, playerTOP))
            {
                topCOLOR = Color.Red;
            }
            if (PlayerHasCollided(visableMap, playerBOTTOM))
            {
                bottomCOLOR = Color.Red;
            }
            if (PlayerHasCollided(visableMap, playerLEFT))
            {
                leftCOLOR = Color.Red;
            }
            if (PlayerHasCollided(visableMap, playerRIGHT))
            {
                rightCOLOR = Color.Red;
            }
        }

        void MovingOverTerrain()
        {
            TileSearch ts = new TileSearch();
            // retrieves the locations of "rough terrain" tiles in this case water
            List<PositionOnMap> waterPositions = ts.ReturnLocationsOfTilesFromBackground('W');
            foreach(PositionOnMap pom in waterPositions)
            {
                if(playerRect.Intersects(new Rectangle((int)pom.Row * 32, (int)pom.Col * 32, 32, 32)))
                {
                    // if the player is moving over rough terrain they slow down
                    playerVelocity=2f;
                }
            }


        }


        public void Draw(SpriteBatch _spriteBatch)
        {// draws the player
            _spriteBatch.Draw(playerTileSet, playerRect, sourceRectangles[currAnimationIndex], Color.White);
            //_spriteBatch.Draw(playerCollisionBoxTexture, playerRect, Color.White);


            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    char tile = ScreenManager.visibleMAP[i, j];

                    if (tile == 'R')
                    {
                        // COLLIDABLES
                        //_spriteBatch.Draw(redNode, new Rectangle(j * 32, i * 32, 32, 32), Color.White);

                    }
                }
            }


            if (GameScreen.developerView)
            {   // displays the hitboxes if the user turns on dev mode
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, playerRect, Color.BlueViolet);

                _spriteBatch.Draw(whitePixel, playerTOP, topCOLOR); //TOP
                _spriteBatch.Draw(whitePixel, playerBOTTOM, bottomCOLOR); // BOTTOM
                _spriteBatch.Draw(whitePixel, playerLEFT, leftCOLOR); // LEFT
                _spriteBatch.Draw(whitePixel, playerRIGHT, rightCOLOR); // RIGHT



            }




        }
        // animates the player
        void AnimateOri(GameTime gameTime)
        {
            if (timer > threshold)
            {
                if (currAnimationIndex == 1)
                {
                    if (prevAnimationIndex == 0)
                    {
                        currAnimationIndex = 2;
                    }
                    else
                    {
                        currAnimationIndex = 0;
                    }
                    prevAnimationIndex = currAnimationIndex;
                }
                else
                {
                    currAnimationIndex = 1;
                }
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        // animates the player
        bool forward = true;
        void Animate(GameTime gameTime)
        {
            if (timer > threshold)
            {
                
                if (forward)
                {
                    currAnimationIndex++;
                    if(currAnimationIndex == 5)
                    {
                        forward = false;
                    }
                }
                if (!forward)
                {
                    currAnimationIndex--;
                    if (currAnimationIndex == 0)
                    {
                        forward = true;
                    }
                }

                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        // retrieves the source rectangles for the textures used for the animations of the player
        Rectangle[] GetSourceRects(string wayFacing)
            {
                Rectangle[] Idle = new Rectangle[5]; // IDLE ANIMATION
                Idle[0] = new Rectangle(0, 0, playerWidth, playerHeight);
                Idle[1] = new Rectangle(32, 0, playerWidth, playerHeight);
                Idle[2] = new Rectangle(64, 0, playerWidth, playerHeight);
                Idle[3] = new Rectangle(96, 0, playerWidth, playerHeight);
                Idle[4] = new Rectangle(128, 0, playerWidth, playerHeight);

                Rectangle[] Left = new Rectangle[5]; // MOVING LEFT ANIMATION
                Left[0] = new Rectangle(0, 48, playerWidth, playerHeight);
                Left[1] = new Rectangle(32, 48, playerWidth, playerHeight);
                Left[2] = new Rectangle(64, 48, playerWidth, playerHeight);
                Left[3] = new Rectangle(96, 48, playerWidth, playerHeight);
                Left[4] = new Rectangle(128, 48, playerWidth, playerHeight);

                Rectangle[] Right = new Rectangle[5]; //MOVING RIGHT ANIMATION
                Right[0] = new Rectangle(0, 96, playerWidth, playerHeight);
                Right[1] = new Rectangle(32, 96, playerWidth, playerHeight);
                Right[2] = new Rectangle(64, 96, playerWidth, playerHeight);
                Right[3] = new Rectangle(96, 96, playerWidth, playerHeight);
                Right[4] = new Rectangle(128, 96, playerWidth, playerHeight);

                Rectangle[] Back = new Rectangle[5]; // MOVING BACK/UP ANIMATION
                Back[0] = new Rectangle(0, 144, playerWidth, playerHeight);
                Back[1] = new Rectangle(32, 144, playerWidth, playerHeight);
                Back[2] = new Rectangle(64, 144, playerWidth, playerHeight);
                Back[3] = new Rectangle(96, 144, playerWidth, playerHeight);
                Back[4] = new Rectangle(128, 144, playerWidth, playerHeight);

                switch (wayFacing)
                {
                    case "Idle":
                        return Idle;

                    case "Left":
                        return Left;

                    case "Right":
                        return Right;

                    case "Back":
                        return Back;

                    default:
                        return Idle;

                }

            }

        
    } 
}
