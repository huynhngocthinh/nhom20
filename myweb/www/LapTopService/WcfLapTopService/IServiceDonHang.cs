using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLapTopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDonHang" in both code and config file together.
    [ServiceContract]
    public interface IServiceDonHang
    {
        [OperationContract]
        List<DonHang> SelectDonHang();

        [OperationContract]
        int InsertDonHang(DonHang info);

        [OperationContract]
        int UpdateDonHang(DonHang info);

        [OperationContract]
        int DeleteDonHang(DonHang info);

        [OperationContract]
        List<CT_DonHang> SelectCTDH();

        [OperationContract]
        int InsertCTDH(CT_DonHang info);

        [OperationContract]
        int UpdateCTDH(CT_DonHang info);

        [OperationContract]
        int DeleteCTDH(CT_DonHang info);

        [OperationContract]
        List<Thongke> BaocaoNgay(string ngay1, string ngay2);

        [OperationContract]
        List<Thongke> ThongkeNVThang(int manv, int thang, int nam);

        [OperationContract]
        List<Thongke> ThongkeSPThang(int thang, int nam);
    }

    [DataContract]
    public class Thongke
    {
        int id;
        string ten;
        int dongia;
        int soluong;
        int thanhtien;


        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string TEN
        {
            get { return ten; }
            set { ten = value; }
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
