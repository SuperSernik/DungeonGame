using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ScreenManagement.MenuItems
{
    class ScreenButton
    {
        // vars 
        Vector2 buttonPos;
        string buttonTEXT;
        public string buttonType;

        Texture2D buttonTextureAtlas;
        Rectangle[] sourceRect;

        Rectangle pressed;
        Rectangle released;

        Rectangle btnSourceRect;

        SpriteFont Arial24;
        Vector2 textPos;

        public bool btnPressed;
        public bool btnHoveredOver;

        public Rectangle buttonRect;

        MouseState mouse;
        MouseState mBtnState;

        string btnDesign;

        // 2 different constructors for 2 different button variations
        public ScreenButton(Vector2 Postion, string text, string type, string NEWbtnDesgn)
        {
            buttonPos = Postion;
            buttonTEXT = text;  
            buttonType = type;
            btnDesign = NEWbtnDesgn;

        }
        public ScreenButton(Vector2 Postion, string type, string NEWbtnDesign)
        {
            buttonPos = Postion;
            buttonTEXT = " ";
            buttonType = type;
            btnDesign = NEWbtnDesign;
        }

        public void LoadContent(ContentManager Content)
        {// loads in the texture of the button
            buttonTextureAtlas = Content.Load<Texture2D>("MenuScreens/MenuItems/buttonTextureAtlas");
            Arial24 = Content.Load<SpriteFont>("Fonts/Arial24");

            if(btnDesign == "boxOne")
            {// sets up the parameters for a standard box button
                btnSourceRect = new Rectangle(0, 0, 192, 80);
                buttonRect = new Rectangle((int)buttonPos.X, (int)buttonPos.Y, (int)(btnSourceRect.Width * 1.5), (int)(btnSourceRect.Height * 1.5));


            }
            if (btnDesign == "cross")
            {// sets up the parameters for an exit button
                btnSourceRect = new Rectangle(192, 0, 80, 80);
                buttonRect = new Rectangle((int)buttonPos.X, (int)buttonPos.Y, (int)(btnSourceRect.Width * 1), (int)(btnSourceRect.Height * 1));

            }

            // makes sure that the text is well positioned on the screen
            textPos = new Vector2(((buttonRect.X + (buttonRect.Width / 2))) - (buttonTEXT.Length/2) * 16, (buttonRect.Y + (buttonRect.Height / 2)) -15);

            btnPressed = false;

        }

        public void Update(GameTime gametime)
        {
            mouse = Mouse.GetState();
            mBtnState = Mouse.GetState();
            // this changes the color of the button as the user hovers over the button 
            if (buttonRect.Contains(new Rectangle((int)mouse.Position.X, (int)mouse.Position.Y, 1, 1)))
            {
                btnHoveredOver = true;
            }
            else
            {
                btnHoveredOver = false;
            }
            // this checks for the button being pressed.
            if(buttonRect.Contains(new Rectangle((int)mouse.Position.X, (int)mouse.Position.Y, 1, 1)) && (mouse.LeftButton == ButtonState.Pressed))
            {
                btnPressed = true;
            }
            else
            {
                btnPressed = false;
                    
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            if (!btnHoveredOver)
            {// draws the button to the screen
                _spriteBatch.Draw(buttonTextureAtlas, buttonRect, btnSourceRect, Color.White); // button    
                _spriteBatch.DrawString(Arial24, buttonTEXT, textPos, Color.Wheat);             // text on the button
            }
            else if (btnPressed)
            {
                _spriteBatch.Draw(buttonTextureAtlas, buttonRect, btnSourceRect, Color.Red);// button    
                _spriteBatch.DrawString(Arial24, buttonTEXT, textPos, Color.Red);            // text on the button
            }
            else if (btnHoveredOver)
            {
                _spriteBatch.Draw(buttonTextureAtlas, buttonRect, btnSourceRect, new Color(Color.Blue, 1f));// button    
                _spriteBatch.DrawString(Arial24, buttonTEXT, textPos, new Color(Color.Blue, 1f));            // text on the button
            }



        }


    }
}
