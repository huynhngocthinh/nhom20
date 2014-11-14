using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using LapTopService.Models;
using PagedList;
using LapTopService.ServiceReferencePhanLoai;
using LapTopService.ServiceReferenceSanPham;

namespace LapTopService.Controllers
{
    public class SanPhamController : Controller
    {
        ServiceReferenceSanPham.ServiceSanPhamClient sp = new ServiceReferenceSanPham.ServiceSanPhamClient();
        ServiceReferencePhanLoai.ServicePhanLoaiClient pl = new ServiceReferencePhanLoai.ServicePhanLoaiClient();
        static int maloai;
        //
        // GET: /SanPham/

        public ActionResult Index()
        {
            var pro = sp.SelectSanPham().OrderByDescending(x => x.MaSP).Take(9);
            ViewBag.Views = "Index";
            return View(pro);
        }
        //chi tiết sản phẩm
        public ActionResult Details(int id)
        { 
            var pro = sp.ChitietSanPham(id);
            maloai = pro.First().MaLoai;
            ViewBag.Views = "ChiTiet";
            return PartialView(pro);
        }
        //Phân loại sản phẩm
        public ActionResult LoaiSanPham(int id, int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var pro = sp.SelectSanPhamByCategory(id).OrderByDescending(x => x.Gia).ToPagedList(pageNum, pageSize);
            var ct = pl.SelectPhanLoaiById(pro.First().MaLoai).First();
            ViewBag.Views = "LoaiSanPham";
            ViewBag.Titles = ct.TenLoai;
            return PartialView(pro);
        }
        //BOX-Tim Kiem
        [ChildActionOnly]
        public ActionResult DSLoaiTimKiem()
        {
            var loaisp = pl.SelectPhanLoai();
            return PartialView(loaisp);
        }
        //TIM KIEM NANG CAO
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        [HttpPost]
        public ActionResult Timkiem(FormCollection f)
        {
            return RedirectToAction("TKnangcao", new { phanloai = f["phanloai"], giatu = f["giatu"], den = f["den"] });
        }
        public ActionResult TKnangcao(int phanloai, string Str_giatu, string Str_den, int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);

            phanloai = int.Parse(Request.QueryString["phanloai"]);
            Str_giatu = Request.QueryString["giatu"];
            Str_den = Request.QueryString["den"];


            var loaisp = pl.SelectPhanLoaiById(phanloai);
            string loai = "";
            foreach (var item in loaisp)
            {
                loai = item.TenLoai;
                //maloai = item.MaNSX;
            }
            ViewBag.KhongTimThay = "Không tìm thấy các sản phẩm thỏa điều kiện!";
            if (phanloai == 0)
                ViewBag.Loaihang = "Tất cả mặt hàng";
            else ViewBag.Loaihang = loai;
            if (!IsNumber(Str_giatu))
                ViewBag.Giatu = "0";
            else ViewBag.Giatu = Str_giatu;
            if (!IsNumber(Str_den))
                ViewBag.Giaden = "Không giới hạn";
            else ViewBag.Giaden = Str_den;

            var pro = sp.SearchSanPham(phanloai, Str_giatu, Str_den).OrderByDescending(x => x.Gia).ToPagedList(pageNum, pageSize);

            ViewBag.phanloai = phanloai;
            return View(pro);
        }
        //hiển thị menu sản phẩm
        public ActionResult MenuSanPham()
        {
            var mn = pl.SelectPhanLoai().ToList();
            ViewBag.Views = "HienThiMenuSP";
            return PartialView(mn);
        }

        public ActionResult SanPhamCungLoai()
        {
            var pro1 = sp.SelectSanPham().Where(p => p.MaLoai == maloai).Take(8);
            ViewBag.Views = "SanPhamCungLoai";
            return PartialView(pro1);
        }

    }
}
