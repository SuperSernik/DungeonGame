using DungeonGame.Entities;
using DungeonGame.NPCs.Characters;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.NPCs
{
    class NPCManager
    {

        List<NPC> NPCs = new List<NPC>();

        public NPCManager()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            addNPCsToList(CreateZombies(Content, GameScreen.numberOfZombies));
            addNPCsToList(CreateVillagers(Content, GameScreen.numberOfVillagers));
        }

        public void Update(GameTime gameTime)
        {
            foreach (NPC npc in NPCs)
            {
                npc.Update(gameTime, GameScreen.MainPlayer.HitBox);
                npc.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (NPC npc in NPCs) { npc.Draw(_spriteBatch); }
        }




        void addNPCsToList(List<NPC> listOfNPCs)
        {
            foreach (NPC npc in listOfNPCs)
            {
                NPCs.Add(npc);
            }
        }

        public List<NPC> CreateZombies(ContentManager Content, int ammountOfZombies)
        {
            // Create a list of zombies of type NPC
            List<NPC> ListOfZombies = new List<NPC>();
            for (int i = 0; i < ammountOfZombies; i++)
            {
                // Create new zombie
                Zombie zom = new Zombie();
                // Load the texture of the zombies
                zom.LoadContent(Content);
                // Add the new zombie to the list
                ListOfZombies.Add(zom);
            }// Return the list the the 'gameScreen' Class
            return ListOfZombies;
        }

        public List<NPC> CreateVillagers(ContentManager Content, int ammountOfVillagers)
        {// Create a list of NPCs to return
            List<NPC> ListOfVillagers = new List<NPC>();
            // Create the ammount of villagers as specified in the
            //  ammount of villagers variable
            for (int i = 0; i < ammountOfVillagers; i++)
            {
                // Create the villager
                Villager villager = new Villager();
                // Load its texture
                villager.LoadContent(Content);
                // Add it to the list
                ListOfVillagers.Add(villager);
            }// return the list
            return ListOfVillagers;
        }




    }
}
