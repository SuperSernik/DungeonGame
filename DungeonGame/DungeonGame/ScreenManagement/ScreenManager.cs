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
    // this is the main class that control everything in the game
    // this class decides between which screens are being displayed at
    // what time as well as set up basic settings such as window resolution 
    class ScreenManager
    {
        //ATTRIBUTES
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
        // SCREEN SETTINGS
        public bool IsFULL_SCREEN;
        public bool IsMOUSE_VISABLE;

        bool fullScreen;
        // current screen getter
        public UserScreen CurrentScreen
        {
            get { return currentScreen; }
        }
        // list that contains all of the screens
        List<UserScreen> screens = new List<UserScreen>();

        // sets up the class as a singleton class
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }
        // getter / setter for the map that is used
        public char[,] Vmap
        {
            get { return Vmap; }
            set { visibleMAP = value; }
        }


        public Vector2 Resolution;
        public static Vector2 MapDimentions;




        public ScreenManager()
        {
            SetResAndScreenSize(); // sets the windows size and res

            setMap(); // sets the map
            //MapDimentions = new Vector2(100, 100);
            //visibleMAP = MapLayerManager.Instance.FTESTMAP;
            //visibleLAYER = MapLayerManager.Instance.layerOne;

            // creats all of the new screens that a used
            splashScreen = new SplashScreen();  
            mainMenuScreen = new MenuScreen();
            mainSettingsScreen = new SettingsScreen();
            gameScreen = new GameScreen();
            controlsDisplayScreen = new DisplayControlsScreen();

            // #################  CHANGE DISPLAY SCREEN HERE  ########################
            currentScreen = mainMenuScreen;
            // #######################################################################

            // adds all of the screens being used to the list
            // so that they can be cycled through when neccessary
            screens.Add(splashScreen);
            screens.Add(mainMenuScreen);
            screens.Add(gameScreen);
            screens.Add(mainSettingsScreen);
            screens.Add(controlsDisplayScreen);
        }

        public virtual void LoadContent(ContentManager Content)
        {
            // loads textures for hitboxes etc.
            DevTexturesManger.Instance.LoadContent(Content);

            //currentScreen.LoadContent(Content); 
            // loads the data for each screen in the screens array
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
            // updates what is happening on the screens
            currentScreen.Update(gameTime, game1);
            currentScreen.Update(gameTime);
            // handles switching screens
            SwitchingScreensLogic();
            


        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            // draws all of the things that the user can see 
            // on the screen
            currentScreen.Draw(_spriteBatch);

        }

        // switching logic
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


        // all of the possible combinations of switching screens
        void SwitchingScreensLogic()
        {
            // This method makes use of the screenType attribute, and depending on what screen the player is currently on
            // the game will transfere then to another window after an event such as a back button is clicked etc.


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
            //this method sets the map for the game

            // opens and reads the data from a file
            FileManager fm = new FileManager();
            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");

            foreach (string x in data)
            {
                string[] lines = x.Split(':');
                // depending on what data is stored in the presets file
                // is what the game will use as the startup data

                if (lines[0] == "map")
                {
                    if (lines[1] == "FOne")
                    {   // if this is the map the game needs to draw then
                        // sets the visable map to this one
                        visibleMAP = MapLayerManager.Instance.FMapOne;
                        // sets the visable layer to this one
                        visibleLAYER = MapLayerManager.Instance.layerOne;
                        // sets the map dimentions to these
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
            // this is the logic for switching to fullscreen
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
            // sets the res depening of the file from the presets file
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
