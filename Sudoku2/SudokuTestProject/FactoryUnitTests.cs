using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Factories;
using Sudoku.Parsers;
using System;

namespace SudokuTestProject
{
    [TestClass]
    public class FactoryUnitTests
    {
        [TestMethod]
        public void TestCreateIrregularSudokuParser() 
        {
            //Arrange
            IrregularSudokuParserFactory factory = new IrregularSudokuParserFactory();

            //Act
            var samurai = factory.Create("samurai");
            var jigsaw = factory.Create("jigsaw");

            //Assert
            Assert.IsInstanceOfType(samurai, typeof(SamuraiSudokuParser));
            Assert.IsInstanceOfType(jigsaw, typeof(JigsawSudokuParser));
            Assert.AreEqual(false, samurai.Equals(jigsaw));
        }        
        
        [TestMethod]
        public void TestCreateRegularSudokuParser() 
        {
            //Arrange
            RegularSudokuParserFactory factory = new RegularSudokuParserFactory();

            //Act
            var normal = factory.Create("normal");

            //Assert
            Assert.IsInstanceOfType(normal, typeof(NormalSudokuParser));
        }        
    }
}
