using GraminIndia.Areas.Admin.Helper;
using GraminIndia.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using Website.DAL;

namespace GraminIndia.Areas.Admin.Repository
{
    public class NavigationRepository : IDisposable
    {
        private bool disposedValue;
        public List<Navigation> GetNavigationList()
        {
            var dal = new DataAccessLayer();
            var list = new List<Navigation>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Navigation", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new Navigation()
                    {
                        NavigationId = Convert.ToInt32(sdr["NavigationId"].ToString()),
                        NavigationName = sdr["NavigationName"] as string,
                    });
                }
            }
            return list;
        }
        public string AddNavigation(Navigation Navi)
        {
            string MachinIp = GetMachinIp.GetLocalIPAddress();
            var dal = new DataAccessLayer();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 4),
                new SqlParameter("@NavigationName", Navi.NavigationName),
                new SqlParameter("@CreatedBy", 1),
                new SqlParameter("@CreatedMachineIP", MachinIp)
            };
            return dal.ExecuteNonQueryParamStringTemp("USP_Navigation", parameters);
        }
        public Navigation EditNavi(int NavigationId)
        {
            var dal = new DataAccessLayer();
            Navigation navi = new Navigation();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 2),
                new SqlParameter("@NavigationId", NavigationId)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Navigation", parameters))
            {
                while (sdr.Read())
                {
                    navi.NavigationId = Convert.ToInt32(sdr["NavigationId"]);
                    navi.NavigationName = sdr["NavigationName"].ToString();
                }
                return navi;
            }
        }
        public int UpdateNavigation(Navigation Navi)
        {
            var dal = new DataAccessLayer();
            string MachinIp = GetMachinIp.GetLocalIPAddress();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 4),
                new SqlParameter("@NavigationId", Navi.NavigationId),
                new SqlParameter("@NavigationName", Navi.NavigationName),
                new SqlParameter("@UpdatedBy", 1),
                new SqlParameter("@UpdatedMachineIP", MachinIp),
            };
            return dal.ExecuteNonQuery("USP_Navigation", parameters);
        }
        public int DeleteNavigation(int id)
        {
            var dal = new DataAccessLayer();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 3),
                new SqlParameter("@NavigationId", id),
            };
            return dal.ExecuteNonQuery("USP_Navigation", parameters);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}