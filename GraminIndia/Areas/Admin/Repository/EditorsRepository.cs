using GraminIndia.Areas.Admin.Helper;
using GraminIndia.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website.DAL;

namespace GraminIndia.Areas.Admin.Repository
{
    public class EditorsRepository: IDisposable
    {
        private bool disposedValue;
        public List<Editors> GetNavigationList()
        {
            var dal = new DataAccessLayer();
            var list = new List<Editors>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_EditorRegistration", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new Editors()
                    {
                        UserId = Convert.ToInt32(sdr["UserId"].ToString()),
                        UserName = sdr["UserName"] as string,
                        EmpCode = sdr["EmpCode"] as string,
                        FullName = sdr["FullName"] as string,
                        Email = sdr["Email"] as string,
                        MobileNo = sdr["MobileNo"] as string,
                        Designation = sdr["Designation"] as string,
                    });
                }
            }
            return list;
        }
        public string SaveRegistration(Editors Edit)
        {
            string MachinIp = GetMachinIp.GetLocalIPAddress();
            var dal = new DataAccessLayer();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 4),
                new SqlParameter("@UserName", Edit.Email),
                new SqlParameter("@Email", Edit.Email),
                new SqlParameter("@MobileNo", Edit.MobileNo),
                new SqlParameter("@Password", Edit.Password),
                new SqlParameter("@CreatedBy", 1),
                new SqlParameter("@CreatedMachinIP", MachinIp)
            };
            return dal.ExecuteNonQueryParamStringTemp("USP_EditorRegistration", parameters);
        }
        public Editors EditEditorRegistration(int UserId)
        {
            var dal = new DataAccessLayer();
            Editors Edit = new Editors();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 2),
                new SqlParameter("@UserId", UserId)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_EditorRegistration", parameters))
            {
                while (sdr.Read())
                {
                    Edit.UserId = Convert.ToInt32(sdr["UserId"]);
                    Edit.Salutation = Convert.ToInt32(sdr["Salutation"]);                   
                    Edit.FirstName = sdr["FirstName"].ToString();
                    Edit.MiddleName = sdr["MiddleName"].ToString();
                    Edit.LastName = sdr["LastName"].ToString();
                    Edit.EmpCode = sdr["EmpCode"].ToString();
                    Edit.MobileNo = sdr["MobileNo"].ToString();
                    Edit.Email = sdr["Email"].ToString();
                    Edit.RoleId = Convert.ToInt32(sdr["RoleId"]);
                    Edit.CountryId = Convert.ToInt32(sdr["CountryId"]);
                    Edit.StateId = Convert.ToInt32(sdr["StateId"]);
                    Edit.DistrictId = Convert.ToInt32(sdr["DistrictId"]);
                }
                return Edit;
            }
        }
        public string UpdateUsers(Editors edit)
        {
            var dal = new DataAccessLayer();
            string MachinIp = GetMachinIp.GetLocalIPAddress();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 4),
                new SqlParameter("@UserId", edit.UserId),
                new SqlParameter("@Salutation", edit.Salutation),
                new SqlParameter("@FirstName", edit.FirstName),
                new SqlParameter("@MiddleName", edit.MiddleName),
                new SqlParameter("@LastName", edit.LastName),
                new SqlParameter("@RoleId", edit.RoleId),              
                new SqlParameter("@CountryId", edit.CountryId),
                new SqlParameter("@StateId", edit.StateId),
                new SqlParameter("@DistrictId", edit.DistrictId),
                new SqlParameter("@UpdatedBy", 1),
                new SqlParameter("@UpdatedMachinIP", MachinIp),
                new SqlParameter("@UserProfilePicture", edit.UserProfilePicture),
            };
            return dal.ExecuteNonQueryParamStringTemp("USP_EditorRegistration", parameters);
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