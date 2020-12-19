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
                {1, 2, 2, 1, 0, 0},
                {0, 1,-1, 2, 1, 0},
                {1, 2, 3,-1, 1, 0},
                {1,-1, 2, 1, 1, 0}
            };

            for (int row = 0; row < expectedMineField.GetLength(0); row++)
                for (int col = 0; col < expectedMineField.GetLength(1); col++)
                    Assert.Equal(expectedMineField[row, col], actualMineField[row, col]);
        }

        [Fact]
        public void TestTextToIntMineFieldConversion()
        {
            string[] inputMineField =
            {
                "..*",
                "...",
                "...",
            };

            var actualMineField = Minesweeper.ConvertToIntMineField(3, 3, inputMineField);

            var expectedMineField = new int[,]
            {
                {0,0,-1},
                {0,0,0},
                {0,0,0}
            };

            for (int row = 0; row < expectedMineField.GetLength(0); row++)
                for (int col = 0; col < expectedMineField.GetLength(1); col++)
                    Assert.Equal(expectedMineField[row, col], actualMineField[row, col]);
        }

        [Fact]
        public void TestIntToTextMineFieldConversion()
        {
            var inputMineField = new int[,]
            {
                {0,1,-1},
                {1,2,1},
                {-1,1,0}
            };
            var actualMineField = Minesweeper.ConvertToTextMineField(inputMineField);

            string[] expectedMineField =
            {
                ".1*",
                "121",
                "*1.",
            };

            for (int rowIndex = 0; rowIndex < expectedMineField.Length; rowIndex++)
                Assert.Equal(expectedMineField[rowIndex], actualMineField[rowIndex]);
        }

        [Fact]
        public void TestEmptyGrid()
        {
            var actual = Minesweeper.SweepMineField(0, 0, new string[]
                {
                    "...",
                    "...",
                    "...",
                }
            );
            Assert.Equal("", actual[0]);
        }

        [Fact]
        public void TestEmptyMine()
        {
            var actual = Minesweeper.SweepMineField(3, 3, new string[] { "" });
            Assert.Equal(".", actual[0]);
        }

        [Fact]
        public void TestKataExample1()
        {
            var actualMineField = Minesweeper.SweepMineField(3, 2, new string[]
                {
                    ".*.",
                    "..."
                }
            );

            string[] expectedMineField =
            {
                "1*1",
                "111"
            };

            for (int rowIndex = 0; rowIndex < expectedMineField.Length; rowIndex++)
                Assert.Equal(expectedMineField[rowIndex], actualMineField[rowIndex]);
        }

        [Fact]
        public void TestKataExample2()
        {
            var actualMineField = Minesweeper.SweepMineField(5, 3, new string[]
                {
                    "**...",
                    ".....",
                    ".*..."
                }
            );

            string[] expectedMineField =
            {
                    "**1..",
                    "332..",
                    "1*1.."
            };

            for (int rowIndex = 0; rowIndex < expectedMineField.Length; rowIndex++)
                Assert.Equal(expectedMineField[rowIndex], actualMineField[rowIndex]);
        }

        [Fact]
        public void TestKataExample3()
        {
            var actualMineField = Minesweeper.SweepMineField(12, 6, new string[]
                {
                    "............",
                    "............",
                    "............",
                    "....*.......",
                    "............",
                    "............"
                }
            );

            string[] expectedMineField =
            {
                    "............",
                    "............",
                    "...111......",
                    "...1*1......",
                    "...111......",
                    "............"
            };

            for (int rowIndex = 0; rowIndex < expectedMineField.Length; rowIndex++)
                Assert.Equal(expectedMineField[rowIndex], actualMineField[rowIndex]);
        }
    }
}
