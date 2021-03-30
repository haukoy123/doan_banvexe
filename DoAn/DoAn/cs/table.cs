using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.cs
{
    public class tblnx
    {
        public string Manx { set; get; }
        public string Tennx { set; get; }
        public string Sdt { set; get; }
        public string Diachi { set; get; }
        public string Email { set; get; }
        public string Trangthai { set; get; }
    }
    public class tblnv
    {
        public string Manv { set; get; }
        public string Fk_manx { set; get; }
        public int Fk_matk { set; get; }
        public string Tennv { set; get; }
        public DateTime Ngaysinh { set; get; }
        public string Sdt { set; get; }
        public string Diachi { set; get; }
        public string Email { set; get; }
        public string Cmt { set; get; }
        public double Gioitinh { set; get; }
        public string Bophan { set; get; }

    }
    public class tbltk
    {
        public int Matk { set; get; }
        public string Fk_maquyen { set; get; }
        public string Tendn { set; get; }
        public string Matkhau { set; get; }
        public string Trangthai { set; get; }
    }

    public class tblKhachhang
    {
        public string Makh { set; get; }
        public int Fk_matk { set; get; }

        public string tenkh { set; get; }
        public DateTime ngaysinh { set; get; }
        public double gioitinh { set; get; }
        public string sdt { set; get; }
        public string diachi { set; get; }
        public string email { set; get; }
        public string cmnd { set; get; }
    }

    public class tblLichtrinh
    {
        public string malt { set; get; }
        public string Fk_matx { set; get; }
        public string diemden { set; get; }
        public int giave { set; get; }
        public string trangthai { set; get; }
    }

    public class tblChuyenxe
    {
        public string macx { set; get; }
        public string Fk_manx_tx { set; get; }
        public string Fk_maxe { set; get; }
        public string tencx { set; get; }
        public DateTime Ngaydi { set; get; }
        //public string Fk_matkcx { set; get; }
        public string trangthai { set; get; }
    }

    public class tblXe
    {
        public string maxe { set; get; }
        public string Fk_manx { set; get; }
        public string Fk_manv { set; get; }
        public string biensoxe { set; get; }
        public string mauxe { set; get; }
        public string loaixe { set; get; }
        public int soghe { set; get; }
        public string trangthai { set; get; }
    }

    public class tblVexe
    {
        public string mavx { set; get; }
        public string Fk_macx { set; get; }
        public int Fk_matk { set; get; }
        public string tenkh { set; get; }
        public string sdt { set; get; }
        public DateTime thoigiandatve { set; get; }
        public string diemden { set; get; }
        public int soghe { set; get; }
        public int tongtien { set; get; }
        public string trangthai { set; get; }
    }
    public class tblTuyenxe
    {
        public string matx { set; get; }
        public string tentx { set; get; }
        public DateTime giokh { set; get; }
        public DateTime gioden { set; get; }
        public string tinhdi { set; get; }
        public string tinhden { set; get; }
    }

    public class tblnx_tx
    {
        public string manx { set; get; }
        public string matx { set; get; }
        public string manx_tx { set; get; }
        public string trangthai { set; get; }
    }

    public class tblBinhluan
    {
        public string mabl { set; get; }
        public int Fk_matk { set; get; }
        public string noidung { set; get; }
        public DateTime thoigianbl { set; get; }
        public string Fk_manx { set; get; }

    }

    public class tblCTbinhluan
    {
        public string mactbl { set; get; }
        public string Fk_mabl { set; get; }
        public string Fk_matk { set; get; }
        public string noidung { set; get; }
        public DateTime thoigianbl { set; get; }

    }
    public class tblQuyen
    {
        public string maquyen { set; get; }
        public string tenquyen { set; get; }
    }
}