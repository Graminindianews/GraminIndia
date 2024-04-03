using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraminIndia.Areas.Admin.Model
{
    public class Editors
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsBlocked { get; set; }
        public int RoleId { get; set; }
        public string Designation { get; set; }
        public int UserType { get; set; }
        public string EmpCode { get; set; }
        public string Title { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedMachinIP { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int Salutation { get; set; }
        public string UserProfilePicture { get; set; }
    }
}