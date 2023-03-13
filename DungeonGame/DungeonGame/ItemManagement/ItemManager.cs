using DungeonGame.PlayerManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ScreenManagement.Screens;

namespace DungeonGame.ItemManagement.Items
{
    public class ItemManager
    {
        // creates the items
        public static Weapon nyanLauncher = new Weapon("weapon", "nyanLauncher");
        public static Weapon pp = new Weapon("weapon", "pp");
        public static Food cake = new Food("food", "cake");
        public static Food vodka = new Food("food", "vodka");
        public static Food banana = new Food("food", "banana");
        public static Pistol pistol = new Pistol("weapon", "pistol");
        public static Bazooka bazooka = new Bazooka("weapon", "bazooka");

        // list of all existing items
        // (such as a creative menu in minecraft)
        public static List<Item> listOfAllItems = new List<Item>();


        public void LoadContent(ContentManager content)
        {
            // loads textures for the items 
            pistol.LoadContent(content);
            nyanLauncher.LoadContent(content);
            bazooka.LoadContent(content);
            pp.LoadContent(content);

            cake.LoadContent(content);
            vodka.LoadContent(content);
            banana.LoadContent(content);

            // adds items to list of all items
            listOfAllItems.AddRange(new List<Item>
            {
                pistol,
                nyanLauncher,
                bazooka,
                pp,
                cake,
                vodka,
                banana
            });

        }
        public void Update(GameTime gameTime, Player p)
        {
            // updates values for items 
            foreach (var x in listOfAllItems)
            {
                x.Update(gameTime, p.playerPositionORIGIN);
                
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {// draws items
            //pistol.Draw(_spriteBatch);
            if(GameScreen.MainPlayer.CurrentItemHeld != null)
            {
                GameScreen.MainPlayer.CurrentItemHeld.Draw(_spriteBatch);
            }

        }

        /*
pistol.Update(gameTime, p.playerPositionORIGIN);
nyanLauncher.Update(gameTime, p.playerPositionORIGIN);
bazooka.Update(gameTime, p.playerPositionORIGIN);
pp.Update(gameTime, p.playerPositionORIGIN);

cake.Update(gameTime, p.playerPositionORIGIN);
vodka.Update(gameTime, p.playerPositionORIGIN);
banana.Update(gameTime, p.playerPositionORIGIN);
*/

    }
}
