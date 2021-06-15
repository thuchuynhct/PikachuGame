using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    class ChucNang
    {
        public static void Test()
        {
            for (int i = 1; i <= 144; i++)
            {
                ThongSoGiaLap.MapDv[i] = i.ToString();
            }
            /*for (int i = 1; i <= 144; i++)
            {
                ThongSoGiaLap.MapDv[i] = ThongSoGiaLap.BackupMapDv[i];
            }*/
        }
        //------------------------------SAO LƯU DỮ LIỆU------------------------------
        public static void SaoLuu()
        {
            for (int i = 1; i <= 144; i++)
            {
                ThongSoGiaLap.BackupMapDv[i] = ThongSoGiaLap.MapDv[i];
            }
        }
        //------------------------------DỪNG GAME------------------------------
        public static void DungTroChoi()
        {
            KAutoHelper.ADBHelper.TapByPercent(ThongSoGiaLap.deviceID, 11.3, 52.2);
        }
        //------------------------------TIẾP TỤC GAME------------------------------
        public static void TiepTucTroChoi()
        {
            KAutoHelper.ADBHelper.TapByPercent(ThongSoGiaLap.deviceID, 49.8, 50.4);
        }
        //------------------------------NEXT LEVER------------------------------
        public static void NextLever()
        {
            KAutoHelper.ADBHelper.TapByPercent(ThongSoGiaLap.deviceID, 48.7, 53.7);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        //------------------------------LẤY VỊ TRÍ HÀNG CỘT------------------------------
        public static int LayViTriHangCot(int position, int type)
        {
            // 1 return hàng, 2 return cột
            int _hang = 1, _cot = position;
            for (int i = 1; i <= 9; i++)
            {
                if (position > i * 16)
                {
                    _hang = i + 1;
                    _cot = position - i * 16;
                }
            }
            if (type == 1)
            {
                return _hang;
            }
            else
            {
                return _cot;
            }
        }
        //------------------------------Lấy vị trí thay thế------------------------------
        public static int LayViTriThayThe(int Pos, string type)
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
                case "Tren":
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
                case "Duoi":
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
                case "Phai":
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
                case "Trai":
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
        //------------------------------Lấy vị trí rỗng------------------------------
        public static int LayViTriRong(int Pos, string type)
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
                case "Tren":
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
                case "Duoi":
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
                case "Phai":
                    int end2 = _hang * 16;
                    for (int i = Pos + 1; i <= end2; i++)
                    {
                        if (ThongSoGiaLap.MapDv[i] == null)
                        {

                            if (i == end2)
                            {
                                Vitri = i;
                                break;
                            }
                            else
                            {
                                if (ThongSoGiaLap.MapDv[i + 1] != null)
                                {
                                    Vitri = i;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "Trai":
                    int end3 = (_hang * 16) - 15;
                    for (int i = Pos - 1; i >= end3; i--)
                    {
                        if (ThongSoGiaLap.MapDv[i] == null)
                        {
                            if (i == end3)
                            {
                                Vitri = i;
                                break;
                            }
                            else
                            {
                                if (ThongSoGiaLap.MapDv[i - 1] != null)
                                {
                                    Vitri = i;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }
            return Vitri;
        }
        //------------------------------Click vào trí trí ô------------------------------
        public static void ClickViTri(int _vitri1, int _vitri2)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            Helper.ClickArea(_vitri1);
            Helper.ClickArea(_vitri2);
            ThongSoGiaLap.Button[_vitri1].BackColor = Color.Green;
            ThongSoGiaLap.Button[_vitri2].BackColor = Color.Green;
            Thread.Sleep(TimeSpan.FromSeconds(0.2));
            ThongSoGiaLap.Button[_vitri1].BackColor = Color.Gray;
            ThongSoGiaLap.Button[_vitri2].BackColor = Color.Gray;
            GanNullTheoLever(_vitri1, _vitri2, ThongSoGiaLap.Lever);

            ThongSoGiaLap.FullClick++;
        }
        //--------------------------------GÁN NULL CHO TỪNG LEVER---------------------------
        public static void GanNullTheoLever(int _vitri1, int _vitri2, int lever)
        {
            //--------------------------------LEVER 1---------------------------
            if (lever == 1)
            {
                ThongSoGiaLap.MapDv[_vitri1] = null;
                ThongSoGiaLap.MapDv[_vitri2] = null;
                Task t = new Task(() =>
                {
                    ThongSoGiaLap.Button[_vitri1].Text = "";
                    ThongSoGiaLap.Button[_vitri2].Text = "";
                    ThongSoGiaLap.Button[_vitri1].BackColor = Color.Black;
                    ThongSoGiaLap.Button[_vitri2].BackColor = Color.Black;

                });
                t.Start();

            }
            /* --------------------------------LEVER 2---------------------------
             -------------------------------------------------------------------*/
            else if (lever == 2)
            {
                //--------------Nếu 2 VT cùng cột
                if (ChucNang.LayViTriHangCot(_vitri1, 2) == ChucNang.LayViTriHangCot(_vitri2, 2))
                {
                    if (_vitri1 + 16 == _vitri2)
                    {
                        for (int a = _vitri1; a <= 144; a += 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a + 32];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a + 32];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        //-----------Gán rỗng VT1
                        for (int a = _vitri1; a < _vitri2; a += 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a + 16];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a + 16];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                        //------------Gán rỗng VT2
                        for (int b = _vitri2 - 16; b <= 144; b += 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[b] = ThongSoGiaLap.MapDv[b + 32];
                                ThongSoGiaLap.Button[b].Text = ThongSoGiaLap.MapDv[b + 32];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[b] = null; ThongSoGiaLap.Button[b].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[b] == null) ThongSoGiaLap.Button[b].BackColor = Color.Black;
                        }
                    }
                }
                /* ------------------------------------------------------
                 -------------------Nếu 2 VT không cùng cột -------------
                 ------------------------------------------------------*/
                else
                {
                    //Gán rỗng VT1
                    for (int c = _vitri1; c <= 144; c += 16)
                    {
                        try
                        {
                            ThongSoGiaLap.MapDv[c] = ThongSoGiaLap.MapDv[c + 16];
                            ThongSoGiaLap.Button[c].Text = ThongSoGiaLap.MapDv[c + 16];
                        }
                        catch
                        {
                            ThongSoGiaLap.MapDv[c] = null; ThongSoGiaLap.Button[c].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[c] == null) ThongSoGiaLap.Button[c].BackColor = Color.Black;
                    }
                    //Gán rỗng VT2
                    for (int s = _vitri2; s <= 144; s += 16)
                    {
                        try
                        {
                            ThongSoGiaLap.MapDv[s] = ThongSoGiaLap.MapDv[s + 16];
                            ThongSoGiaLap.Button[s].Text = ThongSoGiaLap.MapDv[s + 16];
                        }
                        catch
                        {
                            ThongSoGiaLap.MapDv[s] = null; ThongSoGiaLap.Button[s].Text = "";
                            ThongSoGiaLap.Button[s].BackColor = Color.Black;
                        }
                        if (ThongSoGiaLap.MapDv[s] == null) ThongSoGiaLap.Button[s].BackColor = Color.Black;
                    }
                }
                // Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            }
            /* --------------------------------LEVER 3---------------------------
            -------------------------------------------------------------------*/
            else if (lever == 3)
            {
                //--------------Nếu 2 VT cùng cột
                if (ChucNang.LayViTriHangCot(_vitri1, 2) == ChucNang.LayViTriHangCot(_vitri2, 2))
                {
                    if (_vitri1 + 16 == _vitri2)
                    {
                        for (int a = _vitri2; a >= 1; a -= 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a - 32];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a - 32];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        //-----------Gán rỗng VT1
                        for (int a = _vitri2; a > _vitri1; a -= 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a - 16];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a - 16];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                        //------------Gán rỗng VT2
                        for (int b = _vitri1 + 16; b >= 1; b -= 16)
                        {
                            try
                            {
                                ThongSoGiaLap.MapDv[b] = ThongSoGiaLap.MapDv[b - 32];
                                ThongSoGiaLap.Button[b].Text = ThongSoGiaLap.MapDv[b - 32];
                            }
                            catch
                            {
                                ThongSoGiaLap.MapDv[b] = null; ThongSoGiaLap.Button[b].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[b] == null) ThongSoGiaLap.Button[b].BackColor = Color.Black;
                        }
                    }
                }
                /* ------------------------------------------------------
                 -------------------Nếu 2 VT không cùng cột -------------
                 ------------------------------------------------------*/
                else
                {
                    //Gán rỗng VT1
                    for (int c = _vitri1; c >= 1; c -= 16)
                    {
                        try
                        {
                            ThongSoGiaLap.MapDv[c] = ThongSoGiaLap.MapDv[c - 16];
                            ThongSoGiaLap.Button[c].Text = ThongSoGiaLap.MapDv[c - 16];
                        }
                        catch
                        {
                            ThongSoGiaLap.MapDv[c] = null; ThongSoGiaLap.Button[c].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[c] == null) ThongSoGiaLap.Button[c].BackColor = Color.Black;
                    }
                    //Gán rỗng VT2
                    for (int s = _vitri2; s >= 1; s -= 16)
                    {
                        try
                        {
                            ThongSoGiaLap.MapDv[s] = ThongSoGiaLap.MapDv[s - 16];
                            ThongSoGiaLap.Button[s].Text = ThongSoGiaLap.MapDv[s - 16];
                        }
                        catch
                        {
                            ThongSoGiaLap.MapDv[s] = null; ThongSoGiaLap.Button[s].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[s] == null) ThongSoGiaLap.Button[s].BackColor = Color.Black;
                    }
                }
            }
            /* --------------------------------LEVER 4---------------------------
            ----------------------------------THỤT TRÁI----------------------------*/
            else if (lever == 4)
            {
                //--------------Nếu 2 VT cùng hàng
                if (ChucNang.LayViTriHangCot(_vitri1, 1) == ChucNang.LayViTriHangCot(_vitri2, 1))
                {
                    int DIEM_CUOI_HANG = ChucNang.LayViTriHangCot(_vitri1, 1) * 16;
                    if (_vitri1 + 1 == _vitri2)
                    {
                        for (int a = _vitri1; a <= DIEM_CUOI_HANG; a++)
                        {
                            if (a + 2 <= DIEM_CUOI_HANG)
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a + 2];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a + 2];
                            }
                            else
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        //-----------Gán rỗng VT1                        
                        for (int a = _vitri1; a < _vitri2; a++)
                        {
                            /*if (a + 1 <= DIEM_CUOI_HANG)
                            {*/
                            ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a + 1];
                            ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a + 1];
                            /*}
                            else
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }*/
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                        //------------Gán rỗng VT2
                        for (int b = _vitri2 - 1; b <= DIEM_CUOI_HANG; b++)
                        {
                            if (b + 2 <= DIEM_CUOI_HANG)
                            {
                                ThongSoGiaLap.MapDv[b] = ThongSoGiaLap.MapDv[b + 2];
                                ThongSoGiaLap.Button[b].Text = ThongSoGiaLap.MapDv[b + 2];
                            }
                            else
                            {
                                ThongSoGiaLap.MapDv[b] = null; ThongSoGiaLap.Button[b].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[b] == null) ThongSoGiaLap.Button[b].BackColor = Color.Black;
                        }
                    }
                }
                /* ------------------------------------------------------
                 -------------------Nếu 2 VT không cùng cột -------------
                 ------------------------------------------------------*/
                else
                {
                    //Gán rỗng VT1
                    int DIEM_CUOI_HANG_1 = ChucNang.LayViTriHangCot(_vitri1, 1) * 16;
                    for (int c = _vitri1; c <= DIEM_CUOI_HANG_1; c++)
                    {
                        if (c + 1 <= DIEM_CUOI_HANG_1)
                        {
                            ThongSoGiaLap.MapDv[c] = ThongSoGiaLap.MapDv[c + 1];
                            ThongSoGiaLap.Button[c].Text = ThongSoGiaLap.MapDv[c + 1];
                        }
                        else
                        {
                            ThongSoGiaLap.MapDv[c] = null; ThongSoGiaLap.Button[c].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[c] == null) ThongSoGiaLap.Button[c].BackColor = Color.Black;
                    }
                    //Gán rỗng VT2
                    int DIEM_CUOI_HANG_2 = ChucNang.LayViTriHangCot(_vitri2, 1) * 16;
                    for (int s = _vitri2; s <= DIEM_CUOI_HANG_2; s++)
                    {
                        if (s + 1 <= DIEM_CUOI_HANG_2)
                        {
                            ThongSoGiaLap.MapDv[s] = ThongSoGiaLap.MapDv[s + 1];
                            ThongSoGiaLap.Button[s].Text = ThongSoGiaLap.MapDv[s + 1];
                        }
                        else
                        {
                            ThongSoGiaLap.MapDv[s] = null; ThongSoGiaLap.Button[s].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[s] == null) ThongSoGiaLap.Button[s].BackColor = Color.Black;
                    }
                }
            }
            /* --------------------------------LEVER 5---------------------------
            ----------------------------------THỤT PHẢI----------------------------*/
            else if (lever == 5)
            {
                //--------------Nếu 2 VT cùng hàng
                if (ChucNang.LayViTriHangCot(_vitri1, 1) == ChucNang.LayViTriHangCot(_vitri2, 1))
                {
                    int DIEM_DAU_HANG = (ChucNang.LayViTriHangCot(_vitri1, 1) - 1) * 16 + 1;
                    if (_vitri1 + 1 == _vitri2)
                    {
                        for (int a = _vitri2; a >= DIEM_DAU_HANG; a--)
                        {
                            if (a - 2 >= DIEM_DAU_HANG)
                            {
                                ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a - 2];
                                ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a - 2];
                            }
                            else
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        //-----------Gán rỗng VT1                        
                        for (int a = _vitri2; a > _vitri1; a--)
                        {
                            /*if (a + 1 <= DIEM_CUOI_HANG)
                            {*/
                            ThongSoGiaLap.MapDv[a] = ThongSoGiaLap.MapDv[a - 1];
                            ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a - 1];
                            /*}
                            else
                            {
                                ThongSoGiaLap.MapDv[a] = null; ThongSoGiaLap.Button[a].Text = "";
                            }*/
                            if (ThongSoGiaLap.MapDv[a] == null) ThongSoGiaLap.Button[a].BackColor = Color.Black;
                        }
                        //------------Gán rỗng VT2
                        for (int b = _vitri1 + 1; b >= DIEM_DAU_HANG; b--)
                        {
                            if (b - 2 >= DIEM_DAU_HANG)
                            {
                                ThongSoGiaLap.MapDv[b] = ThongSoGiaLap.MapDv[b - 2];
                                ThongSoGiaLap.Button[b].Text = ThongSoGiaLap.MapDv[b - 2];
                            }
                            else
                            {
                                ThongSoGiaLap.MapDv[b] = null; ThongSoGiaLap.Button[b].Text = "";
                            }
                            if (ThongSoGiaLap.MapDv[b] == null) ThongSoGiaLap.Button[b].BackColor = Color.Black;
                        }
                    }
                }
                /* ------------------------------------------------------
                 -------------------Nếu 2 VT không cùng cột -------------
                 ------------------------------------------------------*/
                else
                {
                    //Gán rỗng VT1
                    int DIEM_DAU_HANG_1 = (ChucNang.LayViTriHangCot(_vitri1, 1) - 1) * 16 + 1;
                    for (int c = _vitri1; c >= DIEM_DAU_HANG_1; c--)
                    {
                        if (c - 1 >= DIEM_DAU_HANG_1)
                        {
                            ThongSoGiaLap.MapDv[c] = ThongSoGiaLap.MapDv[c - 1];
                            ThongSoGiaLap.Button[c].Text = ThongSoGiaLap.MapDv[c - 1];
                        }
                        else
                        {
                            ThongSoGiaLap.MapDv[c] = null; ThongSoGiaLap.Button[c].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[c] == null) ThongSoGiaLap.Button[c].BackColor = Color.Black;
                    }
                    //Gán rỗng VT2
                    int DIEM_DAU_HANG_2 = (ChucNang.LayViTriHangCot(_vitri2, 1) - 1) * 16 + 1;
                    for (int s = _vitri2; s >= DIEM_DAU_HANG_2; s--)
                    {
                        if (s - 1 >= DIEM_DAU_HANG_2)
                        {
                            ThongSoGiaLap.MapDv[s] = ThongSoGiaLap.MapDv[s - 1];
                            ThongSoGiaLap.Button[s].Text = ThongSoGiaLap.MapDv[s - 1];
                        }
                        else
                        {
                            ThongSoGiaLap.MapDv[s] = null; ThongSoGiaLap.Button[s].Text = "";
                        }
                        if (ThongSoGiaLap.MapDv[s] == null) ThongSoGiaLap.Button[s].BackColor = Color.Black;
                    }
                }
            }
        }
    }
}
