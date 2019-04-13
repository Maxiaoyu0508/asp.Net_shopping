using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;

namespace shopping
{
    public class Class1
    {
        public SqlConnection GetConnection()//创立连接
        {
            string str = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }

        public bool doCheck(string condValue, string type, string database_name,string table_name)
        {
            Class1 res = new Class1();
            //string strConn = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            //SqlConnection con = new SqlConnection(strConn);
            SqlConnection con = res.GetConnection();
            //con.Open();
            bool flag = true;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [users] WHERE name=@cond_value", con);
            if (type == "mail")
                cmd.CommandText = "SELECT * FROM [users] WHERE e_mail=@cond_value";
            cmd.Parameters.AddWithValue("@cond_value", condValue);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                flag = false;
            }
            
            cmd = null;
            //con.Close();
            //con = null;
            res.close(con);
            return flag;
        }

        public bool procheck(int a)
        {
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            bool flag = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] WHERE ID=@cond_value", con);
            cmd.Parameters.AddWithValue("@cond_value",a);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                flag = true;
            }
            cmd = null;
            res.close(con);
            return flag;
        }
        public bool login_check(string user_name,string user_password)
        {
            //bool flag = true;
            bool flag_name = false;
            //bool flag_password = false;
            Class1 res = new Class1();
            //string strConn = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            //SqlConnection con = new SqlConnection(strConn);
            //con.Open();
            SqlConnection con= res.GetConnection();
            SqlCommand cmd_name = new SqlCommand("SELECT * FROM [users] WHERE name=@cond_value AND password=@cond_pass", con);
            //SqlCommand cmd_password = new SqlCommand("SELECT * FROM [users] WHERE password=@cond_value", con);
            cmd_name.Parameters.AddWithValue("@cond_value",user_name);
            cmd_name.Parameters.AddWithValue("@cond_pass", user_password);
            //cmd_password.Parameters.AddWithValue("@cond_value", user_password);
            SqlDataReader reader = cmd_name.ExecuteReader();
            while (reader.Read())
            {
                flag_name = true;
                //SqlCommand cmd = new SqlCommand("insert into [users] tag  values(1)");
            }
            int i = res.Multiple(user_name);
            if (i == 1)
            {
                flag_name = false;

            }  
            cmd_name = null;
            reader.Close();
            reader = null;
            res.close(con);
            return flag_name;
        }

        public bool pay_check(string user_name, string user_password)
        {
            //bool flag = true;
            bool flag_name = false;
            //bool flag_password = false;
            Class1 res = new Class1();
            //string strConn = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            //SqlConnection con = new SqlConnection(strConn);
            //con.Open();
            SqlConnection con = res.GetConnection();
            SqlCommand cmd_name = new SqlCommand("SELECT * FROM [users] WHERE name=@cond_value AND password=@cond_pass", con);
            //SqlCommand cmd_password = new SqlCommand("SELECT * FROM [users] WHERE password=@cond_value", con);
            cmd_name.Parameters.AddWithValue("@cond_value", user_name);
            cmd_name.Parameters.AddWithValue("@cond_pass", user_password);
            //cmd_password.Parameters.AddWithValue("@cond_value", user_password);
            SqlDataReader reader = cmd_name.ExecuteReader();
            while (reader.Read())
            {
                flag_name = true;
                //SqlCommand cmd = new SqlCommand("insert into [users] tag  values(1)");
            }
            cmd_name = null;
            reader.Close();
            reader = null;
            res.close(con);
            return flag_name;
        }
        public SqlCommand regist()
        {
            string strConn = WebConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [users] (name,password,num,e_mail,address,zipcode,tag) values(@user_name,@user_password,@user_num,@user_email,@user_add,@user_zip,@user_tag)", con);
            return cmd;
        }
        public void close(SqlConnection a)
        {
            a.Close();
            a = null;
         
        }
        public int Insert(string name, string password, string add, string zip, string num, string email)
        {
            int flag;
            Class1 res = new Class1();
            SqlConnection con= res.GetConnection();
            //SqlCommand cmd = new SqlCommand();
            SqlCommand cmd = res.regist();
            md5 obj = new md5();
            cmd.Parameters.AddWithValue("@user_name",name);
            obj.jiami(password);
            cmd.Parameters.AddWithValue("@user_password", obj.Result);
            cmd.Parameters.AddWithValue("@user_add", add);
            cmd.Parameters.AddWithValue("@user_zip", zip);
            cmd.Parameters.AddWithValue("@user_num", num);
            cmd.Parameters.AddWithValue("@user_email", email);
            cmd.Parameters.AddWithValue("@user_tag", 0);
            flag = cmd.ExecuteNonQuery();
            cmd = null;
            res.close(con);
            return flag;
            
        }
        public int Insert_c(int id, int oid, int pid, decimal price, int num, string name,string name_p,int Do)
        {
            int flag;
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            SqlCommand cmd = new SqlCommand("INSERT INTO [OrderDetail] (ID,OrderBaseID,ProductID,Price,Quantity,name,pname,Done) values(@user_name,@user_password,@user_num,@user_email,@user_add,@user_zip,@name_pp,@name_d)", con);
            cmd.Parameters.AddWithValue("@user_name", id);
            cmd.Parameters.AddWithValue("@user_password", oid);
            cmd.Parameters.AddWithValue("@user_add", num);
            cmd.Parameters.AddWithValue("@user_zip", name);
            cmd.Parameters.AddWithValue("@user_num", pid);
            cmd.Parameters.AddWithValue("@user_email", price);
            cmd.Parameters.AddWithValue("@name_pp", name_p);
            cmd.Parameters.AddWithValue("@name_d", Do);
            flag = cmd.ExecuteNonQuery();
            cmd = null;
            res.close(con);
            return flag;

        }

        public int Insert_o(int id, string oid, string name, string add, string zipcode, string phone_num, decimal price)
        {
            int flag;
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [OrderBase] (ID,OrderDate,Name,Street,ZipCode,Phone,Pay) values(@user_name,@user_password,@user_num,@user_email,@user_add,@user_zip,@name_pp)", con);
            cmd.Parameters.AddWithValue("@user_name", id);
            cmd.Parameters.AddWithValue("@user_password", oid);
            cmd.Parameters.AddWithValue("@user_num", name);
            cmd.Parameters.AddWithValue("@user_email", add);
            cmd.Parameters.AddWithValue("@user_add", zipcode);
            cmd.Parameters.AddWithValue("@user_zip", phone_num);
            cmd.Parameters.AddWithValue("@name_pp", price);
            flag = cmd.ExecuteNonQuery();
            cmd = null;
            res.close(con);
            return flag;

        }
        public void Edit(int a,int b)//加入购物车，购买之后在从数据库中修改，加锁~
        {
            Class1 res = new Class1();
            Object obj = new Object();
            SqlConnection con = res.GetConnection();
            //SqlConnection con= res.GetConnection();
            SqlTransaction back;
            back = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("update [Product] set num=num-@bb where ID=@aa", con);
            //cmd.CommandText = "update [Product] set num=num-@bb where ID=@aa";
            cmd.Transaction = back;
            try
            {
                cmd.Parameters.AddWithValue("@bb", b);
                cmd.Parameters.AddWithValue("@aa", a);
                cmd.ExecuteNonQuery();
                back.Commit();
            }
            catch (Exception e)
            {
                back.Rollback();
            }
            finally
            {
                con.Close();
                con = null;
                cmd = null;
            }
        }

        public void Edit_do(string a)//加入购物车，购买之后在从数据库中修改，加锁~
        {
            Class1 res = new Class1();
            Object obj = new Object();
            SqlConnection con = res.GetConnection();
            //SqlConnection con= res.GetConnection();
            SqlTransaction back;
            back = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("c", con);
            //cmd.CommandText = "update [OrderDetail] set Done=1 where name=@aa";
            cmd.Transaction = back;
            try
            {
                cmd.Parameters.AddWithValue("@aa", a);
                cmd.ExecuteNonQuery();
                back.Commit();
            }
            catch (Exception e)
            {
                back.Rollback();
            }
            finally
            {
                con.Close();
                con = null;
                cmd = null;
            }
        }
        public void Delete(int a,SqlConnection con)//购物车删除
        {
            SqlTransaction back;
            back = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("delete from [OrderDetail] where ProductID=@id", con);
            cmd.Transaction = back;
            try
            {
                cmd.Parameters.AddWithValue("@id", a);
                cmd.ExecuteNonQuery();
                back.Commit();
            }
            catch (Exception e)
            {
                back.Rollback();
            }
            finally
            {
                con.Close();
                con = null;
                cmd = null;
            }

        }
        public decimal P_sum(string name)//计算总金额
        {
            Class1 res = new Class1();
            decimal price_sum=0;
            SqlConnection con= res.GetConnection();
            SqlCommand com =new SqlCommand("select sum(Price*Quantity) as sum from [OrderDetail] where name=@user_name AND Done=0", con);
            com.Parameters.AddWithValue("@user_name", name);
            //if(com.ExecuteScalar())
            if (Convert.IsDBNull(com.ExecuteScalar()))
                price_sum = 0;
            else
                price_sum = Convert.ToDecimal(com.ExecuteScalar());
            con.Close();
            com = null;
            return price_sum;
                //com.CommandText = "select Price*Quantity as sum from [OrderDetail] ";

        }

        public void Check_p(string name)
        {
            int id = 0;
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand com = new SqlCommand("select ProductID,Quantity  from [OrderDetail] where name=@user_name", con);
            com.Parameters.AddWithValue("@user_name",name);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
                {
                    res.Edit(Convert.ToInt32(reader["ProductID"]), Convert.ToInt32(reader["Quantity"]));
                }
            res.close(con);
            com = null;

        }
        public void Delete_M(int a, SqlConnection con)
        {
            SqlTransaction back;
            back = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("delete from [Product] where ID=@id", con);
            cmd.Transaction = back;
            try
            {
                cmd.Parameters.AddWithValue("@id", a);
                cmd.ExecuteNonQuery();
                back.Commit();
            }
            catch (Exception e)
            {
                back.Rollback();
            }
            finally
            {
                con.Close();
                con = null;
                cmd = null;
            }

        }

        public int Edit1(string a,decimal mon,int num,int id)//加入购物车，购买之后在从数据库中修改，加锁~
        {
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlTransaction back;
            int i=0;
            back = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand("update [Product] set Title=@bb,Price=@aa,Num=@cc where ID=@dd", con);
            //cmd.CommandText = "update [Product] set Title=@bb,Price=@aa,Num=@cc where ID=@dd";update [Product] set num=num-@bb where ID=@aa
            //cmd.CommandText = a;
            cmd.Transaction = back;
            try
            {
                cmd.Parameters.AddWithValue("@bb", a);
                cmd.Parameters.AddWithValue("@aa", mon);
                cmd.Parameters.AddWithValue("@cc", num);
                cmd.Parameters.AddWithValue("@dd", id);
                cmd.ExecuteNonQuery();
                back.Commit();
                i = 1;
                
            } 
            catch (Exception e)
            {
                back.Rollback();
                i = 0;
            }
            finally
            {
                con.Close();
                con = null;
                cmd = null;
            }
            return i;
           

        }
        public int Insert_p(string a, decimal mon, int num, int id)
        {
           
            int flag;
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlTransaction back;
            SqlCommand cmd = new SqlCommand("INSERT INTO [Product] (ID,Title,Price,Num) values(@user_id,@user_title,@user_mon,@user_numm)", con);
            back = con.BeginTransaction();
            cmd.Transaction = back;
             try
            {
                cmd.Parameters.AddWithValue("@user_id", id);
                cmd.Parameters.AddWithValue("@user_mon", mon);
                cmd.Parameters.AddWithValue("@user_title", a);
                cmd.Parameters.AddWithValue("@user_numm", num);
                cmd.ExecuteNonQuery();
                back.Commit();
                flag = 1;
            }
            catch (Exception error)
            {
                back.Rollback();
                flag = 0;
            }
            finally
            {
                cmd = null;
                res.close(con);
                con = null;  

            }
            return flag;

        }

        public int Multiple(string name)
        {
            int flag = 0;
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand cmd = new SqlCommand("select tag from [users] where name=@user_name",con);
            cmd.Parameters.AddWithValue("@user_name",name);
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                flag =Convert.ToInt32(reader["tag"]);
            }
            con.Close();
            con = null;
            cmd = null;
            return flag;
        }

        public void Multiple_u(string name)
        {
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand cmd = new SqlCommand("update [users] set tag=1 where name=@user_name", con);
            cmd.Parameters.AddWithValue("@user_name", name);
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
            cmd = null;
        }

        public void Multiple_N(string name)
        {
            Class1 res = new Class1();
            SqlConnection con = res.GetConnection();
            SqlCommand cmd = new SqlCommand("update [users] set tag=0 where name=@user_name", con);
            cmd.Parameters.AddWithValue("@user_name", name);
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
            cmd = null;
        }

    }

}
