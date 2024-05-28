using System;
using System.Windows.Forms;

namespace TextReader
{
    public interface ISnippingForm
    {
        void SnippingForm_Load(object sender, EventArgs e);
        void Capture_MouseDown(object sender, MouseEventArgs e);
        void Capture_MouseMove(object sender, MouseEventArgs e);
        void Capture_MouseUp(object sender, MouseEventArgs e);
        void SaveToClipBoard();
    }
}
