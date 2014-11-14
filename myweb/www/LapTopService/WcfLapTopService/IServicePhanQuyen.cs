using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhanQuyen" in both code and config file together.
    [ServiceContract]
    public interface IServicePhanQuyen
    {
        [OperationContract]
        List<PhanQuyen> SelectPhanQuyen();

        [OperationContract]
        int InsertPhanQuyen(PhanQuyen info);

        [OperationContract]
        int UpdatePhanQuyen(PhanQuyen info);

        [OperationContract]
        int DeletePhanQuyen(PhanQuyen info);
    }
}
