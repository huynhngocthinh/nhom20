using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceNhaCungCap" in both code and config file together.
    [ServiceContract]
    public interface IServiceNhaCungCap
    {
        [OperationContract]
        List<NhaCungCap> SelectNhaCungCap();

        [OperationContract]
        int InsertNhaCungCap(NhaCungCap info);

        [OperationContract]
        int UpdateNhaCungCap(NhaCungCap info);

        [OperationContract]
        int DeleteNhaCungCap(NhaCungCap info);
    }
}
