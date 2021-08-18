using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTestProject
{

    [TestClass]
    public class SamuraiParserTests
    {
        [TestMethod]
        public void SamuraiSudokuParser_ValidFile_ParseSucceeds()
        {
            //Arrange
            SamuraiSudokuParser parser = new SamuraiSudokuParser();

            List<MainGrid> boards = new List<MainGrid>();

            for (int mg = 0; mg < 5; mg++)
            {
                MainGrid mainGrid = new MainGrid(mg);
                int gridAmount = 0;
                for (int i = 0; i < 9; i++)
                {
                    Grid grid = new Grid(i);
                    int xRow = i - (gridAmount / 3) * 3;

                    int x = xRow*3 > 8 ? 0 : xRow*3;
                    int initX = x;

                    int y = 0;
                    if (gridAmount >= 6)
                    {
                        y = 6;
                    }else if (gridAmount >= 3)
                    {
                        y = 3;
                    }

                    for (int c = 0; c < 9; c++)
                    {
                        if(x > initX + 2)
                        {
                            x = initX;
                            y++;
                        }
                        grid.Children.Add(new Cell(c, 9, x, y, "black"));
                        x++;
                    }
                    gridAmount++;
                    mainGrid.Children.Add(grid);
                }
                boards.Add(mainGrid);
            }

            boards[2].Children[0] = boards[0].Children[8];
            boards[2].Children[2] = boards[1].Children[6];
            boards[2].Children[6] = boards[3].Children[2];
            boards[2].Children[8] = boards[4].Children[0];

            SamuraiSudoku testSudoku = new SamuraiSudoku(boards);

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.samurai");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(SamuraiSudoku));
            CollectionAssert.AreEqual(sudoku.Children, testSudoku.Children, new SudokuComparer());
        }

        [TestMethod]
        public void SamuraiSudokuParser_InvalidFile_ReturnsNull()
        {
            //Arrange
            SamuraiSudokuParser parser = new SamuraiSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\invalid.samurai");

            //Assert
            Assert.IsNull(sudoku);
        }

        [TestMethod]
        public void SamuraiSudokuParser_BoardCount_ReturnsFive()
        {
            //Arrange
            SamuraiSudokuParser parser = new SamuraiSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.samurai");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(SamuraiSudoku));
            Assert.AreEqual(sudoku.Children.Count, 5);
        }

        [TestMethod]
        public void SamuraiSudokuParser_GridCount_ReturnsNine()
        {
            //Arrange
            SamuraiSudokuParser parser = new SamuraiSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.samurai");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(SamuraiSudoku));
            Assert.AreEqual(sudoku.Children.Count, 5);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                Assert.AreEqual(mainGrid.Children.Count, 9);
            }
        }

        [TestMethod]
        public void SamuraiSudokuParser_CellCount_ReturnsNinePerGrid()
        {
            //Arrange
            SamuraiSudokuParser parser = new SamuraiSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.samurai");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(SamuraiSudoku));
            Assert.AreEqual(sudoku.Children.Count, 5);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    Assert.AreEqual(grid.Children.Count, 9);
                }
            }
        }
    }
}
