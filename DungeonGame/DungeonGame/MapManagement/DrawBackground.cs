using DungeonGame;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using DungeonGame.ScreenManagement;
using System.IO;
using DungeonGame.BackendDev;
using System.ComponentModel;

namespace DungeonGame.MapManagement
{
    class DrawBackground
    {
        const char DEFAULT_TEXTURE = ' ';
        const char EMPTY_TEXTURE = '#';
        const char SPAWN_TILE = '@';
        const char FINISH_TILE = '%';

        const char WALL = 'R';
        const char WATER = 'W';
        const char WOODEN_PLANKS = 'B';
        const char GRASS = 'G';
        const char GLOWING_SQUARE = 'A';
        const char SANDISH = 'S';
        const char BLACK_WHITE_TILE = 'T';
        const char COBBLE = 'E';
        const char LAVA = 'L';
        const char WOODEN_TP = 'P';


        private Texture2D tileTextureTileMap;
        private Vector2 tilePos;

        char tile;
        private int tileSize = 32;

        char[,] drawThisMap;

        public DrawBackground(char[,] newMap)
        {
            drawThisMap = newMap;
        }

        public void LoadContent(ContentManager Content)
        {  
            tileTextureTileMap = Content.Load<Texture2D>("TileMaps/TileMapBack");

            //tilePos = Vector2.Zero;
        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        static Rectangle CreateRectangle(Vector2 tilePos, int pixelSize, int row, int column)
        {
            // Creates a rectangle from the position of the tile (x, y) and the size of the tile, (width and height)
            // Since my tiles are squares, the width and the height are the same.
            Rectangle thisRectangle = new Rectangle((int)tilePos.X, (int)tilePos.Y, pixelSize, pixelSize);

            // This calculates the new position of the tile, the column and row position are taken in from
            // a nested loop.
            thisRectangle.X = column * thisRectangle.Width;
            thisRectangle.Y = row * thisRectangle.Height;

            // After i have calculated everything I return the rectangle
            return thisRectangle;
        }


        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            FileManager fm = new FileManager();

            char[,] map = drawThisMap;
            

            //this is how the tiles are drawn from the array to the screen
            for (int k = 0; k < map.GetLength(0); k++) // This finds the row
            {
                for (int l = 0; l < map.GetLength(1); l++) // This finds the column
                {
                    tile = map[k, l];

                    switch (tile)
                    {                    
                        case WALL:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(WALL)), Color.White); 
                            break;

                        case WATER:
                            //tileTexture = tileTextures[2];
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(WATER)), Color.White); 
                            break;

                        case WOODEN_PLANKS:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(WOODEN_PLANKS)), Color.White); 
                            //_spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle("redNode"), Color.White) ; 
                            break;

                        case GRASS:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(GRASS)), Color.White); 
                            break;

                        case GLOWING_SQUARE:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(GLOWING_SQUARE)), Color.White);
                            break;

                        case SANDISH:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(SANDISH)), Color.White);
                            break;

                        case BLACK_WHITE_TILE:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(BLACK_WHITE_TILE)), Color.White);
                            break;

                        case COBBLE:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(COBBLE)), Color.White);
                            break;

                        case LAVA:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(LAVA)), Color.White);
                            break;

                        case SPAWN_TILE:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(SPAWN_TILE)), Color.White);
                            break;

                        case FINISH_TILE:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(FINISH_TILE)), Color.White);
                            break;

                        case WOODEN_TP:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle(Convert.ToString(WOODEN_TP)), Color.White);
                            break;

                        case '#':
                            break;
                            default:
                            _spriteBatch.Draw(tileTextureTileMap, CreateRectangle(tilePos, tileSize, k, l), GetTileSourceRectangle("."), Color.White); 
                            break;




                    }
                }
            }
        }

        Rectangle GetTileSourceRectangleFILE(string tile)
        {
            FileManager fm = new FileManager();

            List<string> data = fm.ReadDataLineByLine("TextureData.txt");

            foreach (string x in data)
            {
                string[] values = x.Split(':');

                if (values[1] == tile)
                {
                    return new Rectangle(Convert.ToInt32(values[2]) * tileSize, Convert.ToInt32(values[3]) * tileSize, tileSize, tileSize);
                }

            }
            return new Rectangle(128, 128, tileSize, tileSize);                 //  DEFAULT PINK TEXTURE
        }


        Rectangle GetTileSourceRectangle(string tile)
        {
            if (tile != null)
            {
                switch (tile)
                {
                    
                    case "R":
                        return new Rectangle(32, 0, tileSize, tileSize);        //  WALLS

                    case "W":
                        return new Rectangle(64, 64, tileSize, tileSize);       //  WATER

                    case "B":
                        return new Rectangle(96, 64, tileSize, tileSize);       //  WOODEN PLANKS

                    case "G": 
                        return new Rectangle(0, 0, tileSize, tileSize);         //  GRASS

                    case "A":
                        return new Rectangle(32, 32, tileSize, tileSize);       // GLOWING SQUARE

                    case "S":
                        return new Rectangle(96, 0, tileSize, tileSize);        // SANDISH

                    case "T":
                        return new Rectangle(0, 32, tileSize, tileSize);        // BLACK_WHITE_TILE

                    case "E":
                        return new Rectangle(0, 64, tileSize, tileSize);        // COBBLE

                    case "L":
                        return new Rectangle(96, 32, tileSize, tileSize);       // LAVA

                    case "@":
                        return new Rectangle(288, 0, tileSize, tileSize);       // SPAWN

                    case "%":
                        return new Rectangle(256, 0, tileSize, tileSize);       // EXIT

                    case "P":
                        return new Rectangle(288, 32, tileSize, tileSize);       // WOODEN TELEPORT

                }
            }

            return new Rectangle(128, 128, tileSize, tileSize);                 //  DEFAULT PINK TEXTURE

        }
        

    }
}

