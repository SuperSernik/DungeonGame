using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Entities;
using DungeonGame.MapManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement.ScreenStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonGame.NPCs;
using DungeonGame.BackendDev;
using DungeonGame.ItemManagement.NonItemItems;

namespace DungeonGame.ScreenManagement.Screens
{// this class creates the game and all of the main components
    // that make up the game such as the player, entities, items etc.
    public class GameScreen : UserScreen
    {
        // vars
        public static int numberOfZombies, numberOfVillagers, numberOfCoins;
        public static bool developerView;
        // creates player
        public static Player MainPlayer = new Player();
        // creates the background
        DrawBackground db = new DrawBackground(ScreenManager.visibleMAP);
        // creates entities
        EntityManger em = new EntityManger();
        // creates npcs
        NPCManager nm = new NPCManager();
        Camera _camera;

        // TESTING
        DrawCheck dc = new DrawCheck();

        public GameScreen()
        {// sets this screens type to game so that 
            // the screen manager can distinguish between screens
            screenType = "game";
        }

        public override void LoadContent(ContentManager Content)
        {// loads the content of all of the textures that are being drawn on the game screen.
            base.LoadContent(Content);
            setGameScreenData();
            db.LoadContent(Content);
            _camera = new Camera();
            em.LoadContent(Content);
            nm.LoadContent(Content);
            MainPlayer.LoadContent(Content);
            dc.LoadContent(Content);

        }


        public override void UnloadContent()
        {// unloads content thats not being used
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            em.Update(gameTime);
            nm.Update(gameTime);
            // updates the players locaiton etc.
            MainPlayer.Update(gameTime);
            // has the camera follow the player
            _camera.Follow(MainPlayer, gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {// if the user clicks 'b' they will be sent back to the menu
                switchToScreen = "menu";
            }
            dc.Update(gameTime);

            toggleDevMode();

        }

        // Toggles developer mode
        // INCLUDE WHEN MOVING DIS
        bool beingPressed = false;
        void toggleDevMode()
        {
            if (Keyboard.GetState().IsKeyDown(Globals.developerModeKey) && beingPressed == false)
            {
                beingPressed = true;
                if(developerView == false)
                {
                    developerView = true;
                }
                else if (developerView == true)
                {
                    developerView = false;

                }
            }

            if (Keyboard.GetState().IsKeyUp(Globals.developerModeKey))
            {
                beingPressed = false;
            }


        }

        public override void Draw(SpriteBatch _spriteBatch)
        {// draws all of the items on the game screen, map, player items etc.
            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            base.Draw(_spriteBatch);
            db.Draw(_spriteBatch);

            em.Draw(_spriteBatch);
            nm.Draw(_spriteBatch);

            dc.Draw(_spriteBatch);

            MainPlayer.Draw(_spriteBatch);
            _spriteBatch.End();


        }




        void setGameScreenData()
        {
            // opens a file 
            FileManager fm = new FileManager();
            // reades the data from the file using my pre programmed functions
            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");
            // sets the values in game to the values stored in the presets file
            foreach(string x in data)
            {
                string[] lines = x.Split(':');

                if (lines[0] == "numberOfCoins")
                {
                    numberOfCoins = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "numberOfZombies")
                {
                    numberOfZombies = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "numberOfVillagers")
                {
                    numberOfVillagers = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "devView")
                {
                    developerView = Convert.ToBoolean(lines[1]);
                }

            }


        }









    }
}

