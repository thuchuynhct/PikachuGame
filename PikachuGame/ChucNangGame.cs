using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    class ChucNangGame
    {
        public static void BatDauKiemTraXuoi()
        {
        //-----------------------Kiểm tra vị trí 1
        a_Is_1:
            for (int VT1 = 1; VT1 <= 143; VT1++)
            {
                //------------------------Kiểm tra VT1 khác rỗng-------------------------------
                if (ThongSoGiaLap.MapDv[VT1] != null)
                {
                    //-----------------------So sánh lần lượt vị trí 1 với vị trí 2
                    for (int VT2 = VT1 + 1; VT2 <= 144; VT2++)
                    {
                        if (ThongSoGiaLap.MapDv[VT1] != null)
                        {
                            if (ThongSoGiaLap.MapDv[VT1] == ThongSoGiaLap.MapDv[VT2])
                            {
                                #region---------------------Trường hợp đặc biết---------------------
                                //Nếu 2 vị trị cạnh nhau nằm ngang
                                if (VT1 + 1 == VT2 && ChucNang.LayViTriHangCot(VT1, 2) != 16)
                                {
                                    ChucNang.ClickViTri(VT1, VT2);
                                    goto a_Is_1;
                                }
                                //Nếu 2 vị trị cạnh nằm dọc nhau
                                if (VT1 + 16 == VT2 && ChucNang.LayViTriHangCot(VT1, 1) != 9)
                                {
                                    ChucNang.ClickViTri(VT1, VT2);
                                    goto a_Is_1;
                                }
                                //---------Nếu cùng hàng 1 hoặc 9
                                if (ChucNang.LayViTriHangCot(VT1, 1) == ChucNang.LayViTriHangCot(VT2, 1))
                                {
                                    if (ChucNang.LayViTriHangCot(VT1, 1) == 9 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        ChucNang.ClickViTri(VT1, VT2);
                                        goto a_Is_1;
                                    }
                                }
                                //---------Nếu cùng cột 1 hoặc 16
                                if (ChucNang.LayViTriHangCot(VT1, 2) == ChucNang.LayViTriHangCot(VT2, 2))
                                {
                                    if (ChucNang.LayViTriHangCot(VT1, 2) == 1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        ChucNang.ClickViTri(VT1, VT2);
                                        goto a_Is_1;
                                    }
                                }
                                #endregion
                                //-----------------So sánh vị trí cột của VT1 và VT2
                                //------Nếu cột VT1 lớn hơn------------
                                if (ChucNang.LayViTriHangCot(VT1, 2) > ChucNang.LayViTriHangCot(VT2, 2))
                                {
                                    //------------------------Nếu bên trái của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Trai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraTraiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên dưới của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Duoi") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 9)
                                    {
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiDuoi(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTrenVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía dưới của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Duoi") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 9)
                                        {
                                            if (SideHelper.KiemTraDuoiDuoiVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên trên của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Tren") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTrenTrenVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên phải của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Phai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                }
                                //-----------------------------------------
                                //------------Nếu cột VT1 nhỏ hơn----------
                                //-----------------------------------------
                                else
                                {
                                    //------------------------Nếu bên phải của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Phai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraPhaiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraPhaiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }

                                    //------------------------Nếu phía dưới của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Duoi") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 9)
                                    {
                                        //---Nếu bên trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên dưới của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Duoi") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 9)
                                        {
                                            if (SideHelper.KiemTraDuoiDuoi(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu phía trên của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Tren") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTrenTrenVT1(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu phía trái của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Trai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        public static void BatDauKiemTraNguoc()
        {
        //-----------------------Kiểm tra vị trí 1
        a_Is_1:
            for (int VT2 = 144; VT2 >= 2; VT2--)
            {
                //------------------------Kiểm tra VT1 khác rỗng-------------------------------
                if (ThongSoGiaLap.MapDv[VT2] != null)
                {
                    //-----------------------So sánh lần lượt vị trí 1 với vị trí 2
                    for (int VT1 = VT2 - 1; VT1 >= 1; VT1--)
                    {
                        if (ThongSoGiaLap.MapDv[VT2] != null)
                        {
                            if (ThongSoGiaLap.MapDv[VT1] == ThongSoGiaLap.MapDv[VT2])
                            {
                                #region---------------------Trường hợp đặc biết---------------------
                                //Nếu 2 vị trị cạnh nhau nằm ngang
                                if (VT1 + 1 == VT2 && ChucNang.LayViTriHangCot(VT1, 2) != 16)
                                {
                                    ChucNang.ClickViTri(VT1, VT2);
                                    goto a_Is_1;
                                }
                                //Nếu 2 vị trị cạnh nằm dọc nhau
                                if (VT1 + 16 == VT2 && ChucNang.LayViTriHangCot(VT1, 1) != 9)
                                {
                                    ChucNang.ClickViTri(VT1, VT2);
                                    goto a_Is_1;
                                }
                                //---------Nếu cùng hàng 1 hoặc 9
                                if (ChucNang.LayViTriHangCot(VT1, 1) == ChucNang.LayViTriHangCot(VT2, 1))
                                {
                                    if (ChucNang.LayViTriHangCot(VT1, 1) == 9 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        ChucNang.ClickViTri(VT1, VT2);
                                        goto a_Is_1;
                                    }
                                }
                                //---------Nếu cùng cột 1 hoặc 16
                                if (ChucNang.LayViTriHangCot(VT1, 2) == ChucNang.LayViTriHangCot(VT2, 2))
                                {
                                    if (ChucNang.LayViTriHangCot(VT1, 2) == 1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        ChucNang.ClickViTri(VT1, VT2);
                                        goto a_Is_1;
                                    }
                                }
                                #endregion
                                //-----------------So sánh vị trí cột của VT1 và VT2
                                //------Nếu cột VT1 lớn hơn------------
                                if (ChucNang.LayViTriHangCot(VT1, 2) > ChucNang.LayViTriHangCot(VT2, 2))
                                {
                                    //------------------------Nếu bên trái của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Trai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraTraiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên dưới của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Duoi") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 9)
                                    {
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiDuoi(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTrenVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu phía dưới của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Duoi") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 9)
                                        {
                                            if (SideHelper.KiemTraDuoiDuoiVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên trên của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Tren") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTrenTrenVT2(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu bên phải của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Phai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        //---Nếu phía phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                }
                                //-----------------------------------------
                                //------------Nếu cột VT1 nhỏ hơn----------
                                //-----------------------------------------
                                else
                                {
                                    //------------------------Nếu bên phải của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Phai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 16)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraPhaiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraPhaiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên phải của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Phai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 16)
                                        {
                                            if (SideHelper.KiemTraPhaiPhai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }

                                    //------------------------Nếu phía dưới của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Duoi") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 9)
                                    {
                                        //---Nếu bên trái của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraDuoiTren(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                        //---Nếu bên dưới của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Duoi") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 9)
                                        {
                                            if (SideHelper.KiemTraDuoiDuoi(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu phía trên của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Tren") != VT1 || ChucNang.LayViTriHangCot(VT1, 1) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Tren") != VT2 || ChucNang.LayViTriHangCot(VT2, 1) == 1)
                                        {
                                            if (SideHelper.KiemTraTrenTrenVT1(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }
                                    //------------------------Nếu phía trái của VT1 rỗng---------------------
                                    if (ChucNang.LayViTriRong(VT1, "Trai") != VT1 || ChucNang.LayViTriHangCot(VT1, 2) == 1)
                                    {
                                        //---Nếu phía trên của VT2 rỗng
                                        if (ChucNang.LayViTriRong(VT2, "Trai") != VT2 || ChucNang.LayViTriHangCot(VT2, 2) == 1)
                                        {
                                            if (SideHelper.KiemTraTraiTrai(VT1, VT2) == true)
                                            {
                                                ChucNang.ClickViTri(VT1, VT2);
                                                goto a_Is_1;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SetGiaTriNullAll()
        {
            for (int a = 1; a <= 144; a++)
            {
                ThongSoGiaLap.MapDv[a] = null;
            }
        }
    }
}
