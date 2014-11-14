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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePhanQuyen" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePhanQuyen.svc or ServicePhanQuyen.svc.cs at the Solution Explorer and start debugging.
    public class ServicePhanQuyen : IServicePhanQuyen
    {
        public List<PhanQuyen> SelectPhanQuyen()
        {
            var list = new List<PhanQuyen>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var phanquyen = from p in db.PhanQuyens select p;
                    foreach (var item in phanquyen)
                    {
                        PhanQuyen pq = new PhanQuyen()
                        {
                            MaPQ = item.MaPQ,
                            TenPQ = item.TenPQ
                        };
                        list.Add(pq);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertPhanQuyen(PhanQuyen info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    PhanQuyen inserted = new PhanQuyen
                    {

                        TenPQ = info.TenPQ
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

        public int UpdatePhanQuyen(PhanQuyen info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    PhanQuyen updated = new PhanQuyen
                    {
                        MaPQ = info.MaPQ,
                        TenPQ = info.TenPQ
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

        public int DeletePhanQuyen(PhanQuyen info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.PhanQuyens
                                   where p.MaPQ == info.MaPQ
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
    }
}
