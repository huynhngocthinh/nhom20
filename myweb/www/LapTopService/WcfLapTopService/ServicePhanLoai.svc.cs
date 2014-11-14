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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePhanLoai" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePhanLoai.svc or ServicePhanLoai.svc.cs at the Solution Explorer and start debugging.
    public class ServicePhanLoai : IServicePhanLoai
    {

        public List<PhanLoai> SelectPhanLoai()
        {
            var list = new List<PhanLoai>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var phanloai = from p in db.PhanLoais select p;
                    foreach (var item in phanloai)
                    {
                        PhanLoai pl = new PhanLoai()
                        {
                            MaLoai = item.MaLoai,
                            TenLoai = item.TenLoai
                        };
                        list.Add(pl);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertPhanLoai(PhanLoai info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    PhanLoai inserted = new PhanLoai
                    {
                        TenLoai = info.TenLoai
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

        public int UpdatePhanLoai(PhanLoai info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    PhanLoai updated = new PhanLoai
                    {
                        MaLoai = info.MaLoai,
                        TenLoai = info.TenLoai
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

        public int DeletePhanLoai(PhanLoai info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.PhanLoais
                                   where p.MaLoai == info.MaLoai
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

        public List<PhanLoai> SelectPhanLoaiById(int id)
        {
            var list = new List<PhanLoai>();
            using (LapTopEntities db = new LapTopEntities())
            {
                try
                {
                    var nhasanxuat = from p in db.PhanLoais where p.MaLoai == id select p;
                    foreach (PhanLoai item in nhasanxuat)
                    {
                        PhanLoai pl = new PhanLoai()
                        {
                            MaLoai = item.MaLoai,
                            TenLoai = item.TenLoai
                        };
                        list.Add(pl);
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
