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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceNhaCungCap" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceNhaCungCap.svc or ServiceNhaCungCap.svc.cs at the Solution Explorer and start debugging.
    public class ServiceNhaCungCap : IServiceNhaCungCap
    {
        public List<NhaCungCap> SelectNhaCungCap()
        {
            var list = new List<NhaCungCap>();
            using (var db = new LapTopEntities())
            {
                try
                {
                    var nhacungcap = from p in db.NhaCungCaps select p;
                    foreach (var item in nhacungcap)
                    {
                        NhaCungCap ncc = new NhaCungCap()
                        {
                            MaNCC = item.MaNCC,
                            TenNCC = item.TenNCC,
                            DiaChi = item.DiaChi,
                            Email = item.Email,
                            SoDT = item.SoDT
                        };
                        list.Add(ncc);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }

        public int InsertNhaCungCap(NhaCungCap info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    NhaCungCap inserted = new NhaCungCap
                    {
                        TenNCC = info.TenNCC,
                        DiaChi = info.DiaChi,
                        Email = info.Email,
                        SoDT = info.SoDT
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

        public int UpdateNhaCungCap(NhaCungCap info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    NhaCungCap updated = new NhaCungCap
                    {
                        MaNCC = info.MaNCC,
                        TenNCC = info.TenNCC,
                        DiaChi = info.DiaChi,
                        Email = info.Email,
                        SoDT = info.SoDT
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

        public int DeleteNhaCungCap(NhaCungCap info)
        {
            using (var db = new LapTopEntities())
            {
                try
                {
                    var deleted = (from p in db.NhaCungCaps
                                   where p.MaNCC == info.MaNCC
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

