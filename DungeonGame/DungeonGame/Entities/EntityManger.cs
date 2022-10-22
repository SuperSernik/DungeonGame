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

namespace DungeonGame.Entities
{
    class EntityManger
    {

        public List<Entity> DrawChests(ContentManager Content)
        {
            TileSearch ts = new TileSearch();
            // Returns all of the positions where a chest should be.
            List<PositionOnMap> ListOfChestPositions = ts.ReturnLocationsOfObjectsFromForeground('C');
            List<Entity> ListOfChestsToDraw = new List<Entity>();

            foreach (PositionOnMap x in ListOfChestPositions)
            {
                // Foreach place that there is a chest on the map 
                // create a new chest.
                Chest c = new Chest(x.Row, x.Col);
                // Load its texture into memory.
                c.LoadContent(Content);
                // Add it to the list of chests that will be 
                // used to draw it later.
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
