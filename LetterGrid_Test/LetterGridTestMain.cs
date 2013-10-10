namespace LetterGrid
{
    using NUnit.Framework;

    [TestFixture]
    public class LetterGridTest
    {
        private LetterGridBoxes theGrid;




        // Initialize the LetterGridBoxes to a default test grid
        [SetUp]
        public void Init()
        {
            theGrid = new LetterGridBoxes();
            theGrid.ReadFromFile("TestGrid.txt");
        }

        // Verifies the load function works
        [Test]
        public void VerifyCorrectLoading()
        {
            Assert.AreEqual(13, theGrid.GridColumnCount);
            Assert.AreEqual(15, theGrid.GridRowCount);

            const string ExpectedGrid = "Hello#Worlds#" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "#           #" +
                                        "             " +
                                        "# # # # # # #";

            // Check First and last rows
            string verificationString = string.Empty;
            for (int j = 0; j < theGrid.GridRowCount; ++j)
            {
                for (int i = 0; i < theGrid.GridColumnCount; ++i)
                {
                    verificationString += theGrid.getCharacter(i, j);
                }
            }

            Assert.AreEqual(ExpectedGrid, verificationString);
        }

        [Test]
        public void TestResizeGrid()
        {
            // Shrink grid
            theGrid.ResizeGrid(8, 6);

            Assert.AreEqual(8, theGrid.GridColumnCount);
            Assert.AreEqual(6, theGrid.GridRowCount);

            string verificationString = string.Empty;
            for (int i = 0; i < theGrid.GridColumnCount; ++i)
            {
                verificationString += theGrid.getCharacter(i, 0);
            }

            Assert.AreEqual("Hello#Wo", verificationString);

            verificationString = string.Empty;
            for (int j = 0; j < theGrid.GridRowCount; ++j)
            {
                verificationString += theGrid.getCharacter(0, j);
            }
            Assert.AreEqual("H # # ", verificationString);

            // Expand Grid
            theGrid.ResizeGrid(12, 9);

            Assert.AreEqual(12, theGrid.GridColumnCount);
            Assert.AreEqual(9, theGrid.GridRowCount);

            verificationString = string.Empty;
            for (int i = 0; i < theGrid.GridColumnCount; ++i)
            {
                verificationString += theGrid.getCharacter(i, 0);
            }

            Assert.AreEqual("Hello#Wo    ", verificationString);

            verificationString = string.Empty;
            for (int j = 0; j < theGrid.GridRowCount; ++j)
            {
                verificationString += theGrid.getCharacter(0, j);
            }
            Assert.AreEqual("H # #    ", verificationString);


        }


    }
}