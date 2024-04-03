using GraminIndia.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website.DAL;

namespace GraminIndia.Areas.Admin.Repository
{
    public class CommonRepository : IDisposable
    {
        private bool disposedValue;
        public List<Common> GetDesignationList()
        {
            var dal = new DataAccessLayer();
            var list = new List<Common>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Designation", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new Common()
                    {
                        DesignationId = Convert.ToInt32(sdr["DesignationId"].ToString()),
                        DesignationName = sdr["DesignationName"] as string,
                    });
                }
            }
            return list;
        }
        public List<Country> GetCountryList()
        {
            var dal = new DataAccessLayer();
            var list = new List<Country>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Country", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new Country()
                    {
                        CountryId = Convert.ToInt32(sdr["CountryId"].ToString()),
                        CountryName = sdr["CountryName"] as string,
                    });
                }
            }
            return list;
        }
        public List<State> GetStateList()
        {
            var dal = new DataAccessLayer();
            var list = new List<State>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_State", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new State()
                    {
                        CountryId = Convert.ToInt32(sdr["CountryId"].ToString()),
                        StateId = Convert.ToInt32(sdr["StateId"].ToString()),
                        StateName = sdr["StateName"] as string,
                    });
                }
            }
            return list;
        }
        public List<District> GetDistrictList()
        {
            var dal = new DataAccessLayer();
            var list = new List<District>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Distrcit", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new District()
                    {
                        CountryId = Convert.ToInt32(sdr["CountryId"].ToString()),
                        StateId = Convert.ToInt32(sdr["StateId"].ToString()),
                        DistrictId = Convert.ToInt32(sdr["DistrictId"].ToString()),
                        DistrictName = sdr["DistrictName"] as string,
                    });
                }
            }
            return list;
        }
        public List<Salutations> GetSalutationList()
        {
            var dal = new DataAccessLayer();
            var list = new List<Salutations>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_Salutation", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new Salutations()
                    {
                        SalutationId = Convert.ToInt32(sdr["SalutationId"].ToString()),
                        Salutation = sdr["Salutation"] as string,
                    });
                }
            }
            return list;
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