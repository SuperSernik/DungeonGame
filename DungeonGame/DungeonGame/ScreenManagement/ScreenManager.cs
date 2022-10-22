using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.BackendDev;
using DungeonGame.MapManagement;
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.ScreenManagement.ScreenStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.ScreenManagement
{

    class ScreenManager
    {
        private static ScreenManager instance;
        public ContentManager Content { private set; get; }
        public SpriteBatch _spriteBatch;

        public UserScreen currentScreen;


        public static char[,] visibleMAP;
        public static char[,] visibleLAYER;

        public UserScreen splashScreen;
        public UserScreen mainMenuScreen;
        public UserScreen gameScreen;
        public UserScreen mainSettingsScreen;

        public bool IsFULL_SCREEN;

        public UserScreen CurrentScreen
        {
            get { return currentScreen; }
        }

        List<UserScreen> screens = new List<UserScreen>();

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public char[,] Vmap
        {
            get { return Vmap; }
            set { visibleMAP = value; }
        }


        public Vector2 Resolution;
        public static Vector2 MapDimentions;


        public ScreenManager()
        {
            Resolution = new Vector2(1600, 960);
            //Resolution = new Vector2(1920, 1080);
            //Resolution = new Vector2(1280, 720);

            IsFULL_SCREEN = false;

            //MapDimentions = new Vector2(100, 100);

            //visibleMAP = MapLayerManager.Instance.FTESTMAP;
            //visibleLAYER = MapLayerManager.Instance.layerOne;

            setMap();

            splashScreen = new SplashScreen();
            mainMenuScreen = new MenuScreen();
            mainSettingsScreen = new SettingsScreen();
            gameScreen = new GameScreen();

            // #################  CHANGE DISPLAY SCREEN HERE  ########################
            currentScreen = gameScreen;
            // #######################################################################

            screens.Add(splashScreen);
            screens.Add(mainMenuScreen);
            screens.Add(gameScreen);
            screens.Add(mainSettingsScreen);

        }

        void setMap()
        {

            FileManager fm = new FileManager();
            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");

            foreach (string x in data)
            {
                string[] lines = x.Split(':');

                if (lines[0] == "map")
                {
                    if (lines[1] == "FOne")
                    {
                        visibleMAP = MapLayerManager.Instance.FMapOne;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(50, 30);
                        return;
                    }
                    else if (lines[1] == "FTwo")
                    {
                        visibleMAP = MapLayerManager.Instance.FMapTwo;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(50, 30);
                        return;
                    }
                    else if(lines[1] == "FThree")
                    {
                        visibleMAP = MapLayerManager.Instance.FMapThree;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(50, 30);
                        return;
                    }
                    else if(lines[1] == "FLargeMapOne")
                    {
                        visibleMAP = MapLayerManager.Instance.FLargeMapOne;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(100, 100);
                        return;
                    }
                    else if (lines[1] == "FTESTMAP")
                    {
                        visibleMAP = MapLayerManager.Instance.FTESTMAP;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(100, 100);
                        return;
                    }


                }


            }

        }

        public void changeScreens()
        {
            if(true)
            {
                
            }
            if (true)
            {

            }
            if (true)
            {

            }

        }


        void toggleScreenSize(GraphicsDeviceManager _graphics)
        {
            bool fullScreen = false;
            if (Keyboard.GetState().IsKeyDown(Keys.N) && !fullScreen)
            {
                Resolution = new Vector2(1920, 1080);
                _graphics.IsFullScreen = true;
                _graphics.ApplyChanges();
                fullScreen = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.N) && fullScreen)
            {
                Resolution = new Vector2(1600, 960);
                _graphics.IsFullScreen = false;
                _graphics.ApplyChanges();
                fullScreen = false;
            }
        }



        public virtual void LoadContent(ContentManager Content)
        {
            DevTexturesManger.Instance.LoadContent(Content);

            //currentScreen.LoadContent(Content); 

            foreach (UserScreen x in screens)
            {
                x.LoadContent(Content);
            }


        }
        public virtual void UnloadContent()
        {

        }


        bool switchScreenFromTo(string screenType, string screenToSwitchTo)
        {
            if(currentScreen.screenType == screenType && currentScreen.switchToScreen == screenToSwitchTo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        void SwitchingScreensLogic()
        {
            if (currentScreen.screenType == "splash" && currentScreen.switchToScreen == "menu" && currentScreen != mainMenuScreen)
            {
                screens.Remove(currentScreen);
                currentScreen = mainMenuScreen;
            }

            if(switchScreenFromTo("menu", "gameScreen"))
            {
                currentScreen = gameScreen;
                mainMenuScreen.switchToScreen = null;
            }
            if(switchScreenFromTo("menu", "settingsScreen"))
            {
                currentScreen = mainSettingsScreen;
                mainMenuScreen.switchToScreen = null;
            }
            if(switchScreenFromTo("game", "menu"))
            {
                currentScreen = mainMenuScreen;
                gameScreen.switchToScreen = null;
            }
            if(switchScreenFromTo("settings", "menu"))
            {
                currentScreen = mainMenuScreen;
                mainSettingsScreen.switchToScreen = null;

            }

        }

        public virtual void Update(GameTime gameTime, Game1 game1, GraphicsDeviceManager _graphics)
        {
            //toggleScreenSize(_graphics);

            currentScreen.Update(gameTime, game1);
            currentScreen.Update(gameTime);

            SwitchingScreensLogic();
            

            /*
            if(currentScreen.screenType == "splash" && currentScreen.switchToScreen == "menu" && currentScreen != mainMenuScreen)
            {
                screens.Remove(currentScreen);
                currentScreen = mainMenuScreen;
            }

            if (currentScreen.screenType == "menu" && currentScreen.switchToScreen == "gameScreen")
            {
                currentScreen = gameScreen;
                mainMenuScreen.switchToScreen = null;
            }

            if (currentScreen.screenType == "menu" && currentScreen.switchToScreen == "settingsScreen")
            {
                currentScreen = mainSettingsScreen;
                mainMenuScreen.switchToScreen = null;
            }

            if (currentScreen.screenType == "game" && currentScreen.switchToScreen == "menu")
            {
                currentScreen = mainMenuScreen;
                gameScreen.switchToScreen = null;
            }

            if (currentScreen.screenType == "settings" && currentScreen.switchToScreen == "menu")
            {
                currentScreen = mainMenuScreen;
                mainSettingsScreen.switchToScreen = null;
            }
            */


        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {

            currentScreen.Draw(_spriteBatch);

        }



        

    }
}
