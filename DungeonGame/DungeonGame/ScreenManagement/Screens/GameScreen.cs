using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Entities;
using DungeonGame.MapManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement.ScreenStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonGame.NPCs;
using DungeonGame.BackendDev;

namespace DungeonGame.ScreenManagement.Screens
{
    public class GameScreen : UserScreen
    {

        int numberOfZombies;
        int numberOfVillagers;
        int numberOfCoins;
        public static bool developerView;


        public static Player MainPlayer = new Player();
        DrawBackground db = new DrawBackground(ScreenManager.visibleMAP);
        EntityManger em = new EntityManger();
        NPCManager nm = new NPCManager();

        Camera _camera;

        List<Entity> Entities = new List<Entity>();
        List<NPC> NPCs = new List<NPC>();

        public GameScreen()
        {
            screenType = "game";
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            setGameScreenData();
            db.LoadContent(Content);

            _camera = new Camera();
            addEntitiesToList(em.DrawChests(Content));
            addEntitiesToList(em.CreateCoins(Content, numberOfCoins));
            addEntitiesToList(em.CreateInGameButton(Content));

            addNPCsToList(nm.CreateZombies(Content, numberOfZombies));
            addNPCsToList(nm.CreateVillagers(Content, numberOfVillagers));

            MainPlayer.LoadContent(Content);

        }


        public override void UnloadContent()
        {
            base.UnloadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            MainPlayer.Update(gameTime);
            _camera.Follow(MainPlayer);

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                switchToScreen = "menu";
            }

            foreach (Entity entity in Entities)
            {

                entity.Update(gameTime);
                entity.Update(gameTime, MainPlayer);
            }

            foreach (NPC npc in NPCs)
            {
                npc.Update(gameTime, MainPlayer.HitBox);
                npc.Update(gameTime); 
            }

            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(transformMatrix: _camera.Transform);


            base.Draw(_spriteBatch);
            db.Draw(_spriteBatch);


            foreach (Entity entity in Entities) { entity.Draw(_spriteBatch); }

            foreach(NPC npc in NPCs) { npc.Draw(_spriteBatch); }



            MainPlayer.Draw(_spriteBatch);
            _spriteBatch.End();

        }

        void setGameScreenData()
        {
            FileManager fm = new FileManager();

            List<string> data = fm.ReadDataLineByLine("GameScreenData.txt");

            foreach(string x in data)
            {
                string[] lines = x.Split(':');

                if (lines[0] == "numberOfCoins")
                {
                    numberOfCoins = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "numberOfZombies")
                {
                    numberOfZombies = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "numberOfVillagers")
                {
                    numberOfVillagers = Convert.ToInt32(lines[1]);
                }
                if (lines[0] == "devView")
                {
                    developerView = Convert.ToBoolean(lines[1]);
                }

            }


        }



        void addNPCsToList(List<NPC> listOfNPCs)
        {
            foreach (NPC npc in listOfNPCs)
            {
                NPCs.Add(npc);
            }
        }
        void addEntitiesToList(List<Entity> listOfEntities)
        {
            foreach (Entity en in listOfEntities)
            {
                Entities.Add(en);
            }
        }

    }
}

