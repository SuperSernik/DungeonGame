namespace DungeonGame.BackendDev
{
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
