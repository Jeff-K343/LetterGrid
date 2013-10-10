using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LetterGrid
{
    public partial class ResizeDialogBox : Form
    {
        Form1 mainForm;

        public ResizeDialogBox(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void ResizeGridOKButton_Click(object sender, EventArgs e)
        {
            mainForm.ResizeLetters(Convert.ToInt32(columnCountSelector.Value), 
                                   Convert.ToInt32(rowCountSelector.Value));
            this.Close();
        }

        private void ResizeGridCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
