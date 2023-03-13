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
{// takes charge of createing new entities and updating them
    class EntityManger
    {
        // all entties are stored in this list
        List<Entity> Entities = new List<Entity>();

        public EntityManger()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            // loads all entities into memory
            addEntitiesToList(DrawChests(Content));
            addEntitiesToList(CreateCoins(Content, GameScreen.numberOfCoins));
            addEntitiesToList(CreateInGameButton(Content));
        }

        public void Update(GameTime gameTime)
        {
            // updates position of entites and whether they are 
            // bein interacted with
            List<Entity> toRem = new List<Entity>();
            foreach (Entity entity in Entities)
            {
                entity.Update(gameTime);
                entity.Update(gameTime, GameScreen.MainPlayer);

                // this removes entities, eg when a coins
                // has been picked up
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
        {// draws all entities
            foreach (Entity entity in Entities) { entity.Draw(_spriteBatch); }

        }
        // adds entites to the main list
        void addEntitiesToList(List<Entity> listOfEntities)
        {
            foreach (Entity en in listOfEntities)
            {
                Entities.Add(en);
            }
        }
        public List<Entity> DrawChests(ContentManager Content)
        {
            // creates chest on the map
            TileSearch ts = new TileSearch();
            // gets locations of chests on map
            List<PositionOnMap> ListOfChestPositions = ts.ReturnLocationsOfObjectsFromForeground('C');
            List<Entity> ListOfChestsToDraw = new List<Entity>();

            // for every poision of chest on map, places a chest there
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
            // places random coins onf the map
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
            // places in game buttons from the locations found on the layer map
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
