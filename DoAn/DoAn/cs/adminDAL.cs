using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DoAn.cs
{
    public class adminDAL
    {
        datacnnt dtcn;

        public adminDAL()
        {
            dtcn = new datacnnt();
        }

        public DataTable getAll_nv_tk_nx()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("TTNVNX_QUA_MAIL", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("TTNVNX_QUA_MAIL", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }

        public DataTable get_nhaxe(string dt, string email)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timnhaxe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dienthoai", dt);
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    cnn.Close();
                    return data;
                }
            }
        }

        public DataTable get_tk_nhanvien(string matk)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timtaikhoan", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@matk", matk);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }

        public DataTable get_tt_nhanvien(string manv)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timnhanvien", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", manv);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }

        public bool themnv(tblnv nv)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_nv", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tennv", nv.Tennv);
                        cmd.Parameters.AddWithValue("@matk", nv.Fk_matk);
                        cmd.Parameters.AddWithValue("@manx", nv.Fk_manx);
                        cmd.Parameters.AddWithValue("@ns ", nv.Ngaysinh);
                        cmd.Parameters.AddWithValue("@gt", nv.Gioitinh);
                        cmd.Parameters.AddWithValue("@sdt", nv.Sdt);
                        cmd.Parameters.AddWithValue("@diachi", nv.Diachi);
                        cmd.Parameters.AddWithValue("@email", nv.Email);
                        cmd.Parameters.AddWithValue("@cmt", nv.Cmt);
                        cmd.Parameters.AddWithValue("@bophan", nv.Bophan);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public bool themtk(tbltk tk)
        {

            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_tk", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maquyen", tk.Fk_maquyen);
                        cmd.Parameters.AddWithValue("@tendn", tk.Tendn);
                        cmd.Parameters.AddWithValue("@mk", tk.Matkhau);
                        cmd.Parameters.AddWithValue("@trangthai ", tk.Trangthai);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public bool themnx(tblnx nx)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_nhaxe", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sdt", nx.Sdt);
                        cmd.Parameters.AddWithValue("@email", nx.Email);
                        cmd.Parameters.AddWithValue("@tennx", nx.Tennx);
                        cmd.Parameters.AddWithValue("@diachi", nx.Diachi);
                        cmd.Parameters.AddWithValue("@trangthai ", nx.Trangthai);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public string getmatk(string email)
        {
            string matk = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timmatk", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gmail", email);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        while (abc.Read())
                        {
                            matk = abc["mataikhoan"].ToString();
                        }
                    }
                    return matk;
                }
            }
        }

        public bool updateTk(tbltk tk)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("updatetk", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@matk", tk.Matk);
                        cmd.Parameters.AddWithValue("@maquyen", tk.Fk_maquyen);
                        cmd.Parameters.AddWithValue("@tendn", tk.Tendn);
                        cmd.Parameters.AddWithValue("@mk", tk.Matkhau);
                        cmd.Parameters.AddWithValue("@trangthai ", tk.Trangthai);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public bool updateNv(tblnv nv)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("updatenv", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manv", nv.Manv);
                        cmd.Parameters.AddWithValue("@matk", nv.Fk_matk);
                        cmd.Parameters.AddWithValue("@tennv", nv.Tennv);
                        cmd.Parameters.AddWithValue("@manx", nv.Fk_manx);
                        cmd.Parameters.AddWithValue("@ns ", nv.Ngaysinh);
                        cmd.Parameters.AddWithValue("@gt", nv.Gioitinh);
                        cmd.Parameters.AddWithValue("@sdt", nv.Sdt);
                        cmd.Parameters.AddWithValue("@diachi", nv.Diachi);
                        cmd.Parameters.AddWithValue("@email", nv.Email);
                        cmd.Parameters.AddWithValue("@cmt", nv.Cmt);
                        cmd.Parameters.AddWithValue("@bophan", nv.Bophan);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public DataTable get_tt_khachhang(string tendn)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("getKH", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tendn", tendn);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }
       
        public DataTable tt_nhaxe()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("ttct_nhaxe", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("ttct_nhaxe", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }
        public DataTable ds_nhaxe()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("dsnhaxe", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("dsnhaxe", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }

        public DataTable get_dstk()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("taikhoan", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("taikhoan", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }

        public DataTable get_quyen()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("cacquyen", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("cacquyen", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }

        public bool updateNx(tblnx nx)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("update_nx", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manx", nx.Manx);
                        cmd.Parameters.AddWithValue("@diachi", nx.Diachi);
                        cmd.Parameters.AddWithValue("@trangthai", nx.Trangthai);
                        cmd.Parameters.AddWithValue("@email", nx.Email);
                        cmd.Parameters.AddWithValue("@tennx", nx.Tennx);
                        cmd.Parameters.AddWithValue("@sdt", nx.Sdt);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public DataTable timkiem_tk(tbltk tk)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timkiem_tk", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maquyen", tk.Fk_maquyen);
                    cmd.Parameters.AddWithValue("@tendn", tk.Tendn);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    cnn.Close();
                    return data;
                }
            }
        }
        public DataTable timkiem_nv(tblnv nv, tblnx nx)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timkiem_nv", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manx",nx.Manx );
                    cmd.Parameters.AddWithValue("@sdt", nv.Sdt);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    cnn.Close();
                    return data;
                }
            }
        }
        public DataTable timkiem_nx(tblnv nv, tblnx nx)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("timkiem_nx", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sdt_nx", nx.Sdt);
                    cmd.Parameters.AddWithValue("@sdt_nvdh", nv.Sdt);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    cnn.Close();
                    return data;
                }
            }
        }
        public DataTable ds_chuyenxe_nhaxe(tblnv nv)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("ds_chuyenxe_nhaxe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manx", nv.Fk_manx);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    cnn.Close();
                    return data;
                }
            }
        }
        public DataTable tk_nv_gmail(string mail)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("get_manx_gmail_nv", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mail", mail);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }
        public bool update_cx( tblChuyenxe cx)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("update_cx", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@macx", cx.macx);
                        cmd.Parameters.AddWithValue("@ngaydi", cx.Ngaydi);
                        cmd.Parameters.AddWithValue("@trangthai", cx.trangthai);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        ////////////////huế/////////////////////////
        public bool themkh(tblKhachhang kh)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_kh", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@matk", kh.Fk_matk);
                        cmd.Parameters.AddWithValue("@tenkh", kh.tenkh);
                        cmd.Parameters.AddWithValue("@ngaysinh", kh.ngaysinh);
                        cmd.Parameters.AddWithValue("@gioitinh", kh.gioitinh);
                        cmd.Parameters.AddWithValue("@sdt", kh.sdt);
                        cmd.Parameters.AddWithValue("@diachi", kh.diachi);
                        cmd.Parameters.AddWithValue("@email", kh.email);
                        cmd.Parameters.AddWithValue("@cmnd", kh.cmnd);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public bool updateKH(tblKhachhang kh)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("updateKH", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@makh", kh.Makh);
                        cmd.Parameters.AddWithValue("@tenkh", kh.tenkh);
                        cmd.Parameters.AddWithValue("@ngaysinh", kh.ngaysinh);
                        cmd.Parameters.AddWithValue("@gioitinh", kh.gioitinh);
                        cmd.Parameters.AddWithValue("@sdt", kh.sdt);
                        cmd.Parameters.AddWithValue("@diachi", kh.diachi);
                        cmd.Parameters.AddWithValue("@cmnd", kh.cmnd);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        ///////////
        public bool themnx_tx(tblnx_tx nx_tx)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_nhaxe_tuyenxe", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manx", nx_tx.manx);
                        cmd.Parameters.AddWithValue("@matuyenxe", nx_tx.matx);
                        cmd.Parameters.AddWithValue("@trangthai", nx_tx.trangthai);

                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }


        public bool themcx(tblChuyenxe cx)
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("them_chuyenxe", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maxe", cx.Fk_maxe);
                        cmd.Parameters.AddWithValue("@manv", cx.Fk_manv);
                        cmd.Parameters.AddWithValue("@tenchuyen", cx.tencx);
                        cmd.Parameters.AddWithValue("@ngaydi", cx.Ngaydi);
                        cmd.Parameters.AddWithValue("@manxtx", cx.Fk_manx_tx);
                        cmd.Parameters.AddWithValue("@trangthai", cx.trangthai);

                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public DataTable dsTuyenxe()
        {
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("dstuyenxe", cnn))
                {
                    using (SqlDataAdapter data = new SqlDataAdapter("dstuyenxe", cnn))
                    {
                        using (DataTable abc = new DataTable())
                        {
                            data.Fill(abc);
                            cnn.Close();
                            return abc;
                        }
                    }
                }
            }
        }
        public DataTable dsxe_nhaxe(tblnx nx)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("dsxe_nx", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manx", nx.Manx);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }

        public DataTable ds_tuyenxe_nhaxe(tblnx nx)
        {
            DataTable data = new DataTable();
            //string manx = "";
            using (SqlConnection cnn = dtcn.getconnect())
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("ds_tuyenxe_nhaxe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manx", nx.Manx);
                    SqlDataReader abc = cmd.ExecuteReader();
                    if (abc.HasRows)
                    {
                        data.Load(abc);
                    }
                    return data;
                }
            }
        }
       


    }
}