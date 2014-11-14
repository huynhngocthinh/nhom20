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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceSanPham" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceSanPham.svc or ServiceSanPham.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSanPham : IServiceSanPham
    {
        public List<SanPham> SelectSanPham()
        {
            var list = new List<SanPham>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var sanpham = from p in db.SanPhams select p;
                    foreach (SanPham item in sanpham)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = item.MaSP,
                            TenSP = item.TenSP,
                            HinhAnh = item.HinhAnh,
                            Gia = item.Gia,
                            MoTa = item.MoTa,
                            MaLoai = item.MaLoai,
                            SoLuong = item.SoLuong
                        };
                        list.Add(sp);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public List<SanPham> SelectSanPhamTheoPhanLoai(int ma)
        {
            var list = new List<SanPham>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var sanpham = from p in db.SanPhams where p.MaLoai == ma select p;
                    foreach (SanPham item in sanpham)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = item.MaSP,
                            TenSP = item.TenSP,
                            HinhAnh = item.HinhAnh,
                            Gia = item.Gia,
                            MoTa = item.MoTa,
                            MaLoai = item.MaLoai,
                            SoLuong = item.SoLuong
                        };
                        list.Add(sp);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertSanPham(SanPham info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    SanPham inserted = new SanPham
                    {
                        TenSP = info.TenSP,
                        HinhAnh = info.HinhAnh,
                        Gia = info.Gia,
                        MoTa = info.MoTa,
                        MaLoai = info.MaLoai,
                        SoLuong = info.SoLuong
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

        public int UpdateSanPham(SanPham info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    SanPham updated = new SanPham
                    {
                        MaSP = info.MaSP,
                        TenSP = info.TenSP,
                        HinhAnh = info.HinhAnh,
                        Gia = info.Gia,
                        MoTa = info.MoTa,
                        MaLoai = info.MaLoai,
                        SoLuong = info.SoLuong
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

        public int DeleteSanPham(SanPham info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.SanPhams
                                   where p.MaSP == info.MaSP
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
        public List<SanPham> SelectSanPhamByCategory(int id)
        {
            var list = new List<SanPham>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var sanpham = from p in db.SanPhams where p.MaLoai == id select p;
                    foreach (SanPham item in sanpham)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = item.MaSP,
                            TenSP = item.TenSP,
                            HinhAnh = item.HinhAnh,
                            Gia = item.Gia,
                            MoTa = item.MoTa,
                            MaLoai = item.MaLoai,
                            SoLuong = item.SoLuong
                        };
                        list.Add(sp);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public List<SanPham> ChitietSanPham(int id)
        {
            var list = new List<SanPham>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var sanpham = from p in db.SanPhams where p.MaSP == id select p;
                    foreach (SanPham item in sanpham)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = item.MaSP,
                            TenSP = item.TenSP,
                            HinhAnh = item.HinhAnh,
                            Gia = item.Gia,
                            MoTa = item.MoTa,
                            MaLoai = item.MaLoai,
                            SoLuong = item.SoLuong
                        };
                        list.Add(sp);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        // TÌM KIẾM NÂNG CAO
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public List<SanPham> SearchSanPham(int phanloai, string Str_giatu, string Str_den)
        {
            var list = new List<SanPham>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var sanpham = (from s in db.SanPhams select s).ToList();
                    int giatu, den;
                    giatu = int.Parse(Str_giatu);
                    den = int.Parse(Str_den);
                    if (phanloai == 0)
                    {
                        sanpham = sanpham.ToList();
                    }
                    else
                    {
                        sanpham = sanpham.Where(s => s.MaLoai == phanloai).ToList();
                    }
                    if (IsNumber(Str_giatu))
                    {
                        sanpham = sanpham.Where(s => s.Gia >= giatu).ToList();
                    }

                    if (IsNumber(Str_den) && den > 0)
                    {
                        sanpham = sanpham.Where(s => s.Gia <= den).ToList();
                    }

                    foreach (SanPham item in sanpham)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = item.MaSP,
                            TenSP = item.TenSP,
                            HinhAnh = item.HinhAnh,
                            Gia = item.Gia,
                            MoTa = item.MoTa,
                            MaLoai = item.MaLoai,
                            SoLuong = item.SoLuong
                        };
                        list.Add(sp);
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
