using System;
using System.Collections.Generic;

namespace minesweeper_kata_csharp
{
    public class Minesweeper
    {
        public static int[,] SweepMineField(int[,] mineField)
        {
            // get mine locations
            var mineLocations = GetMineLocations(mineField);

            // foreach mine location increment adjacent cells
            foreach (var location in mineLocations)
            {
                mineField = IncrementAdjacentCells(location, mineField);
            }

            return mineField;
        }

        private static List<(int Row, int Column)> GetMineLocations(int[,] mineField)
        {
            List<(int, int)> mineLocations = new List<(int Row, int Column)>();

            for (int row = 0; row < mineField.GetLength(0); row++)
                for (int col = 0; col < mineField.GetLength(1); col++)
                {
                    if (mineField[row, col] == -1)
                        mineLocations.Add((row, col));
                }

            return mineLocations;
        }

        private static int[,] IncrementAdjacentCells((int Row, int Column) location, int[,] mineField)
        {
            var maxRow = mineField.GetLength(0);
            var maxCol = mineField.GetLength(1);

            // top left
            if (location.Row > 0 && location.Column > 0 && mineField[location.Row - 1, location.Column - 1] > -1)
                mineField[location.Row - 1, location.Column - 1]++;
            // top 
            if (location.Row > 0 && mineField[location.Row - 1, location.Column] > -1)
                mineField[location.Row - 1, location.Column]++;
            // top right
            if (location.Row > 0 && location.Column < maxCol - 1 && mineField[location.Row - 1, location.Column + 1] > -1)
                mineField[location.Row - 1, location.Column + 1]++;
            // left 
            if (location.Column > 0 && mineField[location.Row, location.Column - 1] > -1)
                mineField[location.Row, location.Column - 1]++;
            // right
            if (location.Column < maxCol - 1 && mineField[location.Row, location.Column + 1] > -1)
                mineField[location.Row, location.Column + 1]++;
            // bottom left
            if (location.Row < maxRow - 1 && location.Column > 0 && mineField[location.Row + 1, location.Column - 1] > -1)
                mineField[location.Row + 1, location.Column - 1]++;
            // bottom 
            if (location.Row < maxRow - 1 && mineField[location.Row + 1, location.Column] > -1)
                mineField[location.Row + 1, location.Column]++;
            // bottom right
            if (location.Row < maxRow - 1 && location.Column < maxCol - 1 && mineField[location.Row + 1, location.Column + 1] > -1)
                mineField[location.Row + 1, location.Column + 1]++;

            return mineField;
        }
    }
}
