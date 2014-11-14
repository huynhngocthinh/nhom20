using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceSanPham" in both code and config file together.
    [ServiceContract]
    public interface IServiceSanPham
    {
        [OperationContract]
        List<SanPham> SelectSanPham();

        [OperationContract]
        List<SanPham> SelectSanPhamTheoPhanLoai(int loai);

        [OperationContract]
        int InsertSanPham(SanPham info);

        [OperationContract]
        int UpdateSanPham(SanPham info);

        [OperationContract]
        int DeleteSanPham(SanPham info);


        //web
        [OperationContract]
        List<SanPham> SelectSanPhamByCategory(int id);

        [OperationContract]
        List<SanPham> ChitietSanPham(int id);

        [OperationContract]
        List<SanPham> SearchSanPham(int nhasanxuat, string Str_giatu, string Str_den);
    }
}
