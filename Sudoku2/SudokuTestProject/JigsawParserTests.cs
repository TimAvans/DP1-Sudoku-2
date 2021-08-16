using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SudokuTestProject
{
   
    [TestClass]
    public class JigsawParserTests
    {
        [TestMethod]
        public void JigsawSudokuParser_ValidFile_ParseSucceeds()
        {
            //Arrange
            JigsawSudokuParser parser = new JigsawSudokuParser();

            MainGrid mainGrid = new MainGrid(0);
            for (int i = 0; i < 9; i++)
            {
                Grid grid = new Grid(i);
                for (int c = 0; c < 9; c++)
                {
                    grid.Children.Add(new Cell(c, 9, c, i, "black"));
                }
                mainGrid.Children.Add(grid);
            }
            JigsawSudoku testSudoku = new JigsawSudoku(mainGrid);

            //Act
            BaseSudoku sudoku = parser.Parse("C:\\Users\\RikVe\\Documents\\GitHub\\DP1-Sudoku-2\\Sudoku2\\SudokuTestProject\\test_files\\puzzle.jigsaw");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(JigsawSudoku));
            CollectionAssert.AreEqual(sudoku.Children, testSudoku.Children, new SudokuComparer());
        }

        [TestMethod]
        public void JigsawSudokuParser_InvalidFile_ReturnsNull()
        {
            //Arrange
            JigsawSudokuParser parser = new JigsawSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\invalid.jigsaw");

            //Assert
            Assert.IsNull(sudoku);
        }

        [TestMethod]
        public void JigsawSudokuParser_GridCount_ReturnsNine()
        {
            //Arrange
            JigsawSudokuParser parser = new JigsawSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.jigsaw");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(JigsawSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            MainGrid mainGrid = (MainGrid)sudoku.Children[0];
            Assert.AreEqual(mainGrid.Children.Count, 9);
        }

        [TestMethod]
        public void JigsawSudokuParser_CellCount_ReturnsNinePerGrid()
        {
            //Arrange
            JigsawSudokuParser parser = new JigsawSudokuParser();

            //Act
            BaseSudoku sudoku = parser.Parse("..\\..\\test_files\\puzzle.jigsaw");

            //Assert
            Assert.IsInstanceOfType(sudoku, typeof(JigsawSudoku));
            Assert.AreEqual(sudoku.Children.Count, 1);
            MainGrid mainGrid = (MainGrid)sudoku.Children[0];
            foreach(Grid grid in mainGrid.Children)
            {
                Assert.AreEqual(grid.Children.Count, 9);
            }
        }
    }
}