using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    class ThongSoGiaLap
    {
        public static int ToaDoGocX = 188;
        public static int ToaDoGocY = 56;
        public static int ChieuDaiKhoi = 56;
        public static int ChieuRongKhoi = 65;
        //-------Thông số game
        public static string deviceID;
        public static List<Button> Button = new List<Button>();
        public static String[] MapDv = new string[145];
        public static String[] BackupMapDv = new string[145];
        //--------Chuyển ảnh
        public static int FullClick = 0;
        public static int Lever = 1;
    }
}
