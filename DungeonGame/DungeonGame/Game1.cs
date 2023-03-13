using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonGame.MapManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.BackendDev;
using System.Diagnostics;

namespace DungeonGame
{
    public class Game1 : Game
    {
        // main graphics and spritebatch variables
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public static string currentGAMESCREEN;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // sets window res to desired parameters
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Resolution.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Resolution.Y;

            // full screen and mouse visability
            _graphics.IsFullScreen = ScreenManager.Instance.IsFULL_SCREEN;
            IsMouseVisible = ScreenManager.Instance.IsMOUSE_VISABLE;
            
            // generic window settings
            Window.AllowAltF4 = true;
            Window.AllowUserResizing = false;
            Window.IsBorderless = false;
            _graphics.ApplyChanges();
            
            // sets the curretn gamescreen for the screen manager
            currentGAMESCREEN = "GameScreen";


            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // activates all of the singleton classes
            Globals._spriteBatch = _spriteBatch;
            Globals._content = Content;
            Globals._graphics = _graphics;
            MapLayerManager.Instance.LoadContent(Content);
            ScreenManager.Instance.LoadContent(Content);
            ScreenManager.Instance._spriteBatch = _spriteBatch;
            OverlayManager.Instance.LoadContent(Content);
            OverlayManager.Instance._spriteBatch = _spriteBatch;


        }
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals._gameTime = gameTime;
            // provides a connection to a game controller if it exists
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // window settings
            IsMouseVisible = ScreenManager.Instance.IsMOUSE_VISABLE;
            _graphics.IsFullScreen = ScreenManager.Instance.IsFULL_SCREEN;
            _graphics.ApplyChanges();

            // game update loop for game screen and overlay screen
            ScreenManager.Instance.Update(gameTime, this, _graphics);
            OverlayManager.Instance.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            // draws the game onto the screen
            ScreenManager.Instance.Draw(_spriteBatch);
            OverlayManager.Instance.Draw(_spriteBatch);


            base.Draw(gameTime);
        }
        public string CurrentGameScreen
        {
            // getter for this screen
            get { return currentGAMESCREEN; }
        }
        public void Quit()
        {
            // ends game
            this.Exit();
        }
    }
}