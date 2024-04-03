using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website.DAL;
using Website.Models;

namespace Website.Repository
{
	public class LoginRepository : IDisposable
	{
		private bool disposedValue;

		public LoginModel GetLoginDetail(string UserName,string Password)
        {
            var dal = new DataAccessLayer();
            LoginModel login = new LoginModel();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_AdminLogin", parameters))
            {
                while (sdr.Read())
                {
                    login.RoleId = Convert.ToInt32(sdr["RoleId"]);
                    login.UserId = Convert.ToInt32(sdr["UserId"]);
                    login.LoginName = sdr["FirstName"].ToString();
                  
                }			
				return login;
            }
        }

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~LoginRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}