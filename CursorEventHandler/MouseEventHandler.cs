using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorEventHandler
{
    public class MouseEventHandler
    {
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        //This is a replacement for Cursor.Position in WinForms
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public static void LeftMouseClick()
        {
            var position = Control.MousePosition;
            mouse_event(MOUSEEVENTF_LEFTDOWN, position.X, position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, position.X, position.Y, 0, 0);
        }

        public static void RightMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, xpos, ypos, 0, 0);
        }

        public static void RightMouseClick()
        {
            var position = Control.MousePosition;
            mouse_event(MOUSEEVENTF_RIGHTDOWN, position.X, position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, position.X, position.Y, 0, 0);
        }

        public static string GetColor()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, Cursor.Position.X, Cursor.Position.Y);
            ReleaseDC(IntPtr.Zero, hdc);
            System.Drawing.Color color = System.Drawing.Color.FromArgb((int) pixel);
            return $"{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static void Delay(int timeInSeconds)
        {
            System.Threading.Thread.Sleep(timeInSeconds * 1000);
        }
    }
}