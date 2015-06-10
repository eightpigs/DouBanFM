using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace DesireFM
{
    public class Hotkey 
    {
        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        //注册热键的api 
        [DllImport("user32")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id); 

    }
}