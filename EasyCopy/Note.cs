using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyCopy
{
    class Note
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CopyData lParam);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //定义消息常数 
        public const int WM_COPYDATA = 0x004A;
        public struct CopyData
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        public static bool SendMsg(string MSG)
        {
            var hwnd = FindWindow(null, "EasyCopy");
            Console.WriteLine("hwnd ="  + hwnd );
            if (hwnd == IntPtr.Zero)
            {
                return false;
            }
            CopyData data;
            data.dwData = IntPtr.Zero;
            data.lpData = MSG;
            data.cbData = Encoding.Default.GetBytes(data.lpData).Length + 1;
            SendMessage(hwnd, WM_COPYDATA, 0, ref data);
            return true;
        }
    }
}
