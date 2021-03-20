using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DoAn.cs
{
    public class datacnnt
    {
        string constr;
        public datacnnt()
        {
            constr = @"Data Source=TRANHAU-PC;Initial Catalog=db_QLBanve;Integrated Security=True";
        }
        public SqlConnection getconnect()
        {
            return new SqlConnection(constr);
        }
    }
}