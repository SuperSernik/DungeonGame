using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonGame.MapManagement;
using DungeonGame.PlayerManagement;

namespace DungeonGame
{
    public class Game1 : Game
    {
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
            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Resolution.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Resolution.Y;

            _graphics.IsFullScreen = ScreenManager.Instance.IsFULL_SCREEN;
            _graphics.ApplyChanges();

            currentGAMESCREEN = "GameScreen";


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            ScreenManager.Instance.Update(gameTime, this, _graphics);
            OverlayManager.Instance.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            ScreenManager.Instance.Draw(_spriteBatch);
            OverlayManager.Instance.Draw(_spriteBatch);



            base.Draw(gameTime);
        }





        public string CurrentGameScreen
        {
            get { return currentGAMESCREEN; }
        }

        public void Quit()
        {
            this.Exit();
}
    }
}