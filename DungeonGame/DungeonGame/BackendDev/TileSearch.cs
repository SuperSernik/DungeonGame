using DungeonGame.ScreenManagement;
using System.Collections.Generic;

namespace DungeonGame.BackendDev
{
    // these are usefule for when i want to search for a tile in a map 
    // or return all of the tiles in a location etc.
    public class TileSearch
    {
        int row, col;

        public TileSearch() { }

        public List<PositionOnMap> ReturnLocationsOfTilesFromBackground(char tileID)
        {
            char[,] map = ScreenManager.visibleMAP; // Retrieves the map from the source
            List<PositionOnMap> ListOfPositions = new List<PositionOnMap>();
            for (int k = 0; k < map.GetLength(0); k++) // This finds the row
            {
                for (int l = 0; l < map.GetLength(1); l++) // This finds the column
                {
                    if (map[k, l] == tileID) // If the char found in that place matches the 
                    { 
                        ListOfPositions.Add(new PositionOnMap(k, l));
                    }
                }
            }
            return ListOfPositions;
        }

        public List<PositionOnMap> ReturnLocationsOfObjectsFromForeground(char objID)
        {
            char[,] layer = ScreenManager.visibleLAYER; // Retrieves the layer from the source
            List<PositionOnMap> ListOfPositions = new List<PositionOnMap>();
            for (int k = 0; k < layer.GetLength(0); k++) // This finds the row
            {
                for (int l = 0; l < layer.GetLength(1); l++) // This finds the column
                {
                    if (layer[k, l] == objID) // If the char found in that place matches the 
                    {//                      obj id, it adds it poition to the list.
                        ListOfPositions.Add(new PositionOnMap(k, l));
                    }
                }
            }
            return ListOfPositions;
        }

        public char WhatObjIDAtThisLocationMAP(int x , int y)
        {
            char[,] map = ScreenManager.visibleMAP;
            return map[y, x];

        }

        public char WhatObjIDAtThisLocationLAYER(int x, int y)
        {
            char[,] layer = ScreenManager.visibleLAYER;
            return layer[y, x];

        }



    }
}
