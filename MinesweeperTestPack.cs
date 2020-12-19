using System;
using Xunit;

namespace minesweeper_kata_csharp
{
    public class MinesweeperTestPack
    {
        [Fact]
        public void TestEmptyMineField()
        {
            var emptyMineField = new int[][]
            {
                new int[] {0,0,0},
                new int[] {0,0,0},
                new int[] {0,0,0}
            };

            var actual = Minesweeper.SweepMineField(emptyMineField);

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Assert.Equal(0, actual[row][col]);
        }
    }
}
