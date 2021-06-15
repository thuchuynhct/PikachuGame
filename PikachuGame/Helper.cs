using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    class Helper
    {
        public static int getViTriHienTai(int position, int type)
        {
            int _hang = 1, _cot = position;
            for (int i = 1; i <= 9; i++)
            {
                if (position > i * 16)
                {
                    _hang = i + 1;
                    _cot = position - i * 16;
                }
            }
            if (type == 1) { return _hang; }
            else { return _cot; }
        }
        public static void Sosanh(int pos1, int pos2)
        {
            if (ThongSoGiaLap.MapDv[pos1] == ThongSoGiaLap.MapDv[pos2])
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                Helper.ClickArea(pos1);
                Helper.ClickArea(pos2);
                ThongSoGiaLap.MapDv[pos1] = null;
                ThongSoGiaLap.MapDv[pos2] = null;
            }

        }
        public static void ClickArea(int position)
        {
            int ToaDo_X, ToaDo_Y, _cot = position, _hang = 1;
            for (int i = 1; i <= 9; i++)
            {
                if (position > i * 16)
                {
                    _hang = i + 1;
                    _cot = position - i * 16;
                }
            }
            ToaDo_X = ThongSoGiaLap.ToaDoGocX + _cot * ThongSoGiaLap.ChieuDaiKhoi - ThongSoGiaLap.ChieuDaiKhoi / 2;
            ToaDo_Y = ThongSoGiaLap.ToaDoGocY + _hang * ThongSoGiaLap.ChieuRongKhoi - ThongSoGiaLap.ChieuRongKhoi / 2;
            //----------Click Toại độ
            KAutoHelper.ADBHelper.Tap(ThongSoGiaLap.deviceID, ToaDo_X, ToaDo_Y);
        }
        public static bool SoSanh2mannh(string Pfirst, string Psecond)
        {
            if (Pfirst == Psecond)
            {
                return true;
            }
            else return false;
        }

        public static void CheckArea()
        {
            int Vitri1 = 0, Vitri2 = 0;
            #region Check top
            for (int i = 1; i <= 16; i++)
            {
                if (ThongSoGiaLap.MapDv[i] == null)
                {
                    Vitri1 = GetThayThe(i, "bot");
                }
                else { Vitri1 = i; }
                for (int x = 1; x <= 16; x++)
                {
                    if (i != x)
                    {
                        if (ThongSoGiaLap.MapDv[x] == null)
                        {
                            Vitri2 = GetThayThe(x, "bot");
                        }
                        else { Vitri2 = x; }
                        //----------So sánh 2 ảnh----------
                        Sosanh(Vitri1, Vitri2);
                    }
                }
            }
            #endregion
            #region Check Bot
            for (int i = 129; i <= 144; i++)
            {
                if (ThongSoGiaLap.MapDv[i] == null)
                {
                    Vitri1 = GetThayThe(i, "top");
                }
                else { Vitri1 = i; }
                for (int x = 129; x <= 144; x++)
                {
                    if (i != x)
                    {
                        if (ThongSoGiaLap.MapDv[x] == null)
                        {
                            Vitri2 = GetThayThe(x, "top");
                        }
                        else { Vitri2 = x; }
                        //----------So sánh 2 ảnh----------
                        Sosanh(Vitri1, Vitri2);
                    }
                }
            }
            #endregion
            #region Mid-ngang
            int VTGoc = 17;
            int[] m_Vitri = { 0, 0, 0 };
            for (int aa = 1; aa <= 8; aa++)
            {
                for (int a = VTGoc; a <= VTGoc + 14; a++)
                {
                    if (ThongSoGiaLap.MapDv[a] != null)
                    {
                        if (ThongSoGiaLap.MapDv[a + 1] == null)
                        {
                            m_Vitri[0] = GetThayThe(a + 1, "right");
                            //m_Vitri[1] = GetThayThe(a + 1, "bot");
                            // m_Vitri[2] = GetThayThe(a + 1, "top");
                        }
                        else { m_Vitri[0] = a + 1; }
                        for (int vt = 0; vt < 3; vt++)
                        {
                            if (m_Vitri[vt] != 0)
                            {
                                Sosanh(a, m_Vitri[vt]);
                            }
                        }


                    }

                    // }
                }
                VTGoc += 16;
            }

            //}
            VTGoc = 16;
            #endregion
            #region Right-dọc
            for (int di = 1; di < 144; di += 16)
            {
                if (ThongSoGiaLap.MapDv[di] == null)
                {
                    Vitri1 = GetThayThe(di, "right");
                }
                else { Vitri1 = di; };
                for (int dy = 1; dy < 144; dy += 16)
                {
                    if (di != dy)
                    {
                        if (ThongSoGiaLap.MapDv[dy] == null)
                        {
                            Vitri2 = GetThayThe(dy, "right");
                        }
                        else { Vitri2 = dy; }
                        Sosanh(Vitri1, Vitri2);
                    }
                }
            }
            #endregion
            #region Left dọc
            for (int li = 16; li < 144; li += 16)
            {
                if (ThongSoGiaLap.MapDv[li] == null)
                {
                    Vitri1 = GetThayThe(li, "left");
                }
                else { Vitri1 = li; };
                for (int ly = 16; ly < 144; ly += 16)
                {
                    if (li != ly)
                    {
                        if (ThongSoGiaLap.MapDv[ly] == null)
                        {
                            Vitri2 = GetThayThe(ly, "lefft");
                        }
                        else { Vitri2 = ly; }
                        Sosanh(Vitri1, Vitri2);
                    }
                }
            }
            #endregion
            #region Mid dọc
            int vtDx = 2;
            for (int dx = vtDx; dx <= 16; dx++)
            {
                for (int di = vtDx; di <= 128; di += 16)
                {
                    if (ThongSoGiaLap.MapDv[di] != null)
                    {
                        if (ThongSoGiaLap.MapDv[di + 16] == null)
                        {
                            Vitri2 = GetThayThe(di + 16, "bot");
                        }
                        else { Vitri2 = di + 16; }
                        Sosanh(di, Vitri2);
                    }
                }
                vtDx++;
            }
            vtDx = 0;
            #endregion
            #region Check Xuống: Trái - phải - dưới

            #endregion
        }
        public static void Testing()
        {
            for (int a = 1; a <= 144; a++)
            {
                if (ThongSoGiaLap.MapDv[a] == null)
                {
                    for (int b = 1; b <= 9; b++)
                    {
                        try
                        {
                            int vitri = a + b * 16;
                            int sosanh = GetThayThe(a, "left");
                            for (int c = 1; c <= 9; c++)
                            {
                                if (ThongSoGiaLap.MapDv[sosanh] != null)
                                {
                                    int vitri2 = a + b * 16;
                                    int sosanh2 = GetThayThe(vitri2, "right");
                                    Sosanh(sosanh, sosanh2);
                                }

                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public static int GetThayThe(int Pos, string type)
        {
            int Vitri = Pos;
            int _cot = Pos, _hang = 1;
            //------------------Lấy ra hàng và cột của vị trí
            for (int i = 1; i <= 9; i++)
            {
                if (Pos > i * 16)
                {
                    _hang = i + 1;
                    _cot = Pos - i * 16;
                }
            }
            switch (type)
            {
                case "top":
                    int end = _hang - 1;
                    for (int i = 1; i <= end; i++)
                    {
                        if (ThongSoGiaLap.MapDv[Pos - 16 * i] != null)
                        {
                            Vitri = Pos - 16 * i;
                            break;
                        }
                    }
                    break;
                case "bot":
                    int end1 = 9 - _hang;
                    for (int i = 1; i <= end1; i++)
                    {
                        if (ThongSoGiaLap.MapDv[Pos + 16 * i] != null)
                        {
                            Vitri = Pos + 16 * i;
                            break;
                        }
                    }
                    break;
                case "right":
                    int end2 = _hang * 16;
                    for (int i = Pos + 1; i <= end2; i++)
                    {
                        if (ThongSoGiaLap.MapDv[i] != null)
                        {
                            Vitri = i;
                            break;
                        }
                    }
                    break;
                case "left":
                    int end3 = (_hang * 16) - 15;
                    for (int i = Pos - 1; i >= end3; i--)
                    {
                        if (ThongSoGiaLap.MapDv[i] != null)
                        {
                            Vitri = i;
                            break;
                        }
                    }
                    break;
            }
            return Vitri;
        }

        public static int GetNull(int Pos, string type)
        {
            int Vitri = Pos;
            int _cot = Pos, _hang = 1;
            //------------------Lấy ra hàng và cột của vị trí
            for (int i = 1; i <= 9; i++)
            {
                if (Pos > i * 16)
                {
                    _hang = i + 1;
                    _cot = Pos - i * 16;
                }
            }
            switch (type)
            {
                case "top":
                    int end = _hang - 1;
                    for (int i = 1; i <= end; i++)
                    {
                        int Pos_ss = Pos - 16 * i;
                        if (ThongSoGiaLap.MapDv[Pos_ss] == null)
                        {
                            if (Pos_ss > 16)
                            {
                                if (ThongSoGiaLap.MapDv[Pos_ss - 16] != null)
                                {
                                    Vitri = Pos_ss;
                                    break;
                                }

                            }
                            else
                            {
                                Vitri = Pos_ss;
                            }

                        }
                        else { break; }
                    }
                    break;
                case "bot":
                    int end1 = 9 - _hang;
                    for (int i = 1; i <= end1; i++)
                    {
                        int Pos_ss = Pos + 16 * i;
                        if (ThongSoGiaLap.MapDv[Pos_ss] == null)
                        {
                            if (Pos_ss < 129)
                            {
                                if (ThongSoGiaLap.MapDv[Pos_ss + 16] != null)
                                {
                                    Vitri = Pos_ss;
                                    break;
                                }
                            }
                            else
                            {
                                Vitri = Pos_ss;
                            }
                        }
                        else { break; }
                    }
                    break;
                case "right":
                    int end2 = _hang * 16;
                    for (int i = Pos + 1; i <= end2; i++)
                    {
                        if (ThongSoGiaLap.MapDv[i] == null)
                        {
                            if (i < end2)
                            {
                                if (ThongSoGiaLap.MapDv[i + 1] != null)
                                {
                                    Vitri = i;
                                    break;
                                }
                            }
                            else
                            {
                                Vitri = i;
                            }
                        }
                        else { break; }
                    }
                    break;
                case "left":
                    int end3 = (_hang * 16) - 15;
                    for (int i = Pos - 1; i >= end3; i--)
                    {
                        if (ThongSoGiaLap.MapDv[i] == null)
                        {
                            if (i > end3)
                            {
                                if (ThongSoGiaLap.MapDv[i - 1] != null)
                                {
                                    Vitri = i;
                                    break;
                                }
                            }
                            else
                            {
                                Vitri = i;
                            }
                        }
                        else { break; }
                    }
                    break;
            }
            return Vitri;
        }
        public static void Example()
        {
            /*for (int i = 33; i <= 48; i++)
            {
                ThongSoGiaLap.MapDv[i] = i.ToString();
            }*/
            ThongSoGiaLap.MapDv[18] = "Cuu";
            ThongSoGiaLap.MapDv[21] = "Cuu";
            ThongSoGiaLap.MapDv[117] = "Cuu";
            ThongSoGiaLap.MapDv[82] = "Cuu";
            ThongSoGiaLap.MapDv[93] = "Cuu";
        }
        public static bool CheckNgangHang(int a, int b)
        {
            int _hangA = Helperv2.getViTriHangCot(a, 1); int _hangB = Helperv2.getViTriHangCot(b, 1);
            int _cotA = Helperv2.getViTriHangCot(a, 2); int _cotB = Helperv2.getViTriHangCot(b, 2);
            int _khoangcach2vt = Math.Abs(_cotA - _cotB);
            int _tamA = 0, _tamB = 0;
            if (Helper.GetNull(a, "top") != a && Helper.GetNull(b, "top") != b)
            {
                //Lấy ra hàng của vị trí null                       
                int Hang_VitriNull = Math.Max(Helperv2.getViTriHangCot(Helper.GetNull(a, "top"), 1), Helperv2.getViTriHangCot(Helper.GetNull(b, "top"), 1));
                //Nếu vị trí hàng null ở hàng 1 hoặc 9 thì trả về true
                if (Hang_VitriNull == 1)
                {
                    return true;
                }
                //Lấy ra vị trí hàng nhỏ nhất của 2 mảnh
                int Hang_Min = Math.Min(_hangA, _hangB);
                //Set vị trí tạm cho 2 vị trí a,b
                if (a < b)
                {
                    if (_cotA < _cotB)
                    {
                        _tamA = a;
                        _tamB = a + _khoangcach2vt;
                    }
                    else
                    {
                        _tamA = a;
                        _tamB = a - _khoangcach2vt;
                    }
                }
                else
                {
                    if (_cotA < _cotB)
                    {
                        _tamA = b - _khoangcach2vt;
                        _tamB = b;
                    }
                    else
                    {
                        _tamA = b + _khoangcach2vt;
                        _tamB = b;
                    }
                }
                int _Thamso = 16;
                //So sánh
                for (int c = Hang_VitriNull; c < Hang_Min; c++)
                {
                    int dem = 0;
                    for (int e = _tamA - _Thamso; e < _tamB - _Thamso; e++)
                    {
                        if (ThongSoGiaLap.MapDv[e] != null)
                        {
                            dem++;
                        }
                    }
                    if (dem == 0)
                    {
                        return true;
                    }
                    _Thamso += 16;

                }

            }
            else if (Helper.GetNull(a, "bot") != a && Helper.GetNull(b, "bot") != b)
            {
                //Lấy ra hàng của vị trí null                       
                int Hang_VitriNull = Math.Min(Helperv2.getViTriHangCot(Helper.GetNull(a, "bot"), 1), Helperv2.getViTriHangCot(Helper.GetNull(b, "bot"), 1));
                //Nếu vị trí hàng null ở hàng 1 hoặc 9 thì trả về true
                if (Hang_VitriNull == 9)
                {
                    return true;
                }
                //Lấy ra vị trí hàng lớn nhất của 2 mảnh
                int Hang_Max = Math.Max(Helperv2.getViTriHangCot(a, 1), Helperv2.getViTriHangCot(b, 1));
                //Set vị trí tạm cho 2 vị trí a,b
                if (a < b)
                {
                    if (_cotA < _cotB)
                    {
                        _tamA = b - _khoangcach2vt;
                        _tamB = b;
                    }
                    else
                    {
                        _tamA = b + _khoangcach2vt;
                        _tamB = b;
                    }
                }
                else
                {
                    if (_cotA < _cotB)
                    {
                        _tamA = a;
                        _tamB = a + _khoangcach2vt;
                    }
                    else
                    {
                        _tamA = a;
                        _tamB = a - _khoangcach2vt;
                    }
                }
                int _Thamso = 16;
                //So sánh
                for (int c = Hang_Max + 1; c <= Hang_VitriNull; c++)
                {
                    int dem = 0;
                    for (int e = a + _Thamso; e < b + _Thamso; e++)
                    {
                        if (ThongSoGiaLap.MapDv[e] != null)
                        {
                            dem++;
                        }
                    }
                    if (dem == 0)
                    {
                        return true;
                    }
                    _Thamso += 16;
                }

            }
            return false;
        }
    }
}
