using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public class procate
    {
       public int insert(Model.procate model1)
       {
           DAL.procate dal = new DAL.procate();
           int result= dal.Insert(model1);
           return result;
       }
       public DataSet dataset()
       {
           DAL.procate dal = new DAL.procate();
           return dal.dataset();
       }
       public DataSet data_set()
       {
           DAL.procate dal = new DAL.procate();
           return dal.data_set();
       }
       public string select_name(int cate_id)
       {
           DAL.procate dal = new DAL.procate();
           return dal.select_name(cate_id);
       }
       public int num(int f_id)
       {
           DAL.procate dal = new DAL.procate();
           return dal.num(f_id);

       }
       public int update(Model.procate mym)
       {
           DAL.procate dal = new DAL.procate();
           return dal.update(mym);
       }
       public int dalete(int cate_id)
       {
           DAL.procate dal = new DAL.procate();
           return dal.delete(cate_id);
       }
       public DataSet data_f(int f_cateid)
       {
           DAL.procate dal = new DAL.procate();
           return dal.data_f(f_cateid);
       }


    }
}
