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
        //SINGLETON CLASS STUFF
        private static ScreenManager instance;
        public ContentManager Content { private set; get; }
        public SpriteBatch _spriteBatch;
        public UserScreen currentScreen;

        // BACKGROUND STUUF
        public static char[,] visibleMAP;
        public static char[,] visibleLAYER;

        // SCREENS
        public UserScreen splashScreen;
        public UserScreen mainMenuScreen;
        public UserScreen gameScreen;
        public UserScreen mainSettingsScreen;
        public UserScreen controlsDisplayScreen;

        public bool IsFULL_SCREEN;
        public bool IsMOUSE_VISABLE;

        bool fullScreen;

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
            SetResAndScreenSize();

            setMap();
            //MapDimentions = new Vector2(100, 100);
            //visibleMAP = MapLayerManager.Instance.FTESTMAP;
            //visibleLAYER = MapLayerManager.Instance.layerOne;

            splashScreen = new SplashScreen();
            mainMenuScreen = new MenuScreen();
            mainSettingsScreen = new SettingsScreen();
            gameScreen = new GameScreen();
            controlsDisplayScreen = new DisplayControlsScreen();

            // #################  CHANGE DISPLAY SCREEN HERE  ########################
            currentScreen = gameScreen;
            // #######################################################################

            screens.Add(splashScreen);
            screens.Add(mainMenuScreen);
            screens.Add(gameScreen);
            screens.Add(mainSettingsScreen);
            screens.Add(controlsDisplayScreen);

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


        public virtual void Update(GameTime gameTime, Game1 game1, GraphicsDeviceManager _graphics)
        {
            //toggleScreenSize(_graphics);
            //toggleFullscreen();
            toggleScreenSize();

            currentScreen.Update(gameTime, game1);
            currentScreen.Update(gameTime);

            SwitchingScreensLogic();
            


        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {

            currentScreen.Draw(_spriteBatch);

        }


        bool switchScreenFromTo(string screenType, string screenToSwitchTo)
        {
            if (currentScreen.screenType == screenType && currentScreen.switchToScreen == screenToSwitchTo)
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

            if (switchScreenFromTo("menu", "gameScreen"))
            {
                currentScreen = gameScreen;
                mainMenuScreen.switchToScreen = null;
            }
            if (switchScreenFromTo("menu", "settingsScreen"))
            {
                currentScreen = mainSettingsScreen;
                mainMenuScreen.switchToScreen = null;
            }
            if (switchScreenFromTo("menu", "controlsDisplay"))
            {
                currentScreen = controlsDisplayScreen;
                mainMenuScreen.switchToScreen = null;
            }
            if (switchScreenFromTo("game", "menu"))
            {
                currentScreen = mainMenuScreen;
                gameScreen.switchToScreen = null;
            }
            if (switchScreenFromTo("settings", "menu"))
            {
                currentScreen = mainMenuScreen;
                mainSettingsScreen.switchToScreen = null;
            }
            if (switchScreenFromTo("controlsDisplay", "menu"))
            {
                currentScreen = mainMenuScreen;
                controlsDisplayScreen.switchToScreen = null;
            }

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
                    else if (lines[1] == "FThree")
                    {
                        visibleMAP = MapLayerManager.Instance.FMapThree;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(50, 30);
                        return;
                    }
                    else if (lines[1] == "FLargeMapOne")
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
                    else if (lines[1] == "FMAPfour")
                    {
                        visibleMAP = MapLayerManager.Instance.FMAPfour;
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        MapDimentions = new Vector2(50, 30);
                        return;
                    }


                }


            }

        }

        bool beingPressed = false;
        void toggleScreenSize()
        {

            if (Keyboard.GetState().IsKeyDown(Globals.fullScreenKey) && beingPressed == false)
            {
                beingPressed = true;
                if (fullScreen == false)
                {
                    fullScreen = true;

                    Resolution = new Vector2(1920, 1080);
                    IsFULL_SCREEN = true;
                }
                else if (fullScreen == true)
                {
                    fullScreen = false;

                    Resolution = new Vector2(1600, 960);
                    IsFULL_SCREEN = false;


                }
            }

            if (Keyboard.GetState().IsKeyUp(Globals.fullScreenKey))
            {
                beingPressed = false;
            }

        }

        void SetResAndScreenSize()
        {
            FileManager fm = new FileManager();
            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");

            foreach (string x in data)
            {
                string[] lines = x.Split(':');

                if (lines[0] == "fullscreen")
                {
                    fullScreen = Convert.ToBoolean(lines[1]);
                }

            }

            if (fullScreen == true)
            {
                Resolution = new Vector2(1920, 1080);
                IsFULL_SCREEN = true;
            }
            if (fullScreen == false)
            {
                Resolution = new Vector2(1600, 960);
                IsFULL_SCREEN = false;
            }
            //Resolution = new Vector2(1280, 720);
        }



    }
}
