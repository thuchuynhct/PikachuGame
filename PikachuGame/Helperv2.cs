using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachuGame
{
    class Helperv2
    {
        public static int getViTriHangCot(int position, int type)
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
        public static void Check()
        {
            //Duyệt 2 mảnh liền nhau
            for (int a = 1; a <= 143; a++)
            {
                if (a % 16 != 0)
                {
                    Helper.Sosanh(a, a + 1);
                }
                Helper.Sosanh(a, a + 16);
            }
            //Duyệt 2 mảnh ko liền nhau
            for (int b = 1; b <= 144; b++)
            {
                if (ThongSoGiaLap.MapDv[b] != null)//Nếu không rỗng
                {
                    for (int c = b + 1; c <= 144; c++)
                    {
                        if (/*c != b && */ThongSoGiaLap.MapDv[c] != null)//Nếu không rỗng
                        {
                            //Nếu 2 mảnh giống nhau
                            if (ThongSoGiaLap.MapDv[b] == ThongSoGiaLap.MapDv[c])
                            {
                                //Nếu cùng nằm trên 1 hàng 
                                if (Helperv2.getViTriHangCot(b, 1) == Helperv2.getViTriHangCot(c, 1))
                                {
                                    //Nếu nằm trên hàng đầu tiên hoặc hàng cuối cùng
                                    if (Helperv2.getViTriHangCot(b, 1) == 1 || (Helperv2.getViTriHangCot(b, 1) == 9))
                                    {
                                        Helper.Sosanh(b, c);
                                    }
                                    // Nếu không nằm trên hàng đầu tiên hoặc hàng cuối cùng
                                    else
                                    {
                                        //Nếu giữa 2 mảnh có khoảng trống
                                        if (Helper.GetThayThe(b, "left") == c || Helper.GetThayThe(b, "right") == c)
                                        {
                                            Helper.Sosanh(b, c);
                                        }
                                        //Nếu giữa 2 mảnh không có khoảng trống
                                        else
                                        {
                                            if (Helper.CheckNgangHang(b, c) == true)
                                            {
                                                Helper.Sosanh(b, c);
                                            }

                                        }
                                    }
                                }
                                //Nếu không nằm trên cùng 1 hàng
                                else
                                {

                                }
                                //Nếu cùng nằm trên 1 cột 
                                if (Helperv2.getViTriHangCot(b, 2) == Helperv2.getViTriHangCot(c, 2))
                                {
                                    //Nếu nằm trên cột đầu tiên hoặc cột cuối cùng
                                    if (Helperv2.getViTriHangCot(b, 2) == 1 || (Helperv2.getViTriHangCot(b, 2) == 16))
                                    {
                                        Helper.Sosanh(b, c);
                                    }
                                    else
                                    {
                                        //Nếu giữa 2 mảnh có khoảng trống
                                        if (Helper.GetThayThe(b, "bot") == c || Helper.GetThayThe(b, "top") == c)
                                        {
                                            Helper.Sosanh(b, c);
                                        }
                                    }
                                }
                                //Nếu không nằm trên cùng 1 cột
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
            //Duyệt 2 mảnh nằm trên 1 hàng hoặc 1 cột
        }
    }
}
