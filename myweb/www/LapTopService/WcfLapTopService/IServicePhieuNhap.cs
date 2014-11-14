using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhieuNhap" in both code and config file together.
    [ServiceContract]
    public interface IServicePhieuNhap
    {
        [OperationContract]
        List<PhieuNhap> SelectPhieuNhap();

        [OperationContract]
        int InsertPhieuNhap(PhieuNhap info);

        [OperationContract]
        int UpdatePhieuNhap(PhieuNhap info);

        [OperationContract]
        int DeletePhieuNhap(PhieuNhap info);

        [OperationContract]
        List<CT_PhieuNhap> SelectCTPN();

        [OperationContract]
        int InsertCTPN(CT_PhieuNhap info);

        [OperationContract]
        int UpdateCTPN(CT_PhieuNhap info);

        [OperationContract]
        int DeleteCTPN(CT_PhieuNhap info);

        [OperationContract]
        List<ThongkePN> ThongkeSPNhapThang(int thang, int nam);
    }

    public class ThongkePN
    {
        int masp;
        string tensp;
        int dongia;
        int soluong;
        int thanhtien;
        [DataMember]
        public int ID
        {
            get { return masp; }
            set { masp = value; }
        }

        [DataMember]
        public string TEN
        {
            get { return tensp; }
            set { tensp = value; }
        }

        [DataMember]
        public int DONGIA
        {
            get { return dongia; }
            set { dongia = value; }
        }

        [DataMember]
        public int SOLUONG
        {
            get { return soluong; }
            set { soluong = value; }
        }

        [DataMember]
        public int THANHTIEN
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
    }
}
