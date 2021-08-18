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
    public class NormalSudokuTests
    {
        [TestMethod]
        public void NormalSudokuParser9x9_ValidFile_ParseSucceeds()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            MainGrid board = new MainGrid(0);

            int gridAmount = 0;
            for (int i = 0; i < 9; i++)
            {
                Grid grid = new Grid(i);
                int xRow = i - (gridAmount / 3) * 3;

                int x = xRow * 3 > 8 ? 0 : xRow * 3;
                int initX = x;

                int y = 0;
                if (gridAmount >= 6)
                {
                    y = 6;
                }
                else if (gridAmount >= 3)
                {
                    y = 3;
                }

                for (int c = 0; c < 9; c++)
                {
                    if (x > initX + 2)
                    {
                        x = initX;
                        y++;
                    }
                    grid.Children.Add(new Cell(c, 9, x, y, "black"));
                    x++;
                }
                gridAmount++;
                board.Children.Add(grid);
            }
            NormalSudoku testSudoku = new NormalSudoku(board);

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal9x9");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            CollectionAssert.AreEqual(sudoku.Children, testSudoku.Children, new SudokuComparer());
        }

        [TestMethod]
        public void NormalSudokuParser6x6_ValidFile_ParseSucceeds()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            MainGrid board = new MainGrid(0);

            int gridAmount = 0;
            for (int i = 0; i < 6; i++)
            {
                Grid grid = new Grid(i);
                int xRow = i - (gridAmount / 2) * 2;

                int x = xRow * 3 > 5 ? 0 : xRow * 3;
                int initX = x;

                int y = 0;

                if (gridAmount >= 2)
                {
                    y = 2;
                }
                if (gridAmount >= 4)
                {
                    y = 4;
                }

                for (int c = 0; c < 6; c++)
                {
                    if (x > initX + 2)
                    {
                        x = initX;
                        y++;
                    }
                    grid.Children.Add(new Cell(c, 6, x, y, "black"));
                    x++;
                }
                gridAmount++;
                board.Children.Add(grid);
            }
            NormalSudoku testSudoku = new NormalSudoku(board);

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal6x6");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            CollectionAssert.AreEqual(sudoku.Children, testSudoku.Children, new SudokuComparer());
        }
        [TestMethod]
        public void NormalSudokuParser4x4_ValidFile_ParseSucceeds()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            MainGrid board = new MainGrid(0);

            int gridAmount = 0;
            for (int i = 0; i < 4; i++)
            {
                Grid grid = new Grid(i);
                int xRow = i - (gridAmount / 2) * 2;

                int x = xRow * 2 > 4 ? 0 : xRow * 2;
                int initX = x;

                int y = 0;
                if (gridAmount >= 2)
                {
                    y = 2;
                }

                for (int c = 0; c < 4; c++)
                {
                    if (x > initX + 1)
                    {
                        x = initX;
                        y++;
                    }
                    grid.Children.Add(new Cell(c, 4, x, y, "black"));
                    x++;
                }
                gridAmount++;
                board.Children.Add(grid);
            }
            NormalSudoku testSudoku = new NormalSudoku(board);

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal4x4");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            CollectionAssert.AreEqual(sudoku.Children, testSudoku.Children, new SudokuComparer());
        }

        [TestMethod]
        public void NormalSudokuParser_InvalidFile_ReturnsNull()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\invalid.normal");

            //Assert
            Assert.IsNull(sudoku);
        }

        [TestMethod]
        public void NormalSudokuParser9x9_GridCount_ReturnsNine()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal9x9");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                Assert.AreEqual(mainGrid.Children.Count, 9);
            }
        }

        [TestMethod]
        public void NormalSudokuParser6x6_GridCount_ReturnsSix()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal6x6");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                Assert.AreEqual(mainGrid.Children.Count, 6);
            }
        }

        [TestMethod]
        public void NormalSudokuParser4x4_GridCount_ReturnsFour()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal4x4");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                Assert.AreEqual(mainGrid.Children.Count, 4);
            }
        }

        [TestMethod]
        public void NormalSudokuParser9x9_CellCount_ReturnsNinePerGrid()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal9x9");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    Assert.AreEqual(grid.Children.Count, 9);
                }
            }
        }

        [TestMethod]
        public void NormalSudokuParser9x9_CellCount_ReturnsSixPerGrid()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal6x6");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    Assert.AreEqual(grid.Children.Count, 6);
                }
            }
        }

        [TestMethod]
        public void NormalSudokuParser9x9_CellCount_ReturnsFourPerGrid()
        {
            //Arrange
            NormalSudokuParser parser = new NormalSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.normal4x4");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(NormalSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            foreach (MainGrid mainGrid in sudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    Assert.AreEqual(grid.Children.Count, 4);
                }
            }
        }
    }
}
