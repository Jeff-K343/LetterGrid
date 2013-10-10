using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LetterGrid
{

    /// <summary>
    /// Global handler for mouse move input
    /// </summary>
    class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE   = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP   = 0x0202;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP   = 0x0205;

        private const int MK_LBUTTON = 0x0001;
        private const int MK_RBUTTON = 0x0002;

        private Point _pos;
        private bool _leftButtonDown;
        private bool _rightButtonDown;


        public Point screenAbsolutePosition 
        {
            get{return _pos;}    
        }

        public bool leftButtonDown 
        {
            get{return _leftButtonDown;}
        }

        public bool rightButtonDown
        { 
            get{return _rightButtonDown;}
        }

        // Constructor
        public GlobalMouseHandler()
        {
            _pos = new Point(0, 0);
            _leftButtonDown = false;
            _rightButtonDown = false;
        }

        // Message filter
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONUP)
            {
                _leftButtonDown = (((int)m.WParam & MK_LBUTTON) == MK_LBUTTON);
            }
            else if (m.Msg == WM_RBUTTONDOWN || m.Msg == WM_RBUTTONUP)
            {
                _rightButtonDown = (((int)m.WParam & MK_RBUTTON) == MK_RBUTTON);
            }
            else if (m.Msg == WM_MOUSEMOVE)
            {
                _pos = System.Windows.Forms.Cursor.Position;
            }

            // Don't capture the event
            return false;
        }
    }
}
