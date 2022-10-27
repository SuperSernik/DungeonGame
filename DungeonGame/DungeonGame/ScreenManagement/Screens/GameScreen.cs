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

namespace DungeonGame.ScreenManagement.Screens
{
    public class GameScreen : UserScreen
    {

        public static int numberOfZombies, numberOfVillagers, numberOfCoins;
        public static bool developerView;



        public static Player MainPlayer = new Player();
        DrawBackground db = new DrawBackground(ScreenManager.visibleMAP);
        EntityManger em = new EntityManger();
        NPCManager nm = new NPCManager();
        Camera _camera;

        // TESTING
        DrawCheck dc = new DrawCheck();

        public GameScreen()
        {
            screenType = "game";
        }

        public override void LoadContent(ContentManager Content)
        {
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
        {
            base.UnloadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            em.Update(gameTime);
            nm.Update(gameTime);

            MainPlayer.Update(gameTime);
            _camera.Follow(MainPlayer);

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                switchToScreen = "menu";
            }
            dc.Update(gameTime);

            toggleDevMode();

        }


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
        {
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
            FileManager fm = new FileManager();

            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");

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

