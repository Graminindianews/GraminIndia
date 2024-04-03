using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraminIndia.Areas.Admin.Model
{
    public class Common
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedMachineIP { get; set; }
    }
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
    }
    public class District
    {
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string DistrictName { get; set; }
    }
    public class Salutations
    {
        public int SalutationId { get; set; }
        public string Salutation { get; set; }
    }
}