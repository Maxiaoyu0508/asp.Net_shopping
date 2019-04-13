using System;
using System.Collections.Generic;

using System.Text;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
  public   class size
    {
      public int insert(Model.size mym)
      {
          DAL.size dal = new DAL.size();
          return dal.Insert(mym);
      }
      public int delete(string size_id)
      {
          DAL.size dal = new DAL.size();
          return dal.delete(size_id);
 
      }
      public DataSet select_size(string size_id)
      {
          DAL.size dal = new DAL.size();
          return dal.select_size(size_id);
      }
      public int delete_1(int u_id)
      {
          DAL.size dal = new DAL.size();
          return dal.delete_1(u_id);
      }
    }
}
