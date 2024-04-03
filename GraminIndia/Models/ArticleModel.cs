using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
	public class ArticleModel
	{
		public int ArticleId { get; set; }
		public int ArticleCategoryId { get; set; }
		public string ArticleCategoryName { get; set; }
		public int? ArticleSubCategoryId { get; set; }
		public string ArticleSubCategoryName { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleShortDiscription { get; set; }
		public string WebUrl { get; set; }
	
		public string Description1 { get; set; }
		
		public string Description2 { get; set; }
		public string ImageUrl1 { get; set; }
		public string ImageUrl2 { get; set; }
		public bool ShowOnHomePage { get; set; }
		public bool ShowOnBanner { get; set; }
		public bool IsBrakeing { get; set; }
		public int AdminLoginId { get; set; }
		public DateTime CreatedDate { get; set; }
		public string PostedDate { get; set; }
	}
}