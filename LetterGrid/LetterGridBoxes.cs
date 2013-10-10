using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LetterGrid
{
    class LetterGridBoxes : Control
    {
        // Largest valid size for a lettergrid
        private const int MAX_ROWS = 32;
        private const int MAX_COLUMNS = 32;

        // Size in px. of each box
        private const int BOX_SIZE = 20;

        // Items used for drawing
        private SolidBrush blackBrush  = new SolidBrush(Color.Black);
        private SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private Font numbersFont = new Font("Arial", 6);


        // True if the square numbers are drawn
        private bool _numberSquares;
        [System.ComponentModel.DefaultValue(true)]
        public bool numberSquares
        {
            get
            {
                return _numberSquares;
            }
            set
            {
                _numberSquares = value;
                this.Invalidate();
            }
        }

        // True if incrementing the cursor moves it horizontally
        [System.ComponentModel.DefaultValue(true)]
        public bool cursorMovesHorizontal { get; set; }

        // Accessors for the cursor's letter
        private string currentLetter
        {
            get
            {
                return theCharacters[LetterCursor.X, LetterCursor.Y];
            }
            set
            {
                theCharacters[LetterCursor.X, LetterCursor.Y] = value;
                Invalidate();
            }
        }

        // Character Data: Row, then column
        private string[,] theCharacters;

        // Returns the character data for a given position.
        // Out of bounds are treated as black squares
        public string getCharacter(int X, int Y)
        {
            if (X < GridColumnCount && Y < GridRowCount)
            {
                if (theCharacters[X, Y] == null)
                {
                    theCharacters[X, Y] = " ";
                }

                if (theCharacters[X, Y].Length != 1)
                {
                    theCharacters[X, Y] = " ";
                }
                return theCharacters[X, Y];
            }
            return "#";
        }

        // Cursor data
        private Point LetterCursor;

        // Set to true if a letter was typed at the end of the line,
        // need to keep track for deletion purposes
        private bool BackspaceDeletesCurrentSquare = false;

        // Valid character regex match - word characters and spaces
        private string validChars = @"[\w \.\-]";
        private Regex rgx;

        // Grid size accessors
        public int GridColumnCount
        {
            get { return theCharacters.GetLength(0); }
        }
        public int GridRowCount
        {
            get {return theCharacters.GetLength(1); }
        }


        //! Constructor
        public LetterGridBoxes()
        {
            theCharacters = new string[1, 1];
            theCharacters[0, 0] = " ";
            SetStyle(ControlStyles.DoubleBuffer, true);
            numberSquares = true;
            rgx = new Regex(validChars);
        }

        //! Resize Method
        public void ResizeGrid(int columns, int rows)
        {
            if (rows <= 0 || rows >= MAX_ROWS || columns <= 0 || columns >= MAX_COLUMNS)
                return;

            // Reallocate to default value
            string[,] tmp = new string[columns, rows];
            for (int i = 0; i < columns; ++i)
            {
                for (int j = 0; j < rows; ++j)
                {
                    tmp[i, j] = " ";
                }
            }

            // Copy old values
            for (int i = 0; i < columns && i < GridColumnCount; ++i)
            {
                for (int j = 0; j < rows && j < GridRowCount; ++j)
                {
                    tmp[i, j] = theCharacters[i, j];
                }
            }
            theCharacters = tmp;

            // Maintain Form Properties
            this.Height = rows * BOX_SIZE + 1;
            this.Width = columns * BOX_SIZE + 1;
            this.Invalidate();
        }


        //! Draws the grid
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Draw the background
            Rectangle backgroundRect = new Rectangle(0, 0, this.Width, this.Height);
            pe.Graphics.FillRectangle(blackBrush, backgroundRect);

            // String Format for Text
            StringFormat letterStringFormat = new StringFormat();
            letterStringFormat.LineAlignment = StringAlignment.Center;
            letterStringFormat.Alignment = StringAlignment.Center;

            // Numbering system
            int currentNumber = 1;

            for (int j = 0; j < GridRowCount; ++j)
            {
                for (int i = 0; i < GridColumnCount; ++i)
                {
                    // # is black space, which is identical to the background
                    if (theCharacters[i, j] != "#")
                    {
                        // Draw the square's background
                        Rectangle currentRect = new Rectangle(BOX_SIZE * i + 1,
                                                              BOX_SIZE * j + 1,
                                                              BOX_SIZE - 1,
                                                              BOX_SIZE - 1);
                        if (LetterCursor.X == i && LetterCursor.Y == j)
                        {
                            pe.Graphics.FillRectangle(yellowBrush, currentRect);
                        }
                        else
                        {
                            pe.Graphics.FillRectangle(whiteBrush, currentRect);
                        }

                        // Number the proper squares
                        if (numberSquares && IsSquareNumbered(i, j))
                        {
                            pe.Graphics.DrawString(currentNumber.ToString(),
                                               numbersFont,
                                               blackBrush,
                                               new Point((BOX_SIZE * i), (BOX_SIZE * j)));
                            ++currentNumber;
                        }

                        // Draw the letter
                        Point letterPos = new Point((BOX_SIZE * i) + (BOX_SIZE / 2),
                                                    (BOX_SIZE * j) + (BOX_SIZE / 2));
                        pe.Graphics.DrawString(theCharacters[i, j],
                                               this.Font,
                                               blackBrush,
                                               letterPos,
                                               letterStringFormat);
                    }
                }
            } 
        }

        /// <summary>
        /// Transforms a screen coordinate into a cursor position
        /// </summary>
        /// <param name="absoluteScreenPos"> The screen position </param>
        /// <param name="cursorPosition"> The indices of the square pointed to </param>
        /// <returns> True if the mouse was over a square, false otherwise</returns>
        bool screenPosToSquareIndex(Point absoluteScreenPos, ref Point outputCursorPosition)
        {
            outputCursorPosition = this.PointToClient(absoluteScreenPos);

            if (outputCursorPosition.X < 0 || outputCursorPosition.Y < 0)
                return false;

            outputCursorPosition.X /= BOX_SIZE;
            outputCursorPosition.Y /= BOX_SIZE;

            if (outputCursorPosition.X >= GridColumnCount || outputCursorPosition.Y >= GridRowCount)
                return false;

            return true;
        }



        public void SetCursorFromMouse(Point absoluteScreenPos)
        {
            Point cursorPos = new Point();
            if (screenPosToSquareIndex(absoluteScreenPos, ref cursorPos))
            {
                if (theCharacters[cursorPos.X, cursorPos.Y] != "#")
                {
                    LetterCursor = cursorPos;
                    BackspaceDeletesCurrentSquare = true; // In case they want to delete this square
                }
            }

            this.Invalidate();
        }

        public void SetSquareBlackFromPosition(Point absoluteScreenPos)
        {
            Point cursorPos = new Point();
            if (screenPosToSquareIndex(absoluteScreenPos, ref cursorPos))
            {
                theCharacters[cursorPos.X, cursorPos.Y] = "#";
            }
            this.Invalidate();
        }

        public void SetSquareNonblackFromPosition(Point absoluteScreenPos)
        {
            Point cursorPos = new Point();
            if (screenPosToSquareIndex(absoluteScreenPos, ref cursorPos))
            {
                theCharacters[cursorPos.X, cursorPos.Y] = " ";
                LetterCursor = cursorPos;
            }
            this.Invalidate();
        }

        //! Writes the character and increments the cursor
        public void TryInputCharacter(char ch)
        {
            if (theCharacters[LetterCursor.X, LetterCursor.Y] != "#")
            {
                string charStr = ch.ToString();
                if (rgx.IsMatch(charStr))
                {
                    theCharacters[LetterCursor.X, LetterCursor.Y] = charStr;
                    IncrementCursor();
                }   
            }
            this.Invalidate();
        }


        private void IncrementCursor()
        {
            // Check for invalid cursor
            if (!IsLetterCursorValid())
                return;

            Point tmpCursor = LetterCursor;
            if (cursorMovesHorizontal)
            {
                MoveCursorRight();
            }
            else // cursor moves vertical
            {
                MoveCursorDown();
            }

            // Make backspace delete the current square iff the cursor could not increment
            BackspaceDeletesCurrentSquare = (tmpCursor == LetterCursor);
        }


        public void EraseCurrentSpace()
        {
            if (IsLetterCursorValid() && currentLetter != "#")
            {
                if (BackspaceDeletesCurrentSquare)
                {
                    currentLetter = " ";
                    BackspaceDeletesCurrentSquare = false;
                }
                else // Delete the letter before this one
                {
                    if (cursorMovesHorizontal)
                    {
                        MoveCursorLeft();
                    }
                    else
                    {
                        MoveCursorUp();
                    }
                    currentLetter = " ";
                }
                
            }
        }

        
        private bool IsLetterCursorValid()
        {
            return (LetterCursor.X >= 0 && LetterCursor.Y >= 0 &&
                    LetterCursor.X < GridColumnCount &&
                    LetterCursor.Y < GridRowCount);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                MoveCursorLeft();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                MoveCursorRight();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                MoveCursorUp();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                MoveCursorDown();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        



        //! Moves the cursor left, skipping black squares
        public void MoveCursorLeft()
        {
            if (!IsLetterCursorValid())
                return;

            Point tmpCursor = LetterCursor;
            do
            {
                --tmpCursor.X;
            } while (tmpCursor.X >= 0 && theCharacters[tmpCursor.X, tmpCursor.Y] == "#");
            if (tmpCursor.X >= 0) // not all black squares until the beginning
            {
                LetterCursor = tmpCursor;
                this.Invalidate();
            }
        }

        //! Moves the cursor right, skipping black squares
        public void MoveCursorRight()
        {
            if (!IsLetterCursorValid())
                return;

            Point tmpCursor = LetterCursor;
            do
            {
                ++tmpCursor.X;
            } while (tmpCursor.X < GridColumnCount && theCharacters[tmpCursor.X, tmpCursor.Y] == "#");
            if (tmpCursor.X < GridColumnCount) // not all black squares until the end
            {
                LetterCursor = tmpCursor;
                this.Invalidate();
            }
        }


        //! Moves the cursor down, skipping black squares
        public void MoveCursorDown()
        {
            if (!IsLetterCursorValid())
                return;

            Point tmpCursor = LetterCursor;
            do
            {
                ++tmpCursor.Y;
            } while (tmpCursor.Y < GridRowCount && theCharacters[tmpCursor.X, tmpCursor.Y] == "#");
            if (tmpCursor.Y < GridRowCount) // not all black squares until the end
            {
                LetterCursor = tmpCursor;
                this.Invalidate();
            }
        }


        //! Moves the cursor down, skipping black squares
        public void MoveCursorUp()
        {
            if (!IsLetterCursorValid())
                return;

            Point tmpCursor = LetterCursor;
            do
            {
                --tmpCursor.Y;
            } while (tmpCursor.Y >= 0 && theCharacters[tmpCursor.X, tmpCursor.Y] == "#");
            if (tmpCursor.Y >= 0) // not all black squares until the end
            {
                LetterCursor = tmpCursor;
                this.Invalidate();
            }
        }



        //! Writes the letter grid to a file
        public void WriteToFile(String fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                WriteHeader(sw);

                // Write data
                for(int j = 0; j < GridRowCount; ++j)
                {
                    for (int i = 0; i < GridColumnCount; ++i)
                    {
                        // Make sure each character is readable
                        if (theCharacters[i, j] == null || theCharacters[i, j].Length != 1)
                            theCharacters[i, j] = " ";

                        // Write the file
                        sw.Write(theCharacters[i, j]);
                    }
                    sw.WriteLine();
                }
            }
        }


        //! Reads the letter grid from a file
        public void ReadFromFile(String fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                // Verify Identifier
                string Identifier = sr.ReadLine();
                if(Identifier != "LetterGrid File")
                {
                    MessageBox.Show("Error Loading File: Invalid Identifier");
                    return;
                }

                // Read dimensions
                string columnsAsString = sr.ReadLine();
                string rowsAsString = sr.ReadLine();
                int columns = Convert.ToInt32(columnsAsString);
                int rows = Convert.ToInt32(rowsAsString);

                if (columns <= 0 || rows <= 0)
                {
                    MessageBox.Show("Error Loading File: Invalid Dimensions");
                    return;
                }

                // Read Data
                string[,] tmp = new string[columns, rows];
                for (int j = 0; j < rows; ++j)
                {
                    string ThisRow = sr.ReadLine();
                    if (ThisRow.Length != columns)
                    {
                        MessageBox.Show("Error Loading File: Invalid Line width");
                        return;
                    }

                    for (int i = 0; i < columns; ++i)
                    {
                        // Input each character
                        tmp[i, j] = ThisRow[i].ToString();

                        // Ensure proper length
                        if (tmp[i, j].Length != 1)
                            tmp[i, j] = " ";
                    }
                }

                // Successful load, switch pointers and redraw
                theCharacters = tmp;
                LetterCursor.X = 0;
                LetterCursor.Y = 0;
                this.Invalidate();
            }
        }


        //! Writes the letter grid to a file
        public void WriteOnlyBlackSquaresToFile(String fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                WriteHeader(sw);

                // Write data
                for (int j = 0; j < GridRowCount; ++j)
                {
                    for (int i = 0; i < GridColumnCount; ++i)
                    {
                        // Write black squares only
                        if (theCharacters[i, j] == "#")
                            sw.Write("#");
                        else
                            sw.Write(" ");
                    }
                    sw.WriteLine();
                }
            }
        }


        // Writes the header for a crossword file
        private void WriteHeader(StreamWriter sw)
        {
            // Write Identifier
            sw.WriteLine("LetterGrid File");
            // Write columns, then rows
            sw.WriteLine(GridColumnCount);
            sw.WriteLine(GridRowCount);
        }


        //! Returns true if the square theLetters[X, Y] needs numbering
        private bool IsSquareNumbered(int X, int Y)
        {
            // Remove out-of-bounds squares
            if (X < 0 || X >= GridColumnCount ||
                Y < 0 || Y >= GridRowCount)
                return false;

            // Remove black squares
            if (theCharacters[X, Y] == "#")
                return false;

            // Check for horizontal start of word
            if ((X == 0 ||  theCharacters[X - 1, Y] == "#")
                && !(X == GridColumnCount - 1 || theCharacters[X + 1, Y] == "#"))
                return true;
             
            // Check for vertical start of word
            if ((Y == 0 || theCharacters[X, Y - 1] == "#")
                && !(Y == GridRowCount - 1 || theCharacters[X, Y + 1] == "#"))
                return true;

            return false;
        }

    }
}
