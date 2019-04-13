using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace shopping
{
    public class Object//---------------对象类
    {
        internal int id,num,c_id;
        internal string name;
        internal Decimal price;
        internal bool delete;
        public Object product(int pro_id)
        {
            try
            {
                Class1 res = new Class1();
                SqlConnection con = res.GetConnection();
                SqlCommand com = new SqlCommand("SELECT ID,Num,CategoryID,Title,Price,Deleted FROM [Product] WHERE ID=@cond_value", con);
                //com.CommandText = "SELECT ID,Num,CategoryID,Title,Price,Deleted FROM [Product] WHERE ID=@cond_value";
                com.Parameters.AddWithValue("@cond_value", pro_id);
                SqlDataReader obj_data = com.ExecuteReader();
                Object obj = new Object();
                while (obj_data.Read())
                {
                    obj.id = Convert.ToInt32(obj_data.GetValue(0));
                    obj.num = Convert.ToInt32(obj_data.GetValue(1));
                    obj.c_id = Convert.ToInt32(obj_data.GetValue(2));
                    obj.name = Convert.ToString(obj_data.GetValue(3));
                    obj.price = Convert.ToDecimal(obj_data.GetValue(4));
                    obj.delete = Convert.ToBoolean(obj_data.GetValue(5));
                }
                con.Close();
                con = null;
                com = null;
                return obj;
            }
            catch (Exception error)
            {

            }

                

            
        }
    }



    public class Object1//---------------对象类
    {
        internal int id, num, c_id;
        internal string name;
        internal Decimal price;
        internal bool delete;
        public Object product(int pro_id)
        {
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand com = new SqlCommand("SELECT ID,Num,CategoryID,Title,Price,Deleted FROM [Product] WHERE ID=@cond_value", con);
            //com.CommandText = "SELECT ID,Num,CategoryID,Title,Price,Deleted FROM [Product] WHERE ID=@cond_value";
            com.Parameters.AddWithValue("@cond_value", pro_id);
            SqlDataReader obj_data = com.ExecuteReader();
            Object obj = new Object();
            while (obj_data.Read())
            {
                obj.id = Convert.ToInt32(obj_data.GetValue(0));
                obj.num = Convert.ToInt32(obj_data.GetValue(1));
                obj.c_id = Convert.ToInt32(obj_data.GetValue(2));
                obj.name = Convert.ToString(obj_data.GetValue(3));
                obj.price = Convert.ToDecimal(obj_data.GetValue(4));
                obj.delete = Convert.ToBoolean(obj_data.GetValue(5));
            }
            con.Close();
            con = null;
            com = null;
            return obj;
        }
    }
}