using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Visitor;
using System.Collections.Generic;
using System;

namespace SudokuTestProject
{
    [TestClass]
    public class ValidationUnitTests
    {
        [TestMethod]
        public void TestValidationVisitor_VisitCell_True()
        {
            //Arrange
            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            celltrue4.Accept(vv);
            celltrue2.Accept(vv);

            //Assert
            Assert.AreEqual(celltrue2.IsValidated, true);
            Assert.AreEqual(celltrue4.IsValidated, true);
        }        
        
        [TestMethod]
        public void TestValidationVisitor_VisitCell_False()
        {
            //Arrange
            Cell cellfalse = new Cell(5, 4, 1, 1, "red");
            Cell cellfalse0 = new Cell(0, 4, 1, 1, "red");

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            cellfalse.Accept(vv);
            cellfalse0.Accept(vv);

            //Assert
            Assert.AreEqual(cellfalse.IsValidated, false);
            Assert.AreEqual(cellfalse0.IsValidated, false);
        }

        [TestMethod]
        public void TestValidationVisitor_VisitGrid_True()
        {
            //Arrange
            Grid gridtrue = new Grid(1);

            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");

            gridtrue.Children = new List<ISudokuPart> { celltrue2, celltrue4 };

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            gridtrue.Accept(vv);

            //Assert
            Assert.AreEqual(true, gridtrue.IsValidated);
        }        
        
        [TestMethod]
        public void TestValidationVisitor_VisitGrid_False()
        {
            //Arrange
            Grid gridfalse_TrueFalse = new Grid(1);
            Grid gridfalse_False = new Grid(1);

            Cell cellfalse = new Cell(5, 4, 1, 1, "red");
            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");
            Cell cellfalse0 = new Cell(0, 4, 1, 1, "red");

            gridfalse_TrueFalse.Children = new List<ISudokuPart> { cellfalse, cellfalse0, celltrue2, celltrue4 };
            gridfalse_False.Children = new List<ISudokuPart> { cellfalse, cellfalse0 };

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            gridfalse_TrueFalse.Accept(vv);
            gridfalse_False.Accept(vv);

            //Assert
            Assert.AreEqual(false, gridfalse_TrueFalse.IsValidated);
            Assert.AreEqual(false, gridfalse_False.IsValidated);
        }

        [TestMethod]
        public void TestValidationVisitor_VisitMainGrid_True()
        {
            //Arrange
            Grid gridtrue = new Grid(1);

            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");

            gridtrue.Children = new List<ISudokuPart> { celltrue2, celltrue4 };

            MainGrid maingridtrue = new MainGrid(1);

            maingridtrue.Children = new List<ISudokuPart> { gridtrue, gridtrue};

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            maingridtrue.Accept(vv);

            //Assert
            Assert.AreEqual(true, maingridtrue.IsValidated);
        }          
        
        [TestMethod]
        public void TestValidationVisitor_VisitMainGrid_False()
        {
            //Arrange
            Grid gridfalse = new Grid(1);
            Grid gridtrue = new Grid(1);

            Cell cellfalse = new Cell(5, 4, 1, 1, "red");
            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");
            Cell cellfalse0 = new Cell(0, 4, 1, 1, "red");

            gridfalse.Children = new List<ISudokuPart> { cellfalse, cellfalse0, celltrue2, celltrue4 };
            gridtrue.Children = new List<ISudokuPart> { celltrue2, celltrue4 };

            MainGrid maingridfalse_False = new MainGrid(1);
            MainGrid maingridfalse_TrueFalse = new MainGrid(1);

            maingridfalse_False.Children = new List<ISudokuPart> { gridfalse, gridfalse};
            maingridfalse_TrueFalse.Children = new List<ISudokuPart> { gridfalse, gridtrue};

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            maingridfalse_TrueFalse.Accept(vv);
            maingridfalse_False.Accept(vv);

            //Assert
            Assert.AreEqual(false, maingridfalse_TrueFalse.IsValidated);
            Assert.AreEqual(false, maingridfalse_False.IsValidated);
        }       
      
        [TestMethod]
        public void TestValidationVisitor_VisitSudoku_True()
        {
            //Arrange
            Grid gridtrue = new Grid(1);

            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");


            gridtrue.Children = new List<ISudokuPart> { celltrue2, celltrue4 };

            MainGrid maingridtrue = new MainGrid(1);

            maingridtrue.Children = new List<ISudokuPart> { gridtrue, gridtrue };

            JigsawSudoku jigsawtrue = new JigsawSudoku(maingridtrue);

            NormalSudoku normaltrue = new NormalSudoku(maingridtrue);

            SamuraiSudoku samuraitrue = new SamuraiSudoku(new List<MainGrid> {maingridtrue, maingridtrue });

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            jigsawtrue.Accept(vv);
            normaltrue.Accept(vv);
            samuraitrue.Accept(vv);

            //Assert
            Assert.AreEqual(true, jigsawtrue.IsValidated);          
            Assert.AreEqual(true, normaltrue.IsValidated);
            Assert.AreEqual(true, samuraitrue.IsValidated);
        }
        
        [TestMethod]
        public void TestValidationVisitor_VisitSudoku_False()
        {
            //Arrange
            Grid gridfalse = new Grid(1);
            Grid gridtrue = new Grid(1);

            Cell cellfalse = new Cell(5, 4, 1, 1, "red");
            Cell celltrue4 = new Cell(4, 4, 1, 1, "red");
            Cell celltrue2 = new Cell(2, 4, 1, 1, "red");
            Cell cellfalse0 = new Cell(0, 4, 1, 1, "red");

            gridfalse.Children = new List<ISudokuPart> { cellfalse, cellfalse0, celltrue2, celltrue4 };
            gridtrue.Children = new List<ISudokuPart> { celltrue2, celltrue4 };

            MainGrid maingridtrue = new MainGrid(1);
            MainGrid maingridfalse2 = new MainGrid(1);
            MainGrid maingridfalse1 = new MainGrid(1);

            maingridtrue.Children = new List<ISudokuPart> { gridtrue, gridtrue };
            maingridfalse2.Children = new List<ISudokuPart> { gridfalse, gridfalse };
            maingridfalse1.Children = new List<ISudokuPart> { gridfalse, gridtrue };

            JigsawSudoku jigsawfalse = new JigsawSudoku(maingridfalse1);

            NormalSudoku normalfalse = new NormalSudoku(maingridfalse2);

            SamuraiSudoku samuraifalse = new SamuraiSudoku(new List<MainGrid> { maingridfalse1, maingridfalse2});
            SamuraiSudoku samuraitruefalse = new SamuraiSudoku(new List<MainGrid> { maingridfalse1, maingridtrue});

            ValidationVisitor vv = new ValidationVisitor();

            //Act
            jigsawfalse.Accept(vv);
            normalfalse.Accept(vv);
            samuraifalse.Accept(vv);
            samuraitruefalse.Accept(vv);

            //Assert
            Assert.AreEqual(false, jigsawfalse.IsValidated);            
            Assert.AreEqual(false, normalfalse.IsValidated);
            Assert.AreEqual(false, samuraifalse.IsValidated);
            Assert.AreEqual(false, samuraitruefalse.IsValidated);
        }
    }
}
