using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    public class DevTexturesManger
    {
        private static DevTexturesManger instance;
        public ContentManager Content { private set; get; }
        public SpriteBatch _spriteBatch;
        public static DevTexturesManger Instance
        {
            get
            {
                if (instance == null)
                    instance = new DevTexturesManger();
                return instance;
            }
        }

        public Texture2D redNode, blueBox;
        

        public void LoadContent(ContentManager Content)
        {
            redNode = Content.Load<Texture2D>("DevAidTextures/redNode2px");
            blueBox = Content.Load<Texture2D>("DevAidTextures/blueBox2px");


        }

    }
}
