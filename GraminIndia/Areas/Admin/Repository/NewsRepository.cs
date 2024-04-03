using GraminIndia.Areas.Admin.Helper;
using GraminIndia.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using Website.DAL;

namespace GraminIndia.Areas.Admin.Repository
{
    public class NewsRepository : IDisposable
    {
        private bool disposedValue;
        private MemoryStream ms;

        public string InsertNews(News news)
        {
            string MachinIp = GetMachinIp.GetLocalIPAddress();
            var dal = new DataAccessLayer();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 4),
                new SqlParameter("@NewsNavigationId", news.NewsNavigationId),
                new SqlParameter("@InsertedBy", news.UserId),
                new SqlParameter("@EditorId", news.UserId),
                new SqlParameter("@NewsTitle", news.NewsTitle),
                new SqlParameter("@NewsHeading", news.NewsHeading),
                new SqlParameter("@NewsDescriptionOne", news.NewsDescriptionOne),
                new SqlParameter("@ImageUrlA", news.ImageUrlA),
                new SqlParameter("@NewsDescriptionTwo", news.NewsDescriptionTwo),
                new SqlParameter("@ImageUrlB", news.ImageUrlB),
                new SqlParameter("@ImageUrlC", news.ImageUrlC),
                new SqlParameter("@CountryId", news.CountryId),
                new SqlParameter("@StateId", news.StateId),
                new SqlParameter("@DistrictId", news.DistrictId),
                new SqlParameter("@YouTubeVideoUrl", news.YouTubeVideoUrl),
                new SqlParameter("@TagDetails", news.TagDetails),
                new SqlParameter("@WebUrls", news.WebUrls),
                new SqlParameter("@Banner", news.Banner),
                new SqlParameter("@CreatedMachinIP", MachinIp),
            };
            return dal.ExecuteNonQueryParamStringTemp("USP_News", parameters);
        }
        public List<News> GetNewsList()
        {
            var dal = new DataAccessLayer();
            var list = new List<News>();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 1)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_News", parameters))
            {
                while (sdr.Read())
                {
                    list.Add(new News()
                    {
                        //InsertedBy = Convert.ToInt32(sdr["InsertedBy"].ToString()),
                        NewsId = Convert.ToInt32(sdr["NewsId"].ToString()),
                        NewsNavigationId = Convert.ToInt32(sdr["NewsNavigationId"].ToString()),
                        NewsTitle = sdr["NewsTitle"] as string,
                        NavigationName = sdr["NavigationName"] as string,
                        ImageUrlA = sdr["ImageUrlA"] as string,
                        CreatedDate = sdr["CreatedDate"] as string,
                        EditorName = sdr["EditorName"] as string,
                    });
                }
            }
            return list;
        }

        public News ViewNewsDetails(int NewsId)
        {
            var dal = new DataAccessLayer();
            News ViewNews = new News();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", 2),
                new SqlParameter("@NewsId", NewsId)
            };

            using (var sdr = dal.SelectRecordBydataReader("USP_News", parameters))
            {
                while (sdr.Read())
                {
                    ViewNews.NewsId = Convert.ToInt32(sdr["NewsId"]);
                    ViewNews.NewsNavigationId = Convert.ToInt32(sdr["NewsNavigationId"]);
                    ViewNews.NewsTitle = sdr["NewsTitle"].ToString();
                    ViewNews.NewsHeading = sdr["NewsHeading"].ToString();
                    ViewNews.NewsDescriptionOne = sdr["NewsDescriptionOne"].ToString();
                    //ViewNews.ImageUrlA = sdr["ImageUrlA"].ToString();
                    //ViewNews.ImageUrlA = Convert.ToBase64String((byte[])sdr["ImageUrlA"]);

                    //string ImageUrlA = (string)sdr["ImageUrlA"].ToString();
                    //byte[] data = System.Text.Encoding.ASCII.GetBytes(ImageUrlA);
                    //ms = new MemoryStream(data);
                    //ImageUrlA = Image.FromStream(ms);

                    ViewNews.NewsDescriptionTwo = sdr["NewsDescriptionTwo"].ToString();
                    ViewNews.ImageUrlB = sdr["ImageUrlB"].ToString();
                    ViewNews.ImageUrlC = sdr["ImageUrlC"].ToString();
                    ViewNews.YouTubeVideoUrl = sdr["YouTubeVideoUrl"].ToString();
                    ViewNews.TagDetails = sdr["TagDetails"].ToString();
                    ViewNews.EditorName = sdr["EditorName"].ToString();
                    ViewNews.Banner = Convert.ToBoolean(sdr["Banner"]);
                }
                return ViewNews;
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