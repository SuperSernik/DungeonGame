namespace DungeonGame.BackendDev
{// i created my own type to store the row and column of a certain tile
    public class PositionOnMap
    {
        private int row, col;
        public PositionOnMap(int NewRow, int NewCol)
        { // Create the 'PositionOnMap'
            row = NewRow;
            col = NewCol;
        }
        public int Row
        { // Getter/Setter for row
            get { return row; }
            set { row = value; }
        }
        public int Col
        { // Getter/Setter for column
            get { return col; }
            set { col = value; }
        }
    }
}
