using DungeonGame.BackendDev;
using DungeonGame.NPCs;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ScreenManagement.Screens;
using System.Reflection.Metadata;

namespace DungeonGame.Entities
{
    class EntityManger
    {
        List<Entity> Entities = new List<Entity>();

        public EntityManger()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            addEntitiesToList(DrawChests(Content));
            addEntitiesToList(CreateCoins(Content, GameScreen.numberOfCoins));
            addEntitiesToList(CreateInGameButton(Content));
        }

        public void Update(GameTime gameTime)
        {
            List<Entity> toRem = new List<Entity>();
            foreach (Entity entity in Entities)
            {
                entity.Update(gameTime);
                entity.Update(gameTime, GameScreen.MainPlayer);

                if(entity.remove == true)
                {
                    toRem.Add(entity);
                }
            }
            foreach (Entity en in toRem)
            {
                Entities.Remove(en);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Entity entity in Entities) { entity.Draw(_spriteBatch); }

        }
        void addEntitiesToList(List<Entity> listOfEntities)
        {
            foreach (Entity en in listOfEntities)
            {
                Entities.Add(en);
            }
        }
        public List<Entity> DrawChests(ContentManager Content)
        {
            TileSearch ts = new TileSearch();
            List<PositionOnMap> ListOfChestPositions = ts.ReturnLocationsOfObjectsFromForeground('C');
            List<Entity> ListOfChestsToDraw = new List<Entity>();

            foreach (PositionOnMap x in ListOfChestPositions)
            {

                Chest c = new Chest(x.Row, x.Col);
                c.LoadContent(Content);
                ListOfChestsToDraw.Add(c);

            }
            return ListOfChestsToDraw;
        }

        public List<Entity> CreateCoins(ContentManager Content, int numberOfCoins)
        {
            List<Entity> ListOfCoins = new List<Entity>();

            for(int i = 0; i < numberOfCoins; i++)
            {
                Coin c = new Coin();
                c.LoadContent(Content);
                ListOfCoins.Add(c);

            }
            return ListOfCoins;
        }

        public List<Entity> CreateInGameButton(ContentManager Content)
        {
            TileSearch ts = new TileSearch();
            List<PositionOnMap> listOfButtonsInLayerRED = ts.ReturnLocationsOfObjectsFromForeground('M');
            List<PositionOnMap> listOfButtonsInLayerGREEN = ts.ReturnLocationsOfObjectsFromForeground('N');


            List<Entity> listOfButtons = new List<Entity>();
            foreach (PositionOnMap x in listOfButtonsInLayerRED)
            {
                InGameButton b = new InGameButton("red", new Vector2(x.Col * 32, x.Row * 32));
                b.LoadContent(Content);
                listOfButtons.Add(b);
            }
            foreach (PositionOnMap y in listOfButtonsInLayerGREEN)
            {
                InGameButton j = new InGameButton("green", new Vector2(y.Col * 32, y.Row * 32));
                j.LoadContent(Content);
                listOfButtons.Add(j);
            }

            return listOfButtons;

        }


    }
}
