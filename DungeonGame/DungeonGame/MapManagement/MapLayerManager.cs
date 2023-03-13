using DungeonGame.BackendDev;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonGame.MapManagement
{   // This is where all of the default maps are stored in the game code 
    // as well as links to the maps that are stored in the file as txt file
    // basically this class servers as a giant map distributor for the draw background
    // class to handle.
    class MapLayerManager
    {

        private static MapLayerManager instance;
        public ContentManager Content { private set; get; }
        // singleton class as we wont need more duplicates of the same maps ever
        public static MapLayerManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MapLayerManager();
                return instance;
            }
        }

        FileManager fm = new FileManager();

        public virtual void LoadContent(ContentManager Content)
        {
            // test of generating a map from scratch using code
            createMapThree();
        }

        public MapLayerManager()
        {// reads maps from file 
            readMapsFromFile();
        }

        // stores map
        private char[,] storedMapOne = new char[30, 50] // This array is how the map is stored in the game, each letter represents a tile.
            {
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'R', 'R', 'R', 'R', 'R', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'R', 'R', 'R', 'R', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'R', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'R', 'R', 'B', 'R', 'R', 'R', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'R', 'R', 'R', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'A', 'A', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'G', 'G', 'G', 'A', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'G', 'G', 'G', 'A', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'G', 'G', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'W', 'W', 'W', 'G', 'G', 'A','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'G', 'G', 'W', 'W', 'W', 'W', 'W', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'W', 'W', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'W', 'W', 'W', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'W', 'W', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'G', 'W', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'W', 'W', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'B', 'B', 'A', 'A', 'G', 'G', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'W', 'W', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'G', 'G', 'G', 'A','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'W', 'W', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'A', 'A', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'}


            };

        private char[,] storedMapTwo = new char[30, 50] //This is another array for storing a map
            {
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'}
            };


        private char[,] storedMapThree = new char[30, 50];
        // creates a blanc canvas map
        private void createMapThree()
        {
            for (int i = 0; i < 30; i++) //rows
            {
                for (int j = 0; j < 50; j++) //columns
                {
                    storedMapThree[i, j] = 'B';
                }

            }

        }

        private char[,] storedMapFour = new char[30, 50] //This is another array for storing a map
            {
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', '#', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'B', 'R', 'R', 'R', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'#', '#', '#', 'R', 'B', 'R', '#', '#', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'#', '#', '#', 'R', 'B', 'R', '#', '#', '#', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'B', 'R', 'R', 'R', 'R', 'R','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'}
            };

        public char[,] mapOne // name to be called from another class
        {
            get { return storedMapOne; } // returns the array of letters
        }
        public char[,] mapTwo  // name to be called from another class
        {
            get { return storedMapTwo; }  // returns the array of letters
        }
        public char[,] mapThree  // name to be called from another class
        {
            get { return storedMapThree; }  // returns the array of letters
        }
        public char[,] mapFour  // name to be called from another class
        {
            get { return storedMapFour; }  // returns the array of letters
        }


        // ###############################  STORED MAPS  #######################################

        private char[,] fileMapOne = new char[30, 50];
        private char[,] fileMapTwo = new char[30, 50];
        private char[,] fileMapThree= new char[30, 50];
        private char[,] fileMapFour = new char[30, 50];

        private char[,] fileLargeMapOne = new char[100, 100];
        private char[,] fileTESTMAP = new char[100, 100];



        private void readMapsFromFile()
        {
            FileManager fm = new FileManager();
            // reads the maps from the files that are passed in as parameters
            fileMapOne = fm.ReadMapFile("mapOne.txt");
            fileMapTwo = fm.ReadMapFile("mapTwo.txt");
            fileMapThree = fm.ReadMapFile("mapThree.txt");
            fileLargeMapOne = fm.ReadMapFile("LargeMapOne.txt");
            fileTESTMAP = fm.ReadMapFile("TESTMAP.txt");
            fileMapFour = fm.ReadMapFile("MAP.txt");


        }

        // getters for all of the maps avaiable.
        // this is important as this is using encapsulation
        // meaning that maps cant be altered by other classes by accident.
        public char[,] FMapOne
        {
            get { return fileMapOne; }
        }
        public char[,] FMapTwo
        {
            get { return fileMapTwo; }
        }
        public char[,] FMapThree
        {
            get { return fileMapThree; }
        }
        public char[,] FLargeMapOne
        {
            get { return fileLargeMapOne; }
        }
        public char[,] FTESTMAP
        {
            get { return fileTESTMAP; }
        }
        public char[,] FMAPfour
        {
            get { return fileMapFour; }
        }

        // #################################  STORED LAYERS  ##################################### 

        private char[,] storedLayerOne = new char[30, 50]
            {
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'R', 'R', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'R', 'R', 'R', 'R', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B','R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'B', 'R', 'R', 'R', 'R', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'B', 'B', 'R', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'A', 'A', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'G', 'G', 'G', 'A', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'G', 'G', 'G', 'A', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'G', 'G', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'N', 'B', 'M', 'B', 'B', 'B','C', 'B', 'C', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'W', 'W', 'W', 'G', 'G', 'A','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'G', 'G', 'W', 'W', 'C', 'W', 'W', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'G', 'G', 'W', 'W', 'W', 'W', 'W', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'G', 'W', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'G', 'W', 'W', 'G', 'G','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'A', 'A', 'G', 'G', 'G', 'G', 'A','A', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'C', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'R', 'R', 'R', 'R', 'R', 'B', 'B', 'B', 'B', 'A', 'A', 'A', 'A', 'A', 'A','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B','B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'R'},
                {'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R','R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'}

        };

        public char[,] layerOne
        {
            get { return storedLayerOne; }
        }


        ///<MAPS>
        /// #########################  MAPS READ FROM FILE  #################################
        /// </MAPS>
        /// 

        



    }
}
