using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikachuGame
{
    public partial class FrMain : Form
    {
        #region data
        int TongDV = 74, Dem;
        List<Bitmap> ListDV = new List<Bitmap>();
        string[] TenDV ={"Cáo","Khỉ","Cá sấu","Hải cẩu","Khủng long 1","Sư tử","Dơi","Cá heo","Tắc kè","Gấu gorila",
                        "Khủng long 2","Voi","Bò","Chim cánh cụt","Sóc","Tê giác","Chó 1","Mèo","Tuần lộc","Gấu trúc",
                        "Ngựa","Cá voi","Thú mỏ vịt","Hà mã","Ốc","Cá ngựa","Công","Gà","Chuột","Chó 2","Vẹt","Cú mèo","Rùa",
                        "Thỏ","Heo","Cừu","Cáo","Khỉ","Hải cẩu","Cừu","Bò","Gấu gorila","Sóc","Cá heo","Tê giác","Cú mèo",
                        "Tuần lộc","Hải cẩu","Voi","Chuột","Chó 2","Công","Hà mã","Khủng long 1","Thỏ","Ốc","Vẹt","Gà",
                        "Chim cánh cụt","Mèo","Ngựa","Heo","Cá ngựa","Gấu gorila","Chuột","Sư tử","Rùa","Gấu trúc",
                        "Tê giác","Chuột","Heo","Khủng long 2","Chó 1","Thỏ"
        };

        #endregion
        public FrMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            LoadData();
        }
        void LoadData()
        {
            for (int i = 1; i <= TongDV; i++)
            {
                ListDV.Add((Bitmap)Bitmap.FromFile("Image//" + i.ToString() + ".png"));
            }
        }
        private void btn_batdau_Click(object sender, EventArgs e)
        {
            btn_batdau.Text = "ĐANG CHẠY";
            TaoMapPikachu();
            ChucNangGame.SetGiaTriNullAll();
            // ChucNang.Test();
            //ChucNangGame.BatDauKiemTra();
            // MessageBox.Show(SideHelper.KiemTraPhaiTren(83,117).ToString());

            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                ThongSoGiaLap.deviceID = listDevice.First();
                Task t = new Task(() =>
                {
                    while (ThongSoGiaLap.Lever < 6)
                    {
                        Search();
                        Thread.Sleep(TimeSpan.FromMilliseconds(200));
                        //--------------------------------QUA MÀN RESET VỀ BAN ĐẦU------------------
                        if (ThongSoGiaLap.FullClick == 0)
                        {
                            for (int a = 1; a <= 144; a++)
                            {
                                ThongSoGiaLap.Button[a].BackColor = Color.Gray;
                            }
                        }
                        //--------------------------------Kiểm tra lever để check------------------
                        if (ThongSoGiaLap.Lever == 3)
                        {
                            ChucNangGame.BatDauKiemTraXuoi();
                        }
                        else
                        {
                            ChucNangGame.BatDauKiemTraNguoc();
                        }
                        //--------------------------------Kiểm tra màn chơi đã hết chưa------------------
                        if (ThongSoGiaLap.FullClick > 71)
                        {
                            ThongSoGiaLap.FullClick = 0;
                            ThongSoGiaLap.Lever++;
                            ChucNang.NextLever();
                        }
                        else if (ThongSoGiaLap.FullClick < 71 && ThongSoGiaLap.FullClick > 0) { Thread.Sleep(TimeSpan.FromSeconds(2)); }
                    }
                });
                t.Start();
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Helper.CheckArea();
            // Helperv2.Check();
            Task t = new Task(() =>
            {
                if (ThongSoGiaLap.FullClick == 0)
                {
                    for (int a = 1; a <= 144; a++)
                    {
                        ThongSoGiaLap.Button[a].BackColor = Color.Gray;
                    }
                }
                ChucNangGame.BatDauKiemTraXuoi();
                if (ThongSoGiaLap.FullClick > 71)
                {
                    ThongSoGiaLap.FullClick = 0;
                    ThongSoGiaLap.Lever++;
                }
                ChucNang.SaoLuu();
            });
            t.Start();
        }
        //---------------------------------------TẠO MAP PIKACHU--------------------------------
        //--------------------------------------------------------------------------------------
        void TaoMapPikachu()
        {
            ThongSoGiaLap.Button.Add(null);
            int X = 0, Y = 0;
            for (int i = 1; i <= 144; i++)
            {
                Button btn = new Button()
                {
                    Width = 45,
                    Height = 45,
                    Location = new Point(X, Y),
                    FlatStyle = FlatStyle.Flat
                };
                this.Controls.Add(btn);
                ThongSoGiaLap.Button.Add(btn);
                X += 45;
                if (i % 16 == 0)
                {
                    Y += 45;
                    X = 0;
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Name = string.Empty;
            for (int a = 1; a <= 144; a++)
            {
                if (a - 1 % 16 == 0)
                {
                    Name += Environment.NewLine + a + ". " + ThongSoGiaLap.MapDv[a] + "     ";
                }
                else
                {
                    Name += a + ". " + ThongSoGiaLap.MapDv[a] + "     ";
                }
            }
        }

        void Search()
        {
            using (var screen = KAutoHelper.ADBHelper.ScreenShoot(ThongSoGiaLap.deviceID))
            {
                ChucNang.DungTroChoi();
                int vitriX = 0, vitriY = 0;
                for (int x = 0; x < ListDV.Count(); x++)
                {

                    var ResutlPoin = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, ListDV[x]);
                    if (ResutlPoin != null)
                    {
                        for (int xa = 0; xa < ResutlPoin.Count(); xa++)
                        {
                            for (int i0 = 1; i0 <= 9; i0++)
                            {
                                if (ThongSoGiaLap.ToaDoGocY + ThongSoGiaLap.ChieuRongKhoi * i0 > ResutlPoin[xa].Y)
                                {
                                    vitriY = i0;
                                    break;
                                }
                            }
                            for (int i1 = 1; i1 <= 16; i1++)
                            {
                                if (ThongSoGiaLap.ToaDoGocX + ThongSoGiaLap.ChieuDaiKhoi * i1 > ResutlPoin[xa].X)
                                {
                                    vitriX = i1;
                                    break;
                                }
                            }
                            int LastPos = (16 * vitriY) - (16 - vitriX);
                            ThongSoGiaLap.MapDv[LastPos] = TenDV[x];
                            Dem++;
                        }
                    }
                }
                //------------------------Vẽ map pikachu lên---------------------------
                for (int a = 1; a <= 144; a++)
                {
                    ThongSoGiaLap.Button[a].Text = ThongSoGiaLap.MapDv[a];
                }
                ChucNang.TiepTucTroChoi();
            }
        }
    }
}
