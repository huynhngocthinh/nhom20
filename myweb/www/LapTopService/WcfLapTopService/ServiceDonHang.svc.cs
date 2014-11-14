using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceDonHang" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceDonHang.svc or ServiceDonHang.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDonHang : IServiceDonHang
    {
        public List<DonHang> SelectDonHang()
        {
            var list = new List<DonHang>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var donhang = from p in db.DonHangs select p;
                    foreach (DonHang item in donhang)
                    {
                        DonHang dh = new DonHang()
                        {
                            MaDH = item.MaDH,
                            MaKH = item.MaKH,
                            Ngay = item.Ngay,
                            Trigia = item.Trigia,
                            TrangThai = item.TrangThai
                        };
                        list.Add(dh);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertDonHang(DonHang info)
        {
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    DonHang inserted = new DonHang
                    {
                        MaKH = info.MaKH,
                        Ngay = info.Ngay,
                        Trigia = info.Trigia,
                        TrangThai = info.TrangThai
                    };
                    db.Entry(inserted).State = EntityState.Added;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int UpdateDonHang(DonHang info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    DonHang updated = new DonHang
                    {
                        MaDH = info.MaDH,
                        MaKH = info.MaKH,
                        Ngay = info.Ngay,
                        Trigia = info.Trigia,
                        TrangThai = info.TrangThai
                    };
                    db.Entry(updated).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int DeleteDonHang(DonHang info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.DonHangs
                                   where p.MaDH == info.MaDH
                                   select p).FirstOrDefault();
                    db.Entry(deleted).State = EntityState.Deleted;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<CT_DonHang> SelectCTDH()
        {
            var list = new List<CT_DonHang>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var chitietdonhang = from p in db.CT_DonHang select p;
                    foreach (CT_DonHang item in chitietdonhang)
                    {
                        CT_DonHang ctdh = new CT_DonHang()
                        {
                            MaDH = item.MaDH,
                            MaSP = item.MaSP,
                            SoLuong = item.SoLuong,
                            Gia = item.Gia
                        };
                        list.Add(ctdh);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertCTDH(CT_DonHang info)
        {
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    CT_DonHang inserted = new CT_DonHang
                    {
                        MaDH = info.MaDH,
                        MaSP = info.MaSP,
                        SoLuong = info.SoLuong,
                        Gia = info.Gia
                    };
                    db.Entry(inserted).State = EntityState.Added;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int UpdateCTDH(CT_DonHang info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    CT_DonHang updated = new CT_DonHang
                    {
                        MaDH = info.MaDH,
                        MaSP = info.MaSP,
                        SoLuong = info.SoLuong,
                        Gia = info.Gia
                    };
                    db.Entry(updated).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int DeleteCTDH(CT_DonHang info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.CT_DonHang
                                   where p.MaDH == info.MaDH && p.MaSP == info.MaSP
                                   select p).FirstOrDefault();
                    db.Entry(deleted).State = EntityState.Deleted;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<Thongke> BaocaoNgay(string ngay1, string ngay2)
        {
            DateTime dt1 = DateTime.Parse(ngay1);
            DateTime dt2 = DateTime.Parse(ngay2);
            var list = new List<Thongke>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var baocao = from dh in db.DonHangs
                                 from ctdh in db.CT_DonHang
                                 from sp in db.SanPhams
                                 where ((dh.Ngay >= dt1) && (dh.Ngay <= dt2) && (dh.MaDH == ctdh.MaDH) && (sp.MaSP == ctdh.MaSP))
                                 select new { ctdh.MaSP, sp.TenSP, ctdh.Gia, ctdh.SoLuong };

                    foreach (var item in baocao)
                    {
                        Thongke tk = new Thongke
                        {
                            ID = item.MaSP,
                            TEN = item.TenSP,
                            DONGIA = (int)item.Gia,
                            SOLUONG = (int)item.SoLuong,
                            THANHTIEN = (int)item.SoLuong * (int)item.Gia
                        };
                        list.Add(tk);
                    }

                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public List<Thongke> ThongkeNVThang(int manv, int thang, int nam)
        {
            //            DateTime dt1 = DateTime.Parse(ngay1);
            //DateTime dt = DateTime.Parse(thang);
            //int month = dt.Month;
            var list = new List<Thongke>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var baocao = from sp in db.SanPhams
                                 from dh in db.DonHangs
                                 from ctdh in db.CT_DonHang
                                 //                                 where ((dh.Ngay >= dt1) && (dh.Ngay <= dt2) && (dh.MaDH == ctdh.MaDH) && (sp.MaSP == ctdh.MaSP))
                                 where ((dh.MaNV == manv) && (dh.Ngay.Value.Month == thang) && (dh.Ngay.Value.Year == nam) && (dh.MaDH == ctdh.MaDH) && (sp.MaSP == ctdh.MaSP))
                                 select new { ctdh.MaSP, sp.TenSP, ctdh.Gia, ctdh.SoLuong };

                    foreach (var item in baocao)
                    {
                        Thongke tk = new Thongke
                        {
                            ID = item.MaSP,
                            TEN = item.TenSP,
                            DONGIA = (int)item.Gia,
                            SOLUONG = (int)item.SoLuong,
                            THANHTIEN = (int)item.SoLuong * (int)item.Gia
                        };
                        list.Add(tk);
                    }

                }
                catch
                {
                    return null;
                }
            }
            return list;
        }


        public List<Thongke> ThongkeSPThang(int thang, int nam)
        {
            //            DateTime dt1 = DateTime.Parse(ngay1);
            //DateTime dt = DateTime.Parse(thang);
            //int month = dt.Month;
            var list = new List<Thongke>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var baocao = from dh in db.DonHangs
                                 from ctdh in db.CT_DonHang
                                 from sp in db.SanPhams
                                 where ((dh.Ngay.Value.Month == thang) && (dh.Ngay.Value.Year == nam) && (dh.MaDH == ctdh.MaDH) && (sp.MaSP == ctdh.MaSP))
                                 select new { ctdh.MaSP, sp.TenSP, ctdh.Gia, ctdh.SoLuong };

                    foreach (var item in baocao)
                    {
                        Thongke tk = new Thongke
                        {
                            ID = item.MaSP,
                            TEN = item.TenSP,
                            DONGIA = (int)item.Gia,
                            SOLUONG = (int)item.SoLuong,
                            THANHTIEN = (int)item.SoLuong * (int)item.Gia
                        };
                        list.Add(tk);
                    }

                }
                catch
                {
                    return null;
                }
            }
            return list;
        }
    }
}
