using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    class SideHelper
    {
        // ------------------------------Check phía bên phải ------------------------------
        #region Kiểm tra phải
        //---------------Kiểm tra phải - trên
        public static bool KiemTraPhaiTren(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Phai");
            for (int a = _vitri1 + 1; a <= _VI_TRI_RONG_1; a++)
            {
                if (ChucNang.LayViTriThayThe(a, "Duoi") == _vitri2)
                {
                    return true;
                }
            }
            return false;

        }
        //---------------Kiểm tra phải - trái
        public static bool KiemTraPhaiTrai(int _vitri1, int _vitri2)
        {
            //------Nếu 2 vị trí nằm cùng hàng
            if (ChucNang.LayViTriThayThe(_vitri1, "Phai") == _vitri2)
            {
                return true;
            }
            //------Nếu 2 vị trí không nằm cùng hàng
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Phai");
            for (int a = _vitri1 + 1; a <= _VI_TRI_RONG_1; a++)
            {
                if (ChucNang.LayViTriHangCot(a, 2) < ChucNang.LayViTriHangCot(_vitri2, 2))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Duoi");
                    for (int b = a + 16; b <= _VI_TRI_RONG_A; b += 16)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Phai") == _vitri2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra phải - phải
        public static bool KiemTraPhaiPhai(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Phai");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Phai");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 2) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 2)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 2) == 16)
            {
                return true;
            }
            for (int a = _vitri1 + 1; a <= _VI_TRI_RONG_1; a++)
            {
                int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Duoi");
                for (int b = a + 16; b <= _VI_TRI_RONG_A; b += 16)
                {
                    if (ChucNang.LayViTriThayThe(b, "Trai") == _vitri2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra phải - dưới
        public static bool KiemTraPhaiDuoi(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                if (ChucNang.LayViTriThayThe(a, "Trai") == _vitri2)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        // ------------------------------Check phía bên dưới ------------------------------
        #region Kiểm tra dưới
        //---------------Kiểm tra dưới - trái
        public static bool KiemTraDuoiTrai(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                if (ChucNang.LayViTriThayThe(a, "Phai") == _vitri2)
                {
                    return true;
                }
            }
            return false;
        }
        //---------------Kiểm tra dưới - trên
        public static bool KiemTraDuoiTren(int _vitri1, int _vitri2)
        {
            //-------------Nếu cùng 1 cột
            if (ChucNang.LayViTriThayThe(_vitri1, "Duoi") == _vitri2)
            {
                return true;
            }
            //------------Nếu không
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                if (ChucNang.LayViTriHangCot(a, 1) < ChucNang.LayViTriHangCot(_vitri2, 1))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Phai");
                    for (int b = a + 1; b <= _VI_TRI_RONG_A; b++)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Duoi") == _vitri2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra dưới - dưới
        public static bool KiemTraDuoiDuoi(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Duoi");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 1)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == 9)
            {
                return true;
            }
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                if (ChucNang.LayViTriHangCot(a, 1) > ChucNang.LayViTriHangCot(_vitri2, 1))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Phai");
                    for (int b = a + 1; b <= _VI_TRI_RONG_A; b++)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Tren") == _vitri2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra dưới - trên VT2
        public static bool KiemTraDuoiTrenVT2(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Trai");
                for (int b = a - 1; b >= _VI_TRI_RONG_A; b--)
                {
                    if (ChucNang.LayViTriThayThe(b, "Duoi") == _vitri2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra dưới - dưới VT2
        public static bool KiemTraDuoiDuoiVT2(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Duoi");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Duoi");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 1)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == 9)
            {
                return true;
            }
            for (int a = _vitri1 + 16; a <= _VI_TRI_RONG_1; a += 16)
            {
                if (ChucNang.LayViTriHangCot(a, 1) > ChucNang.LayViTriHangCot(_vitri2, 1))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Trai");
                    for (int b = a - 1; b >= _VI_TRI_RONG_A; b--)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Tren") == _vitri2)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        #endregion
        // ------------------------------Check phía bên trái ------------------------------
        #region Kiểm tra trái
        //---------------Kiểm tra phải - trên
        public static bool KiemTraTraiTren(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Trai");
            for (int a = _vitri1 - 1; a >= _VI_TRI_RONG_1; a--)
            {
                if (ChucNang.LayViTriThayThe(a, "Duoi") == _vitri2)
                {
                    return true;
                }
            }
            return false;
        }
        //---------------Kiểm tra phải - trên
        public static bool KiemTraTraiPhai(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Trai");
            for (int a = _vitri1 - 1; a >= _VI_TRI_RONG_1; a--)
            {
                if (ChucNang.LayViTriHangCot(a, 2) > ChucNang.LayViTriHangCot(_vitri2, 2))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Duoi");
                    for (int b = a + 16; b <= _VI_TRI_RONG_A; b += 16)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Trai") == _vitri2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra phải - trên
        public static bool KiemTraTraiTrai(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Trai");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Trai");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 2) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 2)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 2) == 1)
            {
                return true;
            }
            for (int a = _vitri1 - 1; a >= _VI_TRI_RONG_1; a--)
            {
                if (ChucNang.LayViTriHangCot(a, 2) < ChucNang.LayViTriHangCot(_vitri2, 2))
                {
                    int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Duoi");
                    for (int b = a + 16; b <= _VI_TRI_RONG_A; b += 16)
                    {
                        if (ChucNang.LayViTriThayThe(b, "Phai") == _vitri2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
        // ------------------------------Check phía bên trên ------------------------------
        #region Kiểm tra trên
        //---------------Kiểm tra trên - trên VT1
        public static bool KiemTraTrenTrenVT1(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Tren");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Tren");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 1)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == 1)
            {
                return true;
            }
            for (int a = _vitri1 - 16; a >= _VI_TRI_RONG_1; a -= 16)
            {
                int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Phai");
                for (int b = a + 1; b <= _VI_TRI_RONG_A; b++)
                {
                    if (ChucNang.LayViTriThayThe(b, "Duoi") == _vitri2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //---------------Kiểm tra trên - trên VT2
        public static bool KiemTraTrenTrenVT2(int _vitri1, int _vitri2)
        {
            int _VI_TRI_RONG_1 = ChucNang.LayViTriRong(_vitri1, "Tren");
            int _VI_TRI_RONG_2 = ChucNang.LayViTriRong(_vitri2, "Tren");
            if (ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == ChucNang.LayViTriHangCot(_VI_TRI_RONG_2, 1)
                && ChucNang.LayViTriHangCot(_VI_TRI_RONG_1, 1) == 1)
            {
                return true;
            }
            for (int a = _vitri1 - 16; a >= _VI_TRI_RONG_1; a -= 16)
            {
                int _VI_TRI_RONG_A = ChucNang.LayViTriRong(a, "Trai");
                for (int b = a - 1; b >= _VI_TRI_RONG_A; b--)
                {
                    if (ChucNang.LayViTriThayThe(b, "Duoi") == _vitri2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
