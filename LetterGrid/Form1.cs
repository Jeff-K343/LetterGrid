using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace LetterGrid
{
    public partial class Form1 : Form
    {        
        //! Spacing stuff
        const int gridBoxOffset = 32;

        //! Enum for program states
        private enum currentState
        {
            MODE_NONE,
            MODE_NORMAL,
            MODE_BLACKEN_SQUARES
        };

        //! The current program state
        currentState myCurrentState;

        //! Holds the mouse state
        GlobalMouseHandler gmh;

        //! Name of the last file for saving purposes
        String fileName;


        //! Constructor
        public Form1()
        {   
            InitializeComponent();

            gmh = new GlobalMouseHandler();
            Application.AddMessageFilter(gmh);

            // Resize the array to its initial size
            ResizeLetters(13, 15);

            theLetters.cursorMovesHorizontal = true;

            myCurrentState = currentState.MODE_BLACKEN_SQUARES;

            fileName = String.Empty;
        }

        //! Helper function to set the current state
        private void setMode(currentState mode)
        {
            myCurrentState = mode;
        }

        private void theLetters_MouseDown(object sender, MouseEventArgs e)
        {
            theLetters.SetCursorFromMouse(gmh.screenAbsolutePosition);

            if (myCurrentState == currentState.MODE_BLACKEN_SQUARES)
            {
                if (gmh.leftButtonDown)
                {
                    theLetters.SetSquareBlackFromPosition(gmh.screenAbsolutePosition);
                }
                else if (gmh.rightButtonDown)
                {
                    theLetters.SetSquareNonblackFromPosition(gmh.screenAbsolutePosition);
                }
            }
        }

        private void theLetters_MouseMove(object sender, MouseEventArgs e)
        {
            if (myCurrentState == currentState.MODE_BLACKEN_SQUARES)
            {
                if (gmh.leftButtonDown)
                {
                    theLetters.SetSquareBlackFromPosition(gmh.screenAbsolutePosition);
                }
                else if (gmh.rightButtonDown)
                {
                    theLetters.SetSquareNonblackFromPosition(gmh.screenAbsolutePosition);
                }
            }
        }

        private void squaresModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(squaresModeToolStripMenuItem.Checked)
                setMode(currentState.MODE_BLACKEN_SQUARES);
            else
                setMode(currentState.MODE_NORMAL);
        }

        private void theLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (myCurrentState == currentState.MODE_NORMAL)
            {
                theLetters.TryInputCharacter(e.KeyChar);
            }
        }

        private void theLetters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                theLetters.EraseCurrentSpace();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void resizeGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeDialogBox dialogBox = new ResizeDialogBox(this);
            dialogBox.ShowDialog();
        }

        public void ResizeLetters(int columns, int rows)
        {
            theLetters.ResizeGrid(columns, rows);

            this.Width = Math.Max(130, theLetters.Width + 32);
            this.Height = theLetters.Height + 40 + 40;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                theLetters.WriteToFile(fileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == String.Empty)
            {
                // 1st time, act as "Save as..." button
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                theLetters.WriteToFile(fileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                theLetters.ReadFromFile(fileName);
            }
        }

        private void moveHorizontalToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (moveHorizontalToolStripMenuItem.Checked)
                theLetters.cursorMovesHorizontal = true;
            else 
                theLetters.cursorMovesHorizontal = false;
        }

        private void numberSquaresToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (numberSquaresToolStripMenuItem.Checked)
                theLetters.numberSquares = true;
            else
                theLetters.numberSquares = false;
        }

        // Keyboard Shortcut implementation
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                Object sender = this;
                EventArgs e = new EventArgs();
                saveToolStripMenuItem_Click(sender, e);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                Object sender = this;
                EventArgs e = new EventArgs();
                loadToolStripMenuItem_Click(sender, e);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Down))
            {
                moveHorizontalToolStripMenuItem.Checked = false;
            }
            else if (keyData == (Keys.Control | Keys.Right))
            {
                moveHorizontalToolStripMenuItem.Checked = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "Save as template";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                theLetters.WriteOnlyBlackSquaresToFile(fileName);
            }
        }

        private void keyCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyCommandsScreen kcs = new KeyCommandsScreen();
            kcs.ShowDialog();
        } 



    }
}
