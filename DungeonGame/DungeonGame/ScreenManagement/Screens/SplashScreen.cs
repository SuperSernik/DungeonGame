using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.ScreenManagement.Screens
{
    public class SplashScreen : UserScreen
    {
        Texture2D image;
        Rectangle imageRect;
        Vector2 origin;

        Texture2D faderPxl;
        Rectangle faderRect;
        double faderOpacity;
        double fadeSpeed;

        float timer;
        int threshold;

        public static bool readyToSwitch;

        public bool ReadyToSwitch
        {
            get { return readyToSwitch; }
        }

        public SplashScreen()
        {
            screenType = "splash";
            switchScreens = false;
        }
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            image = Content.Load<Texture2D>("SplashScreens/DamoDevRed");
            origin = new Vector2(image.Width / 2, image.Height / 2);
            imageRect = new Rectangle((int)(ScreenManager.Instance.Resolution.X / 2) - (int)origin.X,
                (int)(ScreenManager.Instance.Resolution.Y / 2) - (int)origin.Y, image.Width, image.Height);

            faderPxl = Content.Load<Texture2D>("Fx/BlackPixel");
            faderRect = new Rectangle(0, 0, (int)ScreenManager.Instance.Resolution.X, (int)ScreenManager.Instance.Resolution.Y);
            faderOpacity = 2d;
            fadeSpeed = 0.0000000000000000001d;
            readyToSwitch = false;

            timer = 0;
            threshold = 5;

        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (faderOpacity > -2)
            {
                faderOpacity -= fadeSpeed + (double)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (timer > threshold)
            {
                readyToSwitch = true;
                switchToScreen = "menu";
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            base.Draw(_spriteBatch);
            _spriteBatch.Draw(image, imageRect, Color.White);
            _spriteBatch.Draw(faderPxl, faderRect, new Color(Color.Black, (float)faderOpacity));
            _spriteBatch.End();
        }

    }
}
