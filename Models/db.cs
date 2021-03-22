using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APSNET.Models
{
    public class db
    {
        SqlConnection connection = new SqlConnection(@"Data Source=HAUPC;Initial Catalog=DEMOCRUD;User ID=sa;Password=hau@@123");

        public DataSet Empget( Employee emp , out string msg )
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee" , connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID" , emp.ID);
                cmd.Parameters.AddWithValue("@Name" , emp.Name);
                cmd.Parameters.AddWithValue("@City" , emp.City);
                cmd.Parameters.AddWithValue("@State" , emp.State);
                cmd.Parameters.AddWithValue("@Country" , emp.Country);
                cmd.Parameters.AddWithValue("@Department" , emp.Department);
                cmd.Parameters.AddWithValue("@flag" , emp.flag);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.Fill(ds);
                msg = "OK";         
                return ds;
            }
            catch ( Exception ex )
            {
                msg = ex.Message;
                return ds;
            }
        }
        public String Empdml( Employee emp , out string msg )
        {
            
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee" , connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID" , emp.ID);
                cmd.Parameters.AddWithValue("@Name" , emp.Name);
                cmd.Parameters.AddWithValue("@City" , emp.City);
                cmd.Parameters.AddWithValue("@State" , emp.State);
                cmd.Parameters.AddWithValue("@Country" , emp.Country);
                cmd.Parameters.AddWithValue("@Department" , emp.Department);
                cmd.Parameters.AddWithValue("@flag" , emp.flag);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                msg = "OK";
                return msg;
            }
            catch ( Exception ex )
            {
                if ( connection.State == ConnectionState.Open )
                {
                    connection.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }
    }

}
