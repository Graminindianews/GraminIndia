using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraminIndia.Areas.Admin.Model
{
    public class News
    {
        public int NewsId { get; set; }
        public int NewsNavigationId { get; set; }
        public string NavigationName { get; set; }
        public string NewsTitle { get; set; }
        public string NewsHeading { get; set; }
        [AllowHtml]
        public string NewsDescriptionOne { get; set; }
        public string ImageUrlA { get; set; }
        [AllowHtml]
        public string NewsDescriptionTwo { get; set; }
        public string ImageUrlB { get; set; }
        public string ImageUrlC { get; set; }
        public int InsertedBy { get; set; }
        public string EditorName { get; set; }
        //public int LoginSessionId { get; set; }
        public int UserId { get; set; }
        public int UpdatedBy { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public bool Banner { get; set; }
        public string YouTubeVideoUrl { get; set; }
        public string TagDetails { get; set; }
        public bool IsApproved { get; set; }
        public int IsApprovedBy { get; set; }
        public string WebUrls { get; set; }
        public string CreatedMachinIP { get; set; }
        public string UpdatedMachinIP { get; set; }
        public string CreatedDate { get; set; }
    }
}