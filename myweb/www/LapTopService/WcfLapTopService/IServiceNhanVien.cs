using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceNhanVien" in both code and config file together.
    [ServiceContract]
    public interface IServiceNhanVien
    {
        [OperationContract]
        List<NhanVien> SelectNhanVien();

        [OperationContract]
        int InsertNhanVien(NhanVien info);

        [OperationContract]
        int UpdateNhanVien(NhanVien info);

        [OperationContract]
        int DeleteNhanVien(NhanVien info);

        //dang nhap
        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        int SelectIdByUsername(string username);
    }
}
