using System;
using Xunit;

namespace minesweeper_kata_csharp
{
    public class MinesweeperTestPack
    {
        [Fact]
        public void TestEmptyMineField()
        {
            var emptyMineField = new int[,]
            {
                {0,0,0},
                {0,0,0},
                {0,0,0}
            };

            var actual = Minesweeper.SweepMineField(emptyMineField);

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Assert.Equal(0, actual[row, col]);
        }

        [Fact]
        public void TestOneMine()
        {
            var inputMineField = new int[,]
            {
                {0,-1,0},
                {0,0,0},
                {0,0,0}
            };

            var actualMineField = Minesweeper.SweepMineField(inputMineField);

            var expectedMineField = new int[,]
            {
                {1,-1,1},
                {1,1,1},
                {0,0,0}
            };

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Assert.Equal(expectedMineField[row, col], actualMineField[row, col]);
        }

        [Fact]
        public void TestTwoMines()
        {
            var inputMineField = new int[,]
            {
                {0,-1,0},
                {0,0,0},
                {0,0,-1}
            };

            var actualMineField = Minesweeper.SweepMineField(inputMineField);

            var expectedMineField = new int[,]
            {
                {1,-1,1},
                {1,2,2},
                {0,1,-1}
            };

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Assert.Equal(expectedMineField[row, col], actualMineField[row, col]);
        }

        [Fact]
        public void Test4Mines5x6Grid()
        {
            var inputMineField = new int[,]
            {
                {0,-1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0,-1, 0, 0, 0},
                {0, 0, 0,-1, 0, 0},
                {0,-1, 0, 0, 0, 0}
            };

            var actualMineField = Minesweeper.SweepMineField(inputMineField);

            var expectedMineField = new int[,]
            {
                {1,-1, 1, 0, 0, 0},
                {1, 2, 2, 2, 0, 0},
                {0, 1,-1, 2, 1, 0},
                {1, 2, 3,-1, 1, 0},
                {1,-1, 2, 1, 1, 0}
            };

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Assert.Equal(expectedMineField[row, col], actualMineField[row, col]);
        }
    }
}
