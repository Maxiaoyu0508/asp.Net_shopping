﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public  class user
    {
        public SqlDataReader  login(Model.user aa)
        {
            DAL.user dalus = new DAL.user();
            return dalus.login(aa); 
        }
        public SqlDataReader lo(Model.user aa)
        {
            DAL.user da = new DAL.user();
            return da.lo(aa);
        }
        public int insert(Model.user aa)
        {
            DAL.user dalu = new DAL.user();
            return dalu.insert(aa);
        }
        public DataSet  pan(Model.user aa)
        {
            DAL.user daluss = new DAL.user();
            return daluss.pan(aa);
        }
        public SqlDataReader pp(Model.user aa)
        {
            DAL.user dal = new DAL.user();
            return dal.dd(aa);
        }
        public SqlDataReader drs(Model.user aa)
        {
            DAL.user dsd = new DAL.user();
            return dsd.drs(aa);
        }
        public int upus(Model.user aa)
        {
            DAL.user ds = new DAL.user();
            return ds.upd(aa);
        }
        public int upwd(Model.user aa)
        {
            DAL.user dalll = new DAL.user();
            return dalll.upwd(aa);
        }
        public int upad(Model.address aa)
        {
            DAL.address dala = new DAL.address();
            return dala.insert(aa);
        }
        public SqlDataReader drid(Model.user aa)
        {
            DAL.user da = new DAL.user();
            return da.drid(aa);
        }
        public SqlDataReader drp(Model.user aa)
        {
            DAL.user dals = new DAL.user();
            return dals.drpw(aa);
        }
        public int update(Model.user aa)
        {
            DAL.user dalu = new DAL.user();
            return dalu.update(aa);
        }
        public SqlDataReader drti(Model.user aa)
        {
            DAL.user ds = new DAL.user();
            return ds.drti(aa);
        }

    }
    public class oredr
    {
        public DataSet dspor(int a,int b,Model.order aa)
        {
            DAL.order dalo = new DAL.order();
            return dalo.dsor(a,b,aa);
        }
        public DataSet dspor1(Model.order aa)
        {
            DAL.order dal = new DAL.order();
            return dal.dsmai(aa);
        }
        //查看某条订单
        //public DataSet kanor(int a,int b,string c, Model.order aa)
        //{
        //    DAL.order daloo = new DAL.order();
        //    return daloo.kandi(a,b,c,aa);
        //}

        //public int countcha(Model.order aa)
        //{
        //    DAL.order dalorr = new DAL.order();
        //    return dalorr.countcha(aa);
        //}

        //public SqlDataReader dror(Model.order aa)
        //{
        //    DAL.order daorde = new DAL.order();
        //    return daorde.drorf(aa);
        //}
        public int deor(Model.order aa)
        {
            DAL.order deo = new DAL.order();
            return deo.deo(aa);
        }
        public int count(Model.order aa)
        {
            DAL.order dalk = new DAL.order();
            return dalk.coun(aa);
        }

    }
}
