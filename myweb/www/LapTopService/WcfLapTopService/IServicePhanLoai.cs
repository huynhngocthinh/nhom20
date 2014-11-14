using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhanLoai" in both code and config file together.
    [ServiceContract]
    public interface IServicePhanLoai
    {
        [OperationContract]
        List<PhanLoai> SelectPhanLoai();

        [OperationContract]
        int InsertPhanLoai(PhanLoai info);

        [OperationContract]
        int UpdatePhanLoai(PhanLoai info);

        [OperationContract]
        int DeletePhanLoai(PhanLoai info);

        [OperationContract]
        List<PhanLoai> SelectPhanLoaiById(int id);
    }
}
